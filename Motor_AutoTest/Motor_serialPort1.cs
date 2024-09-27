using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
//主电机
namespace Motor_AutoTest
{
    class Motor_serialPort1
    {
        char[] InputData = new char[64];
        int rx_offset = 0;
        int data_len = 0;
        int flag_rx_done = 0;
        public int rpm_rxnum = 0;
        public int curr_rxnum = 0;
        public int encod_rxnum = 0;
        public int[] rpm_buf = new int[10];
        public int[] curr_buf = new int[10];
        public int[] encod_buf = new int[10];
        Color BackClolor_ON = Color.LightSteelBlue;
        Color BackClolor_OFF = Color.Gainsboro;
        //Form1 pform1 = new Form1();
        public void Motor_SerPort1Init()
        {
            //pform1.serialPort1.Open();//Form1.pform1.
            //MessageBox.Show("警告⚠：主电机串口未打开，请打开主电机串口进行测试！");
            Form1.pform1.serialPort1.DataReceived += new SerialDataReceivedEventHandler(port1_Motor_DataReceived);//必须手动添加事件处理程序
        }
        private void port1_Motor_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int rx_cnt = 0;
            char[] InputBuf = new char[64];
            rx_cnt = Form1.pform1.serialPort1.BytesToRead;
            if (rx_cnt > 64) rx_cnt = 64;
            Form1.pform1.serialPort1.Read(InputBuf, 0, rx_cnt);
            //if (timer1.Enabled == true)
            for (int j = 0; j < rx_cnt; j++)
            {
                if (InputBuf[j] == '(' || InputData[0] == '(') //帧头
                {
                    for (int k = 0; k < rx_cnt - j; k++)
                    {
                        if (k + rx_offset >= 64)
                        {
                            j = 0;
                            rx_cnt = 0;
                            rx_offset = 0;
                            InputData[0] = '*';
                            break;
                        }
                        InputData[k + rx_offset] = InputBuf[k + j];
                        if (InputData[k + rx_offset] == ')') //帧尾
                        {
                            if (k + rx_offset + 1 <= 3) data_len = 0;
                            else
                            {
                                data_len = k + rx_offset + 1 - 4;  //去掉头尾和控制码，剩余有用的数据长度
                                rx_offset = 0;
                                InputData[0] = '*';
                                flag_rx_done = 1; //接收完整有用的包
                            }
                            break;
                        }
                    }
                    if (flag_rx_done != 1) rx_offset += rx_cnt - j; //如果没有接收完成，下一包数据继续放入InputData。
                    break;
                }
            }

            //byte型(十进制)数据转换为16进制的，然后在转换为字符。
            //ToString("X2")，其中'x'为小写则转换后字母为小写，'X'为大写则转换后字母为大写。
            //string strdata = InputBuf[0].ToString("X2") + " ";
            string strdata = "" + InputBuf[0];
            for (int i = 1; i < rx_cnt; i++)
            {
                //strdata += InputBuf[i].ToString("X2") + " ";
                strdata += (char)InputBuf[i];// +" ";
            }
            Form1.pform1.BeginInvoke(new Action(() =>
            {
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 接收主电机数据：");
                //DP_DataRecord.AppendText(" count = "+count.ToString()+"\r\n"); 
                Form1.pform1.DP_DataRecord.AppendText(strdata + "\r\n");
            }));

            if (flag_rx_done == 1)
            {
                flag_rx_done = 0;
                if (Form1.pform1.flag_autotest == 1 || Form1.pform1.FlagAuto_En == false)
                {
                    Form1.pform1.BeginInvoke(new Action(() =>
                    {
                        Motor_ReciceData_Check(InputData);
                    }));
                    //string strdata = serialPort1.ReadLine();   
                }
            }
        }
        public void Motor_ReciceData_Check(char[] buff)
        {
            Form1.pform1.EnDis_Timer1(false);
            if (buff[1] == 'R')
            {
                switch (buff[2])
                {
                    case (char)UART_TEST_ENUM.UART_TEST_CURR:
                        int i_vaule = AsciiToDecNum(3, data_len, buff);
                        curr_buf[curr_rxnum] = i_vaule;
                        curr_rxnum++;
                        if (curr_rxnum == 6)
                        {
                            curr_rxnum = 0;
                            i_vaule = center_value(6, curr_buf);
                            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 读取电流原始值：" + i_vaule.ToString() + "\r\n");
                            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 电流要求最小值：43，最大值：53\r\n");
                            if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN) Form1.pform1.DP_I.Text = i_vaule.ToString();
                            else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE) Form1.pform1.DP_CI.Text = i_vaule.ToString();
                            if (43 <= i_vaule && i_vaule <= 53)
                            {
                                Form1.pform1.flag_err = 0;
                                if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN)
                                {
                                    Form1.pform1.Display_BackColor("I", "OK", i_vaule);
                                }
                                else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE)
                                {
                                    Form1.pform1.Display_BackColor("CI", "OK", i_vaule);
                                }
                                else Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机电流检查：OK\r\n");
                                //if (Form1.pform1.FlagAuto_En == true) Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_VER;
                            }
                            else
                            {
                                if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN)
                                {
                                    Form1.pform1.Display_BackColor("I", "NG", i_vaule);
                                }
                                else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE)
                                {
                                    Form1.pform1.Display_BackColor("CI", "NG", i_vaule);
                                }
                                else
                                {
                                    if (i_vaule < 43) Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机电流检查：NG  低于最小值\r\n");
                                    else if (i_vaule > 53) Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机电流检查：NG  超过最大值\r\n");
                                }
                            }
                        }
                        break;

                    case (char)UART_TEST_ENUM.UART_TEST_VER:
                        int v_adc = AsciiToDecNum(3, data_len, buff);
                        float v_Vaule = (1604 * (float)v_adc + 17) / 10000;
                        Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 读取电压原始值：" + v_Vaule.ToString("0.0") + "\r\n");
                        Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 电压要求最小值：95Vdc  最大值105Vdc\r\n");
                        Form1.pform1.DP_V.Text = v_Vaule.ToString("0.0");

                        if (95.0 <= v_Vaule && v_Vaule <= 105.0)
                        {
                            Form1.pform1.Display_BackColor("V", "OK",0);
                            if (Form1.pform1.FlagAuto_En == true)
                            {
                                Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_TEMP;
                                Form1.pform1.AutoTest_StepContinue(200);
                            }
                        }
                        else
                        {
                            Form1.pform1.Display_BackColor("V", "NG", (int)v_Vaule);
                        }
                        break;

                    case (char)UART_TEST_ENUM.UART_TEST_TEMP:
                        int t_adc = AsciiToDecNum(3, data_len, buff);
                        float t_Vaule = 112 - (1281 * (float)t_adc / 10000);
                        Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 读取温度原始值：" + t_Vaule.ToString("0.00") + "℃\r\n");
                        Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 环境温度设定值：" + Form1.pform1.Set_TempVal.ToString() + "℃\r\n");
                        Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 温度要求最小值：" + (Form1.pform1.Set_TempVal - 5).ToString() + "℃，最大值" + (Form1.pform1.Set_TempVal + 3).ToString() + "℃\r\n");
                        Form1.pform1.DP_T.Text = t_Vaule.ToString("0.00"); //保留两位小数
                        rpm_rxnum = 0;
                        curr_rxnum = 0;
                        if (Form1.pform1.Set_TempVal - 5 <= t_Vaule && t_Vaule <= Form1.pform1.Set_TempVal + 3)
                        {
                            Form1.pform1.Display_BackColor("T", "OK",0);
                            if (Form1.pform1.FlagAuto_En == true)
                            {
                                Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_WIRELESS_ID;
                                Form1.pform1.AutoTest_StepContinue(200);
                            }
                        }
                        else
                        {
                            Form1.pform1.Display_BackColor("T", "NG", (int)t_Vaule);
                        }
                        break;

                    case (char)UART_TEST_ENUM.UART_TEST_RPM:
                        int rpm = AsciiToDecNum(3, data_len-1, buff);
                        //rpm_buf[rpm_rxnum] = rpm;
                        //rpm_rxnum++;
                        //if (rpm_rxnum == 5)
                        {
                            rpm_rxnum = 0;
                            //rpm = center_value(5, rpm_buf);
                            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 读取转速原始值：" + rpm.ToString() + "rpm\r\n");
                            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 转速要求最小值：1149rpm，最大值1189rpm\r\n");
                            if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN) Form1.pform1.DP_R.Text = rpm.ToString();
                            else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE) Form1.pform1.DP_CR.Text = rpm.ToString();
                            if (1149 <= rpm && rpm <= 1189)
                            {
                                Form1.pform1.flag_err = 0;
                                if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN)
                                {
                                    Form1.pform1.Display_BackColor("R", "OK",0);
                                }
                                else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE)
                                {
                                    Form1.pform1.Display_BackColor("CR", "OK",0);
                                }
                                if (Form1.pform1.FlagAuto_En == true)
                                {
                                    if (Form1.pform1.DP_I_OKNG.Text == "OK")
                                    {
                                        if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN) Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_CLOSE;
                                        else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE) Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_STOP;
                                        Form1.pform1.LoadCurrent_DOWN();
                                        Form1.pform1.AutoTest_StepContinue(200);
                                    }
                                }
                            }
                            else
                            {
                                if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN)
                                {
                                    Form1.pform1.Display_BackColor("R", "NG", rpm);
                                }
                                else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE)
                                {
                                    Form1.pform1.Display_BackColor("CR", "NG", rpm);
                                }
                            }
                        }
                        if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN)
                        {
                            if (buff[data_len + 2] == 'O') Form1.pform1.Display_BackColor("OPEN", "OK",0);
                            else
                            {
                                Form1.pform1.Display_BackColor("OPEN", "NG",0);
                            }
                        }
                        else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE)
                        {
                            if (buff[data_len + 2] == 'C') Form1.pform1.Display_BackColor("CLOSE", "OK",0);
                            else 
                            {
                                Form1.pform1.Display_BackColor("CLOSE", "NG",0);
                            }
                        }
                        else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_STOP)
                        {
                            if (buff[data_len + 2] == 'S') Form1.pform1.Display_BackColor("STOP", "OK",0);
                            else 
                            {
                                Form1.pform1.Display_BackColor("STOP", "NG",0);
                            }
                        } 
                        else 
                        {
                            if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
                        }
                        break;

                    case (char)UART_TEST_ENUM.UART_TEST_CURR_RPM:
                        int curr_len = AsciiToDecNum(3, 1, buff);;
                        int rpm_len = AsciiToDecNum(4, 1, buff);;
                        int curr_value = AsciiToDecNum(5, curr_len, buff);
                        int rpm_value = AsciiToDecNum(curr_len+5, rpm_len, buff);
                        if (Form1.pform1.FlagAuto_En == true)
                        {
                            curr_buf[rpm_rxnum] = curr_value;
                            rpm_buf[rpm_rxnum] = rpm_value;
                            rpm_rxnum++;
                        }
                        if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_STOP)
                        {
                            if (buff[5 + curr_len + rpm_len + 1] == '6')
                            {
                                Form1.pform1.Display_BackColor("STOP", "OK", 0);
                                if (Form1.pform1.FlagAuto_En == true)
                                {
                                    Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_BUBREAK;
                                    Form1.pform1.AutoTest_StepContinue(500);
                                }
                            }
                            else
                            {
                                Form1.pform1.Display_BackColor("STOP", "NG", 0);
                            }
                        }
                        if (rpm_rxnum == 6 || Form1.pform1.FlagAuto_En == false)
                        {
                            rpm_rxnum = 0;
                            if (Form1.pform1.FlagAuto_En == true)
                            {
                                curr_value = center_value(6, curr_buf);
                                rpm_value = center_value(6, rpm_buf);
                            }
                            if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN)
                            {
                                if (buff[curr_len + rpm_len + 5] == 'O' && rpm_value > 50)
                                {
                                    Form1.pform1.Display_BackColor("OPEN", "OK",0);
                                }
                                else
                                {
                                    Form1.pform1.Display_BackColor("OPEN", "NG",0);
                                }
                            }
                            else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE)
                            {
                                if (buff[curr_len + rpm_len + 5] == 'C' && rpm_value > 50)
                                {
                                    Form1.pform1.Display_BackColor("CLOSE", "OK",0);
                                }
                                else
                                {
                                    Form1.pform1.Display_BackColor("CLOSE", "NG",0);
                                }
                            }
                            /* else
                             {
                                 if (buff[curr_len + rpm_len + 5] == 'S') Form1.pform1.Display_BackColor("STOP", "OK");
                                 else Form1.pform1.Display_BackColor("STOP", "NG");
                             }*/
                            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 读取电流原始值：" + curr_value.ToString() + "\r\n");
                            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 电流要求最小值：43，最大值：53\r\n");
                            if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN) Form1.pform1.DP_I.Text = curr_value.ToString();
                            else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE) Form1.pform1.DP_CI.Text = curr_value.ToString();
                            if (43 <= curr_value && curr_value <= 53)
                            {
                                Form1.pform1.flag_err = 0;
                                if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN)
                                {
                                    Form1.pform1.Display_BackColor("I", "OK", 0);
                                }
                                else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE)
                                {
                                    Form1.pform1.Display_BackColor("CI", "OK", 0);
                                }
                                else Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<电流>检查：OK\r\n");
                                //if (Form1.pform1.FlagAuto_En == true) Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_VER;
                            }
                            else
                            {
                                if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN)
                                {
                                    Form1.pform1.Display_BackColor("I", "NG", curr_value);
                                }
                                else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE)
                                {
                                    Form1.pform1.Display_BackColor("CI", "NG", curr_value);
                                }
                                else
                                {
                                    if (curr_value < 43) Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机电流检查：NG  低于最小值\r\n");
                                    else if (curr_value > 53) Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机电流检查：NG  超过最大值\r\n");
                                }
                            }
                            
                            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 读取转速原始值：" + rpm_value.ToString() + "rpm\r\n");
                            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 转速要求最小值：1149rpm，最大值1189rpm\r\n");
                            if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN) Form1.pform1.DP_R.Text = rpm_value.ToString();
                            else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE) Form1.pform1.DP_CR.Text = rpm_value.ToString();

                            if (1149 <= rpm_value && rpm_value <= 1189)
                            {
                                Form1.pform1.flag_err = 0;
                                if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN)
                                {
                                    Form1.pform1.Display_BackColor("R", "OK",0);
                                }
                                else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE)
                                {
                                    Form1.pform1.Display_BackColor("CR", "OK",0);
                                }
                                if (Form1.pform1.FlagAuto_En == true)
                                {
                                    if (Form1.pform1.DP_I_OKNG.Text == "OK")
                                    {
                                        if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN) Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_CLOSE;
                                        else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE) Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_STOP;
                                        Form1.pform1.AutoTest_StepContinue(200);
                                    }
                                }
                            }
                            else
                            {
                                if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_OPEN)
                                {
                                    Form1.pform1.Display_BackColor("R", "NG", rpm_value);
                                }
                                else if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_CLOSE)
                                {
                                    Form1.pform1.Display_BackColor("CR", "NG", rpm_value);
                                }
                            }
                        }
                        break;

                    case (char)UART_TEST_ENUM.UART_TEST_WIRELESS_ID:
                        if (buff[3] == 'W')
                        {
                            if (buff[4] == '2')
                            {
                                Form1.pform1.flag_err = 0;
                                Form1.pform1.Display_BackColor("WID", "OK",0);
                                if (Form1.pform1.FlagAuto_En == true)
                                {
                                    Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_OPEN; ;
                                    Form1.pform1.AutoTest_StepContinue(200);
                                }
                            }
                            else
                            {
                                Form1.pform1.Display_BackColor("WID", "NG",0);
                            }
                        }
                        else
                        {
                            Form1.pform1.Display_BackColor("W", "NG",0);
                        }
                        break;

                    case (char)UART_TEST_ENUM.UART_TEST_BUBREAK:
                    case (char)UART_TEST_ENUM.UART_TEST_ENCODER:
                        int ncnt = 0;
                        if (buff[3] == '-') //符号位
                        {
                            ncnt = AsciiToDecNum(4, data_len - 1, buff);
                            encod_buf[encod_rxnum] = ncnt;
                            //Form1.pform1.DP_Stop_OKNG.Text = '-' + ncnt.ToString();
                        }
                        else
                        {
                            ncnt = AsciiToDecNum(3, data_len, buff);
                            encod_buf[encod_rxnum] = ncnt;
                            //Form1.pform1.DP_Stop_OKNG.Text = ncnt.ToString();
                        }
                        encod_rxnum++;
                        if (encod_rxnum == Form1.pform1.bubreak_cnt)
                        {
                            encod_rxnum = 0;
                            if (encod_buf[Form1.pform1.bubreak_cnt - 3] == encod_buf[Form1.pform1.bubreak_cnt - 2] && encod_buf[Form1.pform1.bubreak_cnt - 2] == encod_buf[Form1.pform1.bubreak_cnt - 1] && encod_buf[Form1.pform1.bubreak_cnt - 3] != 0 && encod_buf[Form1.pform1.bubreak_cnt - 2] != 0 && encod_buf[Form1.pform1.bubreak_cnt-1] != 0)
                            {
                                Form1.pform1.Display_BackColor("B", "OK", 0);
                                if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
                            }
                            else
                            {
                                Form1.pform1.Display_BackColor("B", "NG", 0);
                            }
                        }
                        break;
                    default:
                        if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
                        break;
                }
            }
            else if (buff[1] == 'T' && buff[2] == 'E' && buff[3] == 'S' && buff[4] == 'T')
            {
                Form1.pform1.EnDis_Timer1(false);
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 进入<测试模式>OK.\r\n");
                if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Start();
            }
            else if (buff[1] == 'E' && buff[2] == 'N' && buff[3] == 'D')
            {
                Form1.pform1.EnDis_Timer1(false);
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 已退出<测试模式>!\r\n");
                //Form1.pform1.flag_err = TEST_ERROR_ENUM.TEST_ERR_EXIT;
                //if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
            }
            else 
            {
                if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
            }
        }
        public int AsciiToDecNum(int addrstart, int datalen, char[] buf)
        {
            int num = 0;
            for (int i = 0; i < datalen; i++)
            {
                num = num + ((buf[addrstart + i] - 48) * (int)Math.Pow(10, datalen - i - 1));
            }
            return num;
        }
        public void Motor_Port1Click()
        {
            if (Form1.pform1.serialPort1.IsOpen)
            {
                try
                {
                    Form1.pform1.serialPort1.Close();
                }
                catch { }
                Form1.pform1.DP_Uart_OpenClose.BackColor = Color.LightSteelBlue;
                Form1.pform1.DP_Uart_OpenClose.Text = "主电机串口已关闭";
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机串口 已关闭\r\n");
                Form1.pform1.DP_Uart1_comboBox1.Enabled = true;
            }
            else
            {
                try
                {
                    Form1.pform1.serialPort1.PortName = Form1.pform1.DP_Uart1_comboBox1.Text;
                    Form1.pform1.serialPort1.Open();
                    Form1.pform1.DP_Uart_OpenClose.BackColor = Color.LightGreen;
                    Form1.pform1.DP_Uart_OpenClose.Text = "主电机串口已打开";
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机串口 " + Form1.pform1.DP_Uart1_comboBox1.Text + " 已打开\r\n");
                    Form1.pform1.DP_Uart1_comboBox1.Enabled = false;
                }
                catch
                {
                    Form1.pform1.DP_Uart1_comboBox1.Enabled = true;
                    Form1.pform1.DP_Uart_OpenClose.Text = "主电机串口已关闭";
                    Form1.pform1.DP_Uart_OpenClose.BackColor = Color.LightSteelBlue;
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机串口 " + Form1.pform1.DP_Uart1_comboBox1.Text + " 打开失败 请重新选择端口！\r\n");
                    MessageBox.Show("出错，主电机串口 打开失败,请重新选择端口！");
                    Form1.pform1.DP_Uart1_comboBox1.Items.Clear();
                    Form1.pform1.DP_Uart1_comboBox1.Text = "";
                    string[] myselPort = SerialPort.GetPortNames();   //获取可用端口号
                    if (myselPort.Length > 0)  //至少有一个端口
                    {
                        Form1.pform1.DP_Uart1_comboBox1.Items.Clear();    //清空comboBox1中的内容
                        for (int i = 0; i < myselPort.Length; i++)
                        {
                            Form1.pform1.DP_Uart1_comboBox1.Items.Add(myselPort[i]);
                        }
                        Form1.pform1.DP_Uart1_comboBox1.Text = myselPort[0];
                    }
                }
            }
        }
        public void Motor_SerPort1_tx_data(byte[] data, int length)
        {
            if (Form1.pform1.serialPort1.IsOpen)//判断串口是否打开，如果打开执行下一步操作
            {
                try
                {
                    Form1.pform1.serialPort1.Write(data, 0, length); //发送数据
                    Form1.pform1.EnDis_Timer1(true);//应答超时处理
                }
                catch
                {
                    Form1.pform1.flag_err = TEST_ERROR_ENUM.TEST_ERR_MotorPort1;
                    Form1.pform1.timer5.Enabled = false;
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 错误：主电机串口数据发送出错！\r\n");
                    //MessageBox.Show("主电机串口数据发送出错，请检查.", "错误");//错误处理
                    if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
                }
            }
            else
            {
                Form1.pform1.flag_err = TEST_ERROR_ENUM.TEST_ERR_MotorPort1;
                Form1.pform1.DP_Uart_OpenClose.Text = "主电机串口已关闭";
                Form1.pform1.DP_Uart_OpenClose.BackColor = Color.LightSteelBlue; ;
                Form1.pform1.timer5.Enabled = false;
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 出错：主电机串口已断开\r\n");
                //MessageBox.Show("出错：主电机串口已断开！");
                if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
            }
        }
        public void MotorSend_GetV()
        {
            Form1.pform1.Display_BackColor("V", "0",0);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 检查<电压>\r\n");
            string Vstr = "(TV)";
            byte[] Vdata = System.Text.Encoding.Default.GetBytes(Vstr);
            Motor_SerPort1_tx_data(Vdata, Vdata.Length);
        }
        public void MotorSend_GetT()
        {
            Form1.pform1.Display_BackColor("T", "0",0);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 检查<温度>\r\n");
            if (Form1.pform1.flag_temp == 1)
            {
                string Tstr = "(TT)";
                byte[] Tdata = System.Text.Encoding.Default.GetBytes(Tstr);
                Motor_SerPort1_tx_data(Tdata, Tdata.Length);
            }
            else
            {
                Form1.pform1.flag_err = TEST_ERROR_ENUM.TEST_ERR_T;
                Form1.pform1.Display_BackColor("T", "NG", 0);
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 出错，未设定环境温度，请设定环境温度之后再进行测试！\r\n");
                //MessageBox.Show("出错，未设定环境温度，请设定环境温度之后再进行测试！");
                if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
            }
        }
        public void MotorSend_GetI()
        {
            Form1.pform1.Display_BackColor("I", "0",0);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 查看<电流>\r\n");
            string Istr = "(TI)";
            byte[] Idata = System.Text.Encoding.Default.GetBytes(Istr);
            Motor_SerPort1_tx_data(Idata, Idata.Length);
        }
        public void MotorSend_GetCI()
        {
            Form1.pform1.Display_BackColor("CI", "0",0);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 查看<电流>\r\n");
            string Istr = "(TI)";
            byte[] Idata = System.Text.Encoding.Default.GetBytes(Istr);
            Motor_SerPort1_tx_data(Idata, Idata.Length);
        }
        public void MotorSend_GetI_R()
        {
            string Mstr = "(TM)";
            byte[] Mdata = System.Text.Encoding.Default.GetBytes(Mstr);
            if (Form1.pform1.auto_step != UART_TEST_ENUM.UART_TEST_STOP)
            {
                Form1.pform1.Display_BackColor("I", "0", 0);
                Form1.pform1.Display_BackColor("R", "0", 0);
            }
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 查看主电机<开>动作电流和转速\r\n");
            Motor_SerPort1_tx_data(Mdata, Mdata.Length);
        }
        public void MotorSend_GetStop()
        {
            string Mstr = "(TM)";
            byte[] Mdata = System.Text.Encoding.Default.GetBytes(Mstr);
            Form1.pform1.Display_BackColor("STOP", "0", 0);
            Motor_SerPort1_tx_data(Mdata, Mdata.Length);
        }
        public void MotorSend_GetCI_CR()
        {
            string CMstr = "(TM)";
            byte[] CMdata = System.Text.Encoding.Default.GetBytes(CMstr);
            Form1.pform1.Display_BackColor("CI", "0",0);
            Form1.pform1.Display_BackColor("CR", "0",0);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 查看主电机<闭>动作电流和转速\r\n");
            Motor_SerPort1_tx_data(CMdata, CMdata.Length);
        }
        public void MotorSend_GetR()
        {
            Form1.pform1.Display_BackColor("R", "0",0);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 查看<转速>\r\n");
            string Rstr = "(TR)";
            byte[] Rdata = System.Text.Encoding.Default.GetBytes(Rstr);
            Motor_SerPort1_tx_data(Rdata, Rdata.Length);
        }
        public void MotorSend_GetCR()
        {
            Form1.pform1.Display_BackColor("CR", "0",0);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 查看<转速>\r\n");
            string Rstr = "(TR)";
            byte[] Rdata = System.Text.Encoding.Default.GetBytes(Rstr);
            Motor_SerPort1_tx_data(Rdata, Rdata.Length);
        }
        public void MotorSend_Open()
        {
            Form1.pform1.Display_BackColor("OPEN", "0",0);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " <开>动作\r\n");
            string Kstr = "(TK)";
            byte[] Kdata = System.Text.Encoding.Default.GetBytes(Kstr);
            Motor_SerPort1_tx_data(Kdata, Kdata.Length);
        }
        public void MotorSend_Stop()
        {
            Form1.pform1.Display_BackColor("STOP", "0",0);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " <停止>\r\n");
            string Pstr = "(TP)";
            byte[] Pdata = System.Text.Encoding.Default.GetBytes(Pstr);
            Motor_SerPort1_tx_data(Pdata, Pdata.Length);
        }
        public void MotorSend_Close()
        {
            Form1.pform1.Display_BackColor("CLOSE", "0",0);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " <闭>动作\r\n");
            string Cstr = "(TC)";
            byte[] Cdata = System.Text.Encoding.Default.GetBytes(Cstr);
            Motor_SerPort1_tx_data(Cdata, Cdata.Length);
        }
        public void MotorSend_GetWID()
        {
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " <无线ID>测试\r\n");
            Form1.pform1.Display_BackColor("WID","0",0);
            string wstr = "(TW)";
            byte[] wdata = System.Text.Encoding.Default.GetBytes(wstr);
            Motor_SerPort1_tx_data(wdata, wdata.Length);
        }
        public void MotorSend_GetEncod()
        {
            string wstr = "(TE)";
            byte[] wdata = System.Text.Encoding.Default.GetBytes(wstr);
            Motor_SerPort1_tx_data(wdata, wdata.Length);
        }
        public void MotorSend_ExitTest()
        {
            string wstr = "(END)";
            byte[] wdata = System.Text.Encoding.Default.GetBytes(wstr);
            Motor_SerPort1_tx_data(wdata, wdata.Length);
        }
        public void MotorSend_AcBreak_ON()
        {
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<动作刹车>测试开始\r\n");
            Form1.pform1.Display_BackColor("A", "0",0);
            string wstr = "(TA)";
            byte[] wdata = System.Text.Encoding.Default.GetBytes(wstr);
            Motor_SerPort1_tx_data(wdata, wdata.Length);
        }
        public void MotorSend_AcBreak_OFF()
        {
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<动作刹车>测试停止\r\n");
            string wstr = "(TF)";
            byte[] wdata = System.Text.Encoding.Default.GetBytes(wstr);
            Motor_SerPort1_tx_data(wdata, wdata.Length);
        }
        public void MotorSend_BuBreak()
        {
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<施工刹车>测试开始\r\n");
            string wstr = "(TB)";
            byte[] wdata = System.Text.Encoding.Default.GetBytes(wstr);
            Motor_SerPort1_tx_data(wdata, wdata.Length);
        }
        public int center_value(int len,int[] buf)
        {
            int i, j;
            int temp = 0;
            if(len == 1) return buf[0];
            if (len == 2) return ((buf[0] + buf[1]) / 2);

            for (i = 0; i < len; i++)
            {
                for (j = 0; j < len-1; j++)
                {
                    if (buf[j] > buf[j+1])
                    { 
                        temp = buf[j+1];
                        buf[j+1] = buf[j];
                        buf[j] = temp;
                    }
                }
            }
            if (len % 2 != 0)
            {
                temp = (int)(len / 2);
                return (buf[temp]);
            }
            else
            {
                temp = len / 2;
                temp = (buf[temp - 1] + buf[temp]) / 2;
                return (temp);
            }
            /*
            for (i = 1; i < len - 1; i++)
            {
                temp += buf[i];
                //Form1.pform1.DP_DataRecord.AppendText(buf[i].ToString() + "\r\n");
            }
            return (temp / (len-2));*/
        }
    }
}

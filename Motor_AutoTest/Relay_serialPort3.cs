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
using System.Runtime.InteropServices;

namespace Motor_AutoTest
{
    class Relay_serialPort3
    {
        byte[] InputData = new byte[64];
        int rx_offset = 0;
        public int rx_ack_num = 0;
        public int acbreak_num = 0;
        public int bubreak_num = 0;
        public int acok_num = 0;
        int flag_rx_done = 0;
        ModbusCRC16 CHECKCRC16 = new ModbusCRC16();
        Color BackClolor_ON = Color.LightSteelBlue;
        Color BackClolor_OFF = Color.Gainsboro;
        CVisaOpt_Option cv_opt = new CVisaOpt_Option();
        [DllImport("kernel32")]static extern uint GetTickCount();
        public void Relay_SerPort3Init()
        {
            Form1.pform1.serialPort3.DataReceived += new SerialDataReceivedEventHandler(port3_Relay_DataReceived);//必须手动添加事件处理程序
        }
        public void Relay_Port3Click()
        {
            if (Form1.pform1.serialPort3.IsOpen)
            {
                try
                {
                    Form1.pform1.serialPort3.Close();
                }
                catch { }
                Form1.pform1.DP_Uart_Relay.BackColor = Color.LightSteelBlue;
                Form1.pform1.DP_Uart_Relay.Text = "继电器串口已关闭";
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 继电器串口 已关闭\r\n");
                Form1.pform1.DP_Uart3_comboBox3.Enabled = true;
            }
            else
            {
                try
                {
                    Form1.pform1.serialPort3.PortName = Form1.pform1.DP_Uart3_comboBox3.Text;
                    Form1.pform1.serialPort3.Open();
                    Form1.pform1.DP_Uart_Relay.BackColor = Color.LightGreen;
                    Form1.pform1.DP_Uart_Relay.Text = "继电器串口已打开";
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 继电器串口 " + Form1.pform1.DP_Uart3_comboBox3.Text + " 已打开\r\n");
                    //EnDis_TestMode(true);
                    Form1.pform1.DP_Uart3_comboBox3.Enabled = false;
                    //AutoTest_Step = 1;
                    //timer2.Enabled = true;
                }
                catch
                {
                    //EnDis_TestMode(false);
                    Form1.pform1.DP_Uart3_comboBox3.Enabled = true;
                    Form1.pform1.DP_Uart_Relay.Text = "继电器串口已关闭";
                    Form1.pform1.DP_Uart_Relay.BackColor = Color.LightSteelBlue;
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 继电器串口 " + Form1.pform1.DP_Uart3_comboBox3.Text + " 打开失败 请重新选择端口！\r\n");
                    MessageBox.Show("出错，继电器串口 打开失败,请重新选择端口！");
                    Form1.pform1.DP_Uart3_comboBox3.Items.Clear();
                    Form1.pform1.DP_Uart3_comboBox3.Text = "";
                    string[] myselPort = SerialPort.GetPortNames();   //获取可用端口号
                    if (myselPort.Length > 0)  //至少有一个端口
                    {
                        Form1.pform1.DP_Uart3_comboBox3.Items.Clear();    //清空comboBox1中的内容
                        for (int i = 0; i < myselPort.Length; i++)
                        {
                            Form1.pform1.DP_Uart3_comboBox3.Items.Add(myselPort[i]);
                        }
                        Form1.pform1.DP_Uart3_comboBox3.Text = myselPort[0];
                    }
                }
            }
        }
        private void port3_Relay_DataReceived(object sender, SerialDataReceivedEventArgs e) //串口接收处理
        {
            int rx_cnt = 0;
            byte[] InputBuf = new byte[64];
            rx_cnt = Form1.pform1.serialPort3.BytesToRead;
            if (rx_cnt > 64) rx_cnt = 64;
            Form1.pform1.serialPort3.Read(InputBuf, 0, rx_cnt);

            //01 10 00 00 00 02 41 C8
            for (int j = 0; j < rx_cnt; j++)
            {
                if (InputBuf[j] == 0x01 || InputData[0] == 0x01) //帧头
                {
                    for (int k = 0; k < rx_cnt - j; k++)
                    {
                        if (k + rx_offset >= 64)
                        {
                            j = 0;
                            rx_cnt = 0;
                            rx_offset = 0;
                            InputData[0] = 0x00;
                            break;
                        }
                        InputData[k + rx_offset] = InputBuf[k + j];
                        if (k + rx_offset + 1 == rx_ack_num) //接收完整ACK
                        {
                            rx_ack_num = 0;
                            rx_offset = 0;
                            InputData[0] = 0x00;
                            flag_rx_done = 1;
                            break;
                        }
                    }
                    if (flag_rx_done != 1) rx_offset += rx_cnt - j; //如果没有接收完成，下一包数据继续放入InputData。
                    break;
                }
            }
            string strdata = "";
            flag_rx_done = 1;
            for (int i = 0; i < rx_cnt; i++)
            {
                strdata += InputBuf[i].ToString("X2") + " ";
            }
            if (Form1.pform1.auto_step != UART_TEST_ENUM.UART_TEST_READReX2)
            {
                Form1.pform1.BeginInvoke(new Action(() =>
                {
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 接收继电器数据：");
                    Form1.pform1.DP_DataRecord.AppendText(strdata + "\r\n");
                }));
            }
            if (flag_rx_done == 1)
            {
                flag_rx_done = 0;
                Form1.pform1.BeginInvoke(new Action(() =>
                {
                    Relay_ReciceData_Check(InputData);
                }));
            }
        }
        public void Relay_ReciceData_Check(byte[] buff)
        {
            Form1.pform1.EnDis_Timer1(false);
            if (buff[1] == 0x04 && buff[2] == 0x02 && buff[4] == 0x01)
            {
                Form1.pform1.auto_step = UART_TEST_ENUM.UART_TEST_POWEROFF;
                Form1.pform1.Motor_TestCheck(0,100);
            }
            //0x01, 0x10, 0x00, 0x02, 0x00, 0x01
            else if (buff[1] == 0x10 && buff[2] == 0x00 && buff[3] == 0x02 && buff[4] == 0x00 && buff[5] == 0x01)
            {
                ;
            }
            //应答口1输入0：01 04 02 00 00 B9 30
            //应答口1输入1：01 04 02 00 01 78 F0
            else if (buff[1] == 0x04 && buff[2] == 0x02 && buff[4] == 0x00 && buff[5] == 0xB9 && buff[6] == 0x30)
            {
                acbreak_num++;
            }
            else if (buff[1] == 0x04 && buff[2] == 0x02 && buff[4] == 0x01 && buff[5] == 0x78 && buff[6] == 0xF0)
            {
                acbreak_num++;
                acok_num++;
            }
            if (Form1.pform1.auto_step == UART_TEST_ENUM.UART_TEST_ACBREAK_ON)
            {
                if (acbreak_num == 5)
                {
                    if (acok_num >= 3)
                    {
                        Form1.pform1.Display_BackColor("A", "OK",0);
                        BreakLED_ONOFF(true);
                        Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 动作中刹车测试：OK\r\n");
                    }
                    else
                    {
                        Form1.pform1.Display_BackColor("A", "NG",0);
                        BreakLED_ONOFF(false);
                        Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 动作中刹车测试：NG\r\n");
                    }
                    acbreak_num = 0;
                    acok_num = 0;
                }
            }
        }
        public void Relay_SerPort3_tx_data(byte[] data, int length)
        {
            if (Form1.pform1.serialPort3.IsOpen)//判断串口是否打开，如果打开执行下一步操作
            {
                try
                {
                    Form1.pform1.serialPort3.Write(data, 0, length); //发送数据
                    Form1.pform1.EnDis_Timer1(true);//应答超时处理
                }
                catch
                {
                    Form1.pform1.flag_err = TEST_ERROR_ENUM.TEST_ERR_RelayPort3;
                    Form1.pform1.timer5.Enabled = false;
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 错误：继电器串口数据发送出错！\r\n");
                    //MessageBox.Show("继电器串口 数据发送出错，请检查.", "错误");//错误处理
                    if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
                }
            }
            else
            {
                Form1.pform1.DP_Uart_Relay.Text = "继电器串口已关闭";
                Form1.pform1.DP_Uart_Relay.BackColor = Color.LightSteelBlue; ;
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 出错：继电器串口已断开\r\n");
                //MessageBox.Show("出错：继电器串口已断开！");
                Form1.pform1.flag_err = TEST_ERROR_ENUM.TEST_ERR_RelayPort3;
                Form1.pform1.timer5.Enabled = false;
                if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
            }
        }
        public void AuxMotor_TestOpen()//副电机开动作
        {
            UInt16 crc = 0;      //输出模式      //Y10      //控制一个        //输出1
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x09, 0x00, 0x01, 0x04, 0x00, 0x01, 0x00, 0x00 };
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 副电机<开>动作\r\n");
            WaitTime(500);//等待0.5s
            tx_data[8] = 0x00;//输出0
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
        }
        public void AuxMotor_TestStop()//副电机停止
        {
            UInt16 crc = 0;         //输出模式   //Y9      //控制一个        //输出1
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x08, 0x00, 0x01, 0x04, 0x00, 0x01, 0x00, 0x00 };
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 副电机<停止>动作\r\n");
            WaitTime(500);//等待0.5s
            tx_data[8] = 0x00;//输出0
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
        }
        public void WaitTime(uint ms)//等待时长ms
        {
            uint time = GetTickCount();
            while ((GetTickCount() - time) < ms)
            {;}
        }
        public void MainMotor_TestOpen()//主电机开
        {
            UInt16 crc = 0;         //输出模式   //Y3      //控制一个        //输出1
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x02, 0x00, 0x01, 0x04, 0x00, 0x01, 0x00, 0x00 };
            Form1.pform1.Display_BackColor("OPEN", "0",0);
            Form1.pform1.Display_BackColor("I", "0",0);
            Form1.pform1.Display_BackColor("R", "0",0);
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机执行<开>动作\r\n");
            WaitTime(500);//等待500ms
            tx_data[8] = 0x00;//输出0
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
        }
        public void MainMotor_TestStop()//主电机停止
        {
            UInt16 crc = 0;         //输出模式   //Y2      //控制一个        //输出1
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x01, 0x00, 0x01, 0x04, 0x00, 0x01, 0x00, 0x00 };
            Form1.pform1.Display_BackColor("STOP", "0",0);
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<停止>动作\r\n");
            WaitTime(500);//等待0.5s
            tx_data[8] = 0x00;//输出0
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            Form1.pform1.LoadCurrent_DOWN();
        }
        public void MainMotor_TestClose()//主电机闭
        {
            UInt16 crc = 0;         //输出指令   //Y1      //控制一个        //输出1
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x00, 0x00, 0x01, 0x04, 0x00, 0x01, 0x00, 0x00 };
            Form1.pform1.Display_BackColor("CLOSE", "0",0);
            Form1.pform1.Display_BackColor("CI", "0",0);
            Form1.pform1.Display_BackColor("CR", "0",0);
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机执行<闭>动作\r\n");
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            WaitTime(500);//等待0.5s
            tx_data[8] = 0x00;//输出0
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
        }
        public void MainMotor_TestMode()
        {
            UInt16 crc = 0;
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x04, 0x00, 0x01, 0x04, 0x00, 0x01, 0x00, 0x00 };
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 设置为测试模式\r\n");
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
        }
        public void MainMotor_WorkMode()
        {
            UInt16 crc = 0;
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x04, 0x00, 0x01, 0x04, 0x00, 0x00, 0x00, 0x00 };
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 设置为工作模式\r\n");
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
        }
        public void Power_ON()
        {
            UInt16 crc = 0;                     
            if (Form1.pform1.DP_PowerOn_OKNG.Text == "" || Form1.pform1.DP_PowerOn_OKNG.Text == "ON")
            {
                byte[] tx_data = { 0x01, 0x10, 0x00, 0x06, 0x00, 0x02, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
                tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
                tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
                //Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 关闭电源\r\n");
                //rx_ack_num = 8;
                //Relay_SerPort3_tx_data(tx_data, tx_data.Length);
                Release_PowerOFF();
                Form1.pform1.DP_PowerOn_OKNG.Text = "OFF";
                Form1.pform1.Form1WaitTime(500);
                Form1.pform1.DP8_OFF();
            }
            else//打开继电器Y7、Y8 (地址从07开始，两个),输出1
            {
                cv_opt.SourceOpt_Init("DP8");
                cv_opt.Opt_Set("DP8", "ON");
                WaitTime(500);
                byte[] tx_data = { 0x01, 0x10, 0x00, 0x06, 0x00, 0x02, 0x04, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00 };
                crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
                tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
                tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 打开电源\r\n");
                Form1.pform1.DP_PowerOn_OKNG.Text = "ON";
                rx_ack_num = 8;
                Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            }
        }
        public void Power_ONOFF(bool onoff)
        {
            UInt16 crc = 0;
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x06, 0x00, 0x02, 0x04, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00 };
            if (onoff == false)
            {
                tx_data[8] = 0x00;
                tx_data[10] = 0x00;
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 关闭电源\r\n");
                Form1.pform1.DP_PowerOn_OKNG.Text = "OFF";
                
            }
            else
            {
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 打开电源\r\n");
                Form1.pform1.DP_PowerOn_OKNG.Text = "ON";
            }
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            if (onoff == false)
            {
                Form1.pform1.Form1WaitTime(500);
                Form1.pform1.DP8_OFF();
            }
        }
        public void ID_CheckMode()//TP14,ID检测
        {
            UInt16 crc = 0;
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x03, 0x00, 0x01, 0x04, 0x00, 0x01, 0x00, 0x00 };
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " ID检测模式\r\n");
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
        }
        public void BreakLED_ONOFF(bool onoff)//刹车LED
        {
            UInt16 crc = 0;
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x05, 0x00, 0x01, 0x04, 0x00, 0x01, 0x00, 0x00 };
            if (onoff == false) tx_data[8] = 0;
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
        }
        public void Release_PowerOFF()
        {
            UInt16 crc = 0;
            byte[] tx_data = { 0x01, 0x10, 0x00, 0x0A, 0x00, 0x01, 0x04, 0x00, 0x01, 0x00, 0x00 };
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            Power_ONOFF(false);
            WaitTime(200);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            WaitTime(1000);
            tx_data[8] = 0x00;
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 8;
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
        }
        public void Read_ActionBreak()
        {
            UInt16 crc = 0;         //读取指令   //X1       //读取一个
            byte[] tx_data = { 0x01, 0x04, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 7; //需要接收继电器模块应答7个字节
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 动作中刹车测试\r\n");
            //应答口1输入0：01 04 02 00 00 B9 30
            //应答口1输入1：01 04 02 00 01 78 F0
        }
        public void Read_ReX2()
        {
            UInt16 crc = 0;         //读取指令   //X2       //读取一个
            byte[] tx_data = { 0x01, 0x04, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00 };
            crc = CHECKCRC16.GetCRC16_Value(tx_data, tx_data.Length - 2);
            tx_data[tx_data.Length - 2] = (byte)(crc >> 8 & 0xff);
            tx_data[tx_data.Length - 1] = (byte)(crc & 0xff);
            rx_ack_num = 7; //需要接收继电器模块应答7个字节
            Relay_SerPort3_tx_data(tx_data, tx_data.Length);
            //Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 动作中刹车测试\r\n");
            //应答口1输入0：01 04 02 00 00 B9 30
            //应答口1输入1：01 04 02 00 01 78 F0
        }
    }
}

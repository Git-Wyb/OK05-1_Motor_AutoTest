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

public enum UART_TEST_ENUM
{
    UART_TEST_RESET_ON = '0',
    UART_TEST_CURR = 'I',   //查看电流
    UART_TEST_VER = 'V',   //查看电压
    UART_TEST_TEMP = 'T',   //查看温度
    UART_TEST_RPM = 'R',   //查看转速
    UART_TEST_CURR_RPM = 'M',//查看转速和电流
    UART_TEST_ENCODER = 'E',   //查看编码器计数
    UART_TEST_ROTATE = 'O',   //电机旋转一圈
    UART_TEST_WIRELESS_ID = 'W',//查看无线串口是否正常
    UART_TEST_MODE = 'S',   //测试模式
    UART_TEST_EXIT = 'X',   //退出测试模式
    UART_TEST_OPEN = 'K',   //开动作
    UART_TEST_CLOSE = 'C',   //闭动作
    UART_TEST_STOP = 'P',   //停止
    UART_TEST_BUBREAK = 'B',  //测试施工中刹车
    UART_TEST_ACBREAK_ON = 'A', //测试动作中刹车输出
    UART_TEST_ACBREAK_OFF = 'F', //测试动作中刹车停止
    UART_TEST_READReX2 = 'U',
    UART_TEST_POWEROFF = 'Z',
    UART_TEST_DP8OFF = '#',
    UART_TEST_OVER = '*',  //测试结束
    UART_TEST_IDLE = '0'
};
public enum TEST_ERROR_ENUM
{
    TEST_ERR_NONE = 0, //空闲
    TEST_ERR_MotorPort1 = 1, //电机串口异常
    TEST_ERR_ScanPort2 = 2, //扫码枪串口异常
    TEST_ERR_RelayPort3 = 3,//继电器串口异常
    TEST_ERR_NOACK = 4, //通信应答超时
    TEST_ERR_EXIT = 5,//主电机退出测试模式
    TEST_ERR_NODEV = 6,//没用找到仪器
    TEST_ERR_V = 11, //电压错误
    TEST_ERR_T = 12, //温度错误
    TEST_ERR_WIRUART = 13,//无线串口错误
    TEST_ERR_IDCHECK = 14,//无线ID检测错误(存在ID)
    TEST_ERR_OPEN = 15,//主电机开动作异常
    TEST_ERR_I = 16,//主电机开动作电流异常
    TEST_ERR_R = 17,//主电机开动作转速异常
    TEST_ERR_CLOSE = 18,//主电机闭动作异常
    TEST_ERR_CI = 19,//主电机闭动作电流异常
    TEST_ERR_CR = 20,//主电机闭动作转速异常
    TEST_ERR_STOP = 21,//主电机停止异常
    TEST_ERR_BUREAK = 22,//施工中刹车测试异常
    TEST_ERR_ACBREAK = 23,//动作中刹车测试异常
};

namespace Motor_AutoTest
{
    public partial class Form1 : Form
    {
        int flag_MaulOrAuto = 0;
        int flag_Time_Done = 0;
        int flag_rx_done = 0;
        int curr_cnt = 0;
        public int send_cnt = 0;
        public int bubreak_cnt = 0;
        public int flag_updown = 0;
        public bool FlagAuto_En = true;
        public int flag_autotest = 0;
        public int Test_Num = 0;
        public int flag_temp = 1;
        public int Set_TempVal = 27;
        public int Test_OK_Num = 0;
        public int Test_NG_Num = 0;
        public int Test_ALL_Num = 0;
        public UART_TEST_ENUM auto_step = UART_TEST_ENUM.UART_TEST_VER;
        public TEST_ERROR_ENUM flag_err = TEST_ERROR_ENUM.TEST_ERR_NONE;
        int rx_offset = 0;
        int data_len = 0;
        Color BackClolor_ON = Color.LightSteelBlue;
        Color BackClolor_OFF = Color.Gainsboro;
        
        public static Form1 pform1;//定义静态变量pform1，为了方便在类中调用窗体的控件和方法。
        Motor_serialPort1 motor_serport1 = new Motor_serialPort1();
        Scan_serialPort2 scan_serport2 = new Scan_serialPort2();
        Relay_serialPort3 relay_serport3 = new Relay_serialPort3();
        AuxMotor_serialPort4 auxmotor_serport4 = new AuxMotor_serialPort4();
        CVisaOpt_Option cvisa_opt = new CVisaOpt_Option();
        Source_stu source_opt_stu = new Source_stu();
        ModbusCRC16 CRC16 = new ModbusCRC16();
        public Form1()
        {
            InitializeComponent();
            pform1 = this;//将窗体赋给静态变量pform1。
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //DP_DataRecord.AppendText(DateTime.Now.ToString() + " 设置环境温度：27℃\r\n");
            motor_serport1.Motor_SerPort1Init();
            scan_serport2.Scan_SerPort2Init();
            relay_serport3.Relay_SerPort3Init();
            auxmotor_serport4.AuxMotor_SerPort4Init();
            DP_Temp.Text = Set_TempVal.ToString();
            DP_T_Range.Text = (Set_TempVal - 5).ToString() + "~" + (Set_TempVal + 3).ToString();
            if (FlagAuto_En == true) Display_BackColor("BUTTON", "OFF", 0);
            else Display_BackColor("BUTTON", "ON", 0);

            string[] serPort = SerialPort.GetPortNames();   //获取可用端口号
            if (serPort.Length > 0)  //至少有一个端口
            {
                DP_Uart1_comboBox1.Items.Clear();    //清空comboBox1中的内容
                DP_Uart2_comboBox2.Items.Clear();    //清空comboBox2中的内容
                DP_Uart3_comboBox3.Items.Clear();   
                DP_Uart4_comboBox4.Items.Clear();   
                for (int i = 0; i < serPort.Length; i++)
                {
                    DP_Uart1_comboBox1.Items.Add(serPort[i]);
                    DP_Uart2_comboBox2.Items.Add(serPort[i]);
                    DP_Uart3_comboBox3.Items.Add(serPort[i]);
                    DP_Uart4_comboBox4.Items.Add(serPort[i]);
                }
                DP_Uart1_comboBox1.Text = serPort[0];
                DP_Uart2_comboBox2.Text = serPort[0];
                DP_Uart3_comboBox3.Text = serPort[0];
                DP_Uart4_comboBox4.Text = serPort[0];
            }
            
            source_opt_stu = cvisa_opt.SourceOpt_Init("DP8");
            if (source_opt_stu.err == 0)
            {
                DP_DataRecord.AppendText(DateTime.Now.ToString() + " 成功连接直流电源：\r\n");
                DP_DataRecord.AppendText(source_opt_stu.source_name + "\r\n");
                cvisa_opt.Opt_Set("DP8", "ON");
            }
            else 
            {
                flag_err = TEST_ERROR_ENUM.TEST_ERR_NODEV;
                DP_DataRecord.AppendText(DateTime.Now.ToString() + " 错误：没有找到直流电源仪器！\r\n");
                Display_BackColor("DATARE", "NG", 0);
            }
        }
        public void Check_Com_Click(object sender, EventArgs e)
        {
            string[] myselPort = SerialPort.GetPortNames();   //获取可用端口号

            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Close();
                }
                catch { }
            }
            DP_Uart_OpenClose.BackColor = Color.LightSteelBlue;
            DP_Uart_OpenClose.Text = "主电机串口已关闭";
            DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机串口 已关闭\r\n");
            DP_Uart1_comboBox1.Enabled = true;

            if (serialPort2.IsOpen)
            {
                try
                {
                    serialPort2.Close();
                }
                catch { }
            }
            DP_Uart_ScanCode.BackColor = Color.LightSteelBlue;
            DP_Uart_ScanCode.Text = "扫码枪串口已关闭";
            DP_DataRecord.AppendText(DateTime.Now.ToString() + " 扫码枪串口 已关闭\r\n");
            DP_Uart2_comboBox2.Enabled = true;

            if (serialPort3.IsOpen)
            {
                try
                {
                    serialPort3.Close();
                }
                catch { }
            }
            DP_Uart_Relay.BackColor = Color.LightSteelBlue;
            DP_Uart_Relay.Text = "继电器串口已关闭";
            DP_DataRecord.AppendText(DateTime.Now.ToString() + " 继电器串口 已关闭\r\n");
            DP_Uart3_comboBox3.Enabled = true;
            /*
            if (serialPort4.IsOpen)
            {
                try
                {
                    serialPort4.Close();
                }
                catch { }
            }
            DP_Uart_AuxMotor.BackColor = Color.LightSteelBlue;
            DP_Uart_AuxMotor.Text = "副电机串口已关闭";
            DP_DataRecord.AppendText(DateTime.Now.ToString() + " 副电机串口 已关闭\r\n");
            DP_Uart4_comboBox4.Enabled = true;
            */
            if (myselPort.Length > 0)  //至少有一个端口
            {
                DP_Uart1_comboBox1.Items.Clear();    //清空comboBox1中的内容
                DP_Uart2_comboBox2.Items.Clear();    //清空comboBox2中的内容
                DP_Uart3_comboBox3.Items.Clear();    //清空comboBox3中的内容
                //DP_Uart4_comboBox4.Items.Clear();    //清空comboBox4中的内容
                for (int i = 0; i < myselPort.Length; i++)
                {
                    DP_Uart1_comboBox1.Items.Add(myselPort[i]);
                    DP_Uart2_comboBox2.Items.Add(myselPort[i]);
                    DP_Uart3_comboBox3.Items.Add(myselPort[i]);
                    DP_Uart4_comboBox4.Items.Add(myselPort[i]);
                }
                DP_Uart1_comboBox1.Text = myselPort[0];
                DP_Uart2_comboBox2.Text = myselPort[0];
                DP_Uart3_comboBox3.Text = myselPort[0];
                DP_Uart4_comboBox4.Text = myselPort[0];
                DP_DataRecord.AppendText(DateTime.Now.ToString() + " 检查端口完成\r\n");
                //MessageBox.Show("检查端口完成！");
            }
            else
            {
                DP_Uart1_comboBox1.Text = "";
                DP_Uart1_comboBox1.Items.Clear();    //清空comboBox1中的内容
                DP_Uart2_comboBox2.Text = "";
                DP_Uart2_comboBox2.Items.Clear();    //清空comboBox2中的内容
                DP_Uart3_comboBox3.Text = "";
                DP_Uart3_comboBox3.Items.Clear();    //清空comboBox3中的内容
                DP_Uart4_comboBox4.Text = "";
                DP_Uart4_comboBox4.Items.Clear();    //清空comboBox4中的内容
                DP_DataRecord.AppendText(DateTime.Now.ToString() + " 没有找到端口!\r\n");
                //MessageBox.Show("没有找到端口！");
            }
        }
        private void DP_Uart_OpenClose_Click(object sender, EventArgs e)
        {
            motor_serport1.Motor_Port1Click();
        }
        private void DP_Uart_ScanCode_Click(object sender, EventArgs e)
        {
            scan_serport2.Scan_Port2Click();
        }
        private void Check_Temp_Click(object sender, EventArgs e)
        {
            int temp_v = 0;
            bool fb = int.TryParse(DP_Temp.Text, out temp_v); //将指定的字符串转换为等效的有符号整数表示并返回true。如果转换成功, true；否则，false
            //int temp_v = Convert.ToInt32(DP_Temp.Text);//strAsciiToDecNum(0,DP_Temp.TextLength,DP_Temp.Text);
            if (Check_Temp.Text == "确定")
            {
                if (temp_v < 5 || temp_v > 51)
                {
                    flag_temp = 0;
                    Set_TempVal = 0;
                    DP_Temp.Text = "0";
                    Check_Temp.BackColor = Color.LightSteelBlue;
                    DP_DataRecord.AppendText(DateTime.Now.ToString() + " 出错，环境温度设置失败，请输入5 ~ 50的整数！\r\n");
                    MessageBox.Show("出错，环境温度设置失败，请输入5 ~ 50的整数！");
                }
                else
                {
                    Set_TempVal = temp_v;
                    DP_T_Range.Text = (Set_TempVal - 5).ToString() + "~" + (Set_TempVal + 3).ToString();
                    flag_temp = 1;
                    DP_Temp.Enabled = false;
                    Check_Temp.Text = "取消";
                    DP_Temp.Text = temp_v.ToString();
                    DP_DataRecord.AppendText(DateTime.Now.ToString() + " 设定环境温度：" + temp_v.ToString() + "℃\r\n");
                    Check_Temp.BackColor = Color.LightGreen;
                }
            }
            else
            {
                DP_Temp.Enabled = true;
                Check_Temp.Text = "确定";
                Set_TempVal = 0;
                flag_temp = 0;
                Check_Temp.BackColor = Color.LightSteelBlue;
                DP_DataRecord.AppendText(DateTime.Now.ToString() + " 取消设定环境温度：" + temp_v.ToString() + "℃\r\n");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            flag_err = TEST_ERROR_ENUM.TEST_ERR_NOACK;
            DP_DataRecord.AppendText(DateTime.Now.ToString() + " 应答超时！\r\n");
            EnDis_Timer1(false);
            rx_offset = 0;
            if (FlagAuto_En == true && flag_autotest == 1) AutoTest_Stop();
            //DP_AutoTest_OKNG(false);
        }
        public void EnDis_Timer1(bool endis)
        {
            if (endis == true)
            {
                if (timer1.Enabled != true)
                {
                    timer1.Enabled = true;
                }
                timer1.Interval = 200;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void OutPut_Data_Click(object sender, EventArgs e)
        {
            Data_Save();
        }
        public void Data_Save()
        {
            if (flag_err == 0)
            {
                Save_Data("OK");
            }
            else
            {
                Save_Data("NG");
            }
        }
        private void Save_Data(string OK_NG)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.Filter = "Excel files (*.csv)|*.csv";
            saveFile1.FilterIndex = 1;
            saveFile1.RestoreDirectory = true; //保存对话框是否记忆上次打开的目录
            //saveFile1.Title = "保存为csv文件";
            //DP_ScanCode.Text = "C2023007";
            saveFile1.FileName = "OK05-1 电机测试 " + DP_ScanCode.Text + " " + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"); //年月日时分秒
            saveFile1.InitialDirectory = Application.StartupPath + "\\OK05-1 Motor TestData\\" + OK_NG; //保存至目录文件夹
            timer3.Enabled = true;
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFile1.FileName, false, System.Text.Encoding.GetEncoding(-0));
                try
                {
                    DP_DataRecord.AppendText(DateTime.Now.ToString() + " 记录已保存到 " + saveFile1.FileName + "\r\n");
                    sw.WriteLine(DP_DataRecord.Text); //要输出的内容
                    //MessageBox.Show("记录已保存到 " + saveFile1.FileName);
                    timer3.Enabled = false;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    sw.Close();
                }
            }
        }
        private void Clear_Data_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult;//设置对话框的返回值
            if (DP_DataRecord.Text != "")   //不为空就提示
            {
                MsgBoxResult = System.Windows.Forms.MessageBox.Show("是否清除数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                if (MsgBoxResult.ToString() == "Yes")//如果对话框的返回值是YES（按"Y"按钮）
                {
                    //选择了Yes，继续
                    DP_DataRecord.Text = "";    //清空文本
                    Display_BackColor("ALL","0",0);
                }
                if (MsgBoxResult.ToString() == "No")//如果对话框的返回值是NO（按"N"按钮）
                {
                    //选择了No，继续
                }
            }
        }
        private void DP_Uart_Relay_Click(object sender, EventArgs e)
        {
            relay_serport3.Relay_Port3Click();
        }

        private void Get_V_Click(object sender, EventArgs e)
        {
            motor_serport1.MotorSend_GetV();
        }

        private void Get_T_Click(object sender, EventArgs e)
        {
            motor_serport1.MotorSend_GetT();
        }
        public void AutoTest_Cmd(UART_TEST_ENUM cmd)
        {
            switch (cmd)
            {
                case UART_TEST_ENUM.UART_TEST_CURR:
                    motor_serport1.MotorSend_GetI();
                    break;

                case UART_TEST_ENUM.UART_TEST_VER:
                    motor_serport1.MotorSend_GetV();
                    break;

                case UART_TEST_ENUM.UART_TEST_TEMP:
                    motor_serport1.MotorSend_GetT();
                    break;

                case UART_TEST_ENUM.UART_TEST_RPM:
                    motor_serport1.MotorSend_GetR();
                    break;

                case UART_TEST_ENUM.UART_TEST_CURR_RPM:
                    motor_serport1.MotorSend_GetI_R();
                    break;

                case UART_TEST_ENUM.UART_TEST_ENCODER:
                    //DP_N_OKNG.Text = "NG";
                    DP_DataRecord.AppendText(DateTime.Now.ToString() + " 查看位置\r\n");
                    string estr = "(TE)";
                    byte[] edata = System.Text.Encoding.Default.GetBytes(estr);
                    motor_serport1.Motor_SerPort1_tx_data(edata, edata.Length);
                    break;

                case UART_TEST_ENUM.UART_TEST_WIRELESS_ID:
                    motor_serport1.MotorSend_GetWID();
                    break;

                case UART_TEST_ENUM.UART_TEST_OPEN:
                    AutoTest_StepPause();
                    motor_serport1.rpm_rxnum = 0;
                    motor_serport1.curr_rxnum = 0;
                    LoadCurrent_UP();
                    relay_serport3.WaitTime(1000);
                    relay_serport3.MainMotor_TestOpen();
                    Motor_TestCheck(6,500);
                    break;

                case UART_TEST_ENUM.UART_TEST_STOP:
                    motor_serport1.rpm_rxnum = 0;
                    motor_serport1.curr_rxnum = 0;
                    relay_serport3.WaitTime(100);
                    relay_serport3.MainMotor_TestStop();
                    relay_serport3.WaitTime(100);
                    motor_serport1.MotorSend_GetStop();
                    //AutoTest_Stop();
                    break;

                case UART_TEST_ENUM.UART_TEST_CLOSE:
                    AutoTest_StepPause();
                    motor_serport1.rpm_rxnum = 0;
                    motor_serport1.curr_rxnum = 0;                    
                    LoadCurrent_UP();
                    relay_serport3.WaitTime(1000);
                    relay_serport3.MainMotor_TestClose();
                    Motor_TestCheck(6,500);
                    break;

                case UART_TEST_ENUM.UART_TEST_BUBREAK:
                    motor_serport1.MotorSend_BuBreak();
                    relay_serport3.WaitTime(100);
                    relay_serport3.AuxMotor_TestOpen();
                    motor_serport1.encod_rxnum = 0;
                    bubreak_cnt = 6;
                    Motor_TestCheck(bubreak_cnt,500);
                    break;
                default:
                    timer2.Enabled = false;
                    break;
            }
        }
        public void AutoTest_StepPause()
        {
            timer2.Enabled = false;
        }
        public void AutoTest_StepContinue(int time)
        {
            timer2.Interval = time;
            timer2.Enabled = true;
        }
        public void AutoTest_Start()
        {
            timer2.Enabled = true;
            auto_step = UART_TEST_ENUM.UART_TEST_VER;
            DP_DataRecord.AppendText(DateTime.Now.ToString() + " 自动测试开始！\r\n");
        }
        public void Form1WaitTime(uint ms)
        {
            relay_serport3.WaitTime(ms);
        }
        public void AutoTest_Stop()
        {
            timer2.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            if ((auto_step == UART_TEST_ENUM.UART_TEST_OPEN) || (auto_step == UART_TEST_ENUM.UART_TEST_CLOSE))
            {
                relay_serport3.MainMotor_TestStop();
            }
            if (auto_step == UART_TEST_ENUM.UART_TEST_BUBREAK)
            {
                relay_serport3.AuxMotor_TestStop();
                relay_serport3.WaitTime(50);
                relay_serport3.MainMotor_WorkMode();
            }
            //relay_serport3.Release_PowerOFF(); //测试结束不关电
            Test_ALL_Num++;
            DP_TestNum.Text = Test_ALL_Num.ToString();
            if (flag_err == 0)
            {
                Test_OK_Num++;
                DP_TEST_OK.Text = "OK:" + Test_OK_Num.ToString();
                DP_DataRecord.AppendText(DateTime.Now.ToString() + " 第：" + Test_ALL_Num.ToString() + "台测试结果OK\r\n");
                Display_BackColor("DATARE", "OK", 0);
                auto_step = UART_TEST_ENUM.UART_TEST_READReX2;
                Motor_TestCheck(2750, 100);//约五分钟
            }
            else
            {
                auto_step = UART_TEST_ENUM.UART_TEST_OVER;
                Test_NG_Num++;
                DP_TEST_NG.Text = "NG:" + Test_NG_Num.ToString();
                DP_DataRecord.AppendText(DateTime.Now.ToString() + " 第：" + Test_ALL_Num.ToString() + "台测试结果NG!\r\n");
                Display_BackColor("DATARE", "NG", 0);
                if(flag_err == TEST_ERROR_ENUM.TEST_ERR_MotorPort1 || flag_err == TEST_ERROR_ENUM.TEST_ERR_ScanPort2 || flag_err == TEST_ERROR_ENUM.TEST_ERR_RelayPort3 || flag_err == TEST_ERROR_ENUM.TEST_ERR_NOACK){}
                else relay_serport3.Power_ONOFF(false);
            }
            //LoadCurrent_DOWN();
            DP_DataRecord.AppendText(DateTime.Now.ToString() + " 自动测试结束！\r\n");
            if (flag_err == TEST_ERROR_ENUM.TEST_ERR_MotorPort1 || flag_err == TEST_ERROR_ENUM.TEST_ERR_ScanPort2 || flag_err == TEST_ERROR_ENUM.TEST_ERR_RelayPort3 || flag_err == TEST_ERROR_ENUM.TEST_ERR_NOACK) { }
            else Data_Save();
            flag_autotest = 0;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("{Enter}"); //输出Enter(回车键),不用手动按键盘回车保存文件。
            timer3.Enabled = false;
        }
        public void DP8_OFF()
        {
            cvisa_opt.Opt_Set("DP8", "OFF");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DP_DataRecord.TextLength != 0)
            {
                DialogResult result = MessageBox.Show("请先保存记录，关闭后记录将丢失！\r\n确认关闭吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (serialPort3.IsOpen) relay_serport3.Release_PowerOFF();
                    Form1.pform1.Form1WaitTime(200);
                    Form1.pform1.DP8_OFF();
                }
            }
            else
            {
                if (serialPort3.IsOpen) relay_serport3.Release_PowerOFF();
            }
            LoadCurrent_DOWN();

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            AutoTest_Cmd(auto_step);
        }
        private void timer4_Tick(object sender, EventArgs e)
        {/*
            if (curr_cnt == 0) flag_updown = 1;
            if (curr_cnt == 6) flag_updown = 0;
            if (curr_cnt < 6 && flag_updown == 1) curr_cnt++;
            else curr_cnt--;
            if (curr_cnt < 0) curr_cnt = 0;
            
            if (flag_updown == 1) cvisa_opt.Opt_Set("DP8", "UP");
            else cvisa_opt.Opt_Set("DP8", "DOWN");
            if (curr_cnt == 6) timer4.Interval = 5000;
            else if (curr_cnt == 0) timer4.Enabled = false;
            else timer4.Interval = 100;*/
            if (curr_cnt != 0)
            {
                if (flag_updown == 1) cvisa_opt.Opt_Set("DP8", "UP");
                else cvisa_opt.Opt_Set("DP8", "DOWN");
                curr_cnt--;
            }
            else timer4.Enabled = false;

        }
        private void Power_ON_Click(object sender, EventArgs e)
        {
            relay_serport3.Power_ON();
        }
        private void Get_I_Click(object sender, EventArgs e)
        {
            //motor_serport1.MotorSend_GetI();
            auto_step = UART_TEST_ENUM.UART_TEST_OPEN;
            motor_serport1.MotorSend_GetI_R();
        }

        private void Get_R_Click(object sender, EventArgs e)
        {
            //motor_serport1.MotorSend_GetR();
            auto_step = UART_TEST_ENUM.UART_TEST_OPEN;
            motor_serport1.MotorSend_GetI_R();
        }

        private void Get_Open_Click(object sender, EventArgs e)
        {
            auto_step = UART_TEST_ENUM.UART_TEST_OPEN;
            motor_serport1.rpm_rxnum = 0;
            motor_serport1.curr_rxnum = 0;
            //LoadCurrent_UP();
            relay_serport3.MainMotor_TestOpen();
            //motor_serport1.MotorSend_Open();
        }

        private void Get_Stop_Click(object sender, EventArgs e)
        {
            auto_step = UART_TEST_ENUM.UART_TEST_STOP;
            relay_serport3.MainMotor_TestStop();
            relay_serport3.WaitTime(150);
            motor_serport1.MotorSend_GetI_R();
            relay_serport3.AuxMotor_TestStop();
            //motor_serport1.MotorSend_Stop();
        }
        private void Get_Close_Click(object sender, EventArgs e)
        {
            auto_step = UART_TEST_ENUM.UART_TEST_CLOSE;
            motor_serport1.curr_rxnum = 0;
            motor_serport1.rpm_rxnum = 0;
            //LoadCurrent_UP();
            relay_serport3.MainMotor_TestClose();
            //motor_serport1.MotorSend_Close();
        }
        private void TestMode_Set_Click(object sender, EventArgs e)
        {
            //relay_serport3.MainMotor_TestMode();
            AutoTest_Init();
        }
        public void AutoTest_Init()
        {
            send_cnt = 0;
            timer2.Enabled = false;
            timer5.Enabled = false;
            timer4.Enabled = false;
            if(FlagAuto_En == true) flag_autotest = 1;
            if (auto_step == UART_TEST_ENUM.UART_TEST_READReX2)
            {
                relay_serport3.Power_ONOFF(false);
                relay_serport3.WaitTime(3000);
            }
            Display_BackColor("ALL", "0", 0);
            if (flag_temp == 0)
            {
                timer2.Enabled = false;
                Form1.pform1.flag_err = TEST_ERROR_ENUM.TEST_ERR_T;
                DP_T_OKNG.Text = "NG";
                DP_T.BackColor = Color.Red;
                DP_T_OKNG.BackColor = Color.Red;
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 出错，未设定环境温度，请设定环境温度之后再进行测试！\r\n");
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 测试结束！\r\n");
                Display_BackColor("DATARE", "NG", 0);
            }
            else
            {
                flag_err = 0;
                source_opt_stu = cvisa_opt.SourceOpt_Init("DP8");
                if (source_opt_stu.err == 0)
                {
                    DP_DataRecord.AppendText(DateTime.Now.ToString() + " 成功连接直流电源：\r\n");
                    DP_DataRecord.AppendText(source_opt_stu.source_name + "\r\n");
                    cvisa_opt.Opt_Set("DP8", "ON");
                    relay_serport3.WaitTime(200);
                }
                else
                {
                    flag_err = TEST_ERROR_ENUM.TEST_ERR_NODEV;
                    DP_DataRecord.AppendText(DateTime.Now.ToString() + " 错误：没有找到直流电源仪器！\r\n");
                    Display_BackColor("DATARE", "NG", 0);
                }
                DP_DataRecord.AppendText(DateTime.Now.ToString() + " 设置环境温度：" + Set_TempVal.ToString() + "℃\r\n");
                //if (flag_err == 0) relay_serport3.Power_ONOFF(false);
                //relay_serport3.WaitTime(1000);
                if (flag_err == 0) relay_serport3.MainMotor_TestMode();
                relay_serport3.WaitTime(100);
                if (flag_err == 0) relay_serport3.Power_ONOFF(true);
                relay_serport3.WaitTime(2000);
                if (flag_err == 0) scan_serport2.Send_TestMode();
            }
        }
        private void LodaCurrent_Up_Click(object sender, EventArgs e)
        {
            curr_cnt = 0;
            //timer4.Enabled = true;
            DP_DataRecord.AppendText(DateTime.Now.ToString() + " 负载电流增大\r\n");
            //relay_serport3.AuxMotor_TestOpen();
            cvisa_opt.Opt_Set("DP8", "UP");
            //LoadCurrent_UP();
        }
        private void LodaCurrent_Down_Click(object sender, EventArgs e)
        {
            curr_cnt = 6;
            DP_DataRecord.AppendText(DateTime.Now.ToString() + " 负载电流减小\r\n");
            cvisa_opt.Opt_Set("DP8", "DOWN");
            //LoadCurrent_DOWN();
        }

        private void DP_Uart_AuxMotor_Click(object sender, EventArgs e)
        {
            auxmotor_serport4.AuxMotor_Port4Click();
        }
        public void LoadCurrent_AutoON()
        {
            DP_DataRecord.AppendText(DateTime.Now.ToString() + " 打开负载\r\n");
            timer4.Enabled = true;
            curr_cnt = 0;
            flag_updown = 2;
        }
        public void LoadCurrent_UP()
        {
            if (flag_updown == 0)
            {
                timer4.Enabled = true;
                flag_updown = 1;
                curr_cnt = 6;
                timer4.Interval = 100;
            }
        }
        public void LoadCurrent_DOWN()
        {
            if (flag_updown == 1)
            {
                timer4.Enabled = true;
                flag_updown = 0;
                curr_cnt = 6;
                timer4.Interval = 100;
            }
        }
        private void Get_CI_Click(object sender, EventArgs e)
        {
            //motor_serport1.MotorSend_GetCI();
            auto_step = UART_TEST_ENUM.UART_TEST_CLOSE;
            motor_serport1.MotorSend_GetCI_CR();
        }

        private void Get_CR_Click(object sender, EventArgs e)
        {
            //motor_serport1.MotorSend_GetCR();
            auto_step = UART_TEST_ENUM.UART_TEST_CLOSE;
            motor_serport1.MotorSend_GetCI_CR();
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (send_cnt > 0) send_cnt--;
            if (auto_step == UART_TEST_ENUM.UART_TEST_OPEN) motor_serport1.MotorSend_GetI_R();
            else if (auto_step == UART_TEST_ENUM.UART_TEST_CLOSE) motor_serport1.MotorSend_GetCI_CR();
            else if (auto_step == UART_TEST_ENUM.UART_TEST_ACBREAK_ON) relay_serport3.Read_ActionBreak();
            else if (auto_step == UART_TEST_ENUM.UART_TEST_BUBREAK || auto_step == UART_TEST_ENUM.UART_TEST_ENCODER) motor_serport1.MotorSend_GetEncod();
            else if (auto_step == UART_TEST_ENUM.UART_TEST_DP8OFF) cvisa_opt.Opt_Set("DP8", "OFF");
            else if (auto_step == UART_TEST_ENUM.UART_TEST_READReX2) relay_serport3.Read_ReX2();
            else if (auto_step == UART_TEST_ENUM.UART_TEST_POWEROFF) relay_serport3.Power_ONOFF(false);

            if (auto_step == UART_TEST_ENUM.UART_TEST_READReX2 && send_cnt == 0)
            {
                auto_step = UART_TEST_ENUM.UART_TEST_POWEROFF;
                relay_serport3.Power_ONOFF(false);
            }

            if (send_cnt <= 0)
            {
                send_cnt = 0;
                timer5.Enabled = false;
            }
        }
        public void Motor_TestCheck(int num,int time)
        {
            send_cnt = num;
            timer5.Interval = time;
            timer5.Enabled = true;
        }
        private void Get_AcBreak_Click(object sender, EventArgs e)
        {
            //auto_step = UART_TEST_ENUM.UART_TEST_ACBREAK_ON;
            //relay_serport3.MainMotor_TestClose();
            //relay_serport3.WaitTime(1000);
            relay_serport3.acbreak_num = 0;
            relay_serport3.acok_num = 0;
            //relay_serport3.AuxMotor_TestOpen();
            //relay_serport3.WaitTime(1000);
            Motor_TestCheck(5,500);
            //motor_serport1.MotorSend_AcBreak_ON();
            //motor_serport1.MotorSend_GetEncod();
        }
        private void Get_BuBreak_Click(object sender, EventArgs e)
        {
            //auto_step = UART_TEST_ENUM.UART_TEST_BUBREAK;
            auto_step = UART_TEST_ENUM.UART_TEST_ENCODER;
            Display_BackColor("B","0",0);
            //relay_serport3.Read_ActionBreak();
            //motor_serport1.MotorSend_AcBreak_OFF();
            motor_serport1.MotorSend_BuBreak();
            relay_serport3.AuxMotor_TestOpen();
            motor_serport1.encod_rxnum = 0;
            bubreak_cnt = 6;
            Motor_TestCheck(bubreak_cnt,500); 
        }
        private void Get_IDCheck_Click(object sender, EventArgs e)
        {
            auto_step = UART_TEST_ENUM.UART_TEST_WIRELESS_ID;
            motor_serport1.MotorSend_GetWID();
        }
        public void Display_BackColor(string type, string okng,int value)
        { 
            switch (type)
            {
                case "OPEN":
                    if (okng == "OK")
                    {
                        DP_Open_OKNG.Text = "OK";
                        DP_Open_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<开>动作：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_OPEN;
                        DP_Open_OKNG.Text = "NG";
                        DP_Open_OKNG.BackColor = Color.Red;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<开>动作：NG\r\n");
                    }
                    else 
                    {
                        DP_Open_OKNG.Text = "";
                        DP_Open_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "CLOSE":
                    if (okng == "OK")
                    {
                        DP_Close_OKNG.Text = "OK";
                        DP_Close_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<闭>动作：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_CLOSE;
                        DP_Close_OKNG.Text = "NG";
                        DP_Close_OKNG.BackColor = Color.Red;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<闭>动作：NG\r\n");
                    }
                    else 
                    {
                        DP_Close_OKNG.Text = "";
                        DP_Close_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "STOP":
                    if (okng == "OK")
                    {
                        DP_Stop_OKNG.Text = "OK";
                        DP_Stop_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<停止>：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_STOP;
                        DP_Stop_OKNG.Text = "NG";
                        DP_Stop_OKNG.BackColor = Color.Red;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<停止>：NG\r\n");
                    }
                    else
                    {
                        DP_Stop_OKNG.Text = "";
                        DP_Stop_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "V":
                    if (okng == "OK")
                    {
                        DP_V_OKNG.Text = "OK";
                        DP_V.BackColor = Color.LightGreen;
                        DP_V_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<电压>检查：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_V;
                        DP_V_OKNG.Text = "NG";
                        DP_V.BackColor = Color.Red;
                        DP_V_OKNG.BackColor = Color.Red;
                        if (value < 95) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<电压>检查：NG，低于最小值\r\n");
                        else if (value >= 105) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<电压>检查：NG，超过最大值\r\n");
                    }
                    else
                    {
                        DP_V_OKNG.Text = "";
                        DP_V.Text = "";
                        DP_V.BackColor = Color.WhiteSmoke;
                        DP_V_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "T"://温度
                    if (okng == "OK")
                    {
                        DP_T_OKNG.Text = "OK";
                        DP_T.BackColor = Color.LightGreen;
                        DP_T_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<温度>检查：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_T;
                        DP_T_OKNG.Text = "NG";
                        DP_T.BackColor = Color.Red;
                        DP_T_OKNG.BackColor = Color.Red;
                        if (value < Set_TempVal - 5) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<温度>检查：NG，低于最小值\r\n");
                        else if (value >= Set_TempVal + 3) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<温度>检查：NG，超过最大值\r\n");
                    }
                    else
                    {
                        DP_T_OKNG.Text = "";
                        DP_T.Text = "";
                        DP_T.BackColor = Color.WhiteSmoke;
                        DP_T_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "I"://电流
                    if (okng == "OK")
                    {
                        DP_I_OKNG.Text = "OK";
                        DP_I.BackColor = Color.LightGreen;
                        DP_I_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<开动作电流>检查：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_I;
                        DP_I_OKNG.Text = "NG";
                        DP_I.BackColor = Color.Red;
                        DP_I_OKNG.BackColor = Color.Red;
                        if (value < 43) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<开动作电流>检查：NG，低于最小值\r\n");
                        else if (value > 53) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<开动作电流>检查：NG，超过最大值\r\n");
                    }
                    else
                    {
                        DP_I_OKNG.Text = "";
                        DP_I.Text = "";
                        DP_I.BackColor = Color.WhiteSmoke;
                        DP_I_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "CI":
                    if (okng == "OK")
                    {
                        DP_CI_OKNG.Text = "OK";
                        DP_CI.BackColor = Color.LightGreen;
                        DP_CI_OKNG.BackColor = Color.LightGreen;
                        Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<闭动作电流>检查：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_CI;
                        DP_CI_OKNG.Text = "NG";
                        DP_CI.BackColor = Color.Red;
                        DP_CI_OKNG.BackColor = Color.Red;
                        if (value < 43) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<闭动作电流>检查：NG，低于最小值\r\n");
                        else if (value > 53) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<闭动作电流>检查：NG，超过最大值\r\n");
                    }
                    else
                    {
                        DP_CI_OKNG.Text = "";
                        DP_CI.Text = "";
                        DP_CI.BackColor = Color.WhiteSmoke;
                        DP_CI_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "R":
                    if (okng == "OK")
                    {
                        DP_R_OKNG.Text = "OK";
                        DP_R.BackColor = Color.LightGreen;
                        DP_R_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<开动作转速>检查：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_R;
                        DP_R_OKNG.Text = "NG";
                        DP_R.BackColor = Color.Red;
                        DP_R_OKNG.BackColor = Color.Red;
                        if (value < 1149) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<开动作转速>检查：NG，低于最小值\r\n");
                        else if (value > 1189) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<开动作转速>检查：NG，超过最大值\r\n");
                    }
                    else
                    {
                        DP_R_OKNG.Text = "";
                        DP_R.Text = "";
                        DP_R.BackColor = Color.WhiteSmoke;
                        DP_R_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "CR":
                    if (okng == "OK")
                    {
                        DP_CR_OKNG.Text = "OK";
                        DP_CR.BackColor = Color.LightGreen;
                        DP_CR_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<闭动作转速>检查：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_CR;
                        DP_CR_OKNG.Text = "NG";
                        DP_CR.BackColor = Color.Red;
                        DP_CR_OKNG.BackColor = Color.Red;
                        if (value < 1149) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<闭动作转速>检查：NG，低于最小值\r\n");
                        else if (value > 1189) DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机<闭动作转速>检查：NG，超过最大值\r\n");
                    }
                    else
                    {
                        DP_CR_OKNG.Text = "";
                        DP_CR.Text = "";
                        DP_CR.BackColor = Color.WhiteSmoke;
                        DP_CR_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "A":
                    if (okng == "OK")
                    {
                        DP_AcBreak_OKNG.Text = "OK";
                        DP_AcBreak_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " <动作中刹车>测试：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_ACBREAK;
                        DP_AcBreak_OKNG.Text = "NG";
                        DP_AcBreak_OKNG.BackColor = Color.Red;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " <动作中刹车>测试：NG\r\n");
                    }
                    else
                    {
                        DP_AcBreak_OKNG.Text = "";
                        DP_AcBreak_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "B":
                    if (okng == "OK")
                    {
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " <施工刹车>测试：OK\r\n");
                        DP_BuBreak_OKNG.Text = "OK";
                        DP_BuBreak_OKNG.BackColor = Color.LightGreen;
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_BUREAK;
                        DP_BuBreak_OKNG.Text = "NG";
                        DP_BuBreak_OKNG.BackColor = Color.Red;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " <施工刹车>测试：NG!\r\n");
                    }
                    else
                    {
                        DP_BuBreak_OKNG.Text = "";
                        DP_BuBreak_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "W":
                    if (okng == "OK")
                    {
                        DP_WirUart_OKNG.Text = "OK";
                        DP_WirUart_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " <无线串口>检查：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_WIRUART;
                        DP_WirUart_OKNG.Text = "NG";
                        DP_WirUart_OKNG.BackColor = Color.Red;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " <无线串口>检查：NG!\r\n");
                    }
                    else
                    {
                        DP_WirUart_OKNG.Text = "";
                        DP_WirUart_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "WID":
                    if (okng == "OK")
                    {
                        DP_WirUart_OKNG.Text = "OK";
                        DP_WirUart_OKNG.BackColor = Color.LightGreen;
                        DP_IDCheck_OKNG.Text = "OK";
                        DP_IDCheck_OKNG.BackColor = Color.LightGreen;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " <无线串口>检查：OK\r\n");
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " <无线ID>检查：OK\r\n");
                    }
                    else if (okng == "NG")
                    {
                        DP_WirUart_OKNG.Text = "OK";
                        DP_WirUart_OKNG.BackColor = Color.LightGreen;
                        DP_IDCheck_OKNG.Text = "NG";
                        DP_IDCheck_OKNG.BackColor = Color.Red;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " <无线串口>检查：OK\r\n");
                        flag_err = TEST_ERROR_ENUM.TEST_ERR_IDCHECK;
                        DP_DataRecord.AppendText(DateTime.Now.ToString() + " <无线ID>检查：NG! 里面存在ID\r\n");
                    }
                    else
                    {
                        DP_WirUart_OKNG.Text = "";
                        DP_WirUart_OKNG.BackColor = Color.WhiteSmoke;
                        DP_IDCheck_OKNG.Text = "";
                        DP_IDCheck_OKNG.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "DATARE":
                    if (okng == "OK")
                    {
                        DP_TESTOKNG.Text = "OK";
                        DP_TESTOKNG.ForeColor = Color.Black;
                        DP_TESTOKNG.BackColor = Color.SpringGreen;
                        DP_DataRecord.BackColor = Color.LightGreen;
                    }
                    else if (okng == "NG")
                    {
                        DP_TESTOKNG.Text = "NG";
                        DP_TESTOKNG.ForeColor = Color.Black;
                        DP_TESTOKNG.BackColor = Color.Red;
                        DP_DataRecord.BackColor = Color.Red;
                    }
                    else
                    {
                        DP_DataRecord.BackColor = Color.WhiteSmoke;
                    }
                    break;

                case "BUTTON":
                    if (okng == "ON")
                    {
                        Get_V.BackColor = BackClolor_ON;
                        Get_T.BackColor = BackClolor_ON;
                        Get_I.BackColor = BackClolor_ON;
                        Get_CI.BackColor = BackClolor_ON;
                        Get_R.BackColor = BackClolor_ON;
                        Get_CR.BackColor = BackClolor_ON;
                        Get_Open.BackColor = BackClolor_ON;
                        Get_Stop.BackColor = BackClolor_ON;
                        Get_Close.BackColor = BackClolor_ON;
                        Get_WirUart.BackColor = BackClolor_ON;
                        Get_IDCheck.BackColor = BackClolor_ON;
                        Get_AcBreak.BackColor = BackClolor_ON;
                        Get_BuBreak.BackColor = BackClolor_ON;
                        Get_V.Enabled = true;
                        Get_T.Enabled = true;
                        Get_I.Enabled = true;
                        Get_CI.Enabled = true;
                        Get_R.Enabled = true;
                        Get_CR.Enabled = true;
                        Get_Open.Enabled = true;
                        Get_Stop.Enabled = true;
                        Get_Close.Enabled = true;
                        Get_WirUart.Enabled = true;
                        Get_IDCheck.Enabled = true;
                        Get_AcBreak.Enabled = true;
                        Get_BuBreak.Enabled = true;
                    }
                    else if (okng == "OFF")
                    {
                        Get_V.BackColor = BackClolor_OFF;
                        Get_T.BackColor = BackClolor_OFF;
                        Get_I.BackColor = BackClolor_OFF;
                        Get_CI.BackColor = BackClolor_OFF;
                        Get_R.BackColor = BackClolor_OFF;
                        Get_CR.BackColor = BackClolor_OFF;
                        Get_Open.BackColor = BackClolor_OFF;
                        Get_Stop.BackColor = BackClolor_OFF;
                        Get_Close.BackColor = BackClolor_OFF;
                        Get_WirUart.BackColor = BackClolor_OFF;
                        Get_IDCheck.BackColor = BackClolor_OFF;
                        Get_AcBreak.BackColor = BackClolor_OFF;
                        Get_BuBreak.BackColor = BackClolor_OFF;
                    }
                    else
                    {
                        
                    }
                    break;

                case "ALL":
                    DP_TESTOKNG.Text = "";
                    DP_Open_OKNG.Text = "";
                    DP_Open_OKNG.BackColor = Color.WhiteSmoke;
                    DP_Close_OKNG.Text = "";
                    DP_Close_OKNG.BackColor = Color.WhiteSmoke;
                    DP_Stop_OKNG.Text = "";
                    DP_Stop_OKNG.BackColor = Color.WhiteSmoke;
                    DP_AcBreak_OKNG.Text = "";
                    DP_AcBreak_OKNG.BackColor = Color.WhiteSmoke;
                    DP_BuBreak_OKNG.Text = "";
                    DP_BuBreak_OKNG.BackColor = Color.WhiteSmoke;
                    DP_IDCheck_OKNG.Text = "";
                    DP_IDCheck_OKNG.BackColor = Color.WhiteSmoke;
                    DP_WirUart_OKNG.Text = "";
                    DP_WirUart_OKNG.BackColor = Color.WhiteSmoke;
                    DP_V_OKNG.Text = "";
                    DP_V.Text = "";
                    DP_V.BackColor = Color.WhiteSmoke;
                    DP_V_OKNG.BackColor = Color.WhiteSmoke;
                    DP_T_OKNG.Text = "";
                    DP_T.Text = "";
                    DP_T.BackColor = Color.WhiteSmoke;
                    DP_T_OKNG.BackColor = Color.WhiteSmoke;
                    DP_I_OKNG.Text = "";
                    DP_I.Text = "";
                    DP_I.BackColor = Color.WhiteSmoke;
                    DP_I_OKNG.BackColor = Color.WhiteSmoke;
                    DP_CI_OKNG.Text = "";
                    DP_CI.Text = "";
                    DP_CI.BackColor = Color.WhiteSmoke;
                    DP_CI_OKNG.BackColor = Color.WhiteSmoke;
                    DP_R_OKNG.Text = "";
                    DP_R.Text = "";
                    DP_R.BackColor = Color.WhiteSmoke;
                    DP_R_OKNG.BackColor = Color.WhiteSmoke;
                    DP_CR_OKNG.Text = "";
                    DP_CR.Text = "";
                    DP_CR.BackColor = Color.WhiteSmoke;
                    DP_CR_OKNG.BackColor = Color.WhiteSmoke;
                    DP_DataRecord.Text = "";
                    DP_DataRecord.BackColor = Color.WhiteSmoke;
                    break;
                default: break;
            }
            if (okng == "NG" && type != "DATARE" && type != "ALL")
            {
                if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Stop();
            }
        }
        private void Get_WirUart_Click(object sender, EventArgs e)
        {
            auto_step = UART_TEST_ENUM.UART_TEST_WIRELESS_ID;
            motor_serport1.MotorSend_GetWID();
        }

        private void Mamual_Switch_Click(object sender, EventArgs e)
        {
            Mamual_Switch.Visible = false;
            Display_BackColor("ALL","0",0);
            Display_BackColor("BUTTON", "ON", 0);
            Power_ON.Visible = true;
            DP_PowerOn_OKNG.Visible = true;
            TestMode_Set.Visible = true;
            LodaCurrent_Up.Visible = true;
            LodaCurrent_Down.Visible = true;
            FlagAuto_En = false;
        }

        private void Temp_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void DP_Temp_TextChanged(object sender, EventArgs e)
        {

        }

        private void DP_TESTOKNG_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

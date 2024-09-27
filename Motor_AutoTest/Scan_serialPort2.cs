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

namespace Motor_AutoTest
{
    class Scan_serialPort2
    {
        byte flag_one = 0;
        int flag_scan = 0;
        byte flag_auto_start = 0;
        Color BackClolor_ON = Color.LightSteelBlue;
        Color BackClolor_OFF = Color.Gainsboro;
        Motor_serialPort1 motor_ser1 = new Motor_serialPort1();
        public void Scan_SerPort2Init()
        {
            Form1.pform1.serialPort2.DataReceived += new SerialDataReceivedEventHandler(port2_Scan_DataReceived);//必须手动添加事件处理程序
        }
        private void port2_Scan_DataReceived(object sender, SerialDataReceivedEventArgs e) //串口接收处理
        {
            int rx_cnt = 0;
            char[] InputBuf = new char[64];
            rx_cnt = Form1.pform1.serialPort2.BytesToRead;
            if (rx_cnt > 64) rx_cnt = 64;
            Form1.pform1.serialPort2.Read(InputBuf, 0, rx_cnt);

            string strdata = "";
            for (int i = 0; i < rx_cnt; i++)
            {
                strdata += InputBuf[i];
            }
            Form1.pform1.BeginInvoke(new Action(() =>
            {
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 扫码枪数据：");
                Form1.pform1.DP_DataRecord.AppendText(strdata + "\r\n");
                Form1.pform1.DP_ScanCode.Text = strdata;
                if (Form1.pform1.serialPort1.IsOpen)
                {
                    if (Form1.pform1.FlagAuto_En == true) Form1.pform1.AutoTest_Init();
                }
                else
                {
                    Form1.pform1.flag_err = TEST_ERROR_ENUM.TEST_ERR_ScanPort2;
                    Form1.pform1.DP_DataRecord.BackColor = Color.White;
                    //timer2.Enabled = false;
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 主电机串口未打开，请打开主电机串口进行测试！\r\n");
                    Form1.pform1.Display_BackColor("DATARE","NG",0);
                    //MessageBox.Show("警告⚠：主电机串口未打开，请打开主电机串口进行测试！");
                }
            }));
        }
        public void Send_TestMode()
        {
            Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 发送进入测试模式\r\n");
            //display_clear();
            string TESTstr = "(TEST)";
            byte[] TESTdata = System.Text.Encoding.Default.GetBytes(TESTstr);//字符串转为byte
            motor_ser1.Motor_SerPort1_tx_data(TESTdata, TESTdata.Length);
        }
        
        public void Scan_Port2Click()
        {
            if (Form1.pform1.serialPort2.IsOpen)
            {
                try
                {
                    Form1.pform1.serialPort2.Close();
                }
                catch { }
                Form1.pform1.DP_Uart_ScanCode.BackColor = Color.LightSteelBlue;
                Form1.pform1.DP_Uart_ScanCode.Text = "扫码枪串口已关闭";
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 扫码枪串口 已关闭\r\n");
                Form1.pform1.DP_Uart2_comboBox2.Enabled = true;
            }
            else
            {
                try
                {
                    Form1.pform1.serialPort2.PortName = Form1.pform1.DP_Uart2_comboBox2.Text;
                    Form1.pform1.serialPort2.Open();
                    Form1.pform1.DP_Uart_ScanCode.BackColor = Color.LightGreen;
                    Form1.pform1.DP_Uart_ScanCode.Text = "扫码枪串口已打开";
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 扫码枪串口 " + Form1.pform1.DP_Uart2_comboBox2.Text + " 已打开\r\n");
                    Form1.pform1.DP_Uart2_comboBox2.Enabled = false;
                }
                catch
                {
                    Form1.pform1.DP_Uart2_comboBox2.Enabled = true;
                    Form1.pform1.DP_Uart_ScanCode.Text = "扫码枪串口已关闭";
                    Form1.pform1.DP_Uart_ScanCode.BackColor = Color.LightSteelBlue;
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 扫码枪串口 " + Form1.pform1.DP_Uart2_comboBox2.Text + " 打开失败 请重新选择端口！\r\n");
                    MessageBox.Show("出错，扫码枪串口 打开失败,请重新选择端口！");
                    Form1.pform1.DP_Uart2_comboBox2.Items.Clear();
                    Form1.pform1.DP_Uart2_comboBox2.Text = "";
                    string[] myselPort = SerialPort.GetPortNames();   //获取可用端口号
                    if (myselPort.Length > 0)  //至少有一个端口
                    {
                        Form1.pform1.DP_Uart2_comboBox2.Items.Clear();    //清空comboBox2中的内容
                        for (int i = 0; i < myselPort.Length; i++)
                        {
                            Form1.pform1.DP_Uart2_comboBox2.Items.Add(myselPort[i]);
                        }
                        Form1.pform1.DP_Uart2_comboBox2.Text = myselPort[0];
                    }
                }
            }
        }
    }
}

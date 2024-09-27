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
//副电机
namespace Motor_AutoTest
{
    class AuxMotor_serialPort4
    {
        Color BackClolor_ON = Color.LightSteelBlue;
        Color BackClolor_OFF = Color.Gainsboro;
        char[] InputData = new char[64];
        int rx_offset = 0;
        int data_len = 0;
        int flag_rx_done = 0;
        public void AuxMotor_SerPort4Init()
        {
            Form1.pform1.serialPort4.DataReceived += new SerialDataReceivedEventHandler(port4_AuxMotor_DataReceived);//必须手动添加事件处理程序
        }
        private void port4_AuxMotor_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int rx_cnt = 0;
            char[] InputBuf = new char[64];
            rx_cnt = Form1.pform1.serialPort4.BytesToRead;
            if (rx_cnt > 64) rx_cnt = 64;
            Form1.pform1.serialPort4.Read(InputBuf, 0, rx_cnt);

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
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 接收副电机数据：");
                //DP_DataRecord.AppendText(" count = "+count.ToString()+"\r\n"); 
                Form1.pform1.DP_DataRecord.AppendText(strdata + "\r\n");
            }));

            if (flag_rx_done == 1)
            {
                flag_rx_done = 0;
                Form1.pform1.BeginInvoke(new Action(() =>
                {
                    AuxMotor_ReciceData_Check(InputData);
                }));
            }
        }
        public void AuxMotor_ReciceData_Check(char[] buff)
        {
            Form1.pform1.EnDis_Timer1(false);
            if (buff[1] == 'R')
            {
                switch (buff[2])
                {
                    case 'S':
                        Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 施工中刹车检测OK\r\n");
                        break;
                    default:
                        Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 施工中刹车检测NG!\r\n");
                        break;
                }
            }
        }
        public void AuxMotor_Port4Click()
        {
            if (Form1.pform1.serialPort4.IsOpen)
            {
                try
                {
                    Form1.pform1.serialPort4.Close();
                }
                catch { }
                Form1.pform1.DP_Uart_AuxMotor.BackColor = Color.LightSteelBlue;
                Form1.pform1.DP_Uart_AuxMotor.Text = "副电机串口已关闭";
                Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 副电机串口 已关闭\r\n");
                Form1.pform1.DP_Uart4_comboBox4.Enabled = true;
            }
            else
            {
                try
                {
                    Form1.pform1.serialPort4.PortName = Form1.pform1.DP_Uart4_comboBox4.Text;
                    Form1.pform1.serialPort4.Open();
                    Form1.pform1.DP_Uart_AuxMotor.BackColor = Color.LightGreen;
                    Form1.pform1.DP_Uart_AuxMotor.Text = "副电机串口已打开";
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 副电机串口 " + Form1.pform1.DP_Uart4_comboBox4.Text + " 已打开\r\n");
                    Form1.pform1.DP_Uart4_comboBox4.Enabled = false;
                }
                catch
                {
                    Form1.pform1.DP_Uart4_comboBox4.Enabled = true;
                    Form1.pform1.DP_Uart_AuxMotor.Text = "副电机串口已关闭";
                    Form1.pform1.DP_Uart_AuxMotor.BackColor = Color.LightSteelBlue;
                    Form1.pform1.DP_DataRecord.AppendText(DateTime.Now.ToString() + " 副电机串口 " + Form1.pform1.DP_Uart4_comboBox4.Text + " 打开失败 请重新选择端口！\r\n");
                    MessageBox.Show("出错，副电机串口 打开失败,请重新选择端口！");
                    Form1.pform1.DP_Uart4_comboBox4.Items.Clear();
                    Form1.pform1.DP_Uart4_comboBox4.Text = "";
                    string[] myselPort = SerialPort.GetPortNames();   //获取可用端口号
                    if (myselPort.Length > 0)  //至少有一个端口
                    {
                        Form1.pform1.DP_Uart4_comboBox4.Items.Clear();    //清空comboBox1中的内容
                        for (int i = 0; i < myselPort.Length; i++)
                        {
                            Form1.pform1.DP_Uart4_comboBox4.Items.Add(myselPort[i]);
                        }
                        Form1.pform1.DP_Uart4_comboBox4.Text = myselPort[0];
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.VisaNS;

struct Source_stu
{
    public int err;
    public string source_name;
};

namespace Motor_AutoTest
{
    class CVisaOpt
    {
        private MessageBasedSession mbSession = null;     //会话

        private ResourceManager mRes = null;              //资源管理

        public static string[] ResourceArray = null;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="strRes"></param>
        /// <returns></returns>
        ///
        // public CVisaOpt()
        //  {
        // }

        /// <summary>
        /// 静态函数，查找仪器资源
        /// </summary>
        /// <param name="strRes"></param>
        /// <returns></returns>
        public string[] FindResource(string strRes)
        {
            //string[] VisaRes = new string[1];
            try
            {
                mRes = null;
                mRes = ResourceManager.GetLocalManager();
                if (mRes == null)
                {
                    //throw new Exception("本机未安装Visa的.Net支持库！");
                }
                ResourceArray = mRes.FindResources(strRes);

                //mRes.Open();
            }
            catch (System.ArgumentException)
            {
                ResourceArray = new string[1];
                ResourceArray[0] = "未能找到可用资源!";
            }
            return ResourceArray;
        }

        /// <summary>
        /// 打开资源
        /// </summary>
        /// <param name="strResourceName"></param>
        public void OpenResource(string strResourceName)
        {
            //若资源名称为空，则直接返回
            if (strResourceName != null)
            {
                try
                {
                    mRes = ResourceManager.GetLocalManager();
                    mbSession = (MessageBasedSession)mRes.Open(strResourceName);
                    //此资源的超时属性
                    //setOutTime(5000);
                    mbSession.Timeout = 15000;
                }
                catch (NationalInstruments.VisaNS.VisaException e)
                {
                    // Global.LogAdd(e.Message);
                }
                catch (Exception exp)
                {
                    //Global.LogAdd(exp.Message);
                    //throw new Exception("VisaCtrl-VisaOpen\n" + exp.Message);
                }
            }
        }


        /// <summary>
        /// 写命令函数
        /// </summary>
        /// <param name="strCommand"></param>
        public void Write(string strCommand)
        {
            try
            {
                if (mbSession != null)
                {
                    mbSession.Write(strCommand);
                }
            }
            catch (NationalInstruments.VisaNS.VisaException e)
            {
                //Global.LogAdd(e.Message);
            }
            catch (Exception exp)
            {
                throw new Exception("VisaCtrl-VisaOpen\n" + exp.Message);
            }
        }


        /// <summary>
        /// 读取返回值函数
        /// </summary>
        /// <returns></returns>
        public string Read()
        {
            try
            {
                if (mbSession != null)
                {

                    return mbSession.ReadString();
                }
            }
            catch (NationalInstruments.VisaNS.VisaException)
            {
                return Convert.ToString(0);
            }
            return Convert.ToString(0);
        }


        /// <summary>
        /// 设置超时时间
        /// </summary>
        /// <param name="time">MS</param>
        public void SetOutTime(int time)
        {
            mbSession.Timeout = time;
        }

        /// <summary>
        /// 释放会话
        /// </summary>
        public void Release()
        {
            if (mbSession != null)
            {
                mbSession.Dispose();
            }
        }
    }

    class CVisaOpt_Option
    {
        CVisaOpt m_VisaOpt = new CVisaOpt();
        CVisaOpt m_VisaOpt_RSA3 = new CVisaOpt();
        CVisaOpt m_VisaOpt_DSG3 = new CVisaOpt();
        CVisaOpt m_VisaOpt_DM3 = new CVisaOpt();
        CVisaOpt m_VisaOpt_DP8 = new CVisaOpt();
        CVisaOpt m_VisaOpt_MSO = new CVisaOpt();
        public Source_stu SourceOpt_Init(string name)
        {
            Source_stu source_stu;
            source_stu.err = 0; source_stu.source_name = "";
            string m_strResourceName = null; //仪器资源名

            string[] InstrResourceArray = m_VisaOpt.FindResource("?*INSTR"); //查找资源

            if (InstrResourceArray[0] == "未能找到可用资源!")
            {
                source_stu.err = 1;
                return source_stu;
            }
            else
            {
                for (int i = 0; i < InstrResourceArray.Length; i++)
                {
                    if (InstrResourceArray[i].Contains(name)) //仪器型号,RSA3频谱仪、DSG3信号源、DM3电压表
                    {
                        m_strResourceName = InstrResourceArray[i];
                    }
                }
            }
            //如果没有找到指定仪器直接退出
            if (m_strResourceName == null)
            {
                source_stu.err = 2;
                return source_stu;
            }
            string strback = "";
            //打开指定资源
            if (name == "RSA3")
            {
                m_VisaOpt_RSA3.OpenResource(m_strResourceName);
                //发送命令
                m_VisaOpt_RSA3.Write("*IDN?");
                //读取命令
                strback = m_VisaOpt_RSA3.Read();
            }
            else if (name == "DSG3")
            {
                m_VisaOpt_DSG3.OpenResource(m_strResourceName);
                //发送命令
                m_VisaOpt_DSG3.Write("*IDN?");
                //读取命令
                strback = m_VisaOpt_DSG3.Read();
            }
            else if (name == "DM3")
            {
                m_VisaOpt_DM3.OpenResource(m_strResourceName);
                //发送命令
                m_VisaOpt_DM3.Write("*IDN?");
                //读取命令
                strback = m_VisaOpt_DM3.Read();
            }
            else if (name == "DP8")
            {
                m_VisaOpt_DP8.OpenResource(m_strResourceName);
                m_VisaOpt_DP8.Write("*IDN?");
                strback = m_VisaOpt_DP8.Read();
            }
            else if (name == "MSO")
            {
                m_VisaOpt_DP8.OpenResource(m_strResourceName);
                m_VisaOpt_DP8.Write("*IDN?");
                strback = m_VisaOpt_MSO.Read();
            }
            //显示读取内容
            source_stu.source_name = strback;
            source_stu.err = 0;

            return source_stu;
        }
        public void Opt_Set(string name, string onoff)
        {
            if (name == "RSA3") //频谱仪
            {
                m_VisaOpt_RSA3.Write(":SENSe:FREQuency:CENTer 429.175MHz"); //设置中心频率
                m_VisaOpt_RSA3.Write(":SENSe:FREQuency:SPAN 100KHz"); //设置扫宽SPAN
                m_VisaOpt_RSA3.Write(":CALCulate:MARKer1:CPSearch:STATe ON"); //打开或关闭连续峰值搜索功能
                //m_VisaOpt_RSA3.Write(":CALCulate:MARKer:AOFF"); //关闭所以打开的光标
            }
            else if (name == "DSG3") //信号源
            {
                if (onoff == "ON")
                {
                    m_VisaOpt_DSG3.Write(":SOURce:FREQuency 426.750MHz");  //载波频率
                    m_VisaOpt_DSG3.Write(":SOURce:LEVel -116dBm");  //载波幅度
                    m_VisaOpt_DSG3.Write(":SOURce:FMPM:TYPE FM");  //调制类型 FM
                    m_VisaOpt_DSG3.Write(":SOURce:FM:STATe ON");   //调制开关 ON
                    m_VisaOpt_DSG3.Write(":SOURce:FM:SOURce INTernal"); //调制源类型
                    m_VisaOpt_DSG3.Write(":SOURce:FM:WAVEform SQUA"); //调制方波
                    m_VisaOpt_DSG3.Write(":SOURce:FM:DEViation 2.2KHz"); //调制频偏
                    m_VisaOpt_DSG3.Write(":SOURce:FM:FREQuency 600Hz"); //调制速率
                    m_VisaOpt_DSG3.Write(":SOURce:MODulation:STATe ON"); //打开所有调制输出开关MOD ON,//OFF关闭调制

                    m_VisaOpt_DSG3.Write(":OUTPut:STATe ON");  //RF输出开关 ON
                }
                else
                {
                    m_VisaOpt_DSG3.Write(":OUTPut:STATe OFF");  //RF输出开关 OFF
                }
            }
            else if (name == "DM3") //电压表
            {
                if (onoff == "I")
                {
                    m_VisaOpt_DM3.Write(":MEASure:CURRent:DC 3"); //电流最大测量200mA
                    //m_VisaOpt_DM3.Write(":MEASure:CURRent:DC?");
                    //string strback_RIGOL_DM305_Vdc = m_VisaOpt_DSG3.Read();
                }
                else if (onoff == "V")
                {
                    m_VisaOpt_DM3.Write(":MEASure:VOLTage:DC 2"); //电压最大测量20V
                }
            }
            else if (name == "DP8")
            {
                if (onoff == "ON")
                {
                    m_VisaOpt_DP8.Write(":SOURce1:CURR:PROT 0.2");//设置通道1过流保护电流为0.2A.
                    m_VisaOpt_DP8.Write(":SOURce1:CURR:PROT:STAT ON");//打开通道1的过流保护功能
                    m_VisaOpt_DP8.Write(":SOURce1:CURR:STEP 0.01");//设置通道1电流变化的步进值为10mA
                    m_VisaOpt_DP8.Write(":SOURce1:VOLT 24");//设置通道1的电压值为24V
                    m_VisaOpt_DP8.Write(":SOURce1:CURR 0.004");//设置通道1的输出电流为0.004A.
                    m_VisaOpt_DP8.Write(":SOURce2:VOLT 12");//设置通道2的电压值为12V
                    m_VisaOpt_DP8.Write(":SOURce2:CURR 0.5");//设置通道2的输出电流为0.5A.
                    m_VisaOpt_DP8.Write("OUTP CH2,ON");//打开通道2输出
                    m_VisaOpt_DP8.Write("OUTP CH1,ON");//打开通道1输出
                }
                else if (onoff == "OFF")
                {
                    m_VisaOpt_DP8.Write("OUTP CH2,OFF");//关闭通道2输出
                    m_VisaOpt_DP8.Write("OUTP CH1,OFF");//关闭通道1输出
                }
                else if (onoff == "UP")
                {
                    m_VisaOpt_DP8.Write(":SOURce1:CURR UP");//按步进增大通道1的输出电流.
                }
                else if (onoff == "DOWN")
                {
                    m_VisaOpt_DP8.Write(":SOURce1:CURR DOWN");//按步进减小通道1的输出电流.
                }
            }
            else if (name == "MSO")
            { 
                
            }
        }
        public string Opt_GetIVdc(string name, string iv)
        {
            if (name == "DM3")
            {
                if (iv == "I")
                {
                    m_VisaOpt_DM3.Write(":MEASure:CURRent:DC?");
                    string strback_Idc = m_VisaOpt_DM3.Read();
                    return strback_Idc;
                }
                else if (iv == "V")
                {
                    m_VisaOpt_DM3.Write(":MEASure:VOLTage:DC?");
                    string strback_Idc = m_VisaOpt_DM3.Read();
                    return strback_Idc;
                }
            }
            return "0";
        }
    }
}

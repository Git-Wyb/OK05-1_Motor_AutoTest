namespace Motor_AutoTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Com_groupBox = new System.Windows.Forms.GroupBox();
            this.DP_Uart3_comboBox3 = new System.Windows.Forms.ComboBox();
            this.DP_Uart_Relay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Check_Com = new System.Windows.Forms.Button();
            this.DP_Uart1_comboBox1 = new System.Windows.Forms.ComboBox();
            this.DP_Uart_OpenClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.DP_Uart2_comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DP_Uart_ScanCode = new System.Windows.Forms.Button();
            this.DP_Uart4_comboBox4 = new System.Windows.Forms.ComboBox();
            this.DP_Uart_AuxMotor = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.Clear_Data = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.OutPut_Data = new System.Windows.Forms.Button();
            this.DP_DataRecord = new System.Windows.Forms.TextBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Temp_groupBox = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Check_Temp = new System.Windows.Forms.Button();
            this.DP_Temp = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Scan_Code_groupBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DP_ScanCode = new System.Windows.Forms.TextBox();
            this.serialPort3 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DP_TEST_NG = new System.Windows.Forms.Label();
            this.DP_TEST_OK = new System.Windows.Forms.Label();
            this.DP_TESTOKNG = new System.Windows.Forms.Label();
            this.DP_CR_Range = new System.Windows.Forms.TextBox();
            this.DP_CI_Range = new System.Windows.Forms.TextBox();
            this.DP_R_Range = new System.Windows.Forms.TextBox();
            this.DP_I_Range = new System.Windows.Forms.TextBox();
            this.DP_T_Range = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DP_V_Range = new System.Windows.Forms.TextBox();
            this.DP_WirUart_OKNG = new System.Windows.Forms.TextBox();
            this.Get_WirUart = new System.Windows.Forms.Button();
            this.DP_IDCheck_OKNG = new System.Windows.Forms.TextBox();
            this.Get_IDCheck = new System.Windows.Forms.Button();
            this.DP_BuBreak_OKNG = new System.Windows.Forms.TextBox();
            this.Get_BuBreak = new System.Windows.Forms.Button();
            this.Get_CI = new System.Windows.Forms.Button();
            this.DP_AcBreak_OKNG = new System.Windows.Forms.TextBox();
            this.DP_CI = new System.Windows.Forms.TextBox();
            this.DP_CI_OKNG = new System.Windows.Forms.TextBox();
            this.Get_AcBreak = new System.Windows.Forms.Button();
            this.Get_CR = new System.Windows.Forms.Button();
            this.DP_CR = new System.Windows.Forms.TextBox();
            this.DP_CR_OKNG = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Get_V = new System.Windows.Forms.Button();
            this.Get_T = new System.Windows.Forms.Button();
            this.Get_I = new System.Windows.Forms.Button();
            this.DP_Stop_OKNG = new System.Windows.Forms.TextBox();
            this.DP_I = new System.Windows.Forms.TextBox();
            this.Get_Stop = new System.Windows.Forms.Button();
            this.DP_V = new System.Windows.Forms.TextBox();
            this.Get_Open = new System.Windows.Forms.Button();
            this.DP_T = new System.Windows.Forms.TextBox();
            this.DP_Close_OKNG = new System.Windows.Forms.TextBox();
            this.DP_I_OKNG = new System.Windows.Forms.TextBox();
            this.DP_V_OKNG = new System.Windows.Forms.TextBox();
            this.DP_Open_OKNG = new System.Windows.Forms.TextBox();
            this.DP_T_OKNG = new System.Windows.Forms.TextBox();
            this.Get_Close = new System.Windows.Forms.Button();
            this.Get_R = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DP_R = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DP_R_OKNG = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.DP_TestNum = new System.Windows.Forms.TextBox();
            this.Power_ON = new System.Windows.Forms.Button();
            this.DP_PowerOn_OKNG = new System.Windows.Forms.TextBox();
            this.TestMode_Set = new System.Windows.Forms.Button();
            this.LodaCurrent_Up = new System.Windows.Forms.Button();
            this.LodaCurrent_Down = new System.Windows.Forms.Button();
            this.serialPort4 = new System.IO.Ports.SerialPort(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.Mamual_Switch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Com_groupBox.SuspendLayout();
            this.Temp_groupBox.SuspendLayout();
            this.Scan_Code_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Com_groupBox
            // 
            this.Com_groupBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Com_groupBox.Controls.Add(this.DP_Uart3_comboBox3);
            this.Com_groupBox.Controls.Add(this.DP_Uart_Relay);
            this.Com_groupBox.Controls.Add(this.label1);
            this.Com_groupBox.Controls.Add(this.Check_Com);
            this.Com_groupBox.Controls.Add(this.DP_Uart1_comboBox1);
            this.Com_groupBox.Controls.Add(this.DP_Uart_OpenClose);
            this.Com_groupBox.Controls.Add(this.label8);
            this.Com_groupBox.Controls.Add(this.DP_Uart2_comboBox2);
            this.Com_groupBox.Controls.Add(this.label7);
            this.Com_groupBox.Controls.Add(this.DP_Uart_ScanCode);
            this.Com_groupBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Com_groupBox.Location = new System.Drawing.Point(12, 12);
            this.Com_groupBox.Name = "Com_groupBox";
            this.Com_groupBox.Size = new System.Drawing.Size(510, 161);
            this.Com_groupBox.TabIndex = 79;
            this.Com_groupBox.TabStop = false;
            this.Com_groupBox.Text = "端口设置";
            // 
            // DP_Uart3_comboBox3
            // 
            this.DP_Uart3_comboBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Uart3_comboBox3.FormattingEnabled = true;
            this.DP_Uart3_comboBox3.Location = new System.Drawing.Point(175, 108);
            this.DP_Uart3_comboBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_Uart3_comboBox3.Name = "DP_Uart3_comboBox3";
            this.DP_Uart3_comboBox3.Size = new System.Drawing.Size(114, 22);
            this.DP_Uart3_comboBox3.TabIndex = 72;
            // 
            // DP_Uart_Relay
            // 
            this.DP_Uart_Relay.BackColor = System.Drawing.Color.LightSteelBlue;
            this.DP_Uart_Relay.Cursor = System.Windows.Forms.Cursors.Default;
            this.DP_Uart_Relay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Uart_Relay.Location = new System.Drawing.Point(309, 104);
            this.DP_Uart_Relay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_Uart_Relay.Name = "DP_Uart_Relay";
            this.DP_Uart_Relay.Size = new System.Drawing.Size(141, 31);
            this.DP_Uart_Relay.TabIndex = 73;
            this.DP_Uart_Relay.Text = "继电器串口已关闭";
            this.DP_Uart_Relay.UseVisualStyleBackColor = false;
            this.DP_Uart_Relay.Click += new System.EventHandler(this.DP_Uart_Relay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 74;
            this.label1.Text = "继电器:";
            // 
            // Check_Com
            // 
            this.Check_Com.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Check_Com.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Check_Com.Location = new System.Drawing.Point(4, 36);
            this.Check_Com.Name = "Check_Com";
            this.Check_Com.Size = new System.Drawing.Size(87, 76);
            this.Check_Com.TabIndex = 67;
            this.Check_Com.Text = "检查端口";
            this.Check_Com.UseVisualStyleBackColor = false;
            this.Check_Com.Click += new System.EventHandler(this.Check_Com_Click);
            // 
            // DP_Uart1_comboBox1
            // 
            this.DP_Uart1_comboBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Uart1_comboBox1.FormattingEnabled = true;
            this.DP_Uart1_comboBox1.Location = new System.Drawing.Point(174, 18);
            this.DP_Uart1_comboBox1.Name = "DP_Uart1_comboBox1";
            this.DP_Uart1_comboBox1.Size = new System.Drawing.Size(114, 22);
            this.DP_Uart1_comboBox1.TabIndex = 64;
            // 
            // DP_Uart_OpenClose
            // 
            this.DP_Uart_OpenClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.DP_Uart_OpenClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.DP_Uart_OpenClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Uart_OpenClose.Location = new System.Drawing.Point(308, 14);
            this.DP_Uart_OpenClose.Name = "DP_Uart_OpenClose";
            this.DP_Uart_OpenClose.Size = new System.Drawing.Size(141, 31);
            this.DP_Uart_OpenClose.TabIndex = 65;
            this.DP_Uart_OpenClose.Text = "主电机串口已关闭";
            this.DP_Uart_OpenClose.UseVisualStyleBackColor = false;
            this.DP_Uart_OpenClose.Click += new System.EventHandler(this.DP_Uart_OpenClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(108, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 14);
            this.label8.TabIndex = 71;
            this.label8.Text = "主电机：";
            // 
            // DP_Uart2_comboBox2
            // 
            this.DP_Uart2_comboBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Uart2_comboBox2.FormattingEnabled = true;
            this.DP_Uart2_comboBox2.Location = new System.Drawing.Point(175, 62);
            this.DP_Uart2_comboBox2.Name = "DP_Uart2_comboBox2";
            this.DP_Uart2_comboBox2.Size = new System.Drawing.Size(114, 22);
            this.DP_Uart2_comboBox2.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(109, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 14);
            this.label7.TabIndex = 70;
            this.label7.Text = "扫码枪:";
            // 
            // DP_Uart_ScanCode
            // 
            this.DP_Uart_ScanCode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.DP_Uart_ScanCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.DP_Uart_ScanCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Uart_ScanCode.Location = new System.Drawing.Point(309, 57);
            this.DP_Uart_ScanCode.Name = "DP_Uart_ScanCode";
            this.DP_Uart_ScanCode.Size = new System.Drawing.Size(141, 31);
            this.DP_Uart_ScanCode.TabIndex = 69;
            this.DP_Uart_ScanCode.Text = "扫码枪串口已关闭";
            this.DP_Uart_ScanCode.UseVisualStyleBackColor = false;
            this.DP_Uart_ScanCode.Click += new System.EventHandler(this.DP_Uart_ScanCode_Click);
            // 
            // DP_Uart4_comboBox4
            // 
            this.DP_Uart4_comboBox4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Uart4_comboBox4.FormattingEnabled = true;
            this.DP_Uart4_comboBox4.Location = new System.Drawing.Point(597, 16);
            this.DP_Uart4_comboBox4.Name = "DP_Uart4_comboBox4";
            this.DP_Uart4_comboBox4.Size = new System.Drawing.Size(114, 22);
            this.DP_Uart4_comboBox4.TabIndex = 75;
            this.DP_Uart4_comboBox4.Visible = false;
            // 
            // DP_Uart_AuxMotor
            // 
            this.DP_Uart_AuxMotor.BackColor = System.Drawing.Color.LightSteelBlue;
            this.DP_Uart_AuxMotor.Cursor = System.Windows.Forms.Cursors.Default;
            this.DP_Uart_AuxMotor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Uart_AuxMotor.Location = new System.Drawing.Point(731, 12);
            this.DP_Uart_AuxMotor.Name = "DP_Uart_AuxMotor";
            this.DP_Uart_AuxMotor.Size = new System.Drawing.Size(141, 31);
            this.DP_Uart_AuxMotor.TabIndex = 76;
            this.DP_Uart_AuxMotor.Text = "副电机串口已关闭";
            this.DP_Uart_AuxMotor.UseVisualStyleBackColor = false;
            this.DP_Uart_AuxMotor.Visible = false;
            this.DP_Uart_AuxMotor.Click += new System.EventHandler(this.DP_Uart_AuxMotor_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(531, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 14);
            this.label15.TabIndex = 77;
            this.label15.Text = "副电机：";
            this.label15.Visible = false;
            // 
            // Clear_Data
            // 
            this.Clear_Data.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Clear_Data.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Clear_Data.Location = new System.Drawing.Point(1211, 745);
            this.Clear_Data.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Clear_Data.Name = "Clear_Data";
            this.Clear_Data.Size = new System.Drawing.Size(100, 80);
            this.Clear_Data.TabIndex = 83;
            this.Clear_Data.Text = "清除记录";
            this.Clear_Data.UseVisualStyleBackColor = false;
            this.Clear_Data.Click += new System.EventHandler(this.Clear_Data_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(811, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 82;
            this.label2.Text = "数据记录";
            // 
            // OutPut_Data
            // 
            this.OutPut_Data.BackColor = System.Drawing.Color.LightSteelBlue;
            this.OutPut_Data.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OutPut_Data.Location = new System.Drawing.Point(814, 747);
            this.OutPut_Data.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OutPut_Data.Name = "OutPut_Data";
            this.OutPut_Data.Size = new System.Drawing.Size(100, 80);
            this.OutPut_Data.TabIndex = 81;
            this.OutPut_Data.Text = "保存记录";
            this.OutPut_Data.UseVisualStyleBackColor = false;
            this.OutPut_Data.Click += new System.EventHandler(this.OutPut_Data_Click);
            // 
            // DP_DataRecord
            // 
            this.DP_DataRecord.BackColor = System.Drawing.SystemColors.Window;
            this.DP_DataRecord.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_DataRecord.Location = new System.Drawing.Point(814, 227);
            this.DP_DataRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DP_DataRecord.MaxLength = 0;
            this.DP_DataRecord.Multiline = true;
            this.DP_DataRecord.Name = "DP_DataRecord";
            this.DP_DataRecord.ReadOnly = true;
            this.DP_DataRecord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DP_DataRecord.Size = new System.Drawing.Size(497, 513);
            this.DP_DataRecord.TabIndex = 80;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Temp_groupBox
            // 
            this.Temp_groupBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Temp_groupBox.Controls.Add(this.label9);
            this.Temp_groupBox.Controls.Add(this.Check_Temp);
            this.Temp_groupBox.Controls.Add(this.DP_Temp);
            this.Temp_groupBox.Controls.Add(this.label11);
            this.Temp_groupBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Temp_groupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Temp_groupBox.Location = new System.Drawing.Point(904, 12);
            this.Temp_groupBox.Name = "Temp_groupBox";
            this.Temp_groupBox.Size = new System.Drawing.Size(406, 100);
            this.Temp_groupBox.TabIndex = 84;
            this.Temp_groupBox.TabStop = false;
            this.Temp_groupBox.Text = "温度设置";
            this.Temp_groupBox.Enter += new System.EventHandler(this.Temp_groupBox_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(29, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 19);
            this.label9.TabIndex = 74;
            this.label9.Text = "设置环境温度:";
            // 
            // Check_Temp
            // 
            this.Check_Temp.BackColor = System.Drawing.Color.LightGreen;
            this.Check_Temp.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Check_Temp.Location = new System.Drawing.Point(280, 18);
            this.Check_Temp.Name = "Check_Temp";
            this.Check_Temp.Size = new System.Drawing.Size(100, 70);
            this.Check_Temp.TabIndex = 76;
            this.Check_Temp.Text = "取消";
            this.Check_Temp.UseVisualStyleBackColor = false;
            this.Check_Temp.Click += new System.EventHandler(this.Check_Temp_Click);
            // 
            // DP_Temp
            // 
            this.DP_Temp.Enabled = false;
            this.DP_Temp.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Temp.Location = new System.Drawing.Point(175, 32);
            this.DP_Temp.Multiline = true;
            this.DP_Temp.Name = "DP_Temp";
            this.DP_Temp.Size = new System.Drawing.Size(70, 40);
            this.DP_Temp.TabIndex = 72;
            this.DP_Temp.Text = "27";
            this.DP_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DP_Temp.TextChanged += new System.EventHandler(this.DP_Temp_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(245, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 16);
            this.label11.TabIndex = 75;
            this.label11.Text = "℃";
            // 
            // Scan_Code_groupBox
            // 
            this.Scan_Code_groupBox.BackColor = System.Drawing.SystemColors.Menu;
            this.Scan_Code_groupBox.Controls.Add(this.label10);
            this.Scan_Code_groupBox.Controls.Add(this.DP_ScanCode);
            this.Scan_Code_groupBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Scan_Code_groupBox.Location = new System.Drawing.Point(12, 211);
            this.Scan_Code_groupBox.Name = "Scan_Code_groupBox";
            this.Scan_Code_groupBox.Size = new System.Drawing.Size(454, 87);
            this.Scan_Code_groupBox.TabIndex = 85;
            this.Scan_Code_groupBox.TabStop = false;
            this.Scan_Code_groupBox.Text = "扫码枪";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 21);
            this.label10.TabIndex = 63;
            this.label10.Text = "编号:";
            // 
            // DP_ScanCode
            // 
            this.DP_ScanCode.BackColor = System.Drawing.SystemColors.Menu;
            this.DP_ScanCode.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_ScanCode.Location = new System.Drawing.Point(78, 32);
            this.DP_ScanCode.Multiline = true;
            this.DP_ScanCode.Name = "DP_ScanCode";
            this.DP_ScanCode.ReadOnly = true;
            this.DP_ScanCode.Size = new System.Drawing.Size(329, 42);
            this.DP_ScanCode.TabIndex = 62;
            this.DP_ScanCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serialPort3
            // 
            this.serialPort3.BaudRate = 38400;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.DP_CR_Range);
            this.groupBox1.Controls.Add(this.DP_CI_Range);
            this.groupBox1.Controls.Add(this.DP_R_Range);
            this.groupBox1.Controls.Add(this.DP_I_Range);
            this.groupBox1.Controls.Add(this.DP_T_Range);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DP_V_Range);
            this.groupBox1.Controls.Add(this.DP_WirUart_OKNG);
            this.groupBox1.Controls.Add(this.Get_WirUart);
            this.groupBox1.Controls.Add(this.DP_IDCheck_OKNG);
            this.groupBox1.Controls.Add(this.Get_IDCheck);
            this.groupBox1.Controls.Add(this.DP_BuBreak_OKNG);
            this.groupBox1.Controls.Add(this.Get_BuBreak);
            this.groupBox1.Controls.Add(this.Get_CI);
            this.groupBox1.Controls.Add(this.DP_AcBreak_OKNG);
            this.groupBox1.Controls.Add(this.DP_CI);
            this.groupBox1.Controls.Add(this.DP_CI_OKNG);
            this.groupBox1.Controls.Add(this.Get_AcBreak);
            this.groupBox1.Controls.Add(this.Get_CR);
            this.groupBox1.Controls.Add(this.DP_CR);
            this.groupBox1.Controls.Add(this.DP_CR_OKNG);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.Get_V);
            this.groupBox1.Controls.Add(this.Get_T);
            this.groupBox1.Controls.Add(this.Get_I);
            this.groupBox1.Controls.Add(this.DP_Stop_OKNG);
            this.groupBox1.Controls.Add(this.DP_I);
            this.groupBox1.Controls.Add(this.Get_Stop);
            this.groupBox1.Controls.Add(this.DP_V);
            this.groupBox1.Controls.Add(this.Get_Open);
            this.groupBox1.Controls.Add(this.DP_T);
            this.groupBox1.Controls.Add(this.DP_Close_OKNG);
            this.groupBox1.Controls.Add(this.DP_I_OKNG);
            this.groupBox1.Controls.Add(this.DP_V_OKNG);
            this.groupBox1.Controls.Add(this.DP_Open_OKNG);
            this.groupBox1.Controls.Add(this.DP_T_OKNG);
            this.groupBox1.Controls.Add(this.Get_Close);
            this.groupBox1.Controls.Add(this.Get_R);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DP_R);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.DP_R_OKNG);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 321);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 506);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试项目";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.DP_TESTOKNG);
            this.groupBox2.Location = new System.Drawing.Point(514, 337);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 145);
            this.groupBox2.TabIndex = 79;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试结果";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DP_TEST_NG);
            this.groupBox3.Controls.Add(this.DP_TEST_OK);
            this.groupBox3.Location = new System.Drawing.Point(154, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 103);
            this.groupBox3.TabIndex = 97;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "统计";
            // 
            // DP_TEST_NG
            // 
            this.DP_TEST_NG.AutoSize = true;
            this.DP_TEST_NG.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_TEST_NG.Location = new System.Drawing.Point(7, 73);
            this.DP_TEST_NG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DP_TEST_NG.Name = "DP_TEST_NG";
            this.DP_TEST_NG.Size = new System.Drawing.Size(53, 19);
            this.DP_TEST_NG.TabIndex = 34;
            this.DP_TEST_NG.Text = "NG:0";
            // 
            // DP_TEST_OK
            // 
            this.DP_TEST_OK.AutoSize = true;
            this.DP_TEST_OK.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_TEST_OK.ForeColor = System.Drawing.Color.Black;
            this.DP_TEST_OK.Location = new System.Drawing.Point(7, 28);
            this.DP_TEST_OK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DP_TEST_OK.Name = "DP_TEST_OK";
            this.DP_TEST_OK.Size = new System.Drawing.Size(53, 19);
            this.DP_TEST_OK.TabIndex = 33;
            this.DP_TEST_OK.Text = "OK:0";
            // 
            // DP_TESTOKNG
            // 
            this.DP_TESTOKNG.AutoSize = true;
            this.DP_TESTOKNG.Font = new System.Drawing.Font("宋体", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_TESTOKNG.ForeColor = System.Drawing.Color.SpringGreen;
            this.DP_TESTOKNG.Location = new System.Drawing.Point(7, 41);
            this.DP_TESTOKNG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DP_TESTOKNG.Name = "DP_TESTOKNG";
            this.DP_TESTOKNG.Size = new System.Drawing.Size(0, 97);
            this.DP_TESTOKNG.TabIndex = 78;
            this.DP_TESTOKNG.Click += new System.EventHandler(this.DP_TESTOKNG_Click);
            // 
            // DP_CR_Range
            // 
            this.DP_CR_Range.BackColor = System.Drawing.Color.Gainsboro;
            this.DP_CR_Range.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_CR_Range.Location = new System.Drawing.Point(354, 447);
            this.DP_CR_Range.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_CR_Range.Multiline = true;
            this.DP_CR_Range.Name = "DP_CR_Range";
            this.DP_CR_Range.ReadOnly = true;
            this.DP_CR_Range.Size = new System.Drawing.Size(100, 35);
            this.DP_CR_Range.TabIndex = 77;
            this.DP_CR_Range.Text = "1149~1189";
            this.DP_CR_Range.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_CI_Range
            // 
            this.DP_CI_Range.BackColor = System.Drawing.Color.Gainsboro;
            this.DP_CI_Range.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_CI_Range.Location = new System.Drawing.Point(354, 388);
            this.DP_CI_Range.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_CI_Range.Multiline = true;
            this.DP_CI_Range.Name = "DP_CI_Range";
            this.DP_CI_Range.ReadOnly = true;
            this.DP_CI_Range.Size = new System.Drawing.Size(100, 35);
            this.DP_CI_Range.TabIndex = 76;
            this.DP_CI_Range.Text = "43~53";
            this.DP_CI_Range.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_R_Range
            // 
            this.DP_R_Range.BackColor = System.Drawing.Color.Gainsboro;
            this.DP_R_Range.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_R_Range.Location = new System.Drawing.Point(354, 274);
            this.DP_R_Range.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_R_Range.Multiline = true;
            this.DP_R_Range.Name = "DP_R_Range";
            this.DP_R_Range.ReadOnly = true;
            this.DP_R_Range.Size = new System.Drawing.Size(100, 35);
            this.DP_R_Range.TabIndex = 75;
            this.DP_R_Range.Text = "1149~1189";
            this.DP_R_Range.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_I_Range
            // 
            this.DP_I_Range.BackColor = System.Drawing.Color.Gainsboro;
            this.DP_I_Range.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_I_Range.Location = new System.Drawing.Point(354, 215);
            this.DP_I_Range.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_I_Range.Multiline = true;
            this.DP_I_Range.Name = "DP_I_Range";
            this.DP_I_Range.ReadOnly = true;
            this.DP_I_Range.Size = new System.Drawing.Size(100, 35);
            this.DP_I_Range.TabIndex = 74;
            this.DP_I_Range.Text = "43~53";
            this.DP_I_Range.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_T_Range
            // 
            this.DP_T_Range.BackColor = System.Drawing.Color.Gainsboro;
            this.DP_T_Range.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_T_Range.Location = new System.Drawing.Point(354, 100);
            this.DP_T_Range.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_T_Range.Multiline = true;
            this.DP_T_Range.Name = "DP_T_Range";
            this.DP_T_Range.ReadOnly = true;
            this.DP_T_Range.Size = new System.Drawing.Size(100, 35);
            this.DP_T_Range.TabIndex = 73;
            this.DP_T_Range.Text = "22~30";
            this.DP_T_Range.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(359, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 72;
            this.label5.Text = "正常范围";
            // 
            // DP_V_Range
            // 
            this.DP_V_Range.BackColor = System.Drawing.Color.Gainsboro;
            this.DP_V_Range.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_V_Range.Location = new System.Drawing.Point(354, 41);
            this.DP_V_Range.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_V_Range.Multiline = true;
            this.DP_V_Range.Name = "DP_V_Range";
            this.DP_V_Range.ReadOnly = true;
            this.DP_V_Range.Size = new System.Drawing.Size(100, 35);
            this.DP_V_Range.TabIndex = 71;
            this.DP_V_Range.Text = "95~105";
            this.DP_V_Range.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_WirUart_OKNG
            // 
            this.DP_WirUart_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_WirUart_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_WirUart_OKNG.Location = new System.Drawing.Point(647, 41);
            this.DP_WirUart_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_WirUart_OKNG.Multiline = true;
            this.DP_WirUart_OKNG.Name = "DP_WirUart_OKNG";
            this.DP_WirUart_OKNG.ReadOnly = true;
            this.DP_WirUart_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_WirUart_OKNG.TabIndex = 70;
            this.DP_WirUart_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Get_WirUart
            // 
            this.Get_WirUart.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_WirUart.Enabled = false;
            this.Get_WirUart.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_WirUart.Location = new System.Drawing.Point(539, 41);
            this.Get_WirUart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_WirUart.Name = "Get_WirUart";
            this.Get_WirUart.Size = new System.Drawing.Size(100, 35);
            this.Get_WirUart.TabIndex = 69;
            this.Get_WirUart.Text = "无线串口";
            this.Get_WirUart.UseVisualStyleBackColor = false;
            this.Get_WirUart.Click += new System.EventHandler(this.Get_WirUart_Click);
            // 
            // DP_IDCheck_OKNG
            // 
            this.DP_IDCheck_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_IDCheck_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_IDCheck_OKNG.Location = new System.Drawing.Point(647, 100);
            this.DP_IDCheck_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_IDCheck_OKNG.Multiline = true;
            this.DP_IDCheck_OKNG.Name = "DP_IDCheck_OKNG";
            this.DP_IDCheck_OKNG.ReadOnly = true;
            this.DP_IDCheck_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_IDCheck_OKNG.TabIndex = 68;
            this.DP_IDCheck_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Get_IDCheck
            // 
            this.Get_IDCheck.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_IDCheck.Enabled = false;
            this.Get_IDCheck.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_IDCheck.Location = new System.Drawing.Point(539, 100);
            this.Get_IDCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_IDCheck.Name = "Get_IDCheck";
            this.Get_IDCheck.Size = new System.Drawing.Size(100, 35);
            this.Get_IDCheck.TabIndex = 67;
            this.Get_IDCheck.Text = "ID检查:";
            this.Get_IDCheck.UseVisualStyleBackColor = false;
            this.Get_IDCheck.Click += new System.EventHandler(this.Get_IDCheck_Click);
            // 
            // DP_BuBreak_OKNG
            // 
            this.DP_BuBreak_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_BuBreak_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_BuBreak_OKNG.Location = new System.Drawing.Point(647, 215);
            this.DP_BuBreak_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_BuBreak_OKNG.Multiline = true;
            this.DP_BuBreak_OKNG.Name = "DP_BuBreak_OKNG";
            this.DP_BuBreak_OKNG.ReadOnly = true;
            this.DP_BuBreak_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_BuBreak_OKNG.TabIndex = 66;
            this.DP_BuBreak_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Get_BuBreak
            // 
            this.Get_BuBreak.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_BuBreak.Enabled = false;
            this.Get_BuBreak.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_BuBreak.Location = new System.Drawing.Point(539, 215);
            this.Get_BuBreak.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_BuBreak.Name = "Get_BuBreak";
            this.Get_BuBreak.Size = new System.Drawing.Size(100, 35);
            this.Get_BuBreak.TabIndex = 65;
            this.Get_BuBreak.Text = "施工刹车";
            this.Get_BuBreak.UseVisualStyleBackColor = false;
            this.Get_BuBreak.Click += new System.EventHandler(this.Get_BuBreak_Click);
            // 
            // Get_CI
            // 
            this.Get_CI.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_CI.Enabled = false;
            this.Get_CI.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_CI.Location = new System.Drawing.Point(4, 388);
            this.Get_CI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_CI.Name = "Get_CI";
            this.Get_CI.Size = new System.Drawing.Size(100, 35);
            this.Get_CI.TabIndex = 57;
            this.Get_CI.Text = "闭 电流:";
            this.Get_CI.UseVisualStyleBackColor = false;
            this.Get_CI.Click += new System.EventHandler(this.Get_CI_Click);
            // 
            // DP_AcBreak_OKNG
            // 
            this.DP_AcBreak_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_AcBreak_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_AcBreak_OKNG.Location = new System.Drawing.Point(647, 278);
            this.DP_AcBreak_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_AcBreak_OKNG.Multiline = true;
            this.DP_AcBreak_OKNG.Name = "DP_AcBreak_OKNG";
            this.DP_AcBreak_OKNG.ReadOnly = true;
            this.DP_AcBreak_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_AcBreak_OKNG.TabIndex = 64;
            this.DP_AcBreak_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DP_AcBreak_OKNG.Visible = false;
            // 
            // DP_CI
            // 
            this.DP_CI.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_CI.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_CI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DP_CI.Location = new System.Drawing.Point(112, 388);
            this.DP_CI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_CI.Multiline = true;
            this.DP_CI.Name = "DP_CI";
            this.DP_CI.ReadOnly = true;
            this.DP_CI.Size = new System.Drawing.Size(120, 35);
            this.DP_CI.TabIndex = 58;
            this.DP_CI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_CI_OKNG
            // 
            this.DP_CI_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_CI_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_CI_OKNG.Location = new System.Drawing.Point(240, 388);
            this.DP_CI_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_CI_OKNG.Multiline = true;
            this.DP_CI_OKNG.Name = "DP_CI_OKNG";
            this.DP_CI_OKNG.ReadOnly = true;
            this.DP_CI_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_CI_OKNG.TabIndex = 59;
            this.DP_CI_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Get_AcBreak
            // 
            this.Get_AcBreak.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_AcBreak.Enabled = false;
            this.Get_AcBreak.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_AcBreak.Location = new System.Drawing.Point(539, 278);
            this.Get_AcBreak.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_AcBreak.Name = "Get_AcBreak";
            this.Get_AcBreak.Size = new System.Drawing.Size(100, 35);
            this.Get_AcBreak.TabIndex = 63;
            this.Get_AcBreak.Text = "动作刹车";
            this.Get_AcBreak.UseVisualStyleBackColor = false;
            this.Get_AcBreak.Visible = false;
            this.Get_AcBreak.Click += new System.EventHandler(this.Get_AcBreak_Click);
            // 
            // Get_CR
            // 
            this.Get_CR.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_CR.Enabled = false;
            this.Get_CR.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_CR.Location = new System.Drawing.Point(4, 447);
            this.Get_CR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_CR.Name = "Get_CR";
            this.Get_CR.Size = new System.Drawing.Size(100, 35);
            this.Get_CR.TabIndex = 60;
            this.Get_CR.Text = "闭 转速:";
            this.Get_CR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Get_CR.UseVisualStyleBackColor = false;
            this.Get_CR.Click += new System.EventHandler(this.Get_CR_Click);
            // 
            // DP_CR
            // 
            this.DP_CR.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_CR.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_CR.Location = new System.Drawing.Point(112, 447);
            this.DP_CR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_CR.Multiline = true;
            this.DP_CR.Name = "DP_CR";
            this.DP_CR.ReadOnly = true;
            this.DP_CR.Size = new System.Drawing.Size(120, 35);
            this.DP_CR.TabIndex = 61;
            this.DP_CR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_CR_OKNG
            // 
            this.DP_CR_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_CR_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_CR_OKNG.Location = new System.Drawing.Point(240, 447);
            this.DP_CR_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_CR_OKNG.Multiline = true;
            this.DP_CR_OKNG.Name = "DP_CR_OKNG";
            this.DP_CR_OKNG.ReadOnly = true;
            this.DP_CR_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_CR_OKNG.TabIndex = 62;
            this.DP_CR_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(670, 18);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 19);
            this.label16.TabIndex = 56;
            this.label16.Text = "OK/NG";
            // 
            // Get_V
            // 
            this.Get_V.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_V.Enabled = false;
            this.Get_V.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_V.Location = new System.Drawing.Point(4, 41);
            this.Get_V.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_V.Name = "Get_V";
            this.Get_V.Size = new System.Drawing.Size(100, 35);
            this.Get_V.TabIndex = 4;
            this.Get_V.Text = " 电 压:\r\n";
            this.Get_V.UseVisualStyleBackColor = false;
            this.Get_V.Click += new System.EventHandler(this.Get_V_Click);
            // 
            // Get_T
            // 
            this.Get_T.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_T.Enabled = false;
            this.Get_T.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_T.Location = new System.Drawing.Point(4, 100);
            this.Get_T.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_T.Name = "Get_T";
            this.Get_T.Size = new System.Drawing.Size(100, 35);
            this.Get_T.TabIndex = 5;
            this.Get_T.Text = "温 度:";
            this.Get_T.UseVisualStyleBackColor = false;
            this.Get_T.Click += new System.EventHandler(this.Get_T_Click);
            // 
            // Get_I
            // 
            this.Get_I.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_I.Enabled = false;
            this.Get_I.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_I.Location = new System.Drawing.Point(4, 215);
            this.Get_I.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_I.Name = "Get_I";
            this.Get_I.Size = new System.Drawing.Size(100, 35);
            this.Get_I.TabIndex = 7;
            this.Get_I.Text = "开 电流:";
            this.Get_I.UseVisualStyleBackColor = false;
            this.Get_I.Click += new System.EventHandler(this.Get_I_Click);
            // 
            // DP_Stop_OKNG
            // 
            this.DP_Stop_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_Stop_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Stop_OKNG.Location = new System.Drawing.Point(647, 158);
            this.DP_Stop_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_Stop_OKNG.Multiline = true;
            this.DP_Stop_OKNG.Name = "DP_Stop_OKNG";
            this.DP_Stop_OKNG.ReadOnly = true;
            this.DP_Stop_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_Stop_OKNG.TabIndex = 50;
            this.DP_Stop_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_I
            // 
            this.DP_I.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_I.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_I.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DP_I.Location = new System.Drawing.Point(112, 215);
            this.DP_I.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_I.Multiline = true;
            this.DP_I.Name = "DP_I";
            this.DP_I.ReadOnly = true;
            this.DP_I.Size = new System.Drawing.Size(120, 35);
            this.DP_I.TabIndex = 8;
            this.DP_I.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Get_Stop
            // 
            this.Get_Stop.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_Stop.Enabled = false;
            this.Get_Stop.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_Stop.Location = new System.Drawing.Point(539, 158);
            this.Get_Stop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_Stop.Name = "Get_Stop";
            this.Get_Stop.Size = new System.Drawing.Size(100, 35);
            this.Get_Stop.TabIndex = 49;
            this.Get_Stop.Text = "停:";
            this.Get_Stop.UseVisualStyleBackColor = false;
            this.Get_Stop.Click += new System.EventHandler(this.Get_Stop_Click);
            // 
            // DP_V
            // 
            this.DP_V.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_V.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_V.Location = new System.Drawing.Point(112, 41);
            this.DP_V.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_V.Multiline = true;
            this.DP_V.Name = "DP_V";
            this.DP_V.ReadOnly = true;
            this.DP_V.Size = new System.Drawing.Size(120, 35);
            this.DP_V.TabIndex = 9;
            this.DP_V.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Get_Open
            // 
            this.Get_Open.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_Open.Enabled = false;
            this.Get_Open.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_Open.Location = new System.Drawing.Point(4, 158);
            this.Get_Open.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_Open.Name = "Get_Open";
            this.Get_Open.Size = new System.Drawing.Size(100, 35);
            this.Get_Open.TabIndex = 48;
            this.Get_Open.Text = "开动作:";
            this.Get_Open.UseVisualStyleBackColor = false;
            this.Get_Open.Click += new System.EventHandler(this.Get_Open_Click);
            // 
            // DP_T
            // 
            this.DP_T.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_T.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_T.Location = new System.Drawing.Point(112, 100);
            this.DP_T.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_T.Multiline = true;
            this.DP_T.Name = "DP_T";
            this.DP_T.ReadOnly = true;
            this.DP_T.Size = new System.Drawing.Size(120, 35);
            this.DP_T.TabIndex = 10;
            this.DP_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_Close_OKNG
            // 
            this.DP_Close_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_Close_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Close_OKNG.Location = new System.Drawing.Point(240, 333);
            this.DP_Close_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_Close_OKNG.Multiline = true;
            this.DP_Close_OKNG.Name = "DP_Close_OKNG";
            this.DP_Close_OKNG.ReadOnly = true;
            this.DP_Close_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_Close_OKNG.TabIndex = 47;
            this.DP_Close_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_I_OKNG
            // 
            this.DP_I_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_I_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_I_OKNG.Location = new System.Drawing.Point(240, 215);
            this.DP_I_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_I_OKNG.Multiline = true;
            this.DP_I_OKNG.Name = "DP_I_OKNG";
            this.DP_I_OKNG.ReadOnly = true;
            this.DP_I_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_I_OKNG.TabIndex = 12;
            this.DP_I_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_V_OKNG
            // 
            this.DP_V_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_V_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_V_OKNG.Location = new System.Drawing.Point(240, 41);
            this.DP_V_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_V_OKNG.Multiline = true;
            this.DP_V_OKNG.Name = "DP_V_OKNG";
            this.DP_V_OKNG.ReadOnly = true;
            this.DP_V_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_V_OKNG.TabIndex = 13;
            this.DP_V_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_Open_OKNG
            // 
            this.DP_Open_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_Open_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_Open_OKNG.Location = new System.Drawing.Point(240, 158);
            this.DP_Open_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_Open_OKNG.Multiline = true;
            this.DP_Open_OKNG.Name = "DP_Open_OKNG";
            this.DP_Open_OKNG.ReadOnly = true;
            this.DP_Open_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_Open_OKNG.TabIndex = 45;
            this.DP_Open_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DP_T_OKNG
            // 
            this.DP_T_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_T_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_T_OKNG.Location = new System.Drawing.Point(240, 100);
            this.DP_T_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_T_OKNG.Multiline = true;
            this.DP_T_OKNG.Name = "DP_T_OKNG";
            this.DP_T_OKNG.ReadOnly = true;
            this.DP_T_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_T_OKNG.TabIndex = 14;
            this.DP_T_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Get_Close
            // 
            this.Get_Close.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_Close.Enabled = false;
            this.Get_Close.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_Close.Location = new System.Drawing.Point(4, 333);
            this.Get_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_Close.Name = "Get_Close";
            this.Get_Close.Size = new System.Drawing.Size(100, 35);
            this.Get_Close.TabIndex = 44;
            this.Get_Close.Text = "闭动作:";
            this.Get_Close.UseVisualStyleBackColor = false;
            this.Get_Close.Click += new System.EventHandler(this.Get_Close_Click);
            // 
            // Get_R
            // 
            this.Get_R.BackColor = System.Drawing.Color.Gainsboro;
            this.Get_R.Enabled = false;
            this.Get_R.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Get_R.Location = new System.Drawing.Point(4, 274);
            this.Get_R.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get_R.Name = "Get_R";
            this.Get_R.Size = new System.Drawing.Size(100, 35);
            this.Get_R.TabIndex = 15;
            this.Get_R.Text = "开 转速:";
            this.Get_R.UseVisualStyleBackColor = false;
            this.Get_R.Click += new System.EventHandler(this.Get_R_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(261, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 33;
            this.label4.Text = "OK/NG";
            // 
            // DP_R
            // 
            this.DP_R.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_R.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_R.Location = new System.Drawing.Point(112, 274);
            this.DP_R.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_R.Multiline = true;
            this.DP_R.Name = "DP_R";
            this.DP_R.ReadOnly = true;
            this.DP_R.Size = new System.Drawing.Size(120, 35);
            this.DP_R.TabIndex = 17;
            this.DP_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(150, 19);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 19);
            this.label13.TabIndex = 32;
            this.label13.Text = "参数";
            // 
            // DP_R_OKNG
            // 
            this.DP_R_OKNG.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DP_R_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_R_OKNG.Location = new System.Drawing.Point(240, 274);
            this.DP_R_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_R_OKNG.Multiline = true;
            this.DP_R_OKNG.Name = "DP_R_OKNG";
            this.DP_R_OKNG.ReadOnly = true;
            this.DP_R_OKNG.Size = new System.Drawing.Size(100, 35);
            this.DP_R_OKNG.TabIndex = 19;
            this.DP_R_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 50;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 500;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(539, 256);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 19);
            this.label14.TabIndex = 87;
            this.label14.Text = "测试总量:";
            // 
            // DP_TestNum
            // 
            this.DP_TestNum.BackColor = System.Drawing.SystemColors.Menu;
            this.DP_TestNum.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_TestNum.Location = new System.Drawing.Point(637, 243);
            this.DP_TestNum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_TestNum.Multiline = true;
            this.DP_TestNum.Name = "DP_TestNum";
            this.DP_TestNum.ReadOnly = true;
            this.DP_TestNum.Size = new System.Drawing.Size(122, 42);
            this.DP_TestNum.TabIndex = 88;
            this.DP_TestNum.Text = "0";
            this.DP_TestNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Power_ON
            // 
            this.Power_ON.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Power_ON.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Power_ON.Location = new System.Drawing.Point(601, 62);
            this.Power_ON.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Power_ON.Name = "Power_ON";
            this.Power_ON.Size = new System.Drawing.Size(122, 38);
            this.Power_ON.TabIndex = 89;
            this.Power_ON.Text = "POWER:";
            this.Power_ON.UseVisualStyleBackColor = false;
            this.Power_ON.Visible = false;
            this.Power_ON.Click += new System.EventHandler(this.Power_ON_Click);
            // 
            // DP_PowerOn_OKNG
            // 
            this.DP_PowerOn_OKNG.BackColor = System.Drawing.SystemColors.Menu;
            this.DP_PowerOn_OKNG.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DP_PowerOn_OKNG.Location = new System.Drawing.Point(731, 62);
            this.DP_PowerOn_OKNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DP_PowerOn_OKNG.Multiline = true;
            this.DP_PowerOn_OKNG.Name = "DP_PowerOn_OKNG";
            this.DP_PowerOn_OKNG.ReadOnly = true;
            this.DP_PowerOn_OKNG.Size = new System.Drawing.Size(99, 38);
            this.DP_PowerOn_OKNG.TabIndex = 90;
            this.DP_PowerOn_OKNG.Text = "OFF";
            this.DP_PowerOn_OKNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DP_PowerOn_OKNG.Visible = false;
            // 
            // TestMode_Set
            // 
            this.TestMode_Set.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TestMode_Set.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestMode_Set.Location = new System.Drawing.Point(601, 120);
            this.TestMode_Set.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TestMode_Set.Name = "TestMode_Set";
            this.TestMode_Set.Size = new System.Drawing.Size(122, 50);
            this.TestMode_Set.TabIndex = 91;
            this.TestMode_Set.Text = "设置测试模式";
            this.TestMode_Set.UseVisualStyleBackColor = false;
            this.TestMode_Set.Visible = false;
            this.TestMode_Set.Click += new System.EventHandler(this.TestMode_Set_Click);
            // 
            // LodaCurrent_Up
            // 
            this.LodaCurrent_Up.BackColor = System.Drawing.Color.LightSteelBlue;
            this.LodaCurrent_Up.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LodaCurrent_Up.Location = new System.Drawing.Point(1027, 120);
            this.LodaCurrent_Up.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LodaCurrent_Up.Name = "LodaCurrent_Up";
            this.LodaCurrent_Up.Size = new System.Drawing.Size(122, 50);
            this.LodaCurrent_Up.TabIndex = 93;
            this.LodaCurrent_Up.Text = "负载电流增大";
            this.LodaCurrent_Up.UseVisualStyleBackColor = false;
            this.LodaCurrent_Up.Visible = false;
            this.LodaCurrent_Up.Click += new System.EventHandler(this.LodaCurrent_Up_Click);
            // 
            // LodaCurrent_Down
            // 
            this.LodaCurrent_Down.BackColor = System.Drawing.Color.LightSteelBlue;
            this.LodaCurrent_Down.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LodaCurrent_Down.Location = new System.Drawing.Point(1189, 120);
            this.LodaCurrent_Down.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LodaCurrent_Down.Name = "LodaCurrent_Down";
            this.LodaCurrent_Down.Size = new System.Drawing.Size(122, 50);
            this.LodaCurrent_Down.TabIndex = 94;
            this.LodaCurrent_Down.Text = "负载电流减小";
            this.LodaCurrent_Down.UseVisualStyleBackColor = false;
            this.LodaCurrent_Down.Visible = false;
            this.LodaCurrent_Down.Click += new System.EventHandler(this.LodaCurrent_Down_Click);
            // 
            // timer5
            // 
            this.timer5.Interval = 500;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // Mamual_Switch
            // 
            this.Mamual_Switch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Mamual_Switch.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Mamual_Switch.Location = new System.Drawing.Point(1143, 189);
            this.Mamual_Switch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Mamual_Switch.Name = "Mamual_Switch";
            this.Mamual_Switch.Size = new System.Drawing.Size(166, 36);
            this.Mamual_Switch.TabIndex = 95;
            this.Mamual_Switch.Text = "切换为手动模式";
            this.Mamual_Switch.UseVisualStyleBackColor = false;
            this.Mamual_Switch.Click += new System.EventHandler(this.Mamual_Switch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(761, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 21);
            this.label3.TabIndex = 96;
            this.label3.Text = "台";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 839);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Mamual_Switch);
            this.Controls.Add(this.DP_Uart4_comboBox4);
            this.Controls.Add(this.LodaCurrent_Down);
            this.Controls.Add(this.DP_Uart_AuxMotor);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.LodaCurrent_Up);
            this.Controls.Add(this.TestMode_Set);
            this.Controls.Add(this.DP_PowerOn_OKNG);
            this.Controls.Add(this.Power_ON);
            this.Controls.Add(this.DP_TestNum);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Scan_Code_groupBox);
            this.Controls.Add(this.Temp_groupBox);
            this.Controls.Add(this.Clear_Data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OutPut_Data);
            this.Controls.Add(this.DP_DataRecord);
            this.Controls.Add(this.Com_groupBox);
            this.Name = "Form1";
            this.Text = "Motor_AutoTest Ver1.01";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Com_groupBox.ResumeLayout(false);
            this.Com_groupBox.PerformLayout();
            this.Temp_groupBox.ResumeLayout(false);
            this.Temp_groupBox.PerformLayout();
            this.Scan_Code_groupBox.ResumeLayout(false);
            this.Scan_Code_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Com_groupBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Clear_Data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OutPut_Data;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox Temp_groupBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Check_Temp;
        private System.Windows.Forms.TextBox DP_Temp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox Scan_Code_groupBox;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button Check_Com;
        public System.IO.Ports.SerialPort serialPort1;
        public System.Windows.Forms.TextBox DP_DataRecord;
        public System.Windows.Forms.ComboBox DP_Uart2_comboBox2;
        public System.IO.Ports.SerialPort serialPort2;
        public System.Windows.Forms.ComboBox DP_Uart1_comboBox1;
        public System.Windows.Forms.TextBox DP_ScanCode;
        public System.Windows.Forms.Button DP_Uart_OpenClose;
        public System.Windows.Forms.Button DP_Uart_ScanCode;
        public System.IO.Ports.SerialPort serialPort3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button DP_Uart_Relay;
        public System.Windows.Forms.ComboBox DP_Uart3_comboBox3;
        private System.Windows.Forms.Button Get_Open;
        private System.Windows.Forms.Button Get_Close;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button Get_V;
        public System.Windows.Forms.Button Get_T;
        public System.Windows.Forms.Button Get_I;
        public System.Windows.Forms.Button Get_R;
        public System.Windows.Forms.TextBox DP_I;
        public System.Windows.Forms.TextBox DP_V;
        public System.Windows.Forms.TextBox DP_T;
        public System.Windows.Forms.TextBox DP_V_OKNG;
        public System.Windows.Forms.TextBox DP_T_OKNG;
        public System.Windows.Forms.TextBox DP_R;
        public System.Windows.Forms.TextBox DP_I_OKNG;
        public System.Windows.Forms.TextBox DP_R_OKNG;
        public System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Timer timer3;
        public System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox DP_TestNum;
        public System.Windows.Forms.TextBox DP_Stop_OKNG;
        public System.Windows.Forms.TextBox DP_Close_OKNG;
        public System.Windows.Forms.TextBox DP_Open_OKNG;
        public System.Windows.Forms.Button Power_ON;
        public System.Windows.Forms.TextBox DP_PowerOn_OKNG;
        public System.Windows.Forms.Button TestMode_Set;
        public System.Windows.Forms.Button LodaCurrent_Up;
        public System.Windows.Forms.Button LodaCurrent_Down;
        public System.Windows.Forms.ComboBox DP_Uart4_comboBox4;
        public System.Windows.Forms.Button DP_Uart_AuxMotor;
        private System.Windows.Forms.Label label15;
        public System.IO.Ports.SerialPort serialPort4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button Get_Stop;
        public System.Windows.Forms.Button Get_CI;
        public System.Windows.Forms.TextBox DP_CI;
        public System.Windows.Forms.TextBox DP_CI_OKNG;
        public System.Windows.Forms.Button Get_CR;
        public System.Windows.Forms.TextBox DP_CR;
        public System.Windows.Forms.TextBox DP_CR_OKNG;
        public System.Windows.Forms.Timer timer5;
        public System.Windows.Forms.TextBox DP_IDCheck_OKNG;
        private System.Windows.Forms.Button Get_IDCheck;
        public System.Windows.Forms.TextBox DP_BuBreak_OKNG;
        private System.Windows.Forms.Button Get_BuBreak;
        public System.Windows.Forms.TextBox DP_AcBreak_OKNG;
        private System.Windows.Forms.Button Get_AcBreak;
        public System.Windows.Forms.TextBox DP_WirUart_OKNG;
        private System.Windows.Forms.Button Get_WirUart;
        public System.Windows.Forms.Button Mamual_Switch;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox DP_V_Range;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox DP_T_Range;
        public System.Windows.Forms.TextBox DP_CR_Range;
        public System.Windows.Forms.TextBox DP_CI_Range;
        public System.Windows.Forms.TextBox DP_R_Range;
        public System.Windows.Forms.TextBox DP_I_Range;
        private System.Windows.Forms.Label DP_TESTOKNG;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label DP_TEST_NG;
        private System.Windows.Forms.Label DP_TEST_OK;
    }
}


namespace AlinkMessager
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gb_ailink = new System.Windows.Forms.GroupBox();
            this.tb_firstcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_ipaddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_agents = new System.Windows.Forms.GroupBox();
            this.tb_employee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_agent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cms_main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_about = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_showmain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_start = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_dialup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_dnd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_transfer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Conference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_statu = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.iv_start = new AheadTec.UIImageView();
            this.uiImageView1 = new AheadTec.UIImageView();
            this.ivAnswer = new AheadTec.UIImageView();
            this.ivHangup = new AheadTec.UIImageView();
            this.tmr_queue = new System.Windows.Forms.Timer(this.components);
            this.rlv_agents = new AheadTec.UIRaceLampView();
            this.cbx_login = new System.Windows.Forms.CheckBox();
            this.cbx_autorun = new System.Windows.Forms.CheckBox();
            this.gb_ailink.SuspendLayout();
            this.gb_agents.SuspendLayout();
            this.cms_main.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iv_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivHangup)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_ailink
            // 
            this.gb_ailink.BackColor = System.Drawing.Color.Transparent;
            this.gb_ailink.Controls.Add(this.tb_firstcode);
            this.gb_ailink.Controls.Add(this.label5);
            this.gb_ailink.Controls.Add(this.tb_port);
            this.gb_ailink.Controls.Add(this.tb_ipaddress);
            this.gb_ailink.Controls.Add(this.label2);
            this.gb_ailink.Controls.Add(this.label1);
            this.gb_ailink.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gb_ailink.Location = new System.Drawing.Point(15, 38);
            this.gb_ailink.Margin = new System.Windows.Forms.Padding(4);
            this.gb_ailink.Name = "gb_ailink";
            this.gb_ailink.Padding = new System.Windows.Forms.Padding(4);
            this.gb_ailink.Size = new System.Drawing.Size(252, 125);
            this.gb_ailink.TabIndex = 1;
            this.gb_ailink.TabStop = false;
            this.gb_ailink.Text = "Ailink服务器信息";
            // 
            // tb_firstcode
            // 
            this.tb_firstcode.Location = new System.Drawing.Point(88, 88);
            this.tb_firstcode.Margin = new System.Windows.Forms.Padding(4);
            this.tb_firstcode.Name = "tb_firstcode";
            this.tb_firstcode.Size = new System.Drawing.Size(148, 25);
            this.tb_firstcode.TabIndex = 5;
            this.tb_firstcode.Text = global::AlinkMessager.Properties.Settings.Default.FirstCode;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(19, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "出局号：";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(88, 56);
            this.tb_port.Margin = new System.Windows.Forms.Padding(4);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(148, 25);
            this.tb_port.TabIndex = 3;
            this.tb_port.Text = global::AlinkMessager.Properties.Settings.Default.CTIPort;
            // 
            // tb_ipaddress
            // 
            this.tb_ipaddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AlinkMessager.Properties.Settings.Default, "CTIAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_ipaddress.Location = new System.Drawing.Point(88, 25);
            this.tb_ipaddress.Margin = new System.Windows.Forms.Padding(4);
            this.tb_ipaddress.Name = "tb_ipaddress";
            this.tb_ipaddress.Size = new System.Drawing.Size(148, 25);
            this.tb_ipaddress.TabIndex = 2;
            this.tb_ipaddress.Text = global::AlinkMessager.Properties.Settings.Default.CTIAddress;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(19, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址：";
            // 
            // gb_agents
            // 
            this.gb_agents.BackColor = System.Drawing.Color.Transparent;
            this.gb_agents.Controls.Add(this.tb_employee);
            this.gb_agents.Controls.Add(this.label6);
            this.gb_agents.Controls.Add(this.tb_password);
            this.gb_agents.Controls.Add(this.tb_agent);
            this.gb_agents.Controls.Add(this.label4);
            this.gb_agents.Controls.Add(this.label3);
            this.gb_agents.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gb_agents.Location = new System.Drawing.Point(16, 170);
            this.gb_agents.Margin = new System.Windows.Forms.Padding(4);
            this.gb_agents.Name = "gb_agents";
            this.gb_agents.Padding = new System.Windows.Forms.Padding(4);
            this.gb_agents.Size = new System.Drawing.Size(251, 138);
            this.gb_agents.TabIndex = 2;
            this.gb_agents.TabStop = false;
            this.gb_agents.Text = "座席信息";
            // 
            // tb_employee
            // 
            this.tb_employee.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AlinkMessager.Properties.Settings.Default, "EmployeeNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_employee.Location = new System.Drawing.Point(87, 58);
            this.tb_employee.Margin = new System.Windows.Forms.Padding(4);
            this.tb_employee.Name = "tb_employee";
            this.tb_employee.Size = new System.Drawing.Size(148, 25);
            this.tb_employee.TabIndex = 9;
            this.tb_employee.Text = global::AlinkMessager.Properties.Settings.Default.EmployeeNo;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(17, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "员工号：";
            // 
            // tb_password
            // 
            this.tb_password.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AlinkMessager.Properties.Settings.Default, "AgentPwd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_password.Location = new System.Drawing.Point(87, 94);
            this.tb_password.Margin = new System.Windows.Forms.Padding(4);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(148, 25);
            this.tb_password.TabIndex = 7;
            this.tb_password.Text = global::AlinkMessager.Properties.Settings.Default.AgentPwd;
            // 
            // tb_agent
            // 
            this.tb_agent.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AlinkMessager.Properties.Settings.Default, "AgentNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_agent.Location = new System.Drawing.Point(87, 25);
            this.tb_agent.Margin = new System.Windows.Forms.Padding(4);
            this.tb_agent.Name = "tb_agent";
            this.tb_agent.Size = new System.Drawing.Size(148, 25);
            this.tb_agent.TabIndex = 5;
            this.tb_agent.Text = global::AlinkMessager.Properties.Settings.Default.AgentNo;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(17, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "密  码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(17, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "座席号：";
            // 
            // cms_main
            // 
            this.cms_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_about,
            this.toolStripSeparator2,
            this.tsmi_showmain,
            this.toolStripSeparator3,
            this.tsmi_start,
            this.tsmi_dialup,
            this.tsmi_dnd,
            this.toolStripSeparator4,
            this.tsmi_transfer,
            this.tsmi_Conference,
            this.toolStripSeparator1,
            this.tsmi_exit});
            this.cms_main.Name = "cms_main";
            this.cms_main.Size = new System.Drawing.Size(183, 236);
            this.cms_main.Opened += new System.EventHandler(this.cms_main_Opened);
            // 
            // tsmi_about
            // 
            this.tsmi_about.Name = "tsmi_about";
            this.tsmi_about.Size = new System.Drawing.Size(182, 26);
            this.tsmi_about.Text = "关于本系统(&A)";
            this.tsmi_about.Click += new System.EventHandler(this.tsmi_about_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // tsmi_showmain
            // 
            this.tsmi_showmain.Name = "tsmi_showmain";
            this.tsmi_showmain.Size = new System.Drawing.Size(182, 26);
            this.tsmi_showmain.Text = "显示主窗口(&M)";
            this.tsmi_showmain.Click += new System.EventHandler(this.tsmi_showmain_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // tsmi_start
            // 
            this.tsmi_start.Image = global::AlinkMessager.Properties.Resources.btn_start;
            this.tsmi_start.Name = "tsmi_start";
            this.tsmi_start.Size = new System.Drawing.Size(182, 26);
            this.tsmi_start.Text = "开始接听(&S)";
            this.tsmi_start.Click += new System.EventHandler(this.iv_start_Click);
            // 
            // tsmi_dialup
            // 
            this.tsmi_dialup.Enabled = false;
            this.tsmi_dialup.Name = "tsmi_dialup";
            this.tsmi_dialup.Size = new System.Drawing.Size(182, 26);
            this.tsmi_dialup.Text = "软外拨(&D)";
            this.tsmi_dialup.Click += new System.EventHandler(this.tsmi_dialup_Click);
            // 
            // tsmi_dnd
            // 
            this.tsmi_dnd.Enabled = false;
            this.tsmi_dnd.Name = "tsmi_dnd";
            this.tsmi_dnd.Size = new System.Drawing.Size(182, 26);
            this.tsmi_dnd.Text = "置忙(&N)";
            this.tsmi_dnd.Click += new System.EventHandler(this.tsmi_dnd_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(179, 6);
            // 
            // tsmi_transfer
            // 
            this.tsmi_transfer.Name = "tsmi_transfer";
            this.tsmi_transfer.Size = new System.Drawing.Size(182, 26);
            this.tsmi_transfer.Text = "转接(&T)";
            this.tsmi_transfer.Click += new System.EventHandler(this.tsmi_transfer_Click);
            // 
            // tsmi_Conference
            // 
            this.tsmi_Conference.Name = "tsmi_Conference";
            this.tsmi_Conference.Size = new System.Drawing.Size(182, 26);
            this.tsmi_Conference.Text = "三方通话(&C)";
            this.tsmi_Conference.Click += new System.EventHandler(this.tsmi_Conference_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // tsmi_exit
            // 
            this.tsmi_exit.Name = "tsmi_exit";
            this.tsmi_exit.Size = new System.Drawing.Size(182, 26);
            this.tsmi_exit.Text = "退出系统(&X)";
            this.tsmi_exit.Click += new System.EventHandler(this.tsmi_exit_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cms_main;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AilinkServer消息客户端";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsl_statu,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(8, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(268, 25);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(84, 20);
            this.toolStripStatusLabel1.Text = "当前状态：";
            // 
            // tsl_statu
            // 
            this.tsl_statu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsl_statu.Name = "tsl_statu";
            this.tsl_statu.Size = new System.Drawing.Size(54, 20);
            this.tsl_statu.Text = "未登录";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // iv_start
            // 
            this.iv_start.Cursor = System.Windows.Forms.Cursors.Default;
            this.iv_start.Hovered = null;
            this.iv_start.Image = global::AlinkMessager.Properties.Resources.btn_start;
            this.iv_start.IsHovered = false;
            this.iv_start.IsSelected = false;
            this.iv_start.Location = new System.Drawing.Point(177, 316);
            this.iv_start.Margin = new System.Windows.Forms.Padding(4);
            this.iv_start.Name = "iv_start";
            this.iv_start.Normal = global::AlinkMessager.Properties.Resources.btn_start;
            this.iv_start.Size = new System.Drawing.Size(64, 60);
            this.iv_start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iv_start.TabIndex = 5;
            this.iv_start.TabStop = false;
            this.iv_start.Click += new System.EventHandler(this.iv_start_Click);
            // 
            // uiImageView1
            // 
            this.uiImageView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiImageView1.Hovered = null;
            this.uiImageView1.IsHovered = false;
            this.uiImageView1.IsSelected = false;
            this.uiImageView1.Location = new System.Drawing.Point(0, 0);
            this.uiImageView1.Name = "uiImageView1";
            this.uiImageView1.Normal = null;
            this.uiImageView1.Size = new System.Drawing.Size(100, 50);
            this.uiImageView1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiImageView1.TabIndex = 0;
            this.uiImageView1.TabStop = false;
            // 
            // ivAnswer
            // 
            this.ivAnswer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ivAnswer.Hovered = null;
            this.ivAnswer.Image = global::AlinkMessager.Properties.Resources.Answer;
            this.ivAnswer.IsHovered = false;
            this.ivAnswer.IsSelected = false;
            this.ivAnswer.Location = new System.Drawing.Point(19, 75);
            this.ivAnswer.Margin = new System.Windows.Forms.Padding(4);
            this.ivAnswer.Name = "ivAnswer";
            this.ivAnswer.Normal = global::AlinkMessager.Properties.Resources.Answer;
            this.ivAnswer.Size = new System.Drawing.Size(32, 30);
            this.ivAnswer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ivAnswer.TabIndex = 14;
            this.ivAnswer.TabStop = false;
            this.ivAnswer.Visible = false;
            this.ivAnswer.Click += new System.EventHandler(this.ivAnswer_Click);
            // 
            // ivHangup
            // 
            this.ivHangup.Cursor = System.Windows.Forms.Cursors.Default;
            this.ivHangup.Hovered = null;
            this.ivHangup.Image = global::AlinkMessager.Properties.Resources.Hangup;
            this.ivHangup.IsHovered = false;
            this.ivHangup.IsSelected = false;
            this.ivHangup.Location = new System.Drawing.Point(59, 75);
            this.ivHangup.Margin = new System.Windows.Forms.Padding(4);
            this.ivHangup.Name = "ivHangup";
            this.ivHangup.Normal = global::AlinkMessager.Properties.Resources.Hangup;
            this.ivHangup.Size = new System.Drawing.Size(32, 30);
            this.ivHangup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ivHangup.TabIndex = 15;
            this.ivHangup.TabStop = false;
            this.ivHangup.Visible = false;
            this.ivHangup.Click += new System.EventHandler(this.ivHangup_Click);
            // 
            // tmr_queue
            // 
            this.tmr_queue.Interval = 1000;
            this.tmr_queue.Tick += new System.EventHandler(this.tmr_queue_Tick);
            // 
            // rlv_agents
            // 
            this.rlv_agents.BackColor = System.Drawing.Color.Transparent;
            this.rlv_agents.Interval = 50;
            this.rlv_agents.Location = new System.Drawing.Point(16, 387);
            this.rlv_agents.Margin = new System.Windows.Forms.Padding(4);
            this.rlv_agents.Name = "rlv_agents";
            this.rlv_agents.ScrollEnabled = false;
            this.rlv_agents.Size = new System.Drawing.Size(251, 29);
            this.rlv_agents.TabIndex = 16;
            this.rlv_agents.Text = "接待员工:8001,8002,8003";
            this.rlv_agents.Visible = false;
            // 
            // cbx_login
            // 
            this.cbx_login.AutoSize = true;
            this.cbx_login.BackColor = System.Drawing.Color.Transparent;
            this.cbx_login.Checked = global::AlinkMessager.Properties.Settings.Default.AutoLogin;
            this.cbx_login.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_login.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AlinkMessager.Properties.Settings.Default, "AutoLogin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbx_login.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbx_login.Location = new System.Drawing.Point(19, 349);
            this.cbx_login.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_login.Name = "cbx_login";
            this.cbx_login.Size = new System.Drawing.Size(119, 19);
            this.cbx_login.TabIndex = 12;
            this.cbx_login.Text = "自动登录服务";
            this.cbx_login.UseVisualStyleBackColor = false;
            this.cbx_login.CheckedChanged += new System.EventHandler(this.cbx_login_CheckedChanged);
            // 
            // cbx_autorun
            // 
            this.cbx_autorun.AutoSize = true;
            this.cbx_autorun.BackColor = System.Drawing.Color.Transparent;
            this.cbx_autorun.Checked = global::AlinkMessager.Properties.Settings.Default.AutoRun;
            this.cbx_autorun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_autorun.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AlinkMessager.Properties.Settings.Default, "AutoRun", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbx_autorun.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbx_autorun.Location = new System.Drawing.Point(19, 322);
            this.cbx_autorun.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_autorun.Name = "cbx_autorun";
            this.cbx_autorun.Size = new System.Drawing.Size(119, 19);
            this.cbx_autorun.TabIndex = 11;
            this.cbx_autorun.Text = "系统自动运行";
            this.cbx_autorun.UseVisualStyleBackColor = false;
            this.cbx_autorun.CheckedChanged += new System.EventHandler(this.cbx_autorun_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 458);
            this.ContextMenuStrip = this.cms_main;
            this.Controls.Add(this.rlv_agents);
            this.Controls.Add(this.cbx_login);
            this.Controls.Add(this.cbx_autorun);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.iv_start);
            this.Controls.Add(this.gb_ailink);
            this.Controls.Add(this.gb_agents);
            this.Controls.Add(this.ivHangup);
            this.Controls.Add(this.ivAnswer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Opacity = 0.95D;
            this.Padding = new System.Windows.Forms.Padding(8, 30, 8, 8);
            this.Text = "AilinkServer消息客户端";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Controls.SetChildIndex(this.ivAnswer, 0);
            this.Controls.SetChildIndex(this.ivHangup, 0);
            this.Controls.SetChildIndex(this.gb_agents, 0);
            this.Controls.SetChildIndex(this.gb_ailink, 0);
            this.Controls.SetChildIndex(this.iv_start, 0);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.cbx_autorun, 0);
            this.Controls.SetChildIndex(this.cbx_login, 0);
            this.Controls.SetChildIndex(this.rlv_agents, 0);
            this.gb_ailink.ResumeLayout(false);
            this.gb_ailink.PerformLayout();
            this.gb_agents.ResumeLayout(false);
            this.gb_agents.PerformLayout();
            this.cms_main.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iv_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivHangup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_ailink;
        private System.Windows.Forms.GroupBox gb_agents;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_ipaddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_agent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip cms_main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_exit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private AheadTec.UIImageView uiImageView1;
        private AheadTec.UIImageView iv_start;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_about;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_start;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dialup;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsl_statu;
        private System.Windows.Forms.CheckBox cbx_autorun;
        private System.Windows.Forms.CheckBox cbx_login;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dnd;
        private System.Windows.Forms.ToolStripMenuItem tsmi_showmain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TextBox tb_firstcode;
        private System.Windows.Forms.Label label5;        
        private AheadTec.UIImageView ivAnswer;
        private AheadTec.UIImageView ivHangup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_transfer;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Conference;
        private System.Windows.Forms.Timer tmr_queue;
        private AheadTec.UIRaceLampView rlv_agents;
        private System.Windows.Forms.TextBox tb_employee;
        private System.Windows.Forms.Label label6;
    }
}


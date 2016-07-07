namespace Union_Lan_Server
{
    partial class f_Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Main));
            this.label_2 = new System.Windows.Forms.Label();
            this.panel_SocketInfo = new System.Windows.Forms.Panel();
            this.label_SocketStatus = new System.Windows.Forms.Label();
            this.button_ServerStart = new System.Windows.Forms.Button();
            this.button_ServerStop = new System.Windows.Forms.Button();
            this.label_SocketIP = new System.Windows.Forms.Label();
            this.checkBox_Main_socket = new System.Windows.Forms.CheckBox();
            this.panel_BaseStatus = new System.Windows.Forms.Panel();
            this.checkBox_Main_base = new System.Windows.Forms.CheckBox();
            this.checkBox_base_status_Path = new System.Windows.Forms.CheckBox();
            this.label_BaseStatus = new System.Windows.Forms.Label();
            this.button_ExitMain = new System.Windows.Forms.Button();
            this.panel_UsersStatus = new System.Windows.Forms.Panel();
            this.dataGridView_ConnectedRemotePoint = new System.Windows.Forms.DataGridView();
            this.label_Connections = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.button_CreateBase = new System.Windows.Forms.Button();
            this.button_MinimizeMain = new System.Windows.Forms.Button();
            this.label_ServerVersion = new System.Windows.Forms.Label();
            this.notifyIcon_Main = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_MainNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sHOWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sETTINGSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_Connection = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog_CreateBase = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel_SocketInfo.SuspendLayout();
            this.panel_BaseStatus.SuspendLayout();
            this.panel_UsersStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ConnectedRemotePoint)).BeginInit();
            this.panel_Main.SuspendLayout();
            this.contextMenuStrip_MainNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_2
            // 
            this.label_2.AutoSize = true;
            this.label_2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_2.Location = new System.Drawing.Point(3, 0);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(74, 15);
            this.label_2.TabIndex = 1;
            this.label_2.Text = "Статус сети";
            // 
            // panel_SocketInfo
            // 
            this.panel_SocketInfo.BackColor = System.Drawing.Color.Silver;
            this.panel_SocketInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_SocketInfo.Controls.Add(this.label_SocketStatus);
            this.panel_SocketInfo.Controls.Add(this.button_ServerStart);
            this.panel_SocketInfo.Controls.Add(this.button_ServerStop);
            this.panel_SocketInfo.Controls.Add(this.label_SocketIP);
            this.panel_SocketInfo.Controls.Add(this.checkBox_Main_socket);
            this.panel_SocketInfo.Controls.Add(this.label_2);
            this.panel_SocketInfo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.panel_SocketInfo.Location = new System.Drawing.Point(3, 41);
            this.panel_SocketInfo.Name = "panel_SocketInfo";
            this.panel_SocketInfo.Size = new System.Drawing.Size(160, 146);
            this.panel_SocketInfo.TabIndex = 2;
            // 
            // label_SocketStatus
            // 
            this.label_SocketStatus.AutoSize = true;
            this.label_SocketStatus.Font = new System.Drawing.Font("Times New Roman", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_SocketStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_SocketStatus.Location = new System.Drawing.Point(6, 66);
            this.label_SocketStatus.Name = "label_SocketStatus";
            this.label_SocketStatus.Size = new System.Drawing.Size(0, 13);
            this.label_SocketStatus.TabIndex = 10;
            // 
            // button_ServerStart
            // 
            this.button_ServerStart.BackColor = System.Drawing.Color.CadetBlue;
            this.button_ServerStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ServerStart.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ServerStart.ForeColor = System.Drawing.Color.White;
            this.button_ServerStart.Location = new System.Drawing.Point(7, 104);
            this.button_ServerStart.Name = "button_ServerStart";
            this.button_ServerStart.Size = new System.Drawing.Size(67, 35);
            this.button_ServerStart.TabIndex = 8;
            this.button_ServerStart.Text = "СТАРТ";
            this.button_ServerStart.UseVisualStyleBackColor = false;
            this.button_ServerStart.Click += new System.EventHandler(this.button_ServerStart_Click);
            // 
            // button_ServerStop
            // 
            this.button_ServerStop.BackColor = System.Drawing.Color.IndianRed;
            this.button_ServerStop.Enabled = false;
            this.button_ServerStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ServerStop.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ServerStop.ForeColor = System.Drawing.Color.White;
            this.button_ServerStop.Location = new System.Drawing.Point(80, 104);
            this.button_ServerStop.Name = "button_ServerStop";
            this.button_ServerStop.Size = new System.Drawing.Size(67, 35);
            this.button_ServerStop.TabIndex = 9;
            this.button_ServerStop.Text = "СТОП";
            this.button_ServerStop.UseVisualStyleBackColor = false;
            this.button_ServerStop.Click += new System.EventHandler(this.button_ServerStop_Click);
            // 
            // label_SocketIP
            // 
            this.label_SocketIP.AutoSize = true;
            this.label_SocketIP.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_SocketIP.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_SocketIP.Location = new System.Drawing.Point(6, 26);
            this.label_SocketIP.Name = "label_SocketIP";
            this.label_SocketIP.Size = new System.Drawing.Size(64, 15);
            this.label_SocketIP.TabIndex = 3;
            this.label_SocketIP.Text = "IP сервера";
            // 
            // checkBox_Main_socket
            // 
            this.checkBox_Main_socket.AutoSize = true;
            this.checkBox_Main_socket.Enabled = false;
            this.checkBox_Main_socket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_Main_socket.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBox_Main_socket.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBox_Main_socket.Location = new System.Drawing.Point(7, 44);
            this.checkBox_Main_socket.Name = "checkBox_Main_socket";
            this.checkBox_Main_socket.Size = new System.Drawing.Size(148, 19);
            this.checkBox_Main_socket.TabIndex = 2;
            this.checkBox_Main_socket.Text = "Подключение сервера";
            this.checkBox_Main_socket.UseVisualStyleBackColor = true;
            // 
            // panel_BaseStatus
            // 
            this.panel_BaseStatus.BackColor = System.Drawing.Color.Silver;
            this.panel_BaseStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_BaseStatus.Controls.Add(this.checkBox_Main_base);
            this.panel_BaseStatus.Controls.Add(this.checkBox_base_status_Path);
            this.panel_BaseStatus.Controls.Add(this.label_BaseStatus);
            this.panel_BaseStatus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.panel_BaseStatus.Location = new System.Drawing.Point(168, 41);
            this.panel_BaseStatus.Name = "panel_BaseStatus";
            this.panel_BaseStatus.Size = new System.Drawing.Size(141, 146);
            this.panel_BaseStatus.TabIndex = 3;
            // 
            // checkBox_Main_base
            // 
            this.checkBox_Main_base.AutoSize = true;
            this.checkBox_Main_base.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBox_Main_base.Enabled = false;
            this.checkBox_Main_base.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_Main_base.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBox_Main_base.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBox_Main_base.Location = new System.Drawing.Point(7, 44);
            this.checkBox_Main_base.Name = "checkBox_Main_base";
            this.checkBox_Main_base.Size = new System.Drawing.Size(100, 19);
            this.checkBox_Main_base.TabIndex = 4;
            this.checkBox_Main_base.Text = "Основная БД";
            this.checkBox_Main_base.UseVisualStyleBackColor = true;
            // 
            // checkBox_base_status_Path
            // 
            this.checkBox_base_status_Path.AutoSize = true;
            this.checkBox_base_status_Path.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox_base_status_Path.Enabled = false;
            this.checkBox_base_status_Path.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_base_status_Path.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBox_base_status_Path.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBox_base_status_Path.Location = new System.Drawing.Point(7, 25);
            this.checkBox_base_status_Path.Name = "checkBox_base_status_Path";
            this.checkBox_base_status_Path.Size = new System.Drawing.Size(82, 19);
            this.checkBox_base_status_Path.TabIndex = 3;
            this.checkBox_base_status_Path.Text = "Путь к БД";
            this.checkBox_base_status_Path.UseVisualStyleBackColor = true;
            // 
            // label_BaseStatus
            // 
            this.label_BaseStatus.AutoSize = true;
            this.label_BaseStatus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_BaseStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_BaseStatus.Location = new System.Drawing.Point(3, 0);
            this.label_BaseStatus.Name = "label_BaseStatus";
            this.label_BaseStatus.Size = new System.Drawing.Size(67, 15);
            this.label_BaseStatus.TabIndex = 1;
            this.label_BaseStatus.Text = "Статус БД";
            // 
            // button_ExitMain
            // 
            this.button_ExitMain.BackColor = System.Drawing.Color.SteelBlue;
            this.button_ExitMain.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_ExitMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ExitMain.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ExitMain.ForeColor = System.Drawing.Color.Honeydew;
            this.button_ExitMain.Location = new System.Drawing.Point(512, 3);
            this.button_ExitMain.Name = "button_ExitMain";
            this.button_ExitMain.Size = new System.Drawing.Size(67, 22);
            this.button_ExitMain.TabIndex = 4;
            this.button_ExitMain.Text = "ВЫХОД";
            this.button_ExitMain.UseVisualStyleBackColor = false;
            this.button_ExitMain.Click += new System.EventHandler(this.button_ExitMain_Click);
            // 
            // panel_UsersStatus
            // 
            this.panel_UsersStatus.BackColor = System.Drawing.Color.Silver;
            this.panel_UsersStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_UsersStatus.Controls.Add(this.dataGridView_ConnectedRemotePoint);
            this.panel_UsersStatus.Controls.Add(this.label_Connections);
            this.panel_UsersStatus.Controls.Add(this.label1);
            this.panel_UsersStatus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.panel_UsersStatus.Location = new System.Drawing.Point(315, 27);
            this.panel_UsersStatus.Name = "panel_UsersStatus";
            this.panel_UsersStatus.Size = new System.Drawing.Size(263, 365);
            this.panel_UsersStatus.TabIndex = 5;
            // 
            // dataGridView_ConnectedRemotePoint
            // 
            this.dataGridView_ConnectedRemotePoint.AllowUserToAddRows = false;
            this.dataGridView_ConnectedRemotePoint.AllowUserToDeleteRows = false;
            this.dataGridView_ConnectedRemotePoint.AllowUserToResizeColumns = false;
            this.dataGridView_ConnectedRemotePoint.AllowUserToResizeRows = false;
            this.dataGridView_ConnectedRemotePoint.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_ConnectedRemotePoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ConnectedRemotePoint.ColumnHeadersVisible = false;
            this.dataGridView_ConnectedRemotePoint.Location = new System.Drawing.Point(1, 46);
            this.dataGridView_ConnectedRemotePoint.MultiSelect = false;
            this.dataGridView_ConnectedRemotePoint.Name = "dataGridView_ConnectedRemotePoint";
            this.dataGridView_ConnectedRemotePoint.ReadOnly = true;
            this.dataGridView_ConnectedRemotePoint.RowHeadersVisible = false;
            this.dataGridView_ConnectedRemotePoint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ConnectedRemotePoint.Size = new System.Drawing.Size(259, 316);
            this.dataGridView_ConnectedRemotePoint.TabIndex = 3;
            // 
            // label_Connections
            // 
            this.label_Connections.AutoSize = true;
            this.label_Connections.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Connections.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_Connections.Location = new System.Drawing.Point(4, 26);
            this.label_Connections.Name = "label_Connections";
            this.label_Connections.Size = new System.Drawing.Size(93, 15);
            this.label_Connections.TabIndex = 2;
            this.label_Connections.Text = "Подключено: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Статус пользователей";
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.Color.White;
            this.panel_Main.Controls.Add(this.button2);
            this.panel_Main.Controls.Add(this.button1);
            this.panel_Main.Controls.Add(this.button_CreateBase);
            this.panel_Main.Controls.Add(this.button_MinimizeMain);
            this.panel_Main.Controls.Add(this.label_ServerVersion);
            this.panel_Main.Controls.Add(this.button_ExitMain);
            this.panel_Main.Controls.Add(this.panel_UsersStatus);
            this.panel_Main.Controls.Add(this.panel_BaseStatus);
            this.panel_Main.Controls.Add(this.panel_SocketInfo);
            this.panel_Main.Location = new System.Drawing.Point(2, 2);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(582, 417);
            this.panel_Main.TabIndex = 6;
            this.panel_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Main_MouseDown);
            this.panel_Main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Main_MouseMove);
            this.panel_Main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Main_MouseUp);
            // 
            // button_CreateBase
            // 
            this.button_CreateBase.BackColor = System.Drawing.Color.CadetBlue;
            this.button_CreateBase.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button_CreateBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CreateBase.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CreateBase.ForeColor = System.Drawing.Color.White;
            this.button_CreateBase.Location = new System.Drawing.Point(4, 3);
            this.button_CreateBase.Name = "button_CreateBase";
            this.button_CreateBase.Size = new System.Drawing.Size(84, 35);
            this.button_CreateBase.TabIndex = 10;
            this.button_CreateBase.Text = "СОЗДАТЬ БАЗУ";
            this.button_CreateBase.UseVisualStyleBackColor = false;
            this.button_CreateBase.Click += new System.EventHandler(this.button_CreateBase_Click);
            // 
            // button_MinimizeMain
            // 
            this.button_MinimizeMain.BackColor = System.Drawing.Color.SteelBlue;
            this.button_MinimizeMain.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_MinimizeMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MinimizeMain.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_MinimizeMain.ForeColor = System.Drawing.Color.Honeydew;
            this.button_MinimizeMain.Location = new System.Drawing.Point(444, 3);
            this.button_MinimizeMain.Name = "button_MinimizeMain";
            this.button_MinimizeMain.Size = new System.Drawing.Size(66, 22);
            this.button_MinimizeMain.TabIndex = 7;
            this.button_MinimizeMain.Text = "СКРЫТЬ";
            this.button_MinimizeMain.UseVisualStyleBackColor = false;
            this.button_MinimizeMain.Click += new System.EventHandler(this.button_MinimizeMain_Click);
            // 
            // label_ServerVersion
            // 
            this.label_ServerVersion.AutoSize = true;
            this.label_ServerVersion.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ServerVersion.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_ServerVersion.Location = new System.Drawing.Point(3, 397);
            this.label_ServerVersion.Name = "label_ServerVersion";
            this.label_ServerVersion.Size = new System.Drawing.Size(104, 13);
            this.label_ServerVersion.TabIndex = 6;
            this.label_ServerVersion.Text = "UNION SERVER v. ";
            // 
            // notifyIcon_Main
            // 
            this.notifyIcon_Main.ContextMenuStrip = this.contextMenuStrip_MainNotify;
            this.notifyIcon_Main.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_Main.Icon")));
            this.notifyIcon_Main.Visible = true;
            this.notifyIcon_Main.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_Main_MouseDoubleClick);
            // 
            // contextMenuStrip_MainNotify
            // 
            this.contextMenuStrip_MainNotify.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contextMenuStrip_MainNotify.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contextMenuStrip_MainNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sHOWToolStripMenuItem,
            this.sETTINGSToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.contextMenuStrip_MainNotify.Name = "contextMenuStrip_MainNotify";
            this.contextMenuStrip_MainNotify.Size = new System.Drawing.Size(136, 70);
            // 
            // sHOWToolStripMenuItem
            // 
            this.sHOWToolStripMenuItem.Name = "sHOWToolStripMenuItem";
            this.sHOWToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.sHOWToolStripMenuItem.Text = "SHOW";
            this.sHOWToolStripMenuItem.Click += new System.EventHandler(this.sHOWToolStripMenuItem_Click);
            // 
            // sETTINGSToolStripMenuItem
            // 
            this.sETTINGSToolStripMenuItem.Name = "sETTINGSToolStripMenuItem";
            this.sETTINGSToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.sETTINGSToolStripMenuItem.Text = "SETTINGS";
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // timer_Connection
            // 
            this.timer_Connection.Interval = 5000;
            this.timer_Connection.Tick += new System.EventHandler(this.timer_Connection_Tick);
            // 
            // folderBrowserDialog_CreateBase
            // 
            this.folderBrowserDialog_CreateBase.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CadetBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(186, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "НАСТРОЙКИ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CadetBlue;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(91, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "ПОЛЬЗОВАТЕЛИ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // f_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(586, 421);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Main);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_Main_FormClosing);
            this.Load += new System.EventHandler(this.f_Main_Load);
            this.panel_SocketInfo.ResumeLayout(false);
            this.panel_SocketInfo.PerformLayout();
            this.panel_BaseStatus.ResumeLayout(false);
            this.panel_BaseStatus.PerformLayout();
            this.panel_UsersStatus.ResumeLayout(false);
            this.panel_UsersStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ConnectedRemotePoint)).EndInit();
            this.panel_Main.ResumeLayout(false);
            this.panel_Main.PerformLayout();
            this.contextMenuStrip_MainNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_2;
        private System.Windows.Forms.Panel panel_SocketInfo;
        private System.Windows.Forms.Panel panel_BaseStatus;
        private System.Windows.Forms.Label label_BaseStatus;
        public System.Windows.Forms.CheckBox checkBox_base_status_Path;
        public System.Windows.Forms.CheckBox checkBox_Main_base;
        private System.Windows.Forms.Button button_ExitMain;
        public System.Windows.Forms.CheckBox checkBox_Main_socket;
        private System.Windows.Forms.Label label_SocketIP;
        private System.Windows.Forms.Panel panel_UsersStatus;
        private System.Windows.Forms.Label label_Connections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.Label label_ServerVersion;
        private System.Windows.Forms.Button button_MinimizeMain;
        private System.Windows.Forms.NotifyIcon notifyIcon_Main;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_MainNotify;
        private System.Windows.Forms.ToolStripMenuItem sHOWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sETTINGSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.Button button_ServerStart;
        private System.Windows.Forms.Button button_ServerStop;
        private System.Windows.Forms.DataGridView dataGridView_ConnectedRemotePoint;
        private System.Windows.Forms.Timer timer_Connection;
        private System.Windows.Forms.Button button_CreateBase;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_CreateBase;
        private System.Windows.Forms.Label label_SocketStatus;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;

    }
}


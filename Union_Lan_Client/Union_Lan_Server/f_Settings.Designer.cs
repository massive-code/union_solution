namespace Union_Lan_Client
{
    partial class f_Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl_Settings = new System.Windows.Forms.TabControl();
            this.tabPage_Connection = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ServerPort = new System.Windows.Forms.TextBox();
            this.checkBox_ProxyEnable = new System.Windows.Forms.CheckBox();
            this.groupBox_ProxySettings = new System.Windows.Forms.GroupBox();
            this.textBox_ProxyPort = new System.Windows.Forms.TextBox();
            this.textBox_ProxyIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.tabPage_Main = new System.Windows.Forms.TabPage();
            this.checkBox_RememberPassword = new System.Windows.Forms.CheckBox();
            this.label_ProgrammLink = new System.Windows.Forms.Label();
            this.checkBox_Autostart = new System.Windows.Forms.CheckBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.panel_SettingMain = new System.Windows.Forms.Panel();
            this.tabControl_Settings.SuspendLayout();
            this.tabPage_Connection.SuspendLayout();
            this.groupBox_ProxySettings.SuspendLayout();
            this.tabPage_Main.SuspendLayout();
            this.panel_SettingMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Settings
            // 
            this.tabControl_Settings.Controls.Add(this.tabPage_Connection);
            this.tabControl_Settings.Controls.Add(this.tabPage_Main);
            this.tabControl_Settings.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl_Settings.Location = new System.Drawing.Point(3, 3);
            this.tabControl_Settings.Name = "tabControl_Settings";
            this.tabControl_Settings.SelectedIndex = 0;
            this.tabControl_Settings.Size = new System.Drawing.Size(423, 205);
            this.tabControl_Settings.TabIndex = 0;
            // 
            // tabPage_Connection
            // 
            this.tabPage_Connection.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_Connection.Controls.Add(this.label4);
            this.tabPage_Connection.Controls.Add(this.textBox_ServerPort);
            this.tabPage_Connection.Controls.Add(this.checkBox_ProxyEnable);
            this.tabPage_Connection.Controls.Add(this.groupBox_ProxySettings);
            this.tabPage_Connection.Controls.Add(this.label1);
            this.tabPage_Connection.Controls.Add(this.textBox_ServerIP);
            this.tabPage_Connection.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Connection.Name = "tabPage_Connection";
            this.tabPage_Connection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Connection.Size = new System.Drawing.Size(415, 177);
            this.tabPage_Connection.TabIndex = 0;
            this.tabPage_Connection.Text = "Подключение";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(215, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Порт сервера:";
            // 
            // textBox_ServerPort
            // 
            this.textBox_ServerPort.Location = new System.Drawing.Point(305, 6);
            this.textBox_ServerPort.Name = "textBox_ServerPort";
            this.textBox_ServerPort.Size = new System.Drawing.Size(46, 22);
            this.textBox_ServerPort.TabIndex = 3;
            // 
            // checkBox_ProxyEnable
            // 
            this.checkBox_ProxyEnable.AutoSize = true;
            this.checkBox_ProxyEnable.Location = new System.Drawing.Point(15, 33);
            this.checkBox_ProxyEnable.Name = "checkBox_ProxyEnable";
            this.checkBox_ProxyEnable.Size = new System.Drawing.Size(15, 14);
            this.checkBox_ProxyEnable.TabIndex = 0;
            this.checkBox_ProxyEnable.UseVisualStyleBackColor = true;
            this.checkBox_ProxyEnable.CheckedChanged += new System.EventHandler(this.checkBox_ProxyEnable_CheckedChanged);
            // 
            // groupBox_ProxySettings
            // 
            this.groupBox_ProxySettings.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_ProxySettings.Controls.Add(this.textBox_ProxyPort);
            this.groupBox_ProxySettings.Controls.Add(this.textBox_ProxyIP);
            this.groupBox_ProxySettings.Controls.Add(this.label3);
            this.groupBox_ProxySettings.Controls.Add(this.label2);
            this.groupBox_ProxySettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox_ProxySettings.Location = new System.Drawing.Point(7, 32);
            this.groupBox_ProxySettings.Name = "groupBox_ProxySettings";
            this.groupBox_ProxySettings.Size = new System.Drawing.Size(359, 51);
            this.groupBox_ProxySettings.TabIndex = 2;
            this.groupBox_ProxySettings.TabStop = false;
            this.groupBox_ProxySettings.Text = "     Прокси";
            // 
            // textBox_ProxyPort
            // 
            this.textBox_ProxyPort.Location = new System.Drawing.Point(298, 19);
            this.textBox_ProxyPort.Name = "textBox_ProxyPort";
            this.textBox_ProxyPort.Size = new System.Drawing.Size(46, 22);
            this.textBox_ProxyPort.TabIndex = 4;
            // 
            // textBox_ProxyIP
            // 
            this.textBox_ProxyIP.Location = new System.Drawing.Point(98, 19);
            this.textBox_ProxyIP.Name = "textBox_ProxyIP";
            this.textBox_ProxyIP.Size = new System.Drawing.Size(100, 22);
            this.textBox_ProxyIP.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(208, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Порт прокси: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP прокси: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP сервера:";
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(105, 6);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(100, 22);
            this.textBox_ServerIP.TabIndex = 0;
            // 
            // tabPage_Main
            // 
            this.tabPage_Main.Controls.Add(this.checkBox_RememberPassword);
            this.tabPage_Main.Controls.Add(this.label_ProgrammLink);
            this.tabPage_Main.Controls.Add(this.checkBox_Autostart);
            this.tabPage_Main.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Main.Name = "tabPage_Main";
            this.tabPage_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Main.Size = new System.Drawing.Size(415, 177);
            this.tabPage_Main.TabIndex = 1;
            this.tabPage_Main.Text = "Основные";
            this.tabPage_Main.UseVisualStyleBackColor = true;
            // 
            // checkBox_RememberPassword
            // 
            this.checkBox_RememberPassword.AutoSize = true;
            this.checkBox_RememberPassword.Location = new System.Drawing.Point(8, 50);
            this.checkBox_RememberPassword.Name = "checkBox_RememberPassword";
            this.checkBox_RememberPassword.Size = new System.Drawing.Size(129, 19);
            this.checkBox_RememberPassword.TabIndex = 5;
            this.checkBox_RememberPassword.Text = "Запомнить пароль";
            this.checkBox_RememberPassword.UseVisualStyleBackColor = true;
            // 
            // label_ProgrammLink
            // 
            this.label_ProgrammLink.AutoSize = true;
            this.label_ProgrammLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_ProgrammLink.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ProgrammLink.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_ProgrammLink.Location = new System.Drawing.Point(6, 29);
            this.label_ProgrammLink.Name = "label_ProgrammLink";
            this.label_ProgrammLink.Size = new System.Drawing.Size(188, 15);
            this.label_ProgrammLink.TabIndex = 4;
            this.label_ProgrammLink.Text = "Создать ярлык на рабочем столе";
            this.label_ProgrammLink.Click += new System.EventHandler(this.label_ProgrammLink_Click);
            // 
            // checkBox_Autostart
            // 
            this.checkBox_Autostart.AutoSize = true;
            this.checkBox_Autostart.Location = new System.Drawing.Point(8, 7);
            this.checkBox_Autostart.Name = "checkBox_Autostart";
            this.checkBox_Autostart.Size = new System.Drawing.Size(207, 19);
            this.checkBox_Autostart.TabIndex = 0;
            this.checkBox_Autostart.Text = "Автозапуск при старте Windows";
            this.checkBox_Autostart.UseVisualStyleBackColor = true;
            this.checkBox_Autostart.CheckedChanged += new System.EventHandler(this.checkBox_Autostart_CheckedChanged);
            // 
            // button_Save
            // 
            this.button_Save.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Save.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Save.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Save.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_Save.Location = new System.Drawing.Point(251, 210);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(93, 47);
            this.button_Save.TabIndex = 11;
            this.button_Save.Text = "СОХРАНИТЬ";
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Close.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Close.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_Close.Location = new System.Drawing.Point(348, 210);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 47);
            this.button_Close.TabIndex = 12;
            this.button_Close.Text = "ЗАКРЫТЬ";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // panel_SettingMain
            // 
            this.panel_SettingMain.BackColor = System.Drawing.Color.White;
            this.panel_SettingMain.Controls.Add(this.tabControl_Settings);
            this.panel_SettingMain.Controls.Add(this.button_Close);
            this.panel_SettingMain.Controls.Add(this.button_Save);
            this.panel_SettingMain.Location = new System.Drawing.Point(1, 1);
            this.panel_SettingMain.Name = "panel_SettingMain";
            this.panel_SettingMain.Size = new System.Drawing.Size(430, 260);
            this.panel_SettingMain.TabIndex = 13;
            // 
            // f_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(432, 262);
            this.ControlBox = false;
            this.Controls.Add(this.panel_SettingMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.f_Settings_Load);
            this.tabControl_Settings.ResumeLayout(false);
            this.tabPage_Connection.ResumeLayout(false);
            this.tabPage_Connection.PerformLayout();
            this.groupBox_ProxySettings.ResumeLayout(false);
            this.groupBox_ProxySettings.PerformLayout();
            this.tabPage_Main.ResumeLayout(false);
            this.tabPage_Main.PerformLayout();
            this.panel_SettingMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Settings;
        private System.Windows.Forms.TabPage tabPage_Connection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.GroupBox groupBox_ProxySettings;
        private System.Windows.Forms.CheckBox checkBox_ProxyEnable;
        private System.Windows.Forms.TextBox textBox_ProxyPort;
        private System.Windows.Forms.TextBox textBox_ProxyIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ServerPort;
        private System.Windows.Forms.TabPage tabPage_Main;
        private System.Windows.Forms.CheckBox checkBox_Autostart;
        private System.Windows.Forms.Panel panel_SettingMain;
        private System.Windows.Forms.Label label_ProgrammLink;
        private System.Windows.Forms.CheckBox checkBox_RememberPassword;
    }
}
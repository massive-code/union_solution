namespace Union_Lan_Server
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
            this.textBox_BasePath = new System.Windows.Forms.TextBox();
            this.button_CloseSettings = new System.Windows.Forms.Button();
            this.button_SaveSettings = new System.Windows.Forms.Button();
            this.button_BasePath = new System.Windows.Forms.Button();
            this.folderBrowserDialog_BasePathSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.panel_Settings = new System.Windows.Forms.Panel();
            this.checkBox_AutoStart = new System.Windows.Forms.CheckBox();
            this.comboBox_IP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ClientVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_SocketPort = new System.Windows.Forms.TextBox();
            this.panel_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_BasePath
            // 
            this.textBox_BasePath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_BasePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_BasePath.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.textBox_BasePath.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.textBox_BasePath.Location = new System.Drawing.Point(10, 39);
            this.textBox_BasePath.Name = "textBox_BasePath";
            this.textBox_BasePath.ReadOnly = true;
            this.textBox_BasePath.Size = new System.Drawing.Size(306, 22);
            this.textBox_BasePath.TabIndex = 0;
            // 
            // button_CloseSettings
            // 
            this.button_CloseSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.button_CloseSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CloseSettings.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_CloseSettings.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_CloseSettings.ImageKey = "pict_RemoveContact.png";
            this.button_CloseSettings.Location = new System.Drawing.Point(322, 206);
            this.button_CloseSettings.Name = "button_CloseSettings";
            this.button_CloseSettings.Size = new System.Drawing.Size(75, 28);
            this.button_CloseSettings.TabIndex = 3;
            this.button_CloseSettings.Text = "закрыть";
            this.button_CloseSettings.UseVisualStyleBackColor = false;
            this.button_CloseSettings.Click += new System.EventHandler(this.button_CloseSettings_Click);
            // 
            // button_SaveSettings
            // 
            this.button_SaveSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.button_SaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SaveSettings.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_SaveSettings.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_SaveSettings.ImageKey = "pict_SaveSettings.png";
            this.button_SaveSettings.Location = new System.Drawing.Point(322, 172);
            this.button_SaveSettings.Name = "button_SaveSettings";
            this.button_SaveSettings.Size = new System.Drawing.Size(75, 28);
            this.button_SaveSettings.TabIndex = 2;
            this.button_SaveSettings.Text = "сохранить";
            this.button_SaveSettings.UseVisualStyleBackColor = false;
            this.button_SaveSettings.Click += new System.EventHandler(this.button_SaveSettings_Click);
            // 
            // button_BasePath
            // 
            this.button_BasePath.BackColor = System.Drawing.Color.Gainsboro;
            this.button_BasePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_BasePath.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_BasePath.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_BasePath.ImageKey = "pict_SelectBaseFolder.png";
            this.button_BasePath.Location = new System.Drawing.Point(322, 36);
            this.button_BasePath.Name = "button_BasePath";
            this.button_BasePath.Size = new System.Drawing.Size(75, 26);
            this.button_BasePath.TabIndex = 1;
            this.button_BasePath.Text = "выбрать";
            this.button_BasePath.UseVisualStyleBackColor = false;
            this.button_BasePath.Click += new System.EventHandler(this.button_BasePath_Click);
            // 
            // panel_Settings
            // 
            this.panel_Settings.BackColor = System.Drawing.Color.White;
            this.panel_Settings.Controls.Add(this.checkBox_AutoStart);
            this.panel_Settings.Controls.Add(this.comboBox_IP);
            this.panel_Settings.Controls.Add(this.label3);
            this.panel_Settings.Controls.Add(this.textBox_ClientVersion);
            this.panel_Settings.Controls.Add(this.label2);
            this.panel_Settings.Controls.Add(this.label1);
            this.panel_Settings.Controls.Add(this.textBox_SocketPort);
            this.panel_Settings.Controls.Add(this.textBox_BasePath);
            this.panel_Settings.Controls.Add(this.button_CloseSettings);
            this.panel_Settings.Controls.Add(this.button_BasePath);
            this.panel_Settings.Controls.Add(this.button_SaveSettings);
            this.panel_Settings.Location = new System.Drawing.Point(2, 2);
            this.panel_Settings.Name = "panel_Settings";
            this.panel_Settings.Size = new System.Drawing.Size(408, 250);
            this.panel_Settings.TabIndex = 4;
            // 
            // checkBox_AutoStart
            // 
            this.checkBox_AutoStart.AutoSize = true;
            this.checkBox_AutoStart.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBox_AutoStart.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBox_AutoStart.Location = new System.Drawing.Point(6, 155);
            this.checkBox_AutoStart.Name = "checkBox_AutoStart";
            this.checkBox_AutoStart.Size = new System.Drawing.Size(200, 19);
            this.checkBox_AutoStart.TabIndex = 11;
            this.checkBox_AutoStart.Text = "Автозапуск при старте ситемы";
            this.checkBox_AutoStart.UseVisualStyleBackColor = true;
            this.checkBox_AutoStart.CheckedChanged += new System.EventHandler(this.checkBox_AutoStart_CheckedChanged);
            // 
            // comboBox_IP
            // 
            this.comboBox_IP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox_IP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_IP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_IP.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.comboBox_IP.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.comboBox_IP.FormattingEnabled = true;
            this.comboBox_IP.Location = new System.Drawing.Point(104, 64);
            this.comboBox_IP.Name = "comboBox_IP";
            this.comboBox_IP.Size = new System.Drawing.Size(121, 23);
            this.comboBox_IP.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(3, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Версия клиента";
            // 
            // textBox_ClientVersion
            // 
            this.textBox_ClientVersion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_ClientVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ClientVersion.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.textBox_ClientVersion.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.textBox_ClientVersion.Location = new System.Drawing.Point(105, 125);
            this.textBox_ClientVersion.Name = "textBox_ClientVersion";
            this.textBox_ClientVersion.ReadOnly = true;
            this.textBox_ClientVersion.Size = new System.Drawing.Size(100, 22);
            this.textBox_ClientVersion.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(3, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Порт сервера";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(3, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP сервера";
            // 
            // textBox_SocketPort
            // 
            this.textBox_SocketPort.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_SocketPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_SocketPort.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.textBox_SocketPort.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.textBox_SocketPort.Location = new System.Drawing.Point(105, 93);
            this.textBox_SocketPort.Name = "textBox_SocketPort";
            this.textBox_SocketPort.Size = new System.Drawing.Size(100, 22);
            this.textBox_SocketPort.TabIndex = 5;
            // 
            // f_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(412, 254);
            this.Controls.Add(this.panel_Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.f_Settings_Load);
            this.panel_Settings.ResumeLayout(false);
            this.panel_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_BasePath;
        private System.Windows.Forms.Button button_BasePath;
        private System.Windows.Forms.Button button_SaveSettings;
        private System.Windows.Forms.Button button_CloseSettings;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_BasePathSelect;
        private System.Windows.Forms.Panel panel_Settings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_SocketPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ClientVersion;
        private System.Windows.Forms.ComboBox comboBox_IP;
        private System.Windows.Forms.CheckBox checkBox_AutoStart;
    }
}
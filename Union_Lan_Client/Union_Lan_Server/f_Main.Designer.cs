namespace Union_Lan_Client
{
    partial class f_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Main));
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.button_SignIn = new System.Windows.Forms.Button();
            this.panel_ServerStatus = new System.Windows.Forms.Panel();
            this.notifyIcon_Main = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_MainBack = new System.Windows.Forms.Panel();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Registartion = new System.Windows.Forms.Label();
            this.checkBox_RememberLogin = new System.Windows.Forms.CheckBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_UserName = new System.Windows.Forms.Label();
            this.label4_Version = new System.Windows.Forms.Label();
            this.pictureBox_Hide = new System.Windows.Forms.PictureBox();
            this.pictureBox_Loading = new System.Windows.Forms.PictureBox();
            this.pictureBox_Settings = new System.Windows.Forms.PictureBox();
            this.label_UnionLan = new System.Windows.Forms.Label();
            this.pictureBox_Exit = new System.Windows.Forms.PictureBox();
            this.label_Connection = new System.Windows.Forms.Label();
            this.contextMenuStrip_Main.SuspendLayout();
            this.panel_MainBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Loading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Login
            // 
            this.textBox_Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Login.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Login.Location = new System.Drawing.Point(49, 82);
            this.textBox_Login.MaxLength = 15;
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(196, 26);
            this.textBox_Login.TabIndex = 5;
            this.textBox_Login.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SignIn
            // 
            this.button_SignIn.BackColor = System.Drawing.Color.SkyBlue;
            this.button_SignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SignIn.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.button_SignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SignIn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_SignIn.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_SignIn.Location = new System.Drawing.Point(102, 180);
            this.button_SignIn.Name = "button_SignIn";
            this.button_SignIn.Size = new System.Drawing.Size(95, 44);
            this.button_SignIn.TabIndex = 1;
            this.button_SignIn.Text = "ВОЙТИ";
            this.button_SignIn.UseVisualStyleBackColor = false;
            this.button_SignIn.Click += new System.EventHandler(this.button_SignIn_Click);
            // 
            // panel_ServerStatus
            // 
            this.panel_ServerStatus.BackColor = System.Drawing.Color.Red;
            this.panel_ServerStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_ServerStatus.Location = new System.Drawing.Point(4, 7);
            this.panel_ServerStatus.Name = "panel_ServerStatus";
            this.panel_ServerStatus.Size = new System.Drawing.Size(10, 10);
            this.panel_ServerStatus.TabIndex = 7;
            // 
            // notifyIcon_Main
            // 
            this.notifyIcon_Main.ContextMenuStrip = this.contextMenuStrip_Main;
            this.notifyIcon_Main.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_Main.Icon")));
            this.notifyIcon_Main.Visible = true;
            this.notifyIcon_Main.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_Main_MouseDoubleClick);
            // 
            // contextMenuStrip_Main
            // 
            this.contextMenuStrip_Main.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.contextMenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.contextMenuStrip_Main.Name = "contextMenuStrip_Main";
            this.contextMenuStrip_Main.Size = new System.Drawing.Size(113, 26);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.закрытьToolStripMenuItem.Text = "Выход";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // panel_MainBack
            // 
            this.panel_MainBack.BackgroundImage = global::Union_Lan_Client.Properties.Resources.pict_MainBack;
            this.panel_MainBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_MainBack.Controls.Add(this.textBox_Password);
            this.panel_MainBack.Controls.Add(this.label_Registartion);
            this.panel_MainBack.Controls.Add(this.checkBox_RememberLogin);
            this.panel_MainBack.Controls.Add(this.label_Password);
            this.panel_MainBack.Controls.Add(this.label_UserName);
            this.panel_MainBack.Controls.Add(this.label4_Version);
            this.panel_MainBack.Controls.Add(this.pictureBox_Hide);
            this.panel_MainBack.Controls.Add(this.pictureBox_Loading);
            this.panel_MainBack.Controls.Add(this.pictureBox_Settings);
            this.panel_MainBack.Controls.Add(this.label_UnionLan);
            this.panel_MainBack.Controls.Add(this.pictureBox_Exit);
            this.panel_MainBack.Controls.Add(this.label_Connection);
            this.panel_MainBack.Location = new System.Drawing.Point(0, 0);
            this.panel_MainBack.Name = "panel_MainBack";
            this.panel_MainBack.Size = new System.Drawing.Size(300, 300);
            this.panel_MainBack.TabIndex = 18;
            this.panel_MainBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MainBack_MouseDown);
            this.panel_MainBack.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MainBack_MouseMove);
            this.panel_MainBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MainBack_MouseUp);
            // 
            // textBox_Password
            // 
            this.textBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Password.Location = new System.Drawing.Point(49, 129);
            this.textBox_Password.MaxLength = 15;
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(196, 26);
            this.textBox_Password.TabIndex = 19;
            this.textBox_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Password_KeyDown);
            // 
            // label_Registartion
            // 
            this.label_Registartion.AutoSize = true;
            this.label_Registartion.BackColor = System.Drawing.Color.Transparent;
            this.label_Registartion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Registartion.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Registartion.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_Registartion.Location = new System.Drawing.Point(101, 230);
            this.label_Registartion.Name = "label_Registartion";
            this.label_Registartion.Size = new System.Drawing.Size(98, 15);
            this.label_Registartion.TabIndex = 16;
            this.label_Registartion.Text = "РЕГИСТРАЦИЯ";
            this.label_Registartion.Click += new System.EventHandler(this.label_Registartion_Click);
            // 
            // checkBox_RememberLogin
            // 
            this.checkBox_RememberLogin.AutoSize = true;
            this.checkBox_RememberLogin.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_RememberLogin.Font = new System.Drawing.Font("Times New Roman", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_RememberLogin.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBox_RememberLogin.Location = new System.Drawing.Point(54, 157);
            this.checkBox_RememberLogin.Name = "checkBox_RememberLogin";
            this.checkBox_RememberLogin.Size = new System.Drawing.Size(182, 17);
            this.checkBox_RememberLogin.TabIndex = 15;
            this.checkBox_RememberLogin.Text = "Запомнить имя пользователя";
            this.checkBox_RememberLogin.UseVisualStyleBackColor = false;
            this.checkBox_RememberLogin.CheckedChanged += new System.EventHandler(this.checkBox_RememberLogin_CheckedChanged);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.BackColor = System.Drawing.Color.Transparent;
            this.label_Password.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Password.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_Password.Location = new System.Drawing.Point(120, 111);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(61, 15);
            this.label_Password.TabIndex = 9;
            this.label_Password.Text = "ПАРОЛЬ";
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.BackColor = System.Drawing.Color.Transparent;
            this.label_UserName.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_UserName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_UserName.Location = new System.Drawing.Point(94, 65);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(111, 15);
            this.label_UserName.TabIndex = 8;
            this.label_UserName.Text = "ПОЛЬЗОВАТЕЛЬ";
            // 
            // label4_Version
            // 
            this.label4_Version.AutoSize = true;
            this.label4_Version.BackColor = System.Drawing.Color.Transparent;
            this.label4_Version.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4_Version.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4_Version.Location = new System.Drawing.Point(220, 46);
            this.label4_Version.Name = "label4_Version";
            this.label4_Version.Size = new System.Drawing.Size(50, 15);
            this.label4_Version.TabIndex = 12;
            this.label4_Version.Text = "Version";
            // 
            // pictureBox_Hide
            // 
            this.pictureBox_Hide.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Hide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Hide.Image = global::Union_Lan_Client.Properties.Resources.pict_Minimize;
            this.pictureBox_Hide.Location = new System.Drawing.Point(244, 0);
            this.pictureBox_Hide.Name = "pictureBox_Hide";
            this.pictureBox_Hide.Size = new System.Drawing.Size(26, 26);
            this.pictureBox_Hide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Hide.TabIndex = 23;
            this.pictureBox_Hide.TabStop = false;
            this.pictureBox_Hide.Click += new System.EventHandler(this.pictureBox_Hide_Click);
            // 
            // pictureBox_Loading
            // 
            this.pictureBox_Loading.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Loading.Image = global::Union_Lan_Client.Properties.Resources.anim_Loader;
            this.pictureBox_Loading.Location = new System.Drawing.Point(176, 26);
            this.pictureBox_Loading.Name = "pictureBox_Loading";
            this.pictureBox_Loading.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Loading.TabIndex = 20;
            this.pictureBox_Loading.TabStop = false;
            // 
            // pictureBox_Settings
            // 
            this.pictureBox_Settings.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Settings.Image = global::Union_Lan_Client.Properties.Resources.pict_Settings;
            this.pictureBox_Settings.Location = new System.Drawing.Point(218, 2);
            this.pictureBox_Settings.Name = "pictureBox_Settings";
            this.pictureBox_Settings.Size = new System.Drawing.Size(23, 23);
            this.pictureBox_Settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Settings.TabIndex = 19;
            this.pictureBox_Settings.TabStop = false;
            this.pictureBox_Settings.Click += new System.EventHandler(this.pictureBox_Settings_Click);
            // 
            // label_UnionLan
            // 
            this.label_UnionLan.AutoSize = true;
            this.label_UnionLan.BackColor = System.Drawing.Color.Transparent;
            this.label_UnionLan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_UnionLan.ForeColor = System.Drawing.Color.DimGray;
            this.label_UnionLan.Location = new System.Drawing.Point(198, 29);
            this.label_UnionLan.Name = "label_UnionLan";
            this.label_UnionLan.Size = new System.Drawing.Size(99, 19);
            this.label_UnionLan.TabIndex = 4;
            this.label_UnionLan.Text = "UNION LAN";
            // 
            // pictureBox_Exit
            // 
            this.pictureBox_Exit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Exit.Image = global::Union_Lan_Client.Properties.Resources.pict_Close;
            this.pictureBox_Exit.Location = new System.Drawing.Point(268, -1);
            this.pictureBox_Exit.Name = "pictureBox_Exit";
            this.pictureBox_Exit.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Exit.TabIndex = 18;
            this.pictureBox_Exit.TabStop = false;
            this.pictureBox_Exit.Click += new System.EventHandler(this.pictureBox_Exit_Click);
            // 
            // label_Connection
            // 
            this.label_Connection.AutoSize = true;
            this.label_Connection.BackColor = System.Drawing.Color.Transparent;
            this.label_Connection.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Connection.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_Connection.Location = new System.Drawing.Point(15, 4);
            this.label_Connection.Name = "label_Connection";
            this.label_Connection.Size = new System.Drawing.Size(117, 15);
            this.label_Connection.TabIndex = 8;
            this.label_Connection.Text = "Сервер не доступен";
            // 
            // f_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_Login);
            this.Controls.Add(this.button_SignIn);
            this.Controls.Add(this.panel_ServerStatus);
            this.Controls.Add(this.panel_MainBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.f_ClientMain_Load);
            this.Shown += new System.EventHandler(this.f_Main_Shown);
            this.contextMenuStrip_Main.ResumeLayout(false);
            this.panel_MainBack.ResumeLayout(false);
            this.panel_MainBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Loading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Exit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.Button button_SignIn;
        private System.Windows.Forms.Panel panel_ServerStatus;
        private System.Windows.Forms.Label label_Connection;
        private System.Windows.Forms.Label label4_Version;
        private System.Windows.Forms.CheckBox checkBox_RememberLogin;
        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.Label label_UnionLan;
        private System.Windows.Forms.Panel panel_MainBack;
        private System.Windows.Forms.PictureBox pictureBox_Exit;
        private System.Windows.Forms.Label label_Registartion;
        private System.Windows.Forms.PictureBox pictureBox_Settings;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.PictureBox pictureBox_Loading;
        private System.Windows.Forms.NotifyIcon notifyIcon_Main;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox_Hide;

    }
}
namespace Union_Lan_Client
{
    partial class f_Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Chat));
            this.webBrowser_Smile = new System.Windows.Forms.WebBrowser();
            this.panel_Smile = new System.Windows.Forms.Panel();
            this.webBrowser_MainChat = new System.Windows.Forms.WebBrowser();
            this.panel_Label = new System.Windows.Forms.Panel();
            this.pictureBox_ContactWriting = new System.Windows.Forms.PictureBox();
            this.pictureBox_Exit = new System.Windows.Forms.PictureBox();
            this.label_MyJob = new System.Windows.Forms.Label();
            this.label_MySurname = new System.Windows.Forms.Label();
            this.label_MyName = new System.Windows.Forms.Label();
            this.pictureBox_Contact = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_AddFile = new System.Windows.Forms.PictureBox();
            this.pictureBox_ClearMessages = new System.Windows.Forms.PictureBox();
            this.pictureBox_Smile = new System.Windows.Forms.PictureBox();
            this.pictureBox_Send = new System.Windows.Forms.PictureBox();
            this.pictureBox_Loading = new System.Windows.Forms.PictureBox();
            this.timer_ChatFormLoad = new System.Windows.Forms.Timer(this.components);
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.wpf_ChatControl1 = new Union_Lan_Client.wpf_ChatControl();
            this.openFileDialog_SelectFile = new System.Windows.Forms.OpenFileDialog();
            this.panel_Smile.SuspendLayout();
            this.panel_Label.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ContactWriting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Contact)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AddFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClearMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Smile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Send)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Loading)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser_Smile
            // 
            this.webBrowser_Smile.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser_Smile.Location = new System.Drawing.Point(2, 2);
            this.webBrowser_Smile.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_Smile.Name = "webBrowser_Smile";
            this.webBrowser_Smile.ScrollBarsEnabled = false;
            this.webBrowser_Smile.Size = new System.Drawing.Size(158, 188);
            this.webBrowser_Smile.TabIndex = 2;
            this.webBrowser_Smile.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Smile_Navigating);
            // 
            // panel_Smile
            // 
            this.panel_Smile.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel_Smile.Controls.Add(this.webBrowser_Smile);
            this.panel_Smile.Location = new System.Drawing.Point(475, 69);
            this.panel_Smile.Name = "panel_Smile";
            this.panel_Smile.Size = new System.Drawing.Size(162, 192);
            this.panel_Smile.TabIndex = 11;
            // 
            // webBrowser_MainChat
            // 
            this.webBrowser_MainChat.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser_MainChat.Location = new System.Drawing.Point(2, 58);
            this.webBrowser_MainChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_MainChat.Name = "webBrowser_MainChat";
            this.webBrowser_MainChat.Size = new System.Drawing.Size(472, 226);
            this.webBrowser_MainChat.TabIndex = 0;
            this.webBrowser_MainChat.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_MainChat_DocumentCompleted);
            this.webBrowser_MainChat.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_MainChat_Navigating);
            // 
            // panel_Label
            // 
            this.panel_Label.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_Label.Controls.Add(this.pictureBox_ContactWriting);
            this.panel_Label.Controls.Add(this.pictureBox_Exit);
            this.panel_Label.Controls.Add(this.label_MyJob);
            this.panel_Label.Controls.Add(this.label_MySurname);
            this.panel_Label.Controls.Add(this.label_MyName);
            this.panel_Label.Controls.Add(this.pictureBox_Contact);
            this.panel_Label.Location = new System.Drawing.Point(2, 2);
            this.panel_Label.Name = "panel_Label";
            this.panel_Label.Size = new System.Drawing.Size(472, 54);
            this.panel_Label.TabIndex = 15;
            this.panel_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Label_MouseDown);
            this.panel_Label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Label_MouseMove);
            this.panel_Label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Label_MouseUp);
            // 
            // pictureBox_ContactWriting
            // 
            this.pictureBox_ContactWriting.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ContactWriting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_ContactWriting.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_ContactWriting.Image")));
            this.pictureBox_ContactWriting.Location = new System.Drawing.Point(416, 1);
            this.pictureBox_ContactWriting.Name = "pictureBox_ContactWriting";
            this.pictureBox_ContactWriting.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_ContactWriting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_ContactWriting.TabIndex = 25;
            this.pictureBox_ContactWriting.TabStop = false;
            this.pictureBox_ContactWriting.Visible = false;
            // 
            // pictureBox_Exit
            // 
            this.pictureBox_Exit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Exit.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Exit.Image")));
            this.pictureBox_Exit.Location = new System.Drawing.Point(443, -3);
            this.pictureBox_Exit.Name = "pictureBox_Exit";
            this.pictureBox_Exit.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Exit.TabIndex = 19;
            this.pictureBox_Exit.TabStop = false;
            this.pictureBox_Exit.Click += new System.EventHandler(this.pictureBox_Exit_Click);
            // 
            // label_MyJob
            // 
            this.label_MyJob.AutoSize = true;
            this.label_MyJob.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_MyJob.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_MyJob.Location = new System.Drawing.Point(57, 34);
            this.label_MyJob.Name = "label_MyJob";
            this.label_MyJob.Size = new System.Drawing.Size(24, 15);
            this.label_MyJob.TabIndex = 6;
            this.label_MyJob.Text = "Job";
            // 
            // label_MySurname
            // 
            this.label_MySurname.AutoSize = true;
            this.label_MySurname.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_MySurname.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_MySurname.Location = new System.Drawing.Point(57, 4);
            this.label_MySurname.Name = "label_MySurname";
            this.label_MySurname.Size = new System.Drawing.Size(57, 15);
            this.label_MySurname.TabIndex = 5;
            this.label_MySurname.Text = "Surname";
            // 
            // label_MyName
            // 
            this.label_MyName.AutoSize = true;
            this.label_MyName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_MyName.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_MyName.Location = new System.Drawing.Point(57, 19);
            this.label_MyName.Name = "label_MyName";
            this.label_MyName.Size = new System.Drawing.Size(38, 15);
            this.label_MyName.TabIndex = 4;
            this.label_MyName.Text = "Name";
            // 
            // pictureBox_Contact
            // 
            this.pictureBox_Contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Contact.Location = new System.Drawing.Point(2, 2);
            this.pictureBox_Contact.Name = "pictureBox_Contact";
            this.pictureBox_Contact.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_Contact.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Contact.TabIndex = 2;
            this.pictureBox_Contact.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.pictureBox_AddFile);
            this.panel1.Controls.Add(this.pictureBox_ClearMessages);
            this.panel1.Controls.Add(this.pictureBox_Smile);
            this.panel1.Controls.Add(this.pictureBox_Send);
            this.panel1.Location = new System.Drawing.Point(2, 286);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 40);
            this.panel1.TabIndex = 23;
            // 
            // pictureBox_AddFile
            // 
            this.pictureBox_AddFile.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_AddFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_AddFile.Image = global::Union_Lan_Client.Properties.Resources.pict_AddFile;
            this.pictureBox_AddFile.Location = new System.Drawing.Point(364, 3);
            this.pictureBox_AddFile.Name = "pictureBox_AddFile";
            this.pictureBox_AddFile.Size = new System.Drawing.Size(33, 33);
            this.pictureBox_AddFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_AddFile.TabIndex = 23;
            this.pictureBox_AddFile.TabStop = false;
            this.pictureBox_AddFile.Click += new System.EventHandler(this.pictureBox_AddFile_Click);
            // 
            // pictureBox_ClearMessages
            // 
            this.pictureBox_ClearMessages.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ClearMessages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_ClearMessages.Image = global::Union_Lan_Client.Properties.Resources.pict_Remove;
            this.pictureBox_ClearMessages.Location = new System.Drawing.Point(3, 7);
            this.pictureBox_ClearMessages.Name = "pictureBox_ClearMessages";
            this.pictureBox_ClearMessages.Size = new System.Drawing.Size(23, 27);
            this.pictureBox_ClearMessages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ClearMessages.TabIndex = 20;
            this.pictureBox_ClearMessages.TabStop = false;
            this.pictureBox_ClearMessages.Click += new System.EventHandler(this.pictureBox_ClearMessages_Click);
            // 
            // pictureBox_Smile
            // 
            this.pictureBox_Smile.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Smile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Smile.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Smile.Image")));
            this.pictureBox_Smile.Location = new System.Drawing.Point(400, 3);
            this.pictureBox_Smile.Name = "pictureBox_Smile";
            this.pictureBox_Smile.Size = new System.Drawing.Size(33, 33);
            this.pictureBox_Smile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Smile.TabIndex = 21;
            this.pictureBox_Smile.TabStop = false;
            this.pictureBox_Smile.Click += new System.EventHandler(this.pictureBox_Smile_Click);
            // 
            // pictureBox_Send
            // 
            this.pictureBox_Send.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Send.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Send.Image = global::Union_Lan_Client.Properties.Resources.pict_Send;
            this.pictureBox_Send.Location = new System.Drawing.Point(436, 3);
            this.pictureBox_Send.Name = "pictureBox_Send";
            this.pictureBox_Send.Size = new System.Drawing.Size(33, 34);
            this.pictureBox_Send.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Send.TabIndex = 22;
            this.pictureBox_Send.TabStop = false;
            this.pictureBox_Send.Click += new System.EventHandler(this.pictureBox_Send_Click);
            // 
            // pictureBox_Loading
            // 
            this.pictureBox_Loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(54)))));
            this.pictureBox_Loading.Image = global::Union_Lan_Client.Properties.Resources.anim_Loader;
            this.pictureBox_Loading.Location = new System.Drawing.Point(221, 151);
            this.pictureBox_Loading.Name = "pictureBox_Loading";
            this.pictureBox_Loading.Size = new System.Drawing.Size(33, 33);
            this.pictureBox_Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Loading.TabIndex = 8;
            this.pictureBox_Loading.TabStop = false;
            // 
            // timer_ChatFormLoad
            // 
            this.timer_ChatFormLoad.Interval = 5;
            this.timer_ChatFormLoad.Tick += new System.EventHandler(this.timer_ChatFormLoad_Tick);
            // 
            // elementHost1
            // 
            this.elementHost1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elementHost1.Location = new System.Drawing.Point(2, 327);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(472, 70);
            this.elementHost1.TabIndex = 16;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.wpf_ChatControl1;
            // 
            // f_Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(644, 399);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Smile);
            this.Controls.Add(this.pictureBox_Loading);
            this.Controls.Add(this.webBrowser_MainChat);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.panel_Label);
            this.DoubleBuffered = true;
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_Chat_FormClosing);
            this.Load += new System.EventHandler(this.f_Chat_Load);
            this.Shown += new System.EventHandler(this.f_Chat_Shown);
            this.panel_Smile.ResumeLayout(false);
            this.panel_Label.ResumeLayout(false);
            this.panel_Label.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ContactWriting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Contact)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AddFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClearMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Smile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Send)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser_Smile;
        private System.Windows.Forms.Panel panel_Smile;
        private System.Windows.Forms.Panel panel_Label;
        public System.Windows.Forms.WebBrowser webBrowser_MainChat;
        private System.Windows.Forms.PictureBox pictureBox_Loading;
        private System.Windows.Forms.PictureBox pictureBox_Contact;
        private System.Windows.Forms.Label label_MyJob;
        private System.Windows.Forms.Label label_MySurname;
        private System.Windows.Forms.Label label_MyName;
        private System.Windows.Forms.PictureBox pictureBox_Exit;
        private System.Windows.Forms.PictureBox pictureBox_ClearMessages;
        private System.Windows.Forms.PictureBox pictureBox_Smile;
        private System.Windows.Forms.PictureBox pictureBox_Send;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private wpf_ChatControl wpf_ChatControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_AddFile;
        public System.Windows.Forms.PictureBox pictureBox_ContactWriting;
        private System.Windows.Forms.Timer timer_ChatFormLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog_SelectFile;

    }
}
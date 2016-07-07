namespace Union_Lan_Client
{
    partial class f_Notification
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Text = new System.Windows.Forms.Label();
            this.pictureBox_ContactImage = new System.Windows.Forms.PictureBox();
            this.pictureBox_Hide = new System.Windows.Forms.PictureBox();
            this.timer_Opacity = new System.Windows.Forms.Timer(this.components);
            this.timer_Closing = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ContactImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hide)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label_Text);
            this.panel1.Controls.Add(this.pictureBox_ContactImage);
            this.panel1.Controls.Add(this.pictureBox_Hide);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 66);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // label_Text
            // 
            this.label_Text.AutoSize = true;
            this.label_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Text.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Text.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_Text.Location = new System.Drawing.Point(75, 12);
            this.label_Text.Name = "label_Text";
            this.label_Text.Size = new System.Drawing.Size(30, 15);
            this.label_Text.TabIndex = 23;
            this.label_Text.Text = "Text";
            this.label_Text.Click += new System.EventHandler(this.label_Text_Click);
            // 
            // pictureBox_ContactImage
            // 
            this.pictureBox_ContactImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_ContactImage.Location = new System.Drawing.Point(6, 3);
            this.pictureBox_ContactImage.Name = "pictureBox_ContactImage";
            this.pictureBox_ContactImage.Size = new System.Drawing.Size(60, 60);
            this.pictureBox_ContactImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ContactImage.TabIndex = 1;
            this.pictureBox_ContactImage.TabStop = false;
            this.pictureBox_ContactImage.Click += new System.EventHandler(this.pictureBox_ContactImage_Click);
            // 
            // pictureBox_Hide
            // 
            this.pictureBox_Hide.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Hide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Hide.Image = global::Union_Lan_Client.Properties.Resources.pict_Close;
            this.pictureBox_Hide.Location = new System.Drawing.Point(236, 2);
            this.pictureBox_Hide.Name = "pictureBox_Hide";
            this.pictureBox_Hide.Size = new System.Drawing.Size(26, 26);
            this.pictureBox_Hide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Hide.TabIndex = 20;
            this.pictureBox_Hide.TabStop = false;
            this.pictureBox_Hide.Click += new System.EventHandler(this.pictureBox_Hide_Click);
            // 
            // timer_Opacity
            // 
            this.timer_Opacity.Interval = 10;
            this.timer_Opacity.Tick += new System.EventHandler(this.timer_Opacity_Tick);
            // 
            // timer_Closing
            // 
            this.timer_Closing.Interval = 10;
            this.timer_Closing.Tick += new System.EventHandler(this.timer_Closing_Tick);
            // 
            // f_Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(270, 70);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_Notification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.f_Notification_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ContactImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_ContactImage;
        private System.Windows.Forms.PictureBox pictureBox_Hide;
        private System.Windows.Forms.Label label_Text;
        private System.Windows.Forms.Timer timer_Opacity;
        public System.Windows.Forms.Timer timer_Closing;
    }
}
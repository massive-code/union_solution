namespace Union_Lan_Server
{
    partial class f_EditUserPassword
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.label_UserName = new System.Windows.Forms.Label();
            this.textBox_UserUID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_Password);
            this.panel1.Controls.Add(this.button_Save);
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Controls.Add(this.label_UserName);
            this.panel1.Controls.Add(this.textBox_UserUID);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 151);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Пароль:";
            // 
            // textBox_Password
            // 
            this.textBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Password.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.textBox_Password.Location = new System.Drawing.Point(118, 41);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(228, 22);
            this.textBox_Password.TabIndex = 14;
            // 
            // button_Save
            // 
            this.button_Save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Save.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_Save.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button_Save.Location = new System.Drawing.Point(141, 104);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(103, 38);
            this.button_Save.TabIndex = 13;
            this.button_Save.Text = "ИЗМЕНИТЬ";
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.SteelBlue;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_Close.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button_Close.Location = new System.Drawing.Point(250, 104);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(86, 38);
            this.button_Close.TabIndex = 12;
            this.button_Close.Text = "ЗАКРЫТЬ";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click_1);
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_UserName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_UserName.Location = new System.Drawing.Point(3, 11);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(112, 15);
            this.label_UserName.TabIndex = 11;
            this.label_UserName.Text = "UID пользователя:";
            // 
            // textBox_UserUID
            // 
            this.textBox_UserUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_UserUID.Enabled = false;
            this.textBox_UserUID.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_UserUID.Location = new System.Drawing.Point(118, 9);
            this.textBox_UserUID.Name = "textBox_UserUID";
            this.textBox_UserUID.Size = new System.Drawing.Size(228, 20);
            this.textBox_UserUID.TabIndex = 9;
            // 
            // f_EditUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(360, 157);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_EditUserPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.f_EditUserPassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.TextBox textBox_UserUID;

    }
}
namespace Union_Lan_Client
{
    partial class f_Error
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
            this.richTextBox_Error = new System.Windows.Forms.RichTextBox();
            this.label_ErrorCaption = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_Error
            // 
            this.richTextBox_Error.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_Error.Location = new System.Drawing.Point(3, 31);
            this.richTextBox_Error.Name = "richTextBox_Error";
            this.richTextBox_Error.ReadOnly = true;
            this.richTextBox_Error.Size = new System.Drawing.Size(355, 118);
            this.richTextBox_Error.TabIndex = 0;
            this.richTextBox_Error.Text = "";
            // 
            // label_ErrorCaption
            // 
            this.label_ErrorCaption.AutoSize = true;
            this.label_ErrorCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ErrorCaption.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_ErrorCaption.Location = new System.Drawing.Point(-1, 9);
            this.label_ErrorCaption.Name = "label_ErrorCaption";
            this.label_ErrorCaption.Size = new System.Drawing.Size(74, 15);
            this.label_ErrorCaption.TabIndex = 1;
            this.label_ErrorCaption.Text = "Error target";
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Close.Location = new System.Drawing.Point(281, 153);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 36);
            this.button_Close.TabIndex = 2;
            this.button_Close.Text = "ЗАКРЫТЬ";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // f_Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(363, 194);
            this.ControlBox = false;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_ErrorCaption);
            this.Controls.Add(this.richTextBox_Error);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_Error";
            this.Text = "f_Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_Error;
        private System.Windows.Forms.Label label_ErrorCaption;
        private System.Windows.Forms.Button button_Close;
    }
}
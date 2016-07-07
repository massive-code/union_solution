namespace Union_Lan_Server
{
    partial class f_UserContacts
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
            this.dataGridView_Contacts = new System.Windows.Forms.DataGridView();
            this.button_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contacts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Contacts
            // 
            this.dataGridView_Contacts.AllowUserToAddRows = false;
            this.dataGridView_Contacts.AllowUserToDeleteRows = false;
            this.dataGridView_Contacts.AllowUserToResizeRows = false;
            this.dataGridView_Contacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Contacts.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_Contacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Contacts.Location = new System.Drawing.Point(2, 2);
            this.dataGridView_Contacts.Name = "dataGridView_Contacts";
            this.dataGridView_Contacts.ReadOnly = true;
            this.dataGridView_Contacts.RowHeadersVisible = false;
            this.dataGridView_Contacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Contacts.Size = new System.Drawing.Size(414, 220);
            this.dataGridView_Contacts.TabIndex = 0;
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.Gainsboro;
            this.button_Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_Close.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_Close.Location = new System.Drawing.Point(331, 224);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(83, 46);
            this.button_Close.TabIndex = 10;
            this.button_Close.Text = "ЗАКРЫТЬ";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // f_UserContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(418, 273);
            this.ControlBox = false;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.dataGridView_Contacts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_UserContacts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.f_UserContacts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contacts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Contacts;
        private System.Windows.Forms.Button button_Close;
    }
}
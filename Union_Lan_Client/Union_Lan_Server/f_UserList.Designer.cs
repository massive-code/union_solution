namespace Union_Lan_Client
{
    partial class f_UserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_UserList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label_UsersCount = new System.Windows.Forms.Label();
            this.imageList_Images = new System.Windows.Forms.ImageList(this.components);
            this.imageList_Operations = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox_Loading = new System.Windows.Forms.PictureBox();
            this.dataGridView_Users = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Loading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Users)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.Color.CadetBlue;
            this.button_Exit.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Exit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Exit.ForeColor = System.Drawing.Color.White;
            this.button_Exit.Location = new System.Drawing.Point(503, 352);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(91, 43);
            this.button_Exit.TabIndex = 4;
            this.button_Exit.Text = "ЗАКРЫТЬ";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label_UsersCount
            // 
            this.label_UsersCount.AutoSize = true;
            this.label_UsersCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_UsersCount.ForeColor = System.Drawing.Color.White;
            this.label_UsersCount.Location = new System.Drawing.Point(12, 364);
            this.label_UsersCount.Name = "label_UsersCount";
            this.label_UsersCount.Size = new System.Drawing.Size(262, 19);
            this.label_UsersCount.TabIndex = 1;
            this.label_UsersCount.Text = "Зарегистрированных пользователей: ";
            // 
            // imageList_Images
            // 
            this.imageList_Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList_Images.ImageSize = new System.Drawing.Size(70, 70);
            this.imageList_Images.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList_Operations
            // 
            this.imageList_Operations.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Operations.ImageStream")));
            this.imageList_Operations.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Operations.Images.SetKeyName(0, "pict_AddContact.png");
            this.imageList_Operations.Images.SetKeyName(1, "pict_RemoveContact.png");
            this.imageList_Operations.Images.SetKeyName(2, "pict_WaitContact.png");
            this.imageList_Operations.Images.SetKeyName(3, "pict_ThisContact.png");
            // 
            // pictureBox_Loading
            // 
            this.pictureBox_Loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(54)))));
            this.pictureBox_Loading.Image = global::Union_Lan_Client.Properties.Resources.anim_Loader;
            this.pictureBox_Loading.Location = new System.Drawing.Point(276, 153);
            this.pictureBox_Loading.Name = "pictureBox_Loading";
            this.pictureBox_Loading.Size = new System.Drawing.Size(43, 43);
            this.pictureBox_Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Loading.TabIndex = 6;
            this.pictureBox_Loading.TabStop = false;
            // 
            // dataGridView_Users
            // 
            this.dataGridView_Users.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Users.Location = new System.Drawing.Point(0, 1);
            this.dataGridView_Users.Name = "dataGridView_Users";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_Users.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Users.ShowCellErrors = false;
            this.dataGridView_Users.Size = new System.Drawing.Size(601, 344);
            this.dataGridView_Users.TabIndex = 8;
            this.dataGridView_Users.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Users_CellContentClick);
            // 
            // f_UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(601, 399);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox_Loading);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.label_UsersCount);
            this.Controls.Add(this.dataGridView_Users);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_UserList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.f_UserList_Load);
            this.Shown += new System.EventHandler(this.f_UserList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Loading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_UsersCount;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.ImageList imageList_Images;
        private System.Windows.Forms.PictureBox pictureBox_Loading;
        private System.Windows.Forms.ImageList imageList_Operations;
        private System.Windows.Forms.DataGridView dataGridView_Users;
    }
}
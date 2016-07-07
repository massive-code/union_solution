namespace Union_Lan_Server
{
    partial class f_UserRegistrationBase
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
            this.dataGridView_Base = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.user_blockingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.off_blockingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменениеПароляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКонтактовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Close = new System.Windows.Forms.Button();
            this.timer_UserStatus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Base)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Base
            // 
            this.dataGridView_Base.AllowUserToAddRows = false;
            this.dataGridView_Base.AllowUserToDeleteRows = false;
            this.dataGridView_Base.AllowUserToResizeRows = false;
            this.dataGridView_Base.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_Base.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Base.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridView_Base.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView_Base.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Base.Name = "dataGridView_Base";
            this.dataGridView_Base.RowHeadersVisible = false;
            this.dataGridView_Base.ShowEditingIcon = false;
            this.dataGridView_Base.Size = new System.Drawing.Size(682, 360);
            this.dataGridView_Base.TabIndex = 0;
            this.dataGridView_Base.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Base_CellMouseEnter);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.user_blockingToolStripMenuItem,
            this.изменениеПароляToolStripMenuItem,
            this.списокКонтактовToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(216, 70);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // user_blockingToolStripMenuItem
            // 
            this.user_blockingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blockingToolStripMenuItem,
            this.off_blockingToolStripMenuItem});
            this.user_blockingToolStripMenuItem.Name = "user_blockingToolStripMenuItem";
            this.user_blockingToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.user_blockingToolStripMenuItem.Text = "Блокировка пользователя";
            // 
            // blockingToolStripMenuItem
            // 
            this.blockingToolStripMenuItem.Name = "blockingToolStripMenuItem";
            this.blockingToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.blockingToolStripMenuItem.Text = "Заблокировать";
            this.blockingToolStripMenuItem.Click += new System.EventHandler(this.blockingToolStripMenuItem_Click_1);
            // 
            // off_blockingToolStripMenuItem
            // 
            this.off_blockingToolStripMenuItem.Enabled = false;
            this.off_blockingToolStripMenuItem.Name = "off_blockingToolStripMenuItem";
            this.off_blockingToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.off_blockingToolStripMenuItem.Text = "Снять блокировку";
            this.off_blockingToolStripMenuItem.Click += new System.EventHandler(this.off_blockingToolStripMenuItem_Click);
            // 
            // изменениеПароляToolStripMenuItem
            // 
            this.изменениеПароляToolStripMenuItem.Name = "изменениеПароляToolStripMenuItem";
            this.изменениеПароляToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.изменениеПароляToolStripMenuItem.Text = "Изменение пароля";
            this.изменениеПароляToolStripMenuItem.Click += new System.EventHandler(this.изменениеПароляToolStripMenuItem_Click);
            // 
            // списокКонтактовToolStripMenuItem
            // 
            this.списокКонтактовToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.списокКонтактовToolStripMenuItem.Name = "списокКонтактовToolStripMenuItem";
            this.списокКонтактовToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.списокКонтактовToolStripMenuItem.Text = "Список контактов";
            this.списокКонтактовToolStripMenuItem.Click += new System.EventHandler(this.списокКонтактовToolStripMenuItem_Click);
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.Gainsboro;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_Close.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_Close.Location = new System.Drawing.Point(596, 361);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(83, 46);
            this.button_Close.TabIndex = 2;
            this.button_Close.Text = "ЗАКРЫТЬ";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // timer_UserStatus
            // 
            this.timer_UserStatus.Interval = 10000;
            this.timer_UserStatus.Tick += new System.EventHandler(this.timer_UserStatus_Tick);
            // 
            // f_UserRegistrationBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(682, 409);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.dataGridView_Base);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_UserRegistrationBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.f_UserRegistrationBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Base)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Base;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Timer timer_UserStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem user_blockingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem off_blockingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменениеПароляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКонтактовToolStripMenuItem;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Union_Lan_Client
{
    public partial class f_Notification : Form
    {
        public String ps_Text;
        public String ps_ImagePath;
        public f_Union gf_Union;
        public String ps_ContactUID;
        Int32 gi_Step = 5;

        public f_Notification()
        {
            InitializeComponent();
        }

        private void f_Notification_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            timer_Opacity.Start();
            this.Top = Screen.PrimaryScreen.WorkingArea.Height;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - (this.Width + 20);
            FileStream lfs = new FileStream(ps_ImagePath, FileMode.Open);
            pictureBox_ContactImage.Image = Image.FromStream(lfs);
            lfs.Close();
            label_Text.Text = ps_Text;
        }

        private void pictureBox_Hide_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label_Text_Click(object sender, EventArgs e)
        {
            gf_Union.pv_OpenChatForm(ps_ContactUID);
            Close();
        }

        private void pictureBox_ContactImage_Click(object sender, EventArgs e)
        {
            gf_Union.pv_OpenChatForm(ps_ContactUID);
            Close();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            gf_Union.pv_OpenChatForm(ps_ContactUID);
            Close();
        }

        private void timer_Opacity_Tick(object sender, EventArgs e)
        {
            if (gi_Step!=0)
            {
                this.Opacity += 0.1;
                this.Top -=15;
                gi_Step--;
            }
            if (gi_Step == 0)
            {
                this.Opacity = 1;
                timer_Opacity.Stop();
            }
        }

        private void timer_Closing_Tick(object sender, EventArgs e)
        {
            if (gi_Step != 5)
            {
                this.Opacity -= 0.1;
                this.Top -= 15;
                gi_Step++;
            }
            if (gi_Step == 5)
            {
                Close();
            }
        }
    }
}

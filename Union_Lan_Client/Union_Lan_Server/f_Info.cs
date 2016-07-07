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
    public partial class f_Info : Form
    {
        public cl_GlobalVariables.str_PersonalData p_PD;

        public f_Info()
        {
            InitializeComponent();
        }

        private void f_Info_Load(object sender, EventArgs e)
        {
            label_Name.Text = p_PD.Name;
            label_Surname.Text = p_PD.Surname;
            label_Birthday.Text = p_PD.Birthday;
            label_Job.Text = p_PD.Job;
            label_Workplace.Text = p_PD.Workplace;
            label_Lifeplace.Text = p_PD.Lifeplace;
            label_Gender.Text = p_PD.Gender;
            FileStream lfs = new FileStream(Application.StartupPath + "\\cache\\" + p_PD.ImageFileName, FileMode.Open);
            pictureBox_Image.Image = Image.FromStream(lfs);
            lfs.Close();
        }

        private void button_Shutdown_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

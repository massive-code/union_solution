using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Union_Lan_Server
{
    public partial class f_MessageArhive : Form
    {
        public cl_GlobalVariables p_GV;
        cl_SQLWorker g_SQLW = new cl_SQLWorker();
        public f_MessageArhive()
        {
            InitializeComponent();
        }

        private void f_MessageArhive_Load(object sender, EventArgs e)
        {
            openFileDialog_ReadMessageArhive.InitialDirectory = p_GV.ps_MainBaseFolderPath();
            if (openFileDialog_ReadMessageArhive.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dataGridView1.DataSource = g_SQLW.pdt_ReadMessageArhive_All(openFileDialog_ReadMessageArhive.FileName);
            }
            else { Close(); }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

      
    }
}

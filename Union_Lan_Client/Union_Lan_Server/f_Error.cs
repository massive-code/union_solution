using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Union_Lan_Client
{
    public partial class f_Error : Form
    {
        public String ps_CompressError_WhenSendingsToServer = "Ошибка при сжатии данных при отправке на сервер";
        public String ps_ConnectionError_WhenSendingsToServer = "Ошибка при отправке данных на сервер";
        public f_Error()
        {
            InitializeComponent();
        }

        public void pv_ErrorShow(String ls_ErrorCaption, String ls_ErrorText)
        {
            label_ErrorCaption.Text = ls_ErrorCaption;
            richTextBox_Error.AppendText(ls_ErrorText);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

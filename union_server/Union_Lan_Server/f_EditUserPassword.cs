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
    public partial class f_EditUserPassword : Form
    {
        cl_SQLWorker g_SQL = new cl_SQLWorker();
        public String ps_UserUID;
        public f_UserRegistrationBase pf_URB;
        public f_EditUserPassword()
        {
            InitializeComponent();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void f_EditUserPassword_Load(object sender, EventArgs e)
        {
            textBox_UserUID.Text = ps_UserUID;
        }


        private void button_Save_Click(object sender, EventArgs e)
        {
            String ls_Path = pf_URB.g_GV.ps_MainUsersRegistrationBasePath();
            String ls_Password = Cryptor.cl_Crypting_Rijndael.psvm_RijndaelEncryptedMethod(Encoding.Default.GetBytes(textBox_Password.Text), pf_URB.g_GV.ps_CryptKey);

            if (g_SQL.pi_EditUserPassword(ls_Path, ps_UserUID, ls_Password) == 1)
            {
                pf_URB.pb_UserChangedPassword = true;
                pf_URB.ps_UserChangedPasswordUID = ps_UserUID;
                pf_URB.ps_UserChangedPasswordData = ls_Password;
            }
            else { pf_URB.pb_UserChangedPassword = false; ; MessageBox.Show("Ошибка"); }
            Close();
        }

        private void button_Close_Click_1(object sender, EventArgs e)
        {
            pf_URB.pb_UserChangedPassword = false;
            Close();
        }


    }
}

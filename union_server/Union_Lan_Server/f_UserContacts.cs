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
    public partial class f_UserContacts : Form
    {
        cl_SQLWorker g_SQLW = new cl_SQLWorker();
        public cl_GlobalVariables p_GV; 
        public String ps_UID;
        public f_UserContacts()
        {
            InitializeComponent();
        }

        private void f_UserContacts_Load(object sender, EventArgs e)
        {
            //String ls_Path = p_GV.ps_UserContactSQLBasePath(ps_UID);
            ////читает базу контактов (UIDы) текущего клиента
            //DataTable ldt_DataTable = g_SQLW.pdt_ReadUserContactSQLBase(ls_Path);
            ////по прочитанным UIDам читает инфу о контактах из главной базы
            //ldt_DataTable = g_SQLW.pdt_ReadUserContacts(p_GV.ps_MainUsersRegistrationBasePath(), ldt_DataTable, "SERVER");
            //dataGridView_Contacts.DataSource = ldt_DataTable;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

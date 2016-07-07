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
using System.Threading;
using System.Reflection;

namespace Union_Lan_Server
{
    public partial class f_UserRegistrationBase : Form
    {
        cl_SQLWorker g_SQLW = new cl_SQLWorker();
        public cl_GlobalVariables g_GV;
        public cl_Server_v2 g_Server_v2;
        public f_Main pf_Main;
        Int32 gi_SelectedRow;
        /////////////////////////////////////
        public Boolean pb_UserChangedPassword;
        public String ps_UserChangedPasswordUID;
        public String ps_UserChangedPasswordData;
        /////////////////////////////////////
        public f_UserRegistrationBase()
        {
            InitializeComponent();
        }
        private void f_UserRegistrationBase_Load(object sender, EventArgs e)
        {
            //////////////////////////////////////////
            DataGridViewTextBoxColumn dg_TextColumn = new DataGridViewTextBoxColumn();
            dg_TextColumn.Name = "Status";
            dataGridView_Base.Columns.Add(dg_TextColumn);
            DataGridViewTextBoxColumn dg_TextIPColumn = new DataGridViewTextBoxColumn();
            dg_TextIPColumn.Name = "IP";
            dataGridView_Base.Columns.Add(dg_TextIPColumn);
            dataGridView_Base.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Base.RowsDefaultCellStyle.SelectionBackColor = Color.SlateGray;
            dataGridView_Base.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView_Base.MultiSelect = false;
            //////////////////////////////////////////

            if (File.Exists(g_GV.ps_MainUsersRegistrationBasePath()) == true)
            {
                pv_LoadBase();
            }

            else { MessageBox.Show("По пути указанном в настройках программы база не найдена."); Close(); }
            SetDoubleBuffered(dataGridView_Base, true);
        }

        void SetDoubleBuffered(Control c, bool value)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null)
            {
                pi.SetValue(c, value, null);
            }
        }

        public void pv_LoadBase()
        {
            dataGridView_Base.DataSource = g_SQLW.pdt_ReadAll_UserRegistrationBase(g_GV.ps_MainUsersRegistrationBasePath());

            dataGridView_Base.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView_Base.Columns["Password"].DisplayIndex = dataGridView_Base.Columns.Count - 1;
            dataGridView_Base.Columns["Password"].DefaultCellStyle.BackColor = Color.Gainsboro;
            dataGridView_Base.Columns["Login"].DisplayIndex = dataGridView_Base.Columns["Password"].DisplayIndex - 1;
            dataGridView_Base.Columns["Name"].DisplayIndex = 3;
            dataGridView_Base.Columns["Surname"].DisplayIndex = 4;
            dataGridView_Base.Columns["UID"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView_Base.Columns["N"].Visible = false;

            Font lf_Font = new Font("Times New Roman", 9, FontStyle.Regular);
            dataGridView_Base.DefaultCellStyle.Font = lf_Font;

            foreach (DataGridViewRow dr_Row in dataGridView_Base.Rows)
            {
                dr_Row.Cells["Status"].Value = "оффлайн";
                dr_Row.Cells["Status"].Style.BackColor = Color.Gainsboro;
            }
            v_UpdateUsersStatus();
            timer_UserStatus.Start();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer_UserStatus_Tick(object sender, EventArgs e)
        {
            v_UpdateUsersStatus();
        }

        void v_UpdateUsersStatus()
        {
            foreach (DataGridViewRow dr_Row in dataGridView_Base.Rows)
            {
                dr_Row.Cells["Status"].Value = "оффлайн";
                dr_Row.Cells["Status"].Style.BackColor = Color.Gainsboro;
                dr_Row.Cells["Status"].Style.SelectionBackColor = Color.SlateGray;
                dr_Row.Cells["Status"].Style.SelectionForeColor = Color.White;
                dr_Row.Cells["IP"].Value = "";

                foreach (cl_Client Client in g_Server_v2.list_Client)
                {
                    if (dr_Row.Cells["UID"].Value.ToString() == Client.g_DW.Client.UID)
                    {
                        dr_Row.Cells["Status"].Value = "онлайн";
                        dr_Row.Cells["Status"].Style.BackColor = Color.LightGreen;
                        dr_Row.Cells["Status"].Style.SelectionBackColor = Color.LightGreen;
                        dr_Row.Cells["Status"].Style.SelectionForeColor = Color.Black;
                        dr_Row.Cells["IP"].Value = Client.tcp_Client.Client.RemoteEndPoint.ToString();
                    }
                }

            }
        }

        private void dataGridView_Base_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            gi_SelectedRow = e.RowIndex;
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            blockingToolStripMenuItem.Enabled = true;
            off_blockingToolStripMenuItem.Enabled = false;

            dataGridView_Base.Rows[gi_SelectedRow].Selected = true;
            if (dataGridView_Base.Rows[gi_SelectedRow].Cells["Attribute"].Value.ToString() == "BLOCKED")
            {
                blockingToolStripMenuItem.Enabled = false;
                off_blockingToolStripMenuItem.Enabled = true;
            }
        }

        private void off_blockingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String ls_UID = dataGridView_Base.Rows[gi_SelectedRow].Cells["UID"].Value.ToString();
            Int32 li_Blocked = g_SQLW.pv_UnBlockUserInBase(g_GV.ps_MainUsersRegistrationBasePath(), ls_UID);
            if (li_Blocked == 1)
            {
                dataGridView_Base.Rows[gi_SelectedRow].Cells["Attribute"].Value = "READY";
            }
        }

        private void blockingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String ls_UID = dataGridView_Base.Rows[gi_SelectedRow].Cells["UID"].Value.ToString();
            Int32 li_Blocked = g_SQLW.pv_BlockUserInBase(g_GV.ps_MainUsersRegistrationBasePath(), ls_UID);
            if (li_Blocked == 1)
            {
                dataGridView_Base.Rows[gi_SelectedRow].Cells["Attribute"].Value = "BLOCKED";
                for (int i = 0; i < g_Server_v2.list_Client.Count; i++)
                {
                    if (ls_UID == g_Server_v2.list_Client[i].g_DW.Client.UID)
                    {
                        g_Server_v2.list_Client[i].g_DW.BLOCKING_BY_SERVER();
                        pf_Main.pv_ClientDisconnect(g_Server_v2.list_Client[i]);
                    }
                }
            }
        }

        private void изменениеПароляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_EditUserPassword lf_EditUserPassword = new f_EditUserPassword();
            lf_EditUserPassword.ps_UserUID = dataGridView_Base.Rows[gi_SelectedRow].Cells["UID"].Value.ToString();
            lf_EditUserPassword.pf_URB = this;
            lf_EditUserPassword.ShowDialog();
            if (pb_UserChangedPassword == true)
            {
                foreach (DataGridViewRow dr_Row in dataGridView_Base.Rows)
                {
                    if (dr_Row.Cells["UID"].Value.ToString() == ps_UserChangedPasswordUID)
                    {
                        dr_Row.Cells["Password"].Value = ps_UserChangedPasswordData;
                    }
                }
            }
        }

        private void списокКонтактовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_UserContacts lf_UC = new f_UserContacts();
            lf_UC.p_GV = g_GV;
            lf_UC.ps_UID = dataGridView_Base.Rows[gi_SelectedRow].Cells["UID"].Value.ToString();
            lf_UC.ShowDialog();
        }

    }
}

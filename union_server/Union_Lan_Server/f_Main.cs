using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace Union_Lan_Server
{
    public partial class f_Main : Form
    {
        cl_GlobalVariables g_GV = new cl_GlobalVariables();
        cl_FileWorker g_FW = new cl_FileWorker();
        cl_Server_v2 g_Server_v2 = new cl_Server_v2();
        cl_Settings g_Settings = new cl_Settings();
        cl_SQLWorker g_SQLW = new cl_SQLWorker();
        public f_Main()
        {
            InitializeComponent();
        }
        private void f_Main_Load(object sender, EventArgs e)
        {
            //////////////////////////////
            DataGridViewTextBoxColumn dg_RemotePoint = new DataGridViewTextBoxColumn();
            dataGridView_ConnectedRemotePoint.Columns.Add(dg_RemotePoint);
            dataGridView_ConnectedRemotePoint.Columns[0].Name = "RemotePoint";
            dataGridView_ConnectedRemotePoint.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //////////////////////////////
            g_FW.pv_CreateLogFile();
            label_ServerVersion.Text += " " + g_GV.g_ServerCurrentVersion;
            g_Settings.pv_CreateSettingsFile();
            g_GV.pcl_SettingsData = g_Settings.p_cl_ReadSettings();

            String ls_Path_SQL_Check = Application.StartupPath + "\\base_check";
            if (File.Exists(ls_Path_SQL_Check) == false)
            {
                if (g_SQLW.pb_Create_SQL_Check(ls_Path_SQL_Check) == false)
                {
                    MessageBox.Show("Для работы сервера необходимо установить компонент SQL Server Compact Edition 4.0"); Close();
                }
            }
            else
            {
                if (g_SQLW.pb_ReadSQL_Check(ls_Path_SQL_Check) == false)
                {
                    MessageBox.Show("Для работы сервера необходимо установить компонент SQL Server Compact Edition 4.0"); Close();
                }
            }

            if (g_GV.pcl_SettingsData.pb_AutoStart == true)
            {
                v_StartWorking();
            }
        }
        private void userRegistrationBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }
        private void button_ExitMain_Click(object sender, EventArgs e)
        {
            prv_CloseApplication();
        }
        public void pv_MainSocketStatusChange(Boolean lb_Status, String ls_IP, String ls_Port)
        {
            if (lb_Status == true)
            {
                checkBox_Main_socket.Checked = lb_Status;
                label_SocketIP.Text = ls_IP + ":" + ls_Port;
                button_ServerStart.Enabled = false;
                button_ServerStop.Enabled = true;
                label_SocketStatus.ForeColor = Color.CadetBlue;
                label_SocketStatus.Text = "Сервер запущен.";
            }
            else 
            {
                label_SocketStatus.ForeColor = Color.Firebrick;
                label_SocketStatus.Text = "Ошибка сети.\nПроверьте настройки.";
            }
        }
        private void menuStrip_Main_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture  = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        private void button_MinimizeMain_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Hide();
        }
        private void sHOWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prv_CloseApplication();
        }
        private void readMessageArhiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_MessageArhive lf_MA = new f_MessageArhive();
            lf_MA.p_GV = g_GV;
            lf_MA.Show();
        }
        private void notifyIcon_Main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }
        private void modifeBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //////////////1
            DataTable ldt_TableUsers = g_SQLW.pdt_ReadAll_UserRegistrationBase(g_GV.ps_MainUsersRegistrationBasePath());
            foreach (DataRow ldr_Row in ldt_TableUsers.Rows)
            {
                DataTable ldt_UserContacts = g_SQLW.pdt_ReadUserContactSQLBase(g_GV.ps_UserContactSQLBasePath(ldr_Row["UID"].ToString()));
                foreach (DataRow ldr_Row2 in ldt_UserContacts.Rows)
                {
                   // Directory.Delete(g_GV.ps_UsersBaseFolderPath() + "\\" + ldr_Row["UID"].ToString() + "\\message_arhive\\" + ldr_Row2["UID"].ToString() + "\\files");
                }
                File.Delete(g_GV.ps_UsersBaseFolderPath() + "\\" + ldr_Row["UID"].ToString() + "\\files._ul");

                //Directory.CreateDirectory(g_GV.ps_UsersBaseFolderPath() + "\\" + ldr_Row["UID"].ToString() + "\\files");
                g_SQLW.pv_Create_UserFilesDB(g_GV.ps_UsersBaseFolderPath() + "\\" + ldr_Row["UID"].ToString() + "\\files._ul");
            }
            //////////////
            /////////////2
            //DataTable ldt_TableUsers2 = g_SQLW.pdt_ReadAll_UserRegistrationBase(g_GV.ps_MainUsersRegistrationBasePath());
            //foreach (DataRow ldr_Row in ldt_TableUsers2.Rows)
            //{
            //    DataTable ldt_UserContacts = g_SQLW.pdt_ReadUserContactSQLBase(g_GV.ps_UserContactSQLBasePath(ldr_Row["UID"].ToString()));
            //    foreach (DataRow ldr_Row2 in ldt_UserContacts.Rows)
            //    {
            //        g_SQLW.pv_ModifeBase(g_GV.ps_UsersBaseFolderPath() + "\\" + ldr_Row["UID"].ToString() + "\\message_arhive\\" + ldr_Row2["UID"].ToString() + "\\messages._ms");
            //    }
            //}
            //////////////


            //DataTable ldt_TableUsers = g_SQLW.pdt_ReadAll_UserRegistrationBase(g_GV.ps_MainUsersRegistrationBasePath());
            //foreach (DataRow ldr_Row in ldt_TableUsers.Rows)
            //{
            //    String ls_Path = g_GV.ps_MainBaseFolderPath() + "\\users_base\\" + ldr_Row["UID"].ToString()+"\\temp_messages._ul";
            //    g_SQLW.pv_Create_TempUserMessageArhive(ls_Path);
            //}

            //g_SQLW.pv_AddColumnToBase(g_GV.ps_MainUsersRegistrationBasePath());
            //g_SQLW.pv_ChangeDataInBase(g_GV.ps_MainUsersRegistrationBasePath());



            MessageBox.Show("Complete");
        }
        private void button_ServerStart_Click(object sender, EventArgs e)
        {
            v_StartWorking();
        }
        void v_StartWorking()
        {
            timer_Connection.Start();
            g_GV.pcl_SettingsData = g_Settings.p_cl_ReadSettings();

            if (File.Exists(g_GV.ps_MainUsersRegistrationBasePath()) == false)
            {
                if (MessageBox.Show("По указанному в настройках пути база данных не найдена. Да - выбрать путь до базы данных.", "Внимание. Отсутствует база данных", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                {
                    f_Settings lf_Settings = new f_Settings();
                    lf_Settings.ShowDialog();
                }
            }

            else
            {
                g_Server_v2.pf_Main = this;
                g_Server_v2.g_GV = g_GV;
                g_Server_v2.pv_ServerStartThread();
                checkBox_base_status_Path.Checked = true;
                checkBox_Main_base.Checked = true;
            }
        }
        private void button_ServerStop_Click(object sender, EventArgs e)
        {
            label_SocketStatus.ForeColor = Color.DarkSlateGray;
            label_SocketStatus.Text = "Сервер остановлен.";
            timer_Connection.Stop();
            g_Server_v2.pb_ServerListening = false;
            g_Server_v2.ptcp_Server.Stop();
            foreach (cl_Client l_Client in g_Server_v2.list_Client)
            {
                l_Client.Blocked = true;
                l_Client.th_ClientThread.Abort();
            }
            g_Server_v2.list_Client.Clear();
            button_ServerStart.Enabled = true;
            button_ServerStop.Enabled = false;
            checkBox_Main_socket.Checked = false;
            label_SocketIP.Text = "IP сервера";
            label_Connections.Text = "Подключено: 0";
            dataGridView_ConnectedRemotePoint.Rows.Clear();
        }
        private void timer_Connection_Tick(object sender, EventArgs e)
        {
            label_Connections.Text = "Подключено: " + g_Server_v2.list_Client.Count;
            dataGridView_ConnectedRemotePoint.Rows.Clear();
            foreach (cl_Client l_Client in g_Server_v2.list_Client)
            {
                dataGridView_ConnectedRemotePoint.Rows.Add(l_Client.tcp_Client.Client.RemoteEndPoint.ToString());
            }
        }
        private void f_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            prv_CloseApplication();
        }
        private void prv_CloseApplication()
        {
            if (g_Server_v2.pb_ServerListening == true)
            {
                g_Server_v2.pb_ServerListening = false;
                g_Server_v2.ptcp_Server.Stop();

                foreach (cl_Client l_Client in g_Server_v2.list_Client)
                {
                    l_Client.Blocked = true;
                    l_Client.th_ClientThread.Abort();
                }
            }
            Application.Exit();
        }
        public void pv_ClientDisconnect(cl_Client Client)
        {
            Client.Blocked = true;
            if (Client.tcp_Client.Connected == true)
            {
                Client.tcp_Client.Client.Close();
                Client.TimeOutTimer.Dispose();
            }
            g_Server_v2.list_Client.Remove(Client);
        }

        private void button_CreateBase_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_CreateBase.ShowDialog();
            String ls_SelectedBasePath = folderBrowserDialog_CreateBase.SelectedPath;
            g_GV.pcl_SettingsData.ps_BasePath = ls_SelectedBasePath;
            g_Settings.pv_WriteSettings(g_GV.pcl_SettingsData);
            g_FW.g_GV = g_GV;
            g_FW.pv_CreateBaseFolder();
            g_FW.pv_CreateUserRegistrationSQLBase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f_Settings lf_Settings = new f_Settings();
            lf_Settings.ShowDialog();
            g_GV.pcl_SettingsData = g_Settings.p_cl_ReadSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f_UserRegistrationBase nf_URB = new f_UserRegistrationBase();
            nf_URB.pf_Main = this;
            nf_URB.g_GV = g_GV;
            nf_URB.g_Server_v2 = g_Server_v2;
            nf_URB.ShowDialog();
        }
        #region UnionFormMove
        ///////////////////////////////////////////////
        Boolean b_MouseDown = false;
        Int32 X;
        Int32 Y;
        private void panel_Main_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDown = false;
        }

        private void panel_Main_MouseMove(object sender, MouseEventArgs e)
        {
            Int32 li_X, li_Y;
            if (b_MouseDown == true)
            {
                li_X = this.Location.X + e.X - X;
                li_Y = this.Location.Y + e.Y - Y;
                this.Location = new Point(li_X, li_Y);
            }
        }

        private void panel_Main_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDown = true;
            X = e.X;
            Y = e.Y;
        }


        /////////////////////////////////////////////// 
        #endregion
    }
}

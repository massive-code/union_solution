using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Management;

namespace Union_Lan_Client
{
    public partial class f_Main : Form
    {
        cl_GlobalVariables g_GV = new cl_GlobalVariables();
        cl_FileWorker g_FW = new cl_FileWorker();
        cl_FileWorker.cl_Settings g_Settings = new cl_FileWorker.cl_Settings();
        cl_DataWorkerClient g_DW = new cl_DataWorkerClient();
        cl_Client_v2 g_Client_v2 = new cl_Client_v2();
        String s_MyLogin = String.Empty;
        String s_MyPassword = String.Empty;

        public f_Main()
        {
            InitializeComponent();
        }
        public void f_ClientMain_Load(object sender, EventArgs e)
        {
            pictureBox_Loading.Visible = false;
            if (Directory.Exists(Application.StartupPath + "//file") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "//file");
            }
            //работа с файлом настроек
            if (File.Exists(g_GV.ps_SettingsFilePath()) == false)
            {
                g_FW.pv_CreateSettings();
            }
            g_Settings = g_FW.p_cl_ReadSettings();
            this.Location = g_Settings.po_MainFormPosition;
            label4_Version.Text += " " + g_GV.ps_ClientVersion;
            checkBox_RememberLogin.Checked = g_Settings.pb_RememberLogin;
            if (g_Settings.pb_RememberLogin == true)
            {
                textBox_Login.Text = g_Settings.ps_Login;
            }

            //очистить временную папку с изоб профиля и обновлениями
            g_FW.pv_ClearDirectory();
            g_FW.pv_CreateLogFile();
            g_DW.pf_MainForm = this;
            g_DW.g_Client_v2 = g_Client_v2;
            g_Client_v2.g_DW = g_DW;
            g_Client_v2.pf_Main = this;
            label_UserName.Visible = false;
            label_Password.Visible = false;
            checkBox_RememberLogin.Visible = false;
            textBox_Login.Enabled = false;
            textBox_Password.Enabled = false;
            textBox_Login.Visible = false;
            textBox_Password.Visible = false;
            button_SignIn.Visible = false;
            button_SignIn.Enabled = false;
            label_Registartion.Enabled = false;
            label_Connection.Text = "Попытка подключения...";
            panel_ServerStatus.BackColor = Color.Blue;
        }
        public void pv_ServerStatus(String lb_Status, String ls_ClientVersion)
        {
            if (lb_Status == "READY")
            {
                panel_ServerStatus.BackColor = Color.ForestGreen;
                label_Connection.Text = "В сети";

                String ls_CurrentVersion = g_GV.ps_ClientVersion.Replace(".","");
                String ls_UpdateVersion = ls_ClientVersion.Replace(".", "");
                if (Convert.ToInt32(ls_CurrentVersion) < Convert.ToInt32(ls_UpdateVersion))
                {
                    label_Connection.Text = "Обновление клиента";
                    pictureBox_Loading.Visible = true;
                    g_DW.pv_UpdateClient();
                }

                else
                {

                    label_UserName.Visible = true;
                    label_Password.Visible = true;
                    checkBox_RememberLogin.Visible = true;
                    label_Registartion.Enabled = true;
                    textBox_Login.Enabled = true;
                    textBox_Password.Enabled = true;
                    button_SignIn.Enabled = true;
                    textBox_Login.Visible = true;
                    textBox_Password.Visible = true;
                    button_SignIn.Visible = true;
                  
                    ////////////////////////////////////
                    try
                    {
                        //работа с сохраненным паролем
                        if (g_Settings.pb_RememberLogin == true & g_Settings.pb_RememberPassword == true & g_Settings.ps_Password != null)
                        {
                            s_MyLogin = g_Settings.ps_Login;
                            String ls_Decrypt = Cryptor.cl_Crypting_Rijndael.psvm_DecryptedMethod(g_Settings.ps_Password, prs_GetID());
                            String ls_Encrypt = Cryptor.cl_Crypting_Rijndael.psvm_RijndaelEncryptedMethod(Encoding.Default.GetBytes(ls_Decrypt), g_GV.ps_CryptKey);
                            s_MyPassword = ls_Encrypt;
                            g_DW.pv_SignIn(s_MyLogin, ls_Encrypt);
                        }
                    }
                    catch
                    {
                        textBox_Login.BackColor = Color.Coral;
                        textBox_Password.BackColor = Color.Coral;
                    }
                }
            }
        }
        private void button_SignIn_Click(object sender, EventArgs e)
        {
            if (textBox_Login.Text == String.Empty)
            {
                textBox_Login.BackColor = Color.Coral;
            }

            else
            {
                g_Settings = g_FW.p_cl_ReadSettings();
                button_SignIn.Enabled = false;
                String ls_CryptedPassword = Cryptor.cl_Crypting_Rijndael.psvm_RijndaelEncryptedMethod(Encoding.Default.GetBytes(textBox_Password.Text), g_GV.ps_CryptKey);
                if (g_Settings.pb_RememberPassword == true)
                {
                    g_Settings.ps_Password = Cryptor.cl_Crypting_Rijndael.psvm_RijndaelEncryptedMethod(Encoding.Default.GetBytes(textBox_Password.Text), prs_GetID());
                }
                g_DW.pv_SignIn(textBox_Login.Text, ls_CryptedPassword);

                s_MyLogin = textBox_Login.Text;
                s_MyPassword = ls_CryptedPassword;

                textBox_Login.BackColor = Color.White;
                textBox_Password.BackColor = Color.White;
                g_FW.pv_WriteSettings(g_Settings);
            }
        }
        public void pv_SignStatus(String ls_Data)
        {
            if (ls_Data == "FAILED")
            {
                button_SignIn.Enabled = true;
                textBox_Login.BackColor = Color.Coral;
                textBox_Password.BackColor = Color.Coral;
            }
            if (ls_Data == "SUCCESS")
            {
                f_Chat lf_Chat = new f_Chat();
                lf_Chat.pv_LoadSmile();
                lf_Chat.pv_LoadMainBrowser();

                cl_XML_Data g_XML = new cl_XML_Data();
                f_Union lf_Union = new f_Union();
                lf_Union.ps_Login = s_MyLogin;
                lf_Union.ps_Password = s_MyPassword;
                lf_Union.g_DW = g_DW;
                lf_Union.pf_Main = this;
                g_Settings = g_FW.p_cl_ReadSettings();
                g_Settings.po_MainFormPosition = this.Location;
                if (g_Settings.pb_RememberLogin == true)
                {
                    g_Settings.ps_Login = s_MyLogin;
                }
                //if (g_Settings.pb_RememberPassword == true)
                //{
                //    g_Settings.ps_Password = Cryptor.cl_Crypting_Rijndael.psvm_RijndaelEncryptedMethod(Encoding.Default.GetBytes(textBox_Password.Text), prs_GetID());
                //}
                g_FW.pv_WriteSettings(g_Settings);

                this.Enabled = false;
                this.Visible = false;
                this.ShowInTaskbar = false;
              
                lf_Union.Show();
            }
        }
        private void checkBox_RememberLogin_CheckedChanged(object sender, EventArgs e)
        {
            g_Settings = g_FW.p_cl_ReadSettings();
            g_Settings.pb_RememberLogin = checkBox_RememberLogin.Checked;
            g_FW.pv_WriteSettings(g_Settings);
        }
        private void pictureBox_Settings_Click(object sender, EventArgs e)
        {
            f_Settings lf_Settings = new f_Settings();
            lf_Settings.ShowDialog();
        }
        private void label_Registartion_Click(object sender, EventArgs e)
        {
            f_UserRegistration lf_UR = new f_UserRegistration();
            lf_UR.ps_WorkStatus = "REGISTRATION";
            lf_UR.g_DW = g_DW;
            lf_UR.ShowDialog();
        }
        private void pictureBox_Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            g_Settings = g_FW.p_cl_ReadSettings();
            g_Settings.po_MainFormPosition = this.Location;
            g_FW.pv_WriteSettings(g_Settings);
            pv_ApplicationExit("EXIT");
        }
        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g_Settings = g_FW.p_cl_ReadSettings();
            g_Settings.po_MainFormPosition = this.Location;
            g_FW.pv_WriteSettings(g_Settings);
            pv_ApplicationExit("EXIT");
        }

        public void pv_ApplicationExit(object sender)
        {
            
            g_DW.pv_ApplicationClose();
            Thread.Sleep(500);
            g_Client_v2.pb_ClientReconnect = false;
            g_Client_v2.pth_Client.Abort();
            if (g_Client_v2.pb_Connected == true)
            {
                g_Client_v2.pb_ClientBlocked = true;
                g_Client_v2.ptcp_Client.Close();
            }
            if (sender.ToString() == "EXIT")
            {
                Application.Exit();
            }
            if (sender.ToString() == "RESTART")
            {
                Application.Restart();
            }
        }

        #region UnionFormMove
        ///////////////////////////////////////////////
        Boolean b_MouseDown = false;
        Int32 X;
        Int32 Y;
        private void panel_MainBack_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDown = false;
        }

        private void panel_MainBack_MouseMove(object sender, MouseEventArgs e)
        {
            Int32 li_X, li_Y;
            if (b_MouseDown == true)
            {
                li_X = this.Location.X + e.X - X;
                li_Y = this.Location.Y + e.Y - Y;
                this.Location = new Point(li_X, li_Y);
            }
        }

        private void panel_MainBack_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDown = true;
            X = e.X;
            Y = e.Y;
        }

   
        /////////////////////////////////////////////// 
        #endregion
        private void textBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button_SignIn_Click(null, null);
            }
        }
        
        private void notifyIcon_Main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Location = g_Settings.po_MainFormPosition;
        }
        private void pictureBox_Hide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private String prs_GetID()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                ManagementObjectCollection moc_Collection = searcher.Get();
                List<String> list_ID = new List<String>();
                foreach (ManagementObject hdd in moc_Collection)
                {
                    list_ID.Add(hdd["SerialNumber"].ToString().Trim());
                }
                return list_ID[0];
            }
            catch { return Environment.MachineName+Environment.UserName; }
        }

        private void f_Main_Shown(object sender, EventArgs e)
        {
            g_Client_v2.pth_Client = new Thread(new ParameterizedThreadStart(g_Client_v2.pv_ConnectThread));
            g_Client_v2.pth_Client.Start();
        }
    }
}
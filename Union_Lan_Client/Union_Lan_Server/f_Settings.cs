using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Union_Lan_Client
{
    public partial class f_Settings : Form
    {
        cl_FileWorker g_FW = new cl_FileWorker();
        cl_FileWorker.cl_Settings g_Settings = new cl_FileWorker.cl_Settings();
        public f_Union gf_Union;
        public f_Settings()
        {
            InitializeComponent();
        }

        private void f_Settings_Load(object sender, EventArgs e)
        {
            g_Settings = g_FW.p_cl_ReadSettings();

            textBox_ServerIP.Text = g_Settings.ps_ServerIP;
            textBox_ServerPort.Text = g_Settings.ps_ServerPort;

            checkBox_ProxyEnable.Checked = g_Settings.pb_ProxyEnabled;
            textBox_ProxyIP.Text = g_Settings.ps_ProxyIP;
            textBox_ProxyPort.Text = g_Settings.ps_ProxyPort;

            if (g_Settings.pb_ProxyEnabled == false)
            {
                groupBox_ProxySettings.Enabled = false;
            }

            checkBox_Autostart.Checked = g_Settings.pb_Autostart;
            checkBox_RememberPassword.Checked = g_Settings.pb_RememberPassword;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            g_Settings.ps_ServerIP = textBox_ServerIP.Text;
            g_Settings.ps_ServerPort = textBox_ServerPort.Text;
            g_Settings.pb_ProxyEnabled = checkBox_ProxyEnable.Checked;
            g_Settings.ps_ProxyIP = textBox_ProxyIP.Text;
            g_Settings.ps_ProxyPort = textBox_ProxyPort.Text;
            g_Settings.pb_Autostart = checkBox_Autostart.Checked;
            g_Settings.pb_RememberPassword = checkBox_RememberPassword.Checked;

            g_FW.pv_WriteSettings(g_Settings);
            #region Добавление\Удаление автозапуска в реестре
            if (checkBox_Autostart.Checked == true)
            {
                try
                {
                    RegistryKey regFirst = Registry.CurrentUser;
                    RegistryKey regsw = regFirst.OpenSubKey("Software", true);
                    RegistryKey regmc = regsw.OpenSubKey("Microsoft", true);
                    RegistryKey regwin = regmc.OpenSubKey("Windows", true);
                    RegistryKey regcv = regwin.OpenSubKey("CurrentVersion", true);
                    RegistryKey regrun = regcv.OpenSubKey("Run", true);
                    regrun.SetValue("UnionLanClient", Application.ExecutablePath, RegistryValueKind.String);
                    regrun.Close();
                    regcv.Close();
                    regwin.Close();
                    regmc.Close();
                    regsw.Close();
                    regFirst.Close();
                }
                catch { MessageBox.Show("Ошибка при добавление автозапуска в реестр"); }
            }

            if (checkBox_Autostart.Checked == false)
            {
                try
                {
                    RegistryKey regFirst = Registry.CurrentUser;
                    RegistryKey regsw = regFirst.OpenSubKey("Software", true);
                    RegistryKey regmc = regsw.OpenSubKey("Microsoft", true);
                    RegistryKey regwin = regmc.OpenSubKey("Windows", true);
                    RegistryKey regcv = regwin.OpenSubKey("CurrentVersion", true);
                    RegistryKey regrun = regcv.OpenSubKey("Run", true);
                    regrun.DeleteValue("UnionLanClient", false);
                    regrun.Close();
                    regcv.Close();
                    regwin.Close();
                    regmc.Close();
                    regsw.Close();
                    regFirst.Close();
                }
                catch { MessageBox.Show("Ошибка при удалении автозапуска в реестре"); }
            } 
            #endregion

            Close();
        }

        private void checkBox_ProxyEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ProxyEnable.Checked == true)
            {
                groupBox_ProxySettings.Enabled = true;
            }
            if (checkBox_ProxyEnable.Checked == false)
            {
                groupBox_ProxySettings.Enabled = false;
            }
        }

        private void checkBox_Autostart_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void label_ProgrammLink_Click(object sender, EventArgs e)
        {
            try
            {
                string s_PathShortcut = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string linkPathName = s_PathShortcut + "\\UnionLan.lnk";
                string s_PathApplication = Application.ExecutablePath;
                IWshRuntimeLibrary.WshShell wsh_Shell = new IWshRuntimeLibrary.WshShell();
                IWshRuntimeLibrary.IWshShortcut wsh_Link = (IWshRuntimeLibrary.IWshShortcut)wsh_Shell.CreateShortcut(linkPathName);
                wsh_Link.WindowStyle = 1;
                wsh_Link.TargetPath = s_PathApplication;
                wsh_Link.Description = "";
                wsh_Link.WorkingDirectory = Application.StartupPath;
                wsh_Link.IconLocation = s_PathApplication;
                wsh_Link.Save();

                g_Settings = g_FW.p_cl_ReadSettings();
                g_Settings.pb_ProgrammLink = true;
                g_FW.pv_WriteSettings(g_Settings);
            }
            catch { MessageBox.Show("Ошибка при создании ярлыка"); }
        }

    }
}

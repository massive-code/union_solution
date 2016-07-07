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
using System.Net;
using System.Net.Sockets;
using Microsoft.Win32;

namespace Union_Lan_Server
{
    public partial class f_Settings : Form
    {
        cl_Settings gcl_Settings = new cl_Settings();
        cl_Settings.cl_Data gcl_Data = new cl_Settings.cl_Data();

        public f_Settings()
        {
            InitializeComponent();
        }

        private void button_BasePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_BasePathSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(folderBrowserDialog_BasePathSelect.SelectedPath + "\\users_registration._ul") == false)
                { MessageBox.Show("Не найдена база пользователей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    textBox_BasePath.Text = folderBrowserDialog_BasePathSelect.SelectedPath;
                    gcl_Data.ps_BasePath = folderBrowserDialog_BasePathSelect.SelectedPath;
                }
            }
        }

        private void f_Settings_Load(object sender, EventArgs e)
        {
            gcl_Data = gcl_Settings.p_cl_ReadSettings();
            textBox_BasePath.Text = gcl_Data.ps_BasePath;
            textBox_SocketPort.Text = gcl_Data.ps_SocketPort;
            textBox_ClientVersion.Text = gcl_Data.ps_ClientVersion;
            checkBox_AutoStart.Checked = gcl_Data.pb_AutoStart;

            IPAddress[] ip_Adress = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress l_IP in ip_Adress)
            {
                if (l_IP.AddressFamily == AddressFamily.InterNetwork)
                {
                    comboBox_IP.Items.Add(l_IP.ToString());
                    if (l_IP.ToString() == gcl_Data.ps_SocketIP)
                    {
                        comboBox_IP.SelectedItem = l_IP.ToString();
                    }
                }
            }
            if(comboBox_IP.Text == String.Empty)
            {
                comboBox_IP.BackColor = Color.IndianRed;
            }
        }

        private void button_CloseSettings_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_SaveSettings_Click(object sender, EventArgs e)
        {
            gcl_Data.ps_ClientVersion = textBox_ClientVersion.Text;
            if (comboBox_IP.Text != String.Empty)
            {
                gcl_Data.ps_SocketIP = comboBox_IP.SelectedItem.ToString();
            }
            else { gcl_Data.ps_SocketIP = String.Empty; }
            gcl_Data.ps_SocketPort = textBox_SocketPort.Text;
            gcl_Data.pb_AutoStart = checkBox_AutoStart.Checked;
            gcl_Settings.pv_WriteSettings(gcl_Data);

            #region Добавление\Удаление автозапуска в реестре
            if (checkBox_AutoStart.Checked == true)
            {
                try
                {
                    RegistryKey regFirst = Registry.CurrentUser;
                    RegistryKey regsw = regFirst.OpenSubKey("Software", true);
                    RegistryKey regmc = regsw.OpenSubKey("Microsoft", true);
                    RegistryKey regwin = regmc.OpenSubKey("Windows", true);
                    RegistryKey regcv = regwin.OpenSubKey("CurrentVersion", true);
                    RegistryKey regrun = regcv.OpenSubKey("Run", true);
                    regrun.SetValue("UnionLanServer", Application.ExecutablePath, RegistryValueKind.String);
                    regrun.Close();
                    regcv.Close();
                    regwin.Close();
                    regmc.Close();
                    regsw.Close();
                    regFirst.Close();
                }
                catch { MessageBox.Show("Ошибка при добавление автозапуска в реестр"); }
            }

            if (checkBox_AutoStart.Checked == false)
            {
                try
                {
                    RegistryKey regFirst = Registry.CurrentUser;
                    RegistryKey regsw = regFirst.OpenSubKey("Software", true);
                    RegistryKey regmc = regsw.OpenSubKey("Microsoft", true);
                    RegistryKey regwin = regmc.OpenSubKey("Windows", true);
                    RegistryKey regcv = regwin.OpenSubKey("CurrentVersion", true);
                    RegistryKey regrun = regcv.OpenSubKey("Run", true);
                    regrun.DeleteValue("UnionLanServer", false);
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

        private void checkBox_AutoStart_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

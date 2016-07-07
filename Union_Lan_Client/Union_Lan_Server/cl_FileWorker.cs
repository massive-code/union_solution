using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace Union_Lan_Client
{
    public class cl_FileWorker
    {
        cl_GlobalVariables g_GV = new cl_GlobalVariables();
        public class cl_Settings
        {
            public Point po_MainFormPosition;
            public Point po_UnionFormPosition;
            public String ps_ServerIP;
            public String ps_ServerPort;
            //////////////////////////////
            public Boolean pb_ProxyEnabled;
            public String ps_ProxyIP;
            public String ps_ProxyPort;
            //////////////////////////////
            public Boolean pb_RememberLogin;
            public String ps_Login;
            //////////////////////////////
            public Boolean pb_Autostart;
            public Boolean pb_ProgrammLink;
            //////////////////////////////
            public Boolean pb_RememberPassword;
            public String ps_Password;
        }

        public void pv_CreateSettings()
        {
          
            cl_Settings l_cl_Settings = new cl_Settings();
            l_cl_Settings.po_MainFormPosition = new Point(0, 0);
            l_cl_Settings.po_UnionFormPosition = new Point(0, 0);
            l_cl_Settings.ps_ServerIP = "127.0.0.1";
            l_cl_Settings.ps_ServerPort = "443";
            //////////////////////////////
            l_cl_Settings.pb_ProxyEnabled = false;
            l_cl_Settings.ps_ProxyIP = null;
            l_cl_Settings.ps_ProxyPort = null;
            //////////////////////////////
            l_cl_Settings.pb_RememberLogin = false;
            l_cl_Settings.pb_RememberPassword = false;
            l_cl_Settings.ps_Login = String.Empty;
            l_cl_Settings.ps_Password = String.Empty;
            //////////////////////////////
            l_cl_Settings.pb_Autostart = true;
            l_cl_Settings.pb_ProgrammLink = false;
            //////////////////////////////
            pv_WriteSettings(l_cl_Settings);

        }

        public void pv_WriteSettings(cl_Settings l_cl_Settings)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(cl_Settings));
            FileStream fs_FileStream = new FileStream(g_GV.ps_SettingsFilePath(), FileMode.Create);
            xml_Serializer.Serialize(fs_FileStream, l_cl_Settings);
            fs_FileStream.Close();
        }

        public cl_Settings p_cl_ReadSettings()
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(cl_Settings));
            FileStream fs_FileStream = new FileStream(g_GV.ps_SettingsFilePath(), FileMode.Open);
            cl_Settings l_Temp =  (cl_Settings)xml_Serializer.Deserialize(fs_FileStream);
            fs_FileStream.Close();
            return l_Temp;
        }

        public void pv_ClearDirectory()
        {
            if (Directory.Exists(Application.StartupPath + "\\cache") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\cache");
            }
            String[] lsm_FilePathes = Directory.GetFiles(Application.StartupPath + "\\cache");
            foreach (String ls_Path in lsm_FilePathes)
            {
                try
                {
                    File.Delete(ls_Path);
                }
                catch (IOException) { }
            }

            if (Directory.Exists(Application.StartupPath + "\\update") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\update");
            }
            lsm_FilePathes = Directory.GetFiles(Application.StartupPath + "\\update");
            foreach (String ls_Path in lsm_FilePathes)
            {
                try
                {
                    File.Delete(ls_Path);
                }
                catch (IOException) { }
            }
        }

        public void pv_CreateLogFile()
        {
            String ls_Path = Application.StartupPath + "\\log.txt";
            if (File.Exists(ls_Path) == false)
            {
                FileStream fs = new FileStream(ls_Path, FileMode.Create);
                fs.Close();
            }
        }

        public void pv_WriteToLogFile(String ls_Text)
        { 
            String ls_Path = Application.StartupPath + "\\log.txt";
            File.AppendAllText(ls_Path, ls_Text+"\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Union_Lan_Server
{
    public class cl_Settings
    {
        cl_GlobalVariables g_GV = new cl_GlobalVariables();

        public class cl_Data
        {
            public String ps_BasePath;
            public String ps_SocketIP;
            public String ps_SocketPort;
            public String ps_ClientVersion;
            public Boolean pb_AutoStart;
        }

        public void pv_CreateSettingsFile()
        {
            if (File.Exists(Application.StartupPath + "\\settings._us") == false)
            {
                cl_Data lcl_SD = new cl_Data();
                lcl_SD.ps_BasePath = Application.StartupPath;
                pv_WriteSettings(lcl_SD);
            }
        }

        public void pv_WriteSettings(cl_Data l_cl_SD)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(cl_Data));
            FileStream fs_FileStream = new FileStream(Application.StartupPath + "\\settings._us", FileMode.Create);
            xml_Serializer.Serialize(fs_FileStream, l_cl_SD);
            fs_FileStream.Close();
        }

        public cl_Data p_cl_ReadSettings()
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(cl_Data));
            FileStream fs_FileStream = new FileStream(Application.StartupPath + "\\settings._us", FileMode.Open);
            cl_Data l_Temp = (cl_Data)xml_Serializer.Deserialize(fs_FileStream);
            fs_FileStream.Close();
            return l_Temp;
        }
    }
}

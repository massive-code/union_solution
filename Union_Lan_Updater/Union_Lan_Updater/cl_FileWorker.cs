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

namespace Union_Lan_Updater
{
    public class cl_FileWorker
    {
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
            public String ps_TimeToUpdateContactsStatus;
            //////////////////////////////
            public Boolean pb_AutorizationByLogin;
        }

        public void pv_WriteSettings(cl_Settings l_cl_Settings, String ls_Path)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(cl_Settings));
            FileStream fs_FileStream = new FileStream(ls_Path, FileMode.Create);
            xml_Serializer.Serialize(fs_FileStream, l_cl_Settings);
            fs_FileStream.Close();
        }

        public cl_Settings p_cl_ReadSettings(String ls_Path)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(cl_Settings));
            FileStream fs_FileStream = new FileStream(ls_Path, FileMode.Open);
            cl_Settings l_Temp = (cl_Settings)xml_Serializer.Deserialize(fs_FileStream);
            fs_FileStream.Close();
            return l_Temp;
        }

    }
}

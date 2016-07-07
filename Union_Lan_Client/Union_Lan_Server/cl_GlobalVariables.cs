using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Union_Lan_Client
{
    public class cl_GlobalVariables
    {
        #region Checked
        public String ps_ClientVersion = "1.37";
        String s_ApplicationStartupPath()
        {
            return Application.StartupPath;
        }
        public String ps_ImageFolder()
        {
            return s_ApplicationStartupPath() + "\\Images\\";
        }
        public String ps_SmileFolder()
        {
            return s_ApplicationStartupPath() + "\\Smile\\";
        }
        public String ps_SettingsFilePath()
        {
            return s_ApplicationStartupPath() + "\\Settings._ul";
        }
        public struct str_PersonalData
        {
            public String UID;
            public String Name;
            public String Surname;
            public String Birthday;
            public String ImageFileName;
            public String Job;
            public String Workplace;
            public String Lifeplace;
            public String Gender;
            public String Login;
            public String Password;
        }
        public struct str_Contact
        {
            public String s_UID;
            public Int32 s_Number;
            public String s_Status;
            public f_Chat f_Form;
            public Boolean b_ChatFormOpened;
            public String s_Name;
            public String s_Surname;
            public String s_ImagePath;
            public String s_Job;
            //////////////////////////
            public List<String> plist_NewMessagesOutcoming;
            public Int32 i_NewMessagesCountIncoming;
            public Boolean b_NewMessagesIncoming;
            //////////////////////////
            public Boolean WritingMessage;
            public System.Threading.Timer WritingAnimation;
            public System.Threading.Timer WritingTimeOutTimer;
        }
        public String ps_CryptKey = "4870c485a"; 
        #endregion

       ///////////////////////////////////////////
       public Int32 pi_ServerTimeOutTimerInterval = 60000;
       ///////////////////////////////////////////
       public Int32 pi_UpdateUpdateContactsInfo = 30*60000;
       public Boolean pb_UF_TimerUpdateContactsInfoEnable = true;
       ///////////////////////////////////////////
       public Int32 pi_UpdateContactsStatus = 60000;
       public Boolean pb_UF_TimerUpdateContactsStatusEnable = true;
       ///////////////////////////////////////////
       public Boolean pb_UF_ChatOpenSend = true;
       public Boolean pb_Compress = true;
       ///////////////////////////////////////////
       public Int32 pi_UserActivity = 30*60000;
       public Boolean pb_UF_TimerUserActivityEnable = true;
    }
}

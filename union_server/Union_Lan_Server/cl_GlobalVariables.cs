using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Union_Lan_Server
{
    public class cl_GlobalVariables
    {
        public String g_ServerCurrentVersion = "1.14";
        public String s_MainBaseFolderName = "union_lan_base";
        String s_UsersBaseFolderName = "users_base";
        String s_UserRegistrationSQLBaseName = "users_registration._ul";
        String s_UserContactsSQLBaseName = "contact._ul";

        public cl_Settings.cl_Data pcl_SettingsData;

        public String ps_MainBaseFolderPath()
        {
            return pcl_SettingsData.ps_BasePath+"\\";
        }
        /// <summary>
        /// Пусть до файла баз регистрации пользователей
        /// </summary>
        /// <returns></returns>
        public String ps_MainUsersRegistrationBasePath()
        {
            return ps_MainBaseFolderPath() + s_UserRegistrationSQLBaseName;
        }
        /// <summary>
        /// Путь до основной папки пользователей 
        /// </summary>
        /// <returns></returns>
        public String ps_UsersBaseFolderPath()
        {
            return ps_MainBaseFolderPath() + s_UsersBaseFolderName;
        }

        public String ps_UserContactSQLBasePath(String ls_UID)
        {
            return ps_UsersBaseFolderPath() + "\\" + ls_UID + "\\" + s_UserContactsSQLBaseName;
        }

        public String ps_CurrentDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        public String ps_CryptKey = "4870c485a";
        ////////////////////////////////////
        public Boolean pb_TimeOutTimerEnable = true;
        public Int32   pi_TimeOutTimerInterval = 10 * 60000;
        public Int32   pi_TimeOutTimerPeriod = 0;
        ////////////////////////////////////
        public Int32 pi_DaysUntilFilesDelete = 1;
    }
}

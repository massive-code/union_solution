using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Union_Lan_Server
{
    public class cl_FileWorker
    {
        public cl_GlobalVariables g_GV;
        cl_SQLWorker g_SQLW = new cl_SQLWorker();

        String gs_LogFilePath = Application.StartupPath + "\\log.txt";

        public f_Main pf_Main;
        /// <summary>
        /// Метод создания всех основных папок для программы
        /// </summary>
        public void pv_CreateBaseFolder()
        {
            if (Directory.Exists(g_GV.ps_MainBaseFolderPath()) == false)
            {
                Directory.CreateDirectory(g_GV.ps_MainBaseFolderPath());
            }

            if (Directory.Exists(g_GV.ps_MainBaseFolderPath() + "\\profile_images") == false)
            {
                Directory.CreateDirectory(g_GV.ps_MainBaseFolderPath() + "\\profile_images");
            }

            if (Directory.Exists(Application.StartupPath+"\\client_update") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\client_update");
            }

            if (Directory.Exists(g_GV.ps_UsersBaseFolderPath()) == false)
            {
                Directory.CreateDirectory(g_GV.ps_UsersBaseFolderPath());
            }

        }
        /// <summary>
        /// Создание базы данных регистрации пользователей.
        /// </summary>
        public void pv_CreateUserRegistrationSQLBase()
        {
            if (File.Exists(g_GV.ps_MainUsersRegistrationBasePath()) == false)
            {
                g_SQLW.pv_Create_UserRegistrationBase(g_GV.ps_MainUsersRegistrationBasePath());
            }
        }
        /// <summary>
        /// Создание папок и баз данных конкретного пользователя по полученному UID
        /// </summary>
        /// <param name="ls_UID"></param>
        public void pv_UserCreat(String ls_UID)
        {
            String ls_UserFolderPath = g_GV.ps_UsersBaseFolderPath() + "\\" + ls_UID;
            String ls_OwnUserMessageArhiveFolderPath = g_GV.ps_UsersBaseFolderPath() + "\\" + ls_UID + "\\message_arhive";
            String ls_TempMessageDB = g_GV.ps_MainBaseFolderPath() + "\\users_base\\" + ls_UID + "\\temp_messages._ul";
            String ls_UserFiles = g_GV.ps_MainBaseFolderPath() + "\\users_base\\" + ls_UID + "\\files";
            String ls_UserFilesDB = g_GV.ps_MainBaseFolderPath() + "\\users_base\\" + ls_UID + "\\files._ul";

            if (Directory.Exists(ls_UserFolderPath) == false) // папка пользователя
            {
                Directory.CreateDirectory(ls_UserFolderPath);
            }

            if (Directory.Exists(ls_OwnUserMessageArhiveFolderPath) == false) 
            {
                Directory.CreateDirectory(ls_OwnUserMessageArhiveFolderPath);
            }

            if (File.Exists(g_GV.ps_UserContactSQLBasePath(ls_UID)) == false) //адресная база пользователя
            {
                g_SQLW.pv_Create_UserContactBase(g_GV.ps_UserContactSQLBasePath(ls_UID));
            }

            if (File.Exists(ls_TempMessageDB) == false) //БД с временными сообщениями
            {
                g_SQLW.pv_Create_TempUserMessageArhive(ls_TempMessageDB);
            }

            if (Directory.Exists(ls_UserFiles) == false)
            {
                Directory.CreateDirectory(ls_UserFiles);
            }

            if (File.Exists(ls_UserFilesDB) == false) 
            {
                g_SQLW.pv_Create_UserFilesDB(ls_UserFilesDB);
            }
        }

        public void pv_Added_UserMessageArhive(String ls_OwnUserUID, String ls_AddedUserUID)
        {
            String ls_OwnUserPath = g_GV.ps_UsersBaseFolderPath() + "\\" + ls_OwnUserUID + "\\message_arhive";
            String ls_AddedUserMainPath = ls_OwnUserPath + "\\" + ls_AddedUserUID;
            if (Directory.Exists(ls_AddedUserMainPath) == false)
            {
                Directory.CreateDirectory(ls_AddedUserMainPath);
            }

            //String ls_AddedUserFilePath = ls_OwnUserPath + "\\" + ls_AddedUserUID + "\\files";
            //if (Directory.Exists(ls_AddedUserFilePath) == false)
            //{
            //    Directory.CreateDirectory(ls_AddedUserFilePath);
            //}

            if (File.Exists(ls_AddedUserMainPath + "\\messages._ms") == false)
            {
                g_SQLW.pv_Create_AddedUserMessageArhive(ls_AddedUserMainPath + "\\messages._ms");
            }
        }

        public void pv_CreateLogFile()
        {
            if (File.Exists(gs_LogFilePath) == false)
            {
                FileStream fs_Stream = new FileStream(gs_LogFilePath, FileMode.Create);
                fs_Stream.Close();
            }
        }

        public void pv_WriteToLogFile(String ls_Data)
        {
            File.AppendAllText(gs_LogFilePath, ls_Data+"\n");
        }
    }
}

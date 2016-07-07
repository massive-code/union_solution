using Cryptor;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Union_Lan_Server
{
    public class cl_DataWorkerServer
    {
        cl_Compression g_CMP = new cl_Compression();
        cl_XML_Data g_XML = new cl_XML_Data();
        cl_SQLWorker g_SQLW = new cl_SQLWorker();
        cl_FileWorker g_FW = new cl_FileWorker();
        public cl_Client g_Client;
        public f_Main pf_Main;//убрать
        public cl_Server_v2 g_Server_v2;
        public cl_GlobalVariables g_GV;//убрать
        delegate void del_ClientDisconnect(cl_Client Client);
        Cryptor.cl_Crypting_Rijndael g_CryRij = new cl_Crypting_Rijndael();
        public struct pstr_Client
        {
            public String UID;
            public String Login;
            public Boolean Compression;
            public Boolean pb_Authorized;
            public Boolean pb_BlockedConnection;
            public Boolean pb_UserActive;
            public String ps_CurrentMessageID;
        }
        public pstr_Client Client = new pstr_Client();
        List<String> glist_ContactChatOpenedUID = new List<String>(); //перевести в структуру
        void v_SendMethod(String ls_SendingData, String ls_DataKind)
        {
            cl_XML_Data.str_DataKind lstr_DK = new cl_XML_Data.str_DataKind();
            lstr_DK.From = "FROM_SERVER";
            lstr_DK.Kind = ls_DataKind;
            lstr_DK.Data = ls_SendingData;
            lstr_DK.ID = Client.ps_CurrentMessageID;
            ls_SendingData = g_XML.vm_DataKind_To_XMLData(lstr_DK);
            if (Client.Compression == true)
            {
                ls_SendingData = g_CMP.Compress(ls_SendingData);
            }
            g_Client.list_SendData.Add(ls_SendingData);
            Client.ps_CurrentMessageID = String.Empty;
        }

        public void pv_GetData_Error()
        {
            v_SendMethod("", "GET_DATA_ERROR");
        }

        public void pv_SEND_CLOSE_CHAT_FORM()
        {
            foreach (String ls_UID in glist_ContactChatOpenedUID)
            {
                foreach (cl_Client l_Client in g_Server_v2.list_Client)
                {
                    if (l_Client.g_DW.Client.UID == ls_UID)
                    {
                        l_Client.g_DW.v_SendMethod(Client.UID, "CHAT_CLOSED");
                    }
                }
            }
        }
        public void pv_IncomindData(String ls_IncData)
        {
            try
            {
                ls_IncData = g_CMP.Decompress(ls_IncData);
                Client.Compression = true;
            }
            catch
            {
                Client.Compression = false;
            }
            if (ls_IncData != "")
            {
                cl_XML_Data.str_DataKind lstr_DataKind = g_XML.pstr_ReadXMLDataKind(ls_IncData);
                pv_IncomingFromClient(lstr_DataKind);
            }
        }
        public void pv_IncomingFromClient(cl_XML_Data.str_DataKind lstr_Data)
        {
            Client.ps_CurrentMessageID = lstr_Data.ID;

            g_SQLW.g_GV = g_GV;
            g_FW.g_GV = g_GV;
            
            switch (lstr_Data.Kind)
            {
                case "CONNECT_SERVER":CONNECT_SERVER();break;
                case "CHECK_CONNECTION":CHECK_CONNECTION();break;
                case "UPDATE_CLIENT":UPDATE_CLIENT();break;
                case "USER_REGISTRATION":USER_REGISTRATION(lstr_Data);break;
                case "USER_DATA_EDIT":USER_DATA_EDIT(lstr_Data);break;
                case "SIGN_IN":SIGN_IN(lstr_Data);break;
                case "PROFILE_INFO": PROFILE_INFO(); break;
                case "USER_COUNT":USER_COUNT();break;
                case "USERS_SHOW":USERS_SHOW(lstr_Data);break;
                case "CONTACTS_OPERATION": v_ContackOperation(lstr_Data.Data);break;
                case "DOWNLOAD_MY_CONTACTS":DOWNLOAD_MY_CONTACTS();break;
                case "DOWNLOAD_TEMP_MESSAGE_ARHIVE": DOWNLOAD_TEMP_MESSAGE_ARHIVE();break;
                case "DOWNLOAD_FILE": DOWNLOAD_FILE(lstr_Data); break;
                case "CONTACTS_STATUS":CONTACTS_STATUS(lstr_Data);break;
                case "SEND_MESSAGE":SEND_MESSAGE(lstr_Data);break;
                case "CHAT_OPEN":CHAT_OPEN(lstr_Data);break;
                case "CHAT_CLOSED":CHAT_CLOSED(lstr_Data);break;
                case "WRITE_MESSAGE_WRITE":WRITE_MESSAGE_WRITE(lstr_Data);break;
                case "MESSAGE_ARHIVE_DOWNLOAD":MESSAGE_ARHIVE_DOWNLOAD(lstr_Data);break;
                case "LOAD_PREV_MESSAGES": LOAD_PREV_MESSAGES(lstr_Data); break;
                case "DELETE_MESSAGES":DELETE_MESSAGES(lstr_Data);break;
                case "APPLICATION_CLOSE": APPLICATION_CLOSE(); break;
                case "SEND_FILE": SEND_FILE(lstr_Data); break;
                case "USER_ACTIVITY": USER_ACTIVITY(lstr_Data); break;
                case "UPDATE_USERS_IN_GROUP": UPDATE_USERS_IN_GROUP(lstr_Data); break;
            }
        }

        private void UPDATE_USERS_IN_GROUP(cl_XML_Data.str_DataKind lstr_Data)
        {
            cl_XML_Data.str_UpdateUsersInGroup lstr = new cl_XML_Data.str_UpdateUsersInGroup();
            lstr = g_XML.pstr_ReadXML_UpdateUsersInGroup(lstr_Data.Data);
            g_SQLW.pv_ClearContactFromUserContactBase(g_GV.ps_UserContactSQLBasePath(Client.UID));
            g_SQLW.pv_UpdateContactsInUserContactBase(g_GV.ps_UserContactSQLBasePath(Client.UID), lstr.list_UIDs);
        }
        private void LOAD_PREV_MESSAGES(cl_XML_Data.str_DataKind lstr_Data)
        {
            String[] ls_Split = lstr_Data.Data.Split(new String[] { "]|[" }, StringSplitOptions.RemoveEmptyEntries);
            DataTable ldt = g_SQLW.pdt_ReadPrevMessages(g_GV.ps_UsersBaseFolderPath() + "\\" + Client.UID + "\\message_arhive\\" + ls_Split[1] + "\\messages._ms", ls_Split[0]);
            cl_XML_Data.str_MessageArhive lstr_MA = new cl_XML_Data.str_MessageArhive();
            lstr_MA.s_UID = ls_Split[1];
            lstr_MA.s_Arhive = g_XML.pv_DataTable_To_XML(ldt);
            String ls_SendingData = g_XML.ps_MessageArhive_To_XMLData(lstr_MA);
            v_SendMethod(ls_SendingData, "MESSAGE_ARHIVE");
        }
        private void USER_ACTIVITY(cl_XML_Data.str_DataKind lstr_Data)
        {
            Client.pb_UserActive = Convert.ToBoolean(lstr_Data.Data);
        }

        private void PROFILE_INFO()
        {
            cl_XML_Data.str_Profile lstr_Profile = new cl_XML_Data.str_Profile();
            DataTable ldt_DataTable = g_SQLW.ps_ReadUserData_UserRegistrationBase(Client.Login);
            lstr_Profile.UID = ldt_DataTable.Rows[0][0].ToString();
            lstr_Profile.Name = ldt_DataTable.Rows[0][1].ToString();
            lstr_Profile.Surname = ldt_DataTable.Rows[0][2].ToString();
            lstr_Profile.BirthDay = ldt_DataTable.Rows[0][3].ToString();
            lstr_Profile.ImageFileName = ldt_DataTable.Rows[0][4].ToString();
            String ls_FilePath = g_GV.ps_MainBaseFolderPath() + "\\profile_images\\" + ldt_DataTable.Rows[0][4].ToString();
            lstr_Profile.ImageFile = File.ReadAllBytes(ls_FilePath);
            lstr_Profile.Job = ldt_DataTable.Rows[0][5].ToString();
            lstr_Profile.Workplace = ldt_DataTable.Rows[0][6].ToString();
            lstr_Profile.Lifeplace = ldt_DataTable.Rows[0][7].ToString();
            lstr_Profile.Gender = ldt_DataTable.Rows[0][8].ToString();
            lstr_Profile.Login = ldt_DataTable.Rows[0][9].ToString();
            String ls_SendingData = g_XML.ps_UserRegistration_To_XMLData(lstr_Profile);
            v_SendMethod(ls_SendingData, "PROFILE_INFO");
        }
        private void SEND_FILE(cl_XML_Data.str_DataKind lstr_Data)
        {
            cl_XML_Data.str_SendFile lstr_SF = g_XML.pstr_ReadXMLSendFile(lstr_Data.Data);
            File.WriteAllBytes(lstr_SF.FileName, lstr_SF.File);
        }
        public void BLOCKING_BY_SERVER()
        {
            v_SendMethod("", "BLOCKING_BY_SERVER");
        }
        private void APPLICATION_CLOSE()
        {
            del_ClientDisconnect ldel = new del_ClientDisconnect(pf_Main.pv_ClientDisconnect);
            pf_Main.Invoke(ldel, new object[] {g_Client});
        }
        private void DELETE_MESSAGES(cl_XML_Data.str_DataKind lstr_Data)
        {
            String ls_DeleteMessageBasePath = g_GV.ps_UsersBaseFolderPath() + "\\" + Client.UID + "\\message_arhive\\" + lstr_Data.Data + "\\messages._ms";
            g_SQLW.pv_DeleteMessages(ls_DeleteMessageBasePath);
            v_SendMethod(lstr_Data.Data, "MESSAGES_DELETED");
        }
        private void MESSAGE_ARHIVE_DOWNLOAD(cl_XML_Data.str_DataKind lstr_Data)
        {
            cl_XML_Data.str_MessageArhive lstr_MA = new cl_XML_Data.str_MessageArhive();
            DataTable ldt_DataTableTempMessages = g_SQLW.pdt_ReadTempMessageArhive_ByUID(g_GV.ps_UsersBaseFolderPath() + "\\" + Client.UID + "\\temp_messages._ul", lstr_Data.Data);
            Boolean lb_SendOnlyNewMessages = false;
            if (ldt_DataTableTempMessages.Rows.Count > 0)
            {
                DateTime ldt_1 = Convert.ToDateTime(ldt_DataTableTempMessages.Rows[0]["Date"]);
                DateTime ldt_2 = Convert.ToDateTime(ldt_DataTableTempMessages.Rows[ldt_DataTableTempMessages.Rows.Count-1]["Date"]);
                if (ldt_1.ToShortDateString() != ldt_2.ToShortDateString())
                {
                    lstr_MA.s_Arhive = g_XML.pv_DataTable_To_XML(ldt_DataTableTempMessages);
                    lb_SendOnlyNewMessages = true;
                }

                if (ldt_1.ToShortDateString() == ldt_2.ToShortDateString())
                {
                    lb_SendOnlyNewMessages = false;
                }
            }
            if (ldt_DataTableTempMessages.Rows.Count == 0 || lb_SendOnlyNewMessages == false)
            {
                String ls_DownloadMessageBasePath = g_GV.ps_UsersBaseFolderPath() + "\\" + Client.UID + "\\message_arhive\\" + lstr_Data.Data + "\\messages._ms";
                DataTable ldt_DataTable = g_SQLW.pdt_ReadMessageArhive_LastDay(ls_DownloadMessageBasePath);
                lstr_MA.s_Arhive = g_XML.pv_DataTable_To_XML(ldt_DataTable);
            }

            lstr_MA.s_UID = lstr_Data.Data;
            lstr_MA.ContactChatFormOpened = false;
            
            foreach (cl_Client l_Client in g_Server_v2.list_Client)
            {
                if (l_Client.g_DW.Client.pb_Authorized == true & l_Client.g_DW.Client.UID == lstr_Data.Data & l_Client.g_DW.Client.pb_BlockedConnection == false)
                {
                    if (l_Client.g_DW.glist_ContactChatOpenedUID.Contains(Client.UID) == true)
                    {
                        lstr_MA.ContactChatFormOpened = true;
                    }
                }
            }

            String ls_SendingData = g_XML.ps_MessageArhive_To_XMLData(lstr_MA);
            v_SendMethod(ls_SendingData, "MESSAGE_ARHIVE");

            String ls_TempMessageArhivePath = g_GV.ps_UsersBaseFolderPath() + "\\" + Client.UID + "\\temp_messages._ul";
            g_SQLW.pv_DeleteRowTempMessages(ls_TempMessageArhivePath, lstr_Data.Data);
        }
        private void WRITE_MESSAGE_WRITE(cl_XML_Data.str_DataKind lstr_Data)
        {
            foreach (cl_Client l_Client in g_Server_v2.list_Client)
            {
                if (l_Client.g_DW.Client.pb_Authorized == true & l_Client.g_DW.Client.UID == lstr_Data.Data & l_Client.g_DW.Client.pb_BlockedConnection == false)
                {
                    l_Client.g_DW.v_SendMethod(Client.UID, "WRITE_MESSAGE_WRITE");
                }
            }
            v_SendMethod("", "MESSAGE_RECEIVED");
        }
        private void CHAT_CLOSED(cl_XML_Data.str_DataKind lstr_Data)
        {
            foreach (cl_Client l_Client in g_Server_v2.list_Client)
            {
                if (l_Client.g_DW.Client.pb_Authorized == true & l_Client.g_DW.Client.UID == lstr_Data.Data & l_Client.g_DW.Client.pb_BlockedConnection == false)
                {
                    l_Client.g_DW.v_SendMethod(Client.UID, "CHAT_CLOSED");
                }
            }

            glist_ContactChatOpenedUID.Remove(lstr_Data.Data);
            v_SendMethod("", "MESSAGE_RECEIVED");
        }
        private void CHAT_OPEN(cl_XML_Data.str_DataKind lstr_Data)
        {
            if (glist_ContactChatOpenedUID.Contains(lstr_Data.Data) == false)
            {
                glist_ContactChatOpenedUID.Add(lstr_Data.Data);
            }
            String ls_AddAttributeReadedToMessagePath = g_GV.ps_UsersBaseFolderPath() + "\\" + lstr_Data.Data + "\\message_arhive\\" + Client.UID + "\\messages._ms";
            g_SQLW.pv_AddAttributeReaded(ls_AddAttributeReadedToMessagePath, lstr_Data.Data);
            foreach (cl_Client l_Client in g_Server_v2.list_Client)
                {
                    if (l_Client.g_DW.Client.pb_Authorized == true & l_Client.g_DW.Client.UID == lstr_Data.Data & l_Client.g_DW.Client.pb_BlockedConnection == false)
                    {
                        l_Client.g_DW.v_SendMethod(Client.UID, "CHAT_OPENED");
                    }
                }

            v_SendMethod("", "MESSAGE_RECEIVED");
        }
        private void SEND_MESSAGE(cl_XML_Data.str_DataKind lstr_Data)
        {
            String ls_SendingData;
            //разбор сообщения
            cl_XML_Data.str_Message lstr_SM = new cl_XML_Data.str_Message();
            lstr_SM = g_XML.pstr_ReadXMLMessage(lstr_Data.Data);
            //добавление сообщения в архив данного клиента
            String ls_AddMessageToThisBasePath = g_GV.ps_UsersBaseFolderPath() + "\\" + lstr_SM.s_From_UID + "\\message_arhive\\" + lstr_SM.s_To_UID + "\\messages._ms";
            String ls_AddmessageToTempMessageArhive = g_GV.ps_UsersBaseFolderPath() + "\\" + lstr_SM.s_To_UID + "\\temp_messages._ul";
            String ls_Message_ID = Cryptor.cl_Crypting_MD5.psvm_MD5_Text(DateTime.Now.ToString());
            lstr_SM.s_Message_ID = ls_Message_ID;
            lstr_SM.s_DateTime = DateTime.Now.ToString();
            if (lstr_SM.s_Attribute == "FILE")
            {
                File.WriteAllBytes(g_GV.ps_UsersBaseFolderPath() + "\\" + lstr_SM.s_From_UID + "\\files\\" + lstr_SM.s_Message_ID, lstr_SM.bm_Investment);
                g_SQLW.pv_AddFileToUserFilesDB(g_GV.ps_UsersBaseFolderPath() + "\\" + lstr_SM.s_From_UID + "\\files._ul", lstr_SM.s_To_UID, DateTime.Now, lstr_SM.s_Text, lstr_SM.s_Message_ID, lstr_SM.bm_Investment.Length.ToString(), "null");
            }

            Boolean lb_AddToTemp = false;
            for (int i = 0; i < g_Server_v2.list_Client.Count; i++ )
            {
                cl_Client l_Client = g_Server_v2.list_Client[i];
                if (l_Client.g_DW.Client.pb_Authorized == true & l_Client.g_DW.Client.UID == lstr_SM.s_To_UID & l_Client.g_DW.Client.pb_BlockedConnection == false)
                {
                    if (l_Client.g_DW.glist_ContactChatOpenedUID.Contains(Client.UID) == true)
                    {
                        if (lstr_SM.s_Attribute == "FILE")
                        {
                            lstr_SM.s_Attribute = "FILE_READED";
                        }

                        else
                        {
                            lstr_SM.s_Attribute = "READED";
                        }
                    }
                    ls_SendingData = g_XML.ps_Message_To_XMLData(lstr_SM);
                    l_Client.g_DW.v_SendMethod(ls_SendingData, "INCOMING_MESSAGE");
                }
                else
                {
                    lb_AddToTemp = true;
                }
            }
            if (lb_AddToTemp == true)
            {
                g_SQLW.pv_AddMessageToTempMessageArhive(ls_AddmessageToTempMessageArhive, lstr_SM.s_From_UID, lstr_SM.s_Text, DateTime.Now, lstr_SM.s_Attribute, ls_Message_ID);
            }
            ls_SendingData = g_XML.ps_Message_To_XMLData(lstr_SM);
            v_SendMethod(ls_SendingData, "INCOMING_MESSAGE");
            g_SQLW.pv_AddMessageToArhive(ls_AddMessageToThisBasePath, lstr_SM.s_From_UID, lstr_SM.s_Text, DateTime.Now, lstr_SM.s_Attribute, ls_Message_ID);
            //добавление сообщения в архив контакта если архив имеется
            String ls_AddMessageToContactBasePath = g_GV.ps_UsersBaseFolderPath() + "\\" + lstr_SM.s_To_UID + "\\message_arhive\\" + lstr_SM.s_From_UID + "\\messages._ms";
            g_FW.pv_Added_UserMessageArhive(lstr_SM.s_To_UID, lstr_SM.s_From_UID);
            g_SQLW.pv_AddMessageToArhive(ls_AddMessageToContactBasePath, lstr_SM.s_From_UID, lstr_SM.s_Text, DateTime.Now, lstr_SM.s_Attribute, ls_Message_ID);
        }

        private void DOWNLOAD_FILE(cl_XML_Data.str_DataKind lstr_Data)
        {
            String[] ls_Split = lstr_Data.Data.Split(new String[] { "]|[" }, StringSplitOptions.RemoveEmptyEntries);
            DataRow ldr = null;
            cl_XML_Data.str_SendFile cl_SF = new cl_XML_Data.str_SendFile();
            String ls_SendingData = String.Empty;
            String ls_DB_Path = g_GV.ps_UsersBaseFolderPath() + "\\" + ls_Split[0] + "\\files._ul";
            ldr = g_SQLW.pdr_ReadRow_UserFilesDB(ls_DB_Path, ls_Split[1]);
            if (ldr != null)
            {
                String ls_FilePath = g_GV.ps_UsersBaseFolderPath() + "\\" + ls_Split[0] + "\\files\\" + ldr["FileNameGiven"].ToString();
                if (File.Exists(ls_FilePath) == true)
                {
                    Byte[] lbm_file = File.ReadAllBytes(ls_FilePath);
                    cl_SF.File = lbm_file;
                    cl_SF.FileName = ldr["FileNameOriginal"].ToString();
                    ls_SendingData = g_XML.ps_SendFile_To_XMLData(cl_SF);
                    v_SendMethod(ls_SendingData, "DOWNLOAD_FILE");
                }
                else
                {
                    g_SQLW.pv_DeleteRow_UserFilesDB(ls_DB_Path, ls_Split[1]);
                    v_SendMethod("FILE_NOT_EXIST", "DOWNLOAD_FILE");
                }
            }
            if (ldr == null)
            {
                v_SendMethod("FILE_NOT_FOUND_IN_DB", "DOWNLOAD_FILE");
            }
        }
        private void CONTACTS_STATUS(cl_XML_Data.str_DataKind lstr_Data)
        {
            //читает базу контактов (UIDы) текущего клиента
            DataTable ldt_DataTable = g_SQLW.pdt_ReadUserContactSQLBase(g_GV.ps_UserContactSQLBasePath(lstr_Data.Data));
            cl_XML_Data.str_ContactsStatus lstr_CS = new cl_XML_Data.str_ContactsStatus();
            lstr_CS.sm_UIDs = new String[ldt_DataTable.Rows.Count];
            lstr_CS.sm_Status = new String[ldt_DataTable.Rows.Count];

            for (Int32 i = 0; i < lstr_CS.sm_Status.Length; i++)
            {
                lstr_CS.sm_Status[i] = "OFF_LINE";
            }

            Int32 j = 0;
            foreach (DataRow ldr_Row in ldt_DataTable.Rows)
            {
                lstr_CS.sm_UIDs[j] = ldr_Row["UID"].ToString();

                foreach (cl_Client l_Client in g_Server_v2.list_Client)
                {
                    if (ldr_Row["UID"].ToString() == l_Client.g_DW.Client.UID & l_Client.g_DW.Client.pb_Authorized == true & l_Client.g_DW.Client.pb_BlockedConnection == false)
                    {
                        lstr_CS.sm_Status[j] = "ON_LINE";
                        if (l_Client.g_DW.Client.pb_UserActive == false)
                        {
                            lstr_CS.sm_Status[j] = "NOT_ACTIVE";
                        }
                    }
                }
                j++;
            }
            String ls_SendingData = g_XML.ps_Write_ContactsStatus_To_XMLData(lstr_CS);
            v_SendMethod(ls_SendingData, "CONTACTS_STATUS");
        }
        private void DOWNLOAD_TEMP_MESSAGE_ARHIVE()
        {
            String ls_Path = g_GV.ps_UsersBaseFolderPath() + "\\" + Client.UID + "\\temp_messages._ul";
            DataTable ldt_TempMessageArhive = g_SQLW.pdt_ReadTempMessageArhive(ls_Path);
            String ls_XMLData = g_XML.pv_DataTable_To_XML(ldt_TempMessageArhive);
            v_SendMethod(ls_XMLData, "TEMP_MESSAGE_ARHIVE");
        }
        private void DOWNLOAD_MY_CONTACTS()
        {
            //читает базу контактов (UIDы) текущего клиента
            DataTable ldt_UsersUIDInfo = g_SQLW.pdt_ReadUserContactSQLBase(g_GV.ps_UserContactSQLBasePath(Client.UID));
            //по прочитанным UIDам читает инфу о контактах из главной базы
            DataTable ldt_UsersAllInfo = g_SQLW.pdt_ReadUserContacts(g_GV.ps_MainUsersRegistrationBasePath(), ldt_UsersUIDInfo, "CLIENT");
            cl_XML_Data.str_ContactList lstr_CL = new cl_XML_Data.str_ContactList();
            lstr_CL.s_DataTable = g_XML.pv_DataTable_To_XML(ldt_UsersAllInfo);

            Int32 i_FilesNumber = 0;
            lstr_CL.bm_ImageFiles = new Byte[ldt_UsersAllInfo.Rows.Count][];
            foreach (DataRow ldr_Row in ldt_UsersAllInfo.Rows)
            {
                lstr_CL.bm_ImageFiles[i_FilesNumber] = File.ReadAllBytes(g_GV.ps_MainBaseFolderPath() + "\\profile_images\\" + ldr_Row[4].ToString());
                i_FilesNumber++;
            }
            String ls_SendingData = g_XML.ps_Write_ContactList_To_XMLData(lstr_CL);
            v_SendMethod(ls_SendingData, "USER_CONTACTS_BASE");
        }
        private void USERS_SHOW(cl_XML_Data.str_DataKind lstr_Data)
        {
            String[] ls_Users = lstr_Data.Data.Split(new String[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
            DataTable ldt_DataTable = g_SQLW.pdt_ReadRows_UserRegistrationBase(ls_Users[0], ls_Users[1]);

            cl_XML_Data.str_ContactList lstr_CL = new cl_XML_Data.str_ContactList();
            lstr_CL.s_DataTable = g_XML.pv_DataTable_To_XML(ldt_DataTable);

            Int32 i_FilesNumber = 0;
            lstr_CL.bm_ImageFiles = new Byte[ldt_DataTable.Rows.Count][];
            foreach (DataRow ldr_Row in ldt_DataTable.Rows)
            {
                lstr_CL.bm_ImageFiles[i_FilesNumber] = File.ReadAllBytes(g_GV.ps_MainBaseFolderPath() + "\\profile_images\\" + ldr_Row[1].ToString());
                i_FilesNumber++;
            }
            String ls_SendingData = g_XML.ps_Write_ContactList_To_XMLData(lstr_CL);
            v_SendMethod(ls_SendingData, "USERS_GET");
        }
        private void USER_COUNT()
        {
            String ls_SendingData;
            ls_SendingData = g_SQLW.po_Count_UserRegistrationBase().ToString();
            v_SendMethod(ls_SendingData, "USERS_BASE_COUNT");
        }
        private void SIGN_IN(cl_XML_Data.str_DataKind lstr_Data)
        {
            String ls_Login = lstr_Data.Data.Split(new String[] { "::" }, StringSplitOptions.None)[0];
            String ls_Password = lstr_Data.Data.Split(new String[] { "::" }, StringSplitOptions.None)[1];
            DataTable ldt_DataTable = g_SQLW.pdt_Autorization(ls_Login, ls_Password);
            if (ldt_DataTable.Rows.Count > 0)
            {
                Client.pb_Authorized = true;
                Client.Login = ls_Login;
                Client.UID = g_SQLW.pdt_FindUIDByLogin(ls_Login).Rows[0][0].ToString();
                v_SendMethod("SUCCESS", "SIGN_IN_STATUS");
                Client.pb_UserActive = true;
                String ls_DB_Path = g_GV.ps_UsersBaseFolderPath() + "\\" + Client.UID + "\\files._ul";
                DataTable ldt = g_SQLW.pdt_ReadAll_UserFilesDB(ls_DB_Path);
                //////////////////////////////////////////////////
                DateTime ldt_DaysNow = DateTime.Now;
                String ls_FilesFolder = g_GV.ps_UsersBaseFolderPath() + "\\" + Client.UID + "\\files";
                foreach (DataRow ldr in ldt.Rows)
                {
                    DateTime ldt_FileTime = Convert.ToDateTime(ldr["Date"].ToString());
                    TimeSpan lts = ldt_DaysNow - ldt_FileTime;
                    if ((lts.Days) > g_GV.pi_DaysUntilFilesDelete)
                    {
                        if (File.Exists(ls_FilesFolder + "\\" + ldr["FileNameGiven"].ToString()) == true)
                        {
                        File.Delete(ls_FilesFolder + "\\" + ldr["FileNameGiven"].ToString());
                        }
                        g_SQLW.pv_DeleteRow_UserFilesDB(ls_DB_Path, ldr["UID"].ToString());
                    }
                }
            }
            else { v_SendMethod("FAILED", "SIGN_IN_STATUS"); }
        }
        private void USER_DATA_EDIT(cl_XML_Data.str_DataKind lstr_Data)
        {
            DataTable ldt_DataTable;
            cl_XML_Data.str_Profile lstr_Profile = g_XML.pstr_ReadXMLUserRegistration(lstr_Data.Data);
            lstr_Profile.ImageFileName = Client.UID + ".jpg";
            ldt_DataTable = g_SQLW.ps_ReadUserData_UserRegistrationBase(lstr_Profile.Login);
            //удалить старую фотку профиля из архива
            File.Delete(g_GV.ps_MainBaseFolderPath() + "\\profile_images\\" + ldt_DataTable.Rows[0][4].ToString());
            //добавить новую фотку в архив
            File.WriteAllBytes(g_GV.ps_MainBaseFolderPath() + "\\profile_images\\" + lstr_Profile.ImageFileName, lstr_Profile.ImageFile);
            //обновить сведения в базе
            g_SQLW.pv_Edit_UserRegistrationData(g_GV.ps_MainUsersRegistrationBasePath(), lstr_Profile);
            v_SendMethod("EDIT_SUCCESS", "USER_DATA_EDITED");
        }
        private void USER_REGISTRATION(cl_XML_Data.str_DataKind lstr_Data)
        {
            String ls_SendingData;
            cl_XML_Data.str_Profile lstr_Profile = g_XML.pstr_ReadXMLUserRegistration(lstr_Data.Data);
            cl_XML_Data.str_Registration_Status lstr_RS = new cl_XML_Data.str_Registration_Status();
            if (g_SQLW.pdt_FindLoginInUserRegistrationBase(lstr_Profile.Login).Rows.Count == 0)
            {
                String ls_UIDString = s_CreateNewUID(lstr_Profile.Login);
                g_FW.pv_UserCreat(ls_UIDString);
                lstr_Profile.ImageFileName = ls_UIDString + ".jpg";
                g_SQLW.pv_Add_UserRegistrationBase(lstr_Profile, g_GV.ps_MainUsersRegistrationBasePath(), ls_UIDString, "FIRST_REGISTRATION", g_GV.ps_CurrentDate);
                File.WriteAllBytes(g_GV.ps_MainBaseFolderPath() + "\\profile_images\\" + lstr_Profile.ImageFileName, lstr_Profile.ImageFile);
                lstr_RS.s_Answer = "SUCCESS";
                ls_SendingData = g_XML.ps_RegistrationStatus_To_XMLData(lstr_RS);
                v_SendMethod(ls_SendingData, "REGISTRATION_STATUS");
            }

            else
            {
                lstr_RS.s_Answer = "LOGIN_EXIST";
                ls_SendingData = g_XML.ps_RegistrationStatus_To_XMLData(lstr_RS);
                v_SendMethod(ls_SendingData, "REGISTRATION_STATUS");
            }
        }
        private void UPDATE_CLIENT()
        {
            String[] lsm_FilePathes = Directory.GetFiles(Application.StartupPath + "\\client_update");
            cl_XML_Data.str_UploadFile[] lstr_UF = new cl_XML_Data.str_UploadFile[lsm_FilePathes.Length];

            for (int i = 0; i < lsm_FilePathes.Length; i++)
            {
                lstr_UF[i].s_FileName = Path.GetFileName(lsm_FilePathes[i]);
                lstr_UF[i].bm_File = File.ReadAllBytes(lsm_FilePathes[i]);
            }

            cl_XML_Data.str_UpdateClient lstr_UC = new cl_XML_Data.str_UpdateClient();
            lstr_UC.pstr_UF = lstr_UF;
            v_SendMethod(g_XML.ps_UpdateClient_To_XMLData(lstr_UC), "UPDATE_FROM_SERVER");
        }
        private void CHECK_CONNECTION()
        {
            v_SendMethod("", "CHECK_CONNECTION:CONNECTED");
        }
        private void CONNECT_SERVER()
        {
            cl_XML_Data.str_ServerStatus lstr_SS = new cl_XML_Data.str_ServerStatus();
            lstr_SS.s_Status = "READY";
            lstr_SS.s_ClientVersion = g_GV.pcl_SettingsData.ps_ClientVersion;
            v_SendMethod(g_XML.ps_ServerStatus_To_XMLData(lstr_SS), "SERVER_STATUS");
        }
        void v_ContackOperation(String ls_Data)
        {
            cl_XML_Data.str_ContactsOperation lstr_CO = new cl_XML_Data.str_ContactsOperation();
            lstr_CO = g_XML.pstr_ReadXMLContactsOperation(ls_Data);
            String ls_BasePathThisContact = g_GV.ps_UserContactSQLBasePath(lstr_CO.s_MyUID);
            String ls_BasePathAddedContact = g_GV.ps_UserContactSQLBasePath(lstr_CO.s_UserUID);
            switch (lstr_CO.s_Operation)
            {
                case "CONTACT_ADD":
                    //добавляет контакт в базу
                    g_SQLW.pv_AddContactToUserContactBase(ls_BasePathThisContact, lstr_CO.s_UserUID);
                    //создает файл архива сообщений
                    g_FW.pv_Added_UserMessageArhive(lstr_CO.s_MyUID, lstr_CO.s_UserUID);
                    //добавляет текущ контакт в адрес книгу собеседника
                    g_SQLW.pv_AddContactToUserContactBase(ls_BasePathAddedContact, lstr_CO.s_MyUID);
                    g_FW.pv_Added_UserMessageArhive(lstr_CO.s_UserUID, lstr_CO.s_MyUID);

                    foreach (cl_Client l_Client in g_Server_v2.list_Client)
                    {
                        if (l_Client.g_DW.Client.pb_Authorized == true & l_Client.g_DW.Client.UID == lstr_CO.s_UserUID & l_Client.g_DW.Client.pb_BlockedConnection == false)
                        {
                            l_Client.g_DW.v_SendMethod("", "UPDATE_CONTACT_LIST_CONTACT_ADDED");
                        }
                    }
                            v_SendMethod(lstr_CO.s_UserUID, "USER_CONTACT_OPERATION_ADD_SUCCESS");
                    break;
                case "CONTACT_DELETE":
                    g_SQLW.pv_DeleteContactFromUserContactBase(ls_BasePathThisContact, lstr_CO.s_UserUID);
                    v_SendMethod(lstr_CO.s_UserUID, "USER_CONTACT_OPERATION_DELETE_SUCCESS");
                    break;
            }
        }
        String s_CreateNewUID(String ls_UIDString)
        {
            return Cryptor.cl_Crypting_MD5.psvm_MD5_Text(ls_UIDString);
        }
    }
}

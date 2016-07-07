using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace Union_Lan_Client
{
    public class cl_DataWorkerClient
    {
        cl_Compression g_CMP = new cl_Compression();
        public TcpClient gtcp_Client;
        public f_Union pf_Union;
        public f_UserList pf_UL;
        public f_UserRegistration pf_UR;
        public cl_Client_v2 g_Client_v2;
        cl_XML_Data g_XML = new cl_XML_Data();
        cl_GlobalVariables g_GV = new cl_GlobalVariables();
        cl_FileWorker g_FW = new cl_FileWorker();
        public f_Main pf_MainForm;
        public cl_GlobalVariables.str_PersonalData g_PD = new cl_GlobalVariables.str_PersonalData();
        #region Отправка данных
        void v_SendMethod(String ls_SendingData, String ls_DataKind)
        {
            cl_XML_Data.str_DataKind lstr_DK = new cl_XML_Data.str_DataKind();
            lstr_DK.From = "FROM_CLIENT";
            lstr_DK.Kind = ls_DataKind;
            lstr_DK.Data = ls_SendingData;
            lstr_DK.ID = Cryptor.cl_Crypting_MD5.psvm_MD5_Text(lstr_DK.Data);
            ls_SendingData = g_XML.vm_DataKind_To_XMLData(lstr_DK);
            if (g_GV.pb_Compress == true)
            {
                ls_SendingData = g_CMP.Compress(ls_SendingData);
            }
            g_Client_v2.list_SendData.Add(ls_SendingData);
        }

        #region Методы отправки
        public void pv_UpdateUsersInGroup(List<String> list_UIDs)
        {
            cl_XML_Data.str_UpdateUsersInGroup lstr = new cl_XML_Data.str_UpdateUsersInGroup();
            lstr.list_UIDs = list_UIDs;
            lstr.ls_GroupKey = "main.all";
            String ls_SendingData = g_XML.ps_UpdateUsersInGroup_To_XMLData(lstr);
            v_SendMethod(ls_SendingData, "UPDATE_USERS_IN_GROUP");
        }
        public void pv_LoadPrevMessages(DateTime ldt, String ls_UID)
        {
            v_SendMethod(ldt.ToShortDateString()+"]|["+ ls_UID, "LOAD_PREV_MESSAGES");
        }
        public void pv_UserActivity(Boolean lb_UserActivity)
        {
            v_SendMethod(lb_UserActivity.ToString(), "USER_ACTIVITY");
        }
        public void pv_ProfileInfo()
        {
            v_SendMethod("", "PROFILE_INFO");
        }
        public void pv_ApplicationClose()
        {
            v_SendMethod(String.Empty, "APPLICATION_CLOSE");
        }
        public void pv_SignIn(String ls_Login, String ls_Password)
        {
            String ls_Data = ls_Login + "::" + ls_Password;
            v_SendMethod(ls_Data, "SIGN_IN");
        }
        public void pv_CheckServerStatus()
        {
            v_SendMethod(String.Empty, "CONNECT_SERVER");
        }
        public void pv_CheckConnection()
        {
            v_SendMethod("", "CHECK_CONNECTION");
        }
        public void pv_SendDataToShowUsersCount()
        {
            v_SendMethod("", "USER_COUNT");
        }
        public void pv_SendDataToOperateContacts(String ls_UID, String ls_Operation)
        {
            cl_XML_Data.str_ContactsOperation lstr_CO = new cl_XML_Data.str_ContactsOperation();
            lstr_CO.s_MyUID = g_PD.UID;
            lstr_CO.s_Operation = ls_Operation;
            lstr_CO.s_UserUID = ls_UID;
            String ls_Data = g_XML.ps_ContatsOperation_To_XMLData(lstr_CO);
            v_SendMethod(ls_Data, "CONTACTS_OPERATION");
        }
        public void pv_DownloadMyContacts()
        {
            v_SendMethod("", "DOWNLOAD_MY_CONTACTS");
        }
        public void pv_DownloadTempMessageArhive()
        {
            v_SendMethod("", "DOWNLOAD_TEMP_MESSAGE_ARHIVE");
        }
        public void pv_ContatsStatus(String ls_MyUID)
        {
            v_SendMethod(ls_MyUID, "CONTACTS_STATUS");
        }
        public void pv_SendDataToShowUsers(Int32 li_I, Int32 li_J)
        {
            String ls_Data = li_I + "::" + li_J;
            v_SendMethod(ls_Data, "USERS_SHOW");
        }
        public void pv_SendMessage(String ls_UserUID, String ls_Text, Byte[] lb_Investment, String ls_Attribute)
        {
            cl_XML_Data.str_Message lstr_SM = new cl_XML_Data.str_Message();
            lstr_SM.s_From_UID = g_PD.UID;
            lstr_SM.s_To_UID = ls_UserUID;
            lstr_SM.s_Text = ls_Text;
            lstr_SM.bm_Investment = lb_Investment;
            lstr_SM.s_Attribute = ls_Attribute;
            String ls_Data = g_XML.ps_Message_To_XMLData(lstr_SM);
            v_SendMethod(ls_Data, "SEND_MESSAGE");
        }
        public void pv_DownloadFile(String ls_FileLink)
        {
            v_SendMethod(ls_FileLink, "DOWNLOAD_FILE");
        }

        public void pv_DeleteMessages(String ls_ContactUID)
        {
            v_SendMethod(ls_ContactUID, "DELETE_MESSAGES");
        }
        public void pv_ChatOpen(String ls_UID)
        {
            v_SendMethod(ls_UID, "CHAT_OPEN");
        }
        public void pv_ChatClosed(String ls_UID)
        {
            v_SendMethod(ls_UID, "CHAT_CLOSED");
        }
        public void pv_WriteMessage_Write(String ls_UID)
        {
            v_SendMethod(ls_UID, "WRITE_MESSAGE_WRITE");
        }
        public void pv_DownloadMessageArhive(String ls_ContactUID)
        {
            v_SendMethod(ls_ContactUID, "MESSAGE_ARHIVE_DOWNLOAD");
        }
        public void pv_UpdateClient()
        {
            v_SendMethod("", "UPDATE_CLIENT");
        } 
        public void pv_SendURData(cl_XML_Data.str_Profile lstr_UR)
        {
            String ls_Data = g_XML.ps_UserRegistration_To_XMLData(lstr_UR);
            v_SendMethod(ls_Data, "USER_REGISTRATION");
        }
        public void pv_SendUDToEdit(cl_XML_Data.str_Profile lstr_UR)
        {
            String ls_Data = g_XML.ps_UserRegistration_To_XMLData(lstr_UR);
            v_SendMethod(ls_Data, "USER_DATA_EDIT");
        }
        #endregion
        public void pv_IncomindData(String ls_IncData)
        {
            if (g_GV.pb_Compress == true)
            {
                ls_IncData = g_CMP.Decompress(ls_IncData);
            }
            cl_XML_Data.str_DataKind lstr_DataKind = new cl_XML_Data.str_DataKind();
            lstr_DataKind = g_XML.pstr_ReadXMLDataKind(ls_IncData);
            switch (lstr_DataKind.From)
            {
                case "FROM_SERVER": pv_IncomingFromServer(lstr_DataKind); break;
            }
        } 
        #endregion

        #region Получение данных
        delegate void del_Main_Status(String s_Status, String s_ClientVersion);
        delegate void del_Main_SignIn(String s_Data);
        delegate void del_Union_LoadContacts(DataTable dt_DataTable);
        delegate void del_Union_TempMessageArhive(DataTable dt_DataTable);
        delegate void del_Union_ContactsStatus(String ls_Data);
        delegate void del_UL_UserCount(Int32 i_Count);
        delegate void del_UL_LoadDataGrid(DataTable dt_DataTable);
        delegate void del_UL_MessageNotification(cl_XML_Data.str_Message lstr_Message);
        delegate void del_UL_InsertIncomingMessageToChatForm(Int32 i_Index, String s_Direction, String s_Data, DateTime dt_DateTime, String s_Message_ID, String s_Attribute);
        delegate void del_UL_InsertDownloadedMessageArhive(String ls_Data);
        delegate void del_Union_MessagesDeleted(String ls_UID);
        delegate void del_Union_UpdateMessageAttributeReaded(String ls_Data);
        delegate void del_Union_ContactClosedChatForm(String ls_Data);
        delegate void del_Union_MessageWrite_Write(String ls_Data);
        delegate void del_Union_MessageWrite_Stop(String ls_Data);
        delegate void del_UR_RegistrationStatus(String s_Data);
        delegate void del_Union_BLOCKING_BY_SERVER(object sender);
        delegate void del_Union_PROFILE_INFO(String s_Data);
        delegate void del_UR_PROFILE_EDITED();

        public void pv_IncomingFromServer(cl_XML_Data.str_DataKind lstr_Data)
        {
            switch (lstr_Data.Kind)
            {
                case "SERVER_STATUS":SERVER_STATUS(lstr_Data);break;
                case "REGISTRATION_STATUS":REGISTRATION_STATUS(lstr_Data);break;
                case "USER_DATA_EDITED":USER_DATA_EDITED(lstr_Data);break;
                case "USERS_BASE_COUNT":USERS_BASE_COUNT(lstr_Data);break;
                case "USERS_GET": USERS_GET(lstr_Data);break;
                case "TEMP_MESSAGE_ARHIVE":TEMP_MESSAGE_ARHIVE(lstr_Data);break;
                case "SIGN_IN_STATUS":SIGN_IN_STATUS(lstr_Data);break;
                case "PROFILE_INFO": PROFILE_INFO(lstr_Data); break;
                case "USER_CONTACT_OPERATION_ADD_SUCCESS":USER_CONTACT_OPERATION_ADD_SUCCESS(lstr_Data);break;
                case "USER_CONTACT_OPERATION_DELETE_SUCCESS":USER_CONTACT_OPERATION_DELETE_SUCCESS(lstr_Data);break;
                case "USER_CONTACTS_BASE":USER_CONTACTS_BASE(lstr_Data);break;
                case "INCOMING_MESSAGE":INCOMING_MESSAGE(lstr_Data);break;
                case "CHAT_OPENED":CHAT_OPENED(lstr_Data);break;
                case "CHAT_CLOSED":CHAT_CLOSED(lstr_Data);break;
                case "WRITE_MESSAGE_WRITE":WRITE_MESSAGE_WRITE(lstr_Data);break;
                case "MESSAGE_ARHIVE":MESSAGE_ARHIVE(lstr_Data);break;
                case "UPDATE_FROM_SERVER":UPDATE_FROM_SERVER(lstr_Data);break;
                case "CONTACTS_STATUS":CONTACTS_STATUS(lstr_Data);break;
                case "UPDATE_CONTACT_LIST_CONTACT_ADDED":UPDATE_CONTACT_LIST_CONTACT_ADDED();break;
                case "MESSAGES_DELETED":MESSAGES_DELETED(lstr_Data);break;
                case "BLOCKING_BY_SERVER":BLOCKING_BY_SERVER();break;
                case "DOWNLOAD_FILE": DOWNLOAD_FILE(lstr_Data); break;
            }
        }

        private void DOWNLOAD_FILE(cl_XML_Data.str_DataKind lstr_Data)
        {
            switch (lstr_Data.Data)
            {
                case "FILE_NOT_EXIST":
                    {
                        MessageBox.Show("FILE_NOT_EXIST");
                    }
                    break;
                case "FILE_NOT_FOUND_IN_DB":
                    {
                        MessageBox.Show("FILE_NOT_FOUND_IN_DB");
                    } 
                    break;
                default:
                    {
                        cl_XML_Data.str_SendFile cl_SD = g_XML.pstr_ReadXMLSendFile(lstr_Data.Data);
                        File.WriteAllBytes(Application.StartupPath + "\\file\\" + cl_SD.FileName, cl_SD.File);
                        Process.Start(Application.StartupPath + "\\file\\" + cl_SD.FileName);
                    } 
                    break;
            }
        }

        private void PROFILE_INFO(cl_XML_Data.str_DataKind lstr_Data)
        {
            del_Union_PROFILE_INFO ldel = new del_Union_PROFILE_INFO(pf_Union._PROFILE_INFO);
            pf_Union.Invoke(ldel, new object[] { lstr_Data.Data});
        }
        private void BLOCKING_BY_SERVER()
        {
            del_Union_BLOCKING_BY_SERVER ldel = new del_Union_BLOCKING_BY_SERVER(pf_MainForm.pv_ApplicationExit);
            pf_Union.Invoke(ldel, new object[] {"EXIT"});
        }

        private cl_XML_Data.str_DataKind MESSAGES_DELETED(cl_XML_Data.str_DataKind lstr_Data)
        {
            del_Union_MessagesDeleted ldel_Union_MessagesDeleted = new del_Union_MessagesDeleted(pf_Union.pv_MessagesDeleted);
            pf_Union.Invoke(ldel_Union_MessagesDeleted, new object[] { lstr_Data.Data });
            return lstr_Data;
        }

        private void UPDATE_CONTACT_LIST_CONTACT_ADDED()
        {
            v_SendMethod(g_PD.UID, "DOWNLOAD_MY_CONTACTS");
        }

        private cl_XML_Data.str_DataKind CONTACTS_STATUS(cl_XML_Data.str_DataKind lstr_Data)
        {
            /////////////////////
            del_Union_ContactsStatus ldel_UCS = new del_Union_ContactsStatus(pf_Union.pv_UpdateContactsStatus);
            pf_Union.Invoke(ldel_UCS, new object[] { lstr_Data.Data });
            return lstr_Data;
        }

        private void UPDATE_FROM_SERVER(cl_XML_Data.str_DataKind lstr_Data)
        {
            cl_XML_Data.str_UpdateClient lstr_UC = new cl_XML_Data.str_UpdateClient();
            lstr_UC = g_XML.pstr_ReadXMLUpdateClient(lstr_Data.Data);
            if (Directory.Exists(Application.StartupPath + "\\update") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\update");
            }

            File.WriteAllText(Application.StartupPath + "\\update\\update._ul", Application.StartupPath);

            for (int i = 0; i < lstr_UC.pstr_UF.Length; i++)
            {
                File.WriteAllBytes(Application.StartupPath + "\\update\\" + lstr_UC.pstr_UF[i].s_FileName, lstr_UC.pstr_UF[i].bm_File);
            }

            Process pr_Updater = new Process();
            pr_Updater.StartInfo.FileName = Application.StartupPath + "\\update\\Union_Lan_Updater.exe";
            pr_Updater.Start();
            pf_MainForm.pv_ApplicationExit("EXIT");
        }

        private cl_XML_Data.str_DataKind MESSAGE_ARHIVE(cl_XML_Data.str_DataKind lstr_Data)
        {
            del_UL_InsertDownloadedMessageArhive ndel_IDMA = new del_UL_InsertDownloadedMessageArhive(pf_Union.pv_InsertDownloadedMessageArhive);
            pf_Union.Invoke(ndel_IDMA, new object[] { lstr_Data.Data });
            return lstr_Data;
        }

        private cl_XML_Data.str_DataKind WRITE_MESSAGE_WRITE(cl_XML_Data.str_DataKind lstr_Data)
        {
            del_Union_MessageWrite_Write ldel_Write = new del_Union_MessageWrite_Write(pf_Union.pv_MessageWrite_Write);
            pf_Union.Invoke(ldel_Write, new object[] { lstr_Data.Data });
            return lstr_Data;
        }

        private cl_XML_Data.str_DataKind CHAT_CLOSED(cl_XML_Data.str_DataKind lstr_Data)
        {
            del_Union_ContactClosedChatForm ndel_CCCF = new del_Union_ContactClosedChatForm(pf_Union.pv_ContactClosedChatForm);
            pf_Union.Invoke(ndel_CCCF, new object[] { lstr_Data.Data });
            return lstr_Data;
        }

        private cl_XML_Data.str_DataKind CHAT_OPENED(cl_XML_Data.str_DataKind lstr_Data)
        {
            del_Union_UpdateMessageAttributeReaded ndel_UMAR = new del_Union_UpdateMessageAttributeReaded(pf_Union.pv_ContactOpenedChatForm);
            pf_Union.Invoke(ndel_UMAR, new object[] { lstr_Data.Data });
            return lstr_Data;
        }

        private cl_XML_Data.str_DataKind INCOMING_MESSAGE(cl_XML_Data.str_DataKind lstr_Data)
        {
            cl_XML_Data.str_Message lstr_SM = new cl_XML_Data.str_Message();
            lstr_SM = g_XML.pstr_ReadXMLMessage(lstr_Data.Data);
            DateTime ldt_Time = Convert.ToDateTime(lstr_SM.s_DateTime);
            //если это мое сообщение - мне от сервера
            if (lstr_SM.s_From_UID == g_PD.UID)
            {
                foreach (cl_GlobalVariables.str_Contact lstr_Contact in pf_Union.g_str_Contacts)
                {
                    if (lstr_Contact.s_UID == lstr_SM.s_To_UID)
                    {
                        del_UL_InsertIncomingMessageToChatForm ndel_UL_IIMTCF = new del_UL_InsertIncomingMessageToChatForm(pf_Union.pv_InsertIncomingMessageToChatForm);
                        pf_Union.Invoke(ndel_UL_IIMTCF, new object[] { lstr_Contact.s_Number, "OUT", lstr_SM.s_Text, ldt_Time, lstr_SM.s_Message_ID, lstr_SM.s_Attribute });
                    }
                }
            }

            //если это мое сооб - кому то
            if (pf_Union.g_str_Contacts.Length > 0)
            {
                //если контакт присут в списке то отобразить окно с новым сообщен
                foreach (cl_GlobalVariables.str_Contact lstr_Contact in pf_Union.g_str_Contacts)
                {
                    //поиск по всем контактам
                    if (lstr_Contact.s_UID == lstr_SM.s_From_UID)
                    {
                        del_UL_MessageNotification ndel_UL_MessageNotification = new del_UL_MessageNotification(pf_Union.pv_MessageNotification);
                        pf_Union.Invoke(ndel_UL_MessageNotification, new object[] { lstr_SM });
                        del_UL_InsertIncomingMessageToChatForm ndel_UL_IIMTCF = new del_UL_InsertIncomingMessageToChatForm(pf_Union.pv_InsertIncomingMessageToChatForm);
                        pf_Union.Invoke(ndel_UL_IIMTCF, new object[] { lstr_Contact.s_Number, "IN", lstr_SM.s_Text, ldt_Time, lstr_SM.s_Message_ID, lstr_SM.s_Attribute });
                    }
                }
            }
            return lstr_Data;
        }

        private cl_XML_Data.str_DataKind USER_CONTACTS_BASE(cl_XML_Data.str_DataKind lstr_Data)
        {
            cl_XML_Data.str_ContactList lstr_CL = new cl_XML_Data.str_ContactList();
            lstr_CL = g_XML.pstr_ReadXML_ContactList(lstr_Data.Data);
            DataTable ldt_DataTable = g_XML.pdt_XML_To_DataTable(lstr_CL.s_DataTable);
            Int32 li_ImageFiles = 0;
            foreach (DataRow ldr_Row in ldt_DataTable.Rows)
            {
                String ls_FilePath = Application.StartupPath + "\\cache\\" + ldr_Row[4].ToString();
                if (File.Exists(ls_FilePath) == false)
                {
                    File.WriteAllBytes(ls_FilePath, lstr_CL.bm_ImageFiles[li_ImageFiles]);
                }
                li_ImageFiles++;
            }

            del_Union_LoadContacts ndel_Union_LoadContacts = new del_Union_LoadContacts(pf_Union.pv_LoadContacts);
            pf_Union.Invoke(ndel_Union_LoadContacts, new object[] { ldt_DataTable });
            return lstr_Data;
        }

        private cl_XML_Data.str_DataKind USER_CONTACT_OPERATION_DELETE_SUCCESS(cl_XML_Data.str_DataKind lstr_Data)
        {
            pf_UL.pv_DeleteOperationRezult(lstr_Data.Data, "SUCCESS");
            return lstr_Data;
        }

        private cl_XML_Data.str_DataKind USER_CONTACT_OPERATION_ADD_SUCCESS(cl_XML_Data.str_DataKind lstr_Data)
        {
            pf_UL.pv_AddOperationRezult(lstr_Data.Data, "SUCCESS");
            return lstr_Data;
        }

        private cl_XML_Data.str_DataKind SIGN_IN_STATUS(cl_XML_Data.str_DataKind lstr_Data)
        {
            del_Main_SignIn ndel_Main_SignIn = new del_Main_SignIn(pf_MainForm.pv_SignStatus);
            pf_MainForm.Invoke(ndel_Main_SignIn, new object[] { lstr_Data.Data });
            return lstr_Data;
        }

        private cl_XML_Data.str_DataKind TEMP_MESSAGE_ARHIVE(cl_XML_Data.str_DataKind lstr_Data)
        {
            DataTable ldt_TempMessageArhive = g_XML.pdt_XML_To_DataTable(lstr_Data.Data);
            del_Union_TempMessageArhive ldel_Union_TempMessageArhive = new del_Union_TempMessageArhive(pf_Union.pv_TempMessageArhive);
            pf_Union.Invoke(ldel_Union_TempMessageArhive, new object[] { ldt_TempMessageArhive });
            return lstr_Data;
        }

        private DataTable USERS_GET(cl_XML_Data.str_DataKind lstr_Data)
        {
            del_UL_LoadDataGrid ndel_UL_LoadDataGrid = new del_UL_LoadDataGrid(pf_UL.pv_LoadDataGrid);
            cl_XML_Data.str_ContactList lstr_CL = g_XML.pstr_ReadXML_ContactList(lstr_Data.Data);
            DataTable ldt_DataTable = g_XML.pdt_XML_To_DataTable(lstr_CL.s_DataTable);
            Int32 li_ImageFiles = 0;
            foreach (DataRow ldr_Row in ldt_DataTable.Rows)
            {
                String ls_FilePath = Application.StartupPath + "\\cache\\" + ldr_Row[1].ToString();
                if (File.Exists(ls_FilePath) == false)
                {
                    File.WriteAllBytes(ls_FilePath, lstr_CL.bm_ImageFiles[li_ImageFiles]);
                }

                li_ImageFiles++;
            }
            try
            {
                pf_UL.Invoke(ndel_UL_LoadDataGrid, new object[] { ldt_DataTable });
            }
            catch { }
            return ldt_DataTable;
        }

        private cl_XML_Data.str_DataKind USERS_BASE_COUNT(cl_XML_Data.str_DataKind lstr_Data)
        {
            Int32 li_UsersCount = Convert.ToInt32(lstr_Data.Data);
            del_UL_UserCount ndel_UL_UserCount = new del_UL_UserCount(pf_UL.pv_UserCount);
            pf_UL.Invoke(ndel_UL_UserCount, new object[] { li_UsersCount });
            return lstr_Data;
        }

        private void USER_DATA_EDITED(cl_XML_Data.str_DataKind lstr_Data)
        {
            if (lstr_Data.Data == "EDIT_SUCCESS")
            {
                del_UR_PROFILE_EDITED ldel = new del_UR_PROFILE_EDITED(pf_UR.pv_ProfileEdited);
                pf_UR.Invoke(ldel);
            }
        }

        private cl_XML_Data.str_DataKind REGISTRATION_STATUS(cl_XML_Data.str_DataKind lstr_Data)
        {
            cl_XML_Data.str_Registration_Status lstr_RS = g_XML.pstr_ReadXMLRegistrationStatus(lstr_Data.Data);
            del_UR_RegistrationStatus ndel_UR_RegistrationStatus = new del_UR_RegistrationStatus(pf_UR.pv_RegistrationStatus);
            pf_UR.Invoke(ndel_UR_RegistrationStatus, new object[] { lstr_RS.s_Answer });
            return lstr_Data;
        }

        private void SERVER_STATUS(cl_XML_Data.str_DataKind lstr_Data)
        {
            cl_XML_Data.str_ServerStatus lstr_SS = new cl_XML_Data.str_ServerStatus();
            lstr_SS = g_XML.pstr_ReadXMLServerStatus(lstr_Data.Data);
            del_Main_Status ndel_Main_Status = new del_Main_Status(pf_MainForm.pv_ServerStatus);
            pf_MainForm.Invoke(ndel_Main_Status, new Object[] { lstr_SS.s_Status, lstr_SS.s_ClientVersion });
        }
        public String ps_CreateNewUID(String ls_UIDString)
        {
            return Cryptor.cl_Crypting_MD5.psvm_MD5_Text(ls_UIDString);
        }
        #endregion

    } 


}

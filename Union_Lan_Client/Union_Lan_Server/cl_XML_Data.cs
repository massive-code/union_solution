using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data;

namespace Union_Lan_Client
{
    public class cl_XML_Data
    {

        #region str_DataKind
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// Обертка любых сообщения для разделения по типу
        /// </summary>
        public struct str_DataKind
        {
            public String ID;
            public String From;
            public String Kind;
            public String Data;
        }
        /// <summary>
        /// Добавление к данным типа для определения на приемнике и преобразование в ХМЛ вид
        /// </summary>
        /// <param name="ls_Kind"></param>
        /// <param name="ls_Data"></param>
        /// <returns></returns>
        public String vm_DataKind_To_XMLData(str_DataKind lstr_DK)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_DataKind));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, lstr_DK);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_DataKind pstr_ReadXMLDataKind(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_DataKind));
            return (str_DataKind)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region str_UpdateUsersInGroup
        public struct str_UpdateUsersInGroup
        {
            public List<String> list_UIDs;
            public String ls_GroupKey;
        }
        public String ps_UpdateUsersInGroup_To_XMLData(str_UpdateUsersInGroup n_str_UUG)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_UpdateUsersInGroup));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, n_str_UUG);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_UpdateUsersInGroup pstr_ReadXML_UpdateUsersInGroup(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_UpdateUsersInGroup));
            return (str_UpdateUsersInGroup)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region str_SendFile
        public struct str_SendFile
        {
            public String FileName;
            public Byte[] File;
        }
        public String ps_SendFile_To_XMLData(str_SendFile n_str_SF)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_SendFile));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, n_str_SF);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_SendFile pstr_ReadXMLSendFile(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_SendFile));
            return (str_SendFile)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region str_UserRegistration
        /// <summary>
        /// Сведения для регистрации пользователя
        /// </summary>
        public struct str_Profile
        {
            public String UID;
            public String Name;
            public String Surname;
            public String BirthDay;
            public String ImageFileName;
            public Byte[] ImageFile;
            public String Job;
            public String Workplace;
            public String Lifeplace;
            public String Login;
            public String Password;
            public String Gender;
        }
        /// <summary>
        ///Преобразование регистр данных внесенных пользователем в ХМЛ вид
        /// </summary>
        /// <param name="n_str_UR">Сведения для регистрации</param>
        /// <returns>Возвращает преобразование</returns>
        public String ps_UserRegistration_To_XMLData(str_Profile n_str_UR)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_Profile));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, n_str_UR);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_Profile pstr_ReadXMLUserRegistration(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_Profile));
            return (str_Profile)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region str_Registration_Status
        /// <summary>
        /// Ответ сервера о результате регистрации
        /// </summary>
        public struct str_Registration_Status
        {
            public String s_Answer;
        }
        /// <summary>
        /// Данные ответа сервера о регистрации в ХМЛ
        /// </summary>
        /// <param name="lstr_RS"></param>
        /// <returns></returns>
        public String ps_RegistrationStatus_To_XMLData(str_Registration_Status lstr_RS)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_Registration_Status));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, lstr_RS);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_Registration_Status pstr_ReadXMLRegistrationStatus(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_Registration_Status));
            return (str_Registration_Status)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region DataTable_XML
        public String pv_DataTable_To_XML(DataTable ldt_DataTable)
        {
            MemoryStream ms_MemoryStream = new MemoryStream();
            ldt_DataTable.WriteXml(ms_MemoryStream, XmlWriteMode.WriteSchema);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public DataTable pdt_XML_To_DataTable(String ls_Data)
        {
            DataTable ldt_DataTable = new DataTable();
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            ldt_DataTable.ReadXml(ms_MemoryStream);
            return ldt_DataTable;
        }
        #endregion

        #region Str_ContactsOperation
        public struct str_ContactsOperation
        {
            public String s_MyUID;
            public String s_Operation;
            public String s_UserUID;
        }

        public String ps_ContatsOperation_To_XMLData(str_ContactsOperation n_str_CO)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_ContactsOperation));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, n_str_CO);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_ContactsOperation pstr_ReadXMLContactsOperation(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_ContactsOperation));
            return (str_ContactsOperation)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region Str_Message
        public struct str_Message
        {
            public String s_From_UID;
            public String s_To_UID;
            public String s_Text;
            public Byte[] bm_Investment;
            public String s_Attribute;
            public String s_DateTime;
            public String s_Message_ID;
        }

        public String ps_Message_To_XMLData(str_Message n_str_M)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_Message));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, n_str_M);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_Message pstr_ReadXMLMessage(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_Message));
            return (str_Message)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region Str_MessageArhive
        public struct str_MessageArhive
        {
            public String s_UID;
            public String s_Arhive;
            public Boolean ContactChatFormOpened;
        }

        public String ps_MessageArhive_To_XMLData(str_MessageArhive n_str_MA)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_MessageArhive));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, n_str_MA);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_MessageArhive pstr_ReadXMLMessageArhive(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_MessageArhive));
            return (str_MessageArhive)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region Str_ServerStatus
        public struct str_ServerStatus
        {
            public String s_Status;
            public String s_ClientVersion;
        }

        public String ps_ServerStatus_To_XMLData(str_ServerStatus n_str_SS)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_ServerStatus));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, n_str_SS);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_ServerStatus pstr_ReadXMLServerStatus(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_ServerStatus));
            return (str_ServerStatus)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region Str_UpdateClient
        public struct str_UploadFile
        {
            public String s_FileName;
            public Byte[] bm_File;
        }
        public struct str_UpdateClient
        {
            public str_UploadFile[] pstr_UF;
        }
        public String ps_UpdateClient_To_XMLData(str_UpdateClient n_str_UC)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_UpdateClient));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, n_str_UC);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_UpdateClient pstr_ReadXMLUpdateClient(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_UpdateClient));
            return (str_UpdateClient)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region Получить список контактов и изображений профиля
        public struct str_ContactList
        {
            public String s_DataTable;
            public Byte[][] bm_ImageFiles;
        }
        public String ps_Write_ContactList_To_XMLData(str_ContactList n_str_CL)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_ContactList));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, n_str_CL);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_ContactList pstr_ReadXML_ContactList(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_ContactList));
            return (str_ContactList)xml_Serializer.Deserialize(ms_MemoryStream);
        }
        #endregion

        #region Список контактов со статусами для обновления в окне
        public struct str_ContactsStatus
        {
            public String[] sm_UIDs;
            public String[] sm_Status;
        }
        public String ps_Write_ContactsStatus_To_XMLData(str_ContactsStatus n_str_CS)
        {
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_ContactsStatus));
            MemoryStream ms_MemoryStream = new MemoryStream();
            xml_Serializer.Serialize(ms_MemoryStream, n_str_CS);
            StreamReader sr_StreamReader = new StreamReader(ms_MemoryStream);
            ms_MemoryStream.Position = 0;
            return sr_StreamReader.ReadToEnd();
        }
        public str_ContactsStatus pstr_ReadXML_ContactsStatus(String ls_Data)
        {
            MemoryStream ms_MemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(ls_Data));
            XmlSerializer xml_Serializer = new XmlSerializer(typeof(str_ContactsStatus));
            return (str_ContactsStatus)xml_Serializer.Deserialize(ms_MemoryStream);
        }

        #endregion
    }

}


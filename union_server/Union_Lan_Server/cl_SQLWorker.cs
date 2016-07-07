using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Data;

namespace Union_Lan_Server
{
    public class cl_SQLWorker
    {
        SqlCeEngine sql_SQL_Engine;
        SqlCeConnection sql_SQL_Connection;
        SqlCeCommand sql_SQL_Command;
        public cl_GlobalVariables g_GV;

        #region SQL_Check
        public Boolean pb_Create_SQL_Check(String ls_BasePath)
        {
            try
            {
                sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
                sql_SQL_Engine.CreateDatabase();
                sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
                sql_SQL_Connection.Open();
                sql_SQL_Command = sql_SQL_Connection.CreateCommand();
                sql_SQL_Command.CommandText =
                         "CREATE TABLE SQL(SQL nvarchar(50))";
                sql_SQL_Command.ExecuteNonQuery();
                sql_SQL_Connection.Close();
                return true;
            }
            catch { return false; }
        }
        public Boolean pb_ReadSQL_Check(String ls_BasePath)
        {
            try
            {
                sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
                sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
                sql_SQL_Connection.Open();
                sql_SQL_Command = sql_SQL_Connection.CreateCommand();
                sql_SQL_Command.CommandText = "SELECT * FROM SQL";
                SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
                DataTable n_dt = new DataTable();
                n_dt.Load(n_SQL_DataReader);
                sql_SQL_Connection.Close();
                return true;
            }
            catch { return false; }
        }
        #endregion

        //создание базы всех пользователей
        public void pv_Create_UserRegistrationBase(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Engine.CreateDatabase();
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText =
            "CREATE TABLE UserRegistration(N int IDENTITY(1,1)," +
                                          "Login nvarchar(50)," +
                                          "Password nvarchar(50)," +
                                          "UID nvarchar(50)," +
                                          "RegistDate nvarchar(50)," +
                                          "ChangeDate nvarchar(50)," +
                                          "Name nvarchar(50)," +
                                          "Surname nvarchar(50)," +
                                          "Birthday nvarchar(50)," +
                                          "Image nvarchar(50)," +
                                          "Job nvarchar(50)," +
                                          "Workplace nvarchar(50)," +
                                          "Lifeplace nvarchar(50)," +
                                          "Gender nvarchar(50)," +
                                          "Attribute nvarchar(50))";
            sql_SQL_Command.ExecuteNonQuery();
            sql_SQL_Connection.Close();
        }

        #region Работа с сообщениями
        //создание базы сообщений для добавленного пользователя
        public void pv_Create_AddedUserMessageArhive(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Engine.CreateDatabase();
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText =
                     "CREATE TABLE Messages(N int IDENTITY(1,1),"+
                                          "UID nvarchar(50)," +
                                          "Date nvarchar(50)," +
                                          "Message ntext," +
                                          "Investment nvarchar(50)," +
                                          "Attribute nvarchar(50),"+
                                          "Message_ID nvarchar(50))";
            sql_SQL_Command.ExecuteNonQuery();
            sql_SQL_Connection.Close();
        }

        

        //добавление сообщения в архив
        public void pv_AddMessageToArhive(String ls_BasePath, String ls_UID, String ls_Message, DateTime ldt_DateTime, String ls_Attribute, String ls_Message_ID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "INSERT INTO Messages(UID, Date, Message, Investment, Attribute, Message_ID) VALUES(?,?,?,?,?,?)";
            sql_SQL_Command.Parameters.AddWithValue("UID", ls_UID);
            sql_SQL_Command.Parameters.AddWithValue("Date", ldt_DateTime.ToString());
            sql_SQL_Command.Parameters.AddWithValue("Message", ls_Message);
            sql_SQL_Command.Parameters.AddWithValue("Investment", "");
            sql_SQL_Command.Parameters.AddWithValue("Attribute", ls_Attribute);
            sql_SQL_Command.Parameters.AddWithValue("Message_ID", ls_Message_ID);
            sql_SQL_Command.ExecuteScalar();
            sql_SQL_Connection.Close();
        }

        public DataTable pdt_ReadMessageArhive_All(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT * FROM Messages";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }

        public DataTable pdt_ReadMessageArhive_LastDay(String ls_BasePath)
        {
            DataTable n_dt = new DataTable();
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();

            //sql_SQL_Command.CommandText = "SELECT Date FROM Messages WHERE N=(SELECT COUNT(*) FROM Messages)";
            //sql_SQL_Command.CommandText = "SELECT * FROM Messages WHERE Date LIKE '%25.02.2016%'";
            //sql_SQL_Command.CommandText = "SELECT TOP(1) Date FROM Messages ORDER BY N DESC";
            //sql_SQL_Command.CommandText = "SELECT Date FROM Messages WHERE N = (SELECT MAX(N) FROM Messages)";
            //sql_SQL_Command.CommandText = "SELECT Date FROM Messages WHERE N = SELECT MAX(N) FROM Messages";
            sql_SQL_Command.CommandText = "SELECT COUNT(*) FROM Messages";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            n_dt.Load(n_SQL_DataReader);
            String ls_Count = n_dt.Rows[0][0].ToString();
           try{
                n_dt.Clear();
                sql_SQL_Command.CommandText = "SELECT Date FROM Messages WHERE N = '" + ls_Count + "'";
                n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
                n_dt.Load(n_SQL_DataReader);
                String ls_LastDay = Convert.ToDateTime(n_dt.Rows[0][1]).ToShortDateString();
                sql_SQL_Command.CommandText = "SELECT * FROM Messages WHERE Date LIKE '%" + ls_LastDay + "%'";
                n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
                n_dt.Clear();
                n_dt.Load(n_SQL_DataReader);
                sql_SQL_Connection.Close();
            }
            catch /////??????????????????????????????????
            {
                n_dt.Clear();
                sql_SQL_Command.CommandText = "SELECT * FROM Messages";
                n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
                n_dt.Load(n_SQL_DataReader);
            }
            return n_dt;
        }

        public DataTable pdt_ReadPrevMessages(String ls_BasePath, String ls_LastDay)
        {
            DataTable n_dt = new DataTable();
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT TOP(1) * FROM Messages WHERE Date LIKE '%" + ls_LastDay + "%'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            n_dt.Load(n_SQL_DataReader);
            if (n_dt.Rows.Count > 0)
            {
                if (n_dt.Rows[0]["N"].ToString() != "1")
                {
                    String ls = (Convert.ToInt32(n_dt.Rows[0]["N"]) - 1).ToString();
                    sql_SQL_Command.CommandText = "SELECT * FROM Messages WHERE N='" + ls + "'";
                    n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
                    n_dt.Clear();
                    n_dt.Load(n_SQL_DataReader);
                    DateTime ldt = Convert.ToDateTime(n_dt.Rows[0]["Date"]);
                    sql_SQL_Command.CommandText = "SELECT * FROM Messages WHERE Date LIKE '%" + ldt.ToShortDateString() + "%'";
                    n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
                    n_dt.Clear();
                    n_dt.Load(n_SQL_DataReader);
                }

                else { n_dt.Clear(); }
            }
            if (n_dt.Rows.Count == 0) { n_dt.Clear(); }
          return n_dt; 
        }

        public void pv_DeleteMessages(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();

            sql_SQL_Command.CommandText = "DROP TABLE Messages";
            //sql_SQL_Command.CommandText = "DELETE FROM Messages ";
            sql_SQL_Command.ExecuteScalar();
            sql_SQL_Command.CommandText =
                  "CREATE TABLE Messages(N int IDENTITY(1,1)," +
                                       "UID nvarchar(50)," +
                                       "Date nvarchar(50)," +
                                       "Message ntext," +
                                       "Investment nvarchar(50)," +
                                       "Attribute nvarchar(50)," +
                                       "Message_ID nvarchar(50))";
            sql_SQL_Command.ExecuteNonQuery();
            //sql_SQL_Command.CommandText = "UPDATE Messages SET N = '0'";
            //sql_SQL_Command.ExecuteScalar();
            sql_SQL_Connection.Close();
        }

        public void pv_AddAttributeReaded(String ls_BasePath, String ls_ContactUID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "UPDATE Messages SET Attribute = 'READED' WHERE Attribute='none' AND UID ='" + ls_ContactUID + "'";
            sql_SQL_Command.ExecuteScalar();
            sql_SQL_Connection.Close();
        }

        public void pv_Create_UserFilesDB(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Engine.CreateDatabase();
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText =
                     "CREATE TABLE Files(UID nvarchar(50)," +
                                          "Date nvarchar(50)," +
                                          "FileNameOriginal ntext," +
                                          "FileNameGiven nvarchar(50)," +
                                          "FileLenght nvarchar(50)," +
                                          "Attribute nvarchar(50))";
            sql_SQL_Command.ExecuteNonQuery();
            sql_SQL_Connection.Close();
        }
        public void pv_AddFileToUserFilesDB(String ls_BasePath, String ls_UID, DateTime ldt_DateTime,
            String FileNameOriginal, String FileNameGiven, String FileLenght, String Attribute)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "INSERT INTO Files(UID, Date, FileNameOriginal, FileNameGiven, FileLenght, Attribute) VALUES(?,?,?,?,?,?)";
            sql_SQL_Command.Parameters.AddWithValue("UID", ls_UID);
            sql_SQL_Command.Parameters.AddWithValue("Date", ldt_DateTime.ToString());
            sql_SQL_Command.Parameters.AddWithValue("FileNameOriginal", FileNameOriginal);
            sql_SQL_Command.Parameters.AddWithValue("FileNameGiven", FileNameGiven);
            sql_SQL_Command.Parameters.AddWithValue("FileLenght", FileLenght);
            sql_SQL_Command.Parameters.AddWithValue("Attribute", Attribute);
            sql_SQL_Command.ExecuteScalar();
            sql_SQL_Connection.Close();
        }

        public DataRow pdr_ReadRow_UserFilesDB(String ls_BasePath, String ls_ID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT * FROM Files WHERE FileNameGiven='"+ls_ID+"'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            if (n_dt.Rows.Count > 0)
            {
                return n_dt.Rows[0];
            }
            else { return null; }
        }

        public DataTable pdt_ReadAll_UserFilesDB(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT * FROM Files";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }

        public void pv_DeleteRow_UserFilesDB(String ls_BasePath, String ls_ID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "DELETE FROM Files WHERE FileNameGiven='" + ls_ID + "'";
            sql_SQL_Command.ExecuteScalar();
            sql_SQL_Connection.Close();
        }
        #region TempMessage

        //создание базы новых сообщений - непрочитанных - временная
        public void pv_Create_TempUserMessageArhive(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Engine.CreateDatabase();
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText =
                     "CREATE TABLE TempMessages(UID nvarchar(50)," +
                                          "Date nvarchar(50)," +
                                          "Message ntext," +
                                          "Investment nvarchar(50)," +
                                          "Attribute nvarchar(50)," +
                                          "Message_ID nvarchar(50))";
            sql_SQL_Command.ExecuteNonQuery();
            sql_SQL_Connection.Close();
        }

        //добавление сообщения в архив временный
        public void pv_AddMessageToTempMessageArhive(String ls_BasePath, String ls_UID, String ls_Message, DateTime ldt_DateTime,
            String ls_Attribute, String ls_Message_ID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "INSERT INTO TempMessages(UID, Date, Message, Investment, Attribute, Message_ID) VALUES(?,?,?,?,?,?)";
            sql_SQL_Command.Parameters.AddWithValue("UID", ls_UID);
            sql_SQL_Command.Parameters.AddWithValue("Date", ldt_DateTime.ToString());
            sql_SQL_Command.Parameters.AddWithValue("Message", ls_Message);
            sql_SQL_Command.Parameters.AddWithValue("Investment", "");
            sql_SQL_Command.Parameters.AddWithValue("Attribute", ls_Attribute);
            sql_SQL_Command.Parameters.AddWithValue("Message_ID", ls_Message_ID);
            sql_SQL_Command.ExecuteScalar();
            sql_SQL_Connection.Close();
        }

        public DataTable pdt_ReadTempMessageArhive(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT * FROM TempMessages";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }

        public DataTable pdt_ReadTempMessageArhive_ByUID(String ls_BasePath, String ls_UID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT * FROM TempMessages WHERE UID='" + ls_UID + "'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }

        public void pv_DeleteRowTempMessages(String ls_BasePath, String ls_UID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "DELETE FROM TempMessages WHERE UID = '" + ls_UID + "'";
            sql_SQL_Command.ExecuteScalar();
            sql_SQL_Connection.Close();
        } 
        #endregion

        #endregion

        public void pv_Create_UserContactBase(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Engine.CreateDatabase();
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText =
            "CREATE TABLE UserContact(UID nvarchar(50), GROUPS nvarchar(50), Blocked nvarchar(50))";
            sql_SQL_Command.ExecuteNonQuery();
            sql_SQL_Connection.Close();
        }

        //добавляет контакт в адресн книгу
        public void pv_AddContactToUserContactBase(String ls_BasePath, String ls_UID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT UID FROM UserContact WHERE UID='" + ls_UID + "'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            //ищет в базе есть ли данный контакт - если нет добавляет
            if (n_dt.Rows.Count == 0)
            {
                sql_SQL_Command = sql_SQL_Connection.CreateCommand();
                sql_SQL_Command.CommandText = "INSERT INTO UserContact(UID, GROUPS, Blocked) VALUES(?,?,?)";
                sql_SQL_Command.Parameters.AddWithValue("UID", ls_UID);
                sql_SQL_Command.Parameters.AddWithValue("GROUPS", "NONE");
                sql_SQL_Command.Parameters.AddWithValue("Blocked", "NONE");
                sql_SQL_Command.ExecuteScalar();
                sql_SQL_Connection.Close();
            }
        }

        public void pv_UpdateContactsInUserContactBase(String ls_BasePath, List<String> list_UIDs)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            
            foreach (String ls_UID in list_UIDs)
            {
                sql_SQL_Command = sql_SQL_Connection.CreateCommand();
                sql_SQL_Command.CommandText = "INSERT INTO UserContact(UID, GROUPS, Blocked) VALUES(?,?,?)";
                sql_SQL_Command.Parameters.AddWithValue("UID", ls_UID);
                sql_SQL_Command.Parameters.AddWithValue("GROUPS", "NONE");
                sql_SQL_Command.Parameters.AddWithValue("Blocked", "NONE");
                sql_SQL_Command.ExecuteScalar();
            }
            sql_SQL_Connection.Close();
        }
        public void pv_DeleteContactFromUserContactBase(String ls_BasePath, String ls_UID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT UID FROM UserContact WHERE UID='" + ls_UID + "'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            //ищет в базе есть ли данный контакт - если есть удаляет
            if (n_dt.Rows.Count == 1)
            {
                sql_SQL_Command = sql_SQL_Connection.CreateCommand();
                sql_SQL_Command.CommandText = "DELETE FROM UserContact WHERE UID = '" + ls_UID + "'";
                sql_SQL_Command.ExecuteScalar();
                sql_SQL_Connection.Close();
            }
        }

        public void pv_ClearContactFromUserContactBase(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "DELETE FROM UserContact";
            sql_SQL_Command.ExecuteScalar();
            sql_SQL_Connection.Close();
        }
        public DataTable pdt_FindUIDByLogin(String ls_Login)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + g_GV.ps_MainUsersRegistrationBasePath() + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT UID FROM UserRegistration WHERE Login='" + ls_Login + "'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }
        public DataTable pdt_ReadUserContactSQLBase(String ls_BasePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BasePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT * FROM UserContact";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }
        public DataTable pdt_ReadAll_UserRegistrationBase(String ls_BaseFilePath)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BaseFilePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT * FROM UserRegistration";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }
        public DataTable pdt_ReadRows_UserRegistrationBase(String ls_RowsNumber, String ls_RowsCount)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + g_GV.ps_MainUsersRegistrationBasePath() + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT UID, Image, Name, Surname, Birthday, Job, Workplace, Lifeplace, Gender FROM UserRegistration WHERE N>=" + ls_RowsNumber + " AND N<=" + ls_RowsCount + "AND Attribute != 'BLOCKED'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }

        public DataTable pdt_FindLoginInUserRegistrationBase(String ls_Login)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + g_GV.ps_MainUsersRegistrationBasePath() + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT Login FROM UserRegistration WHERE Login = '"+ls_Login+"'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }
        public DataTable pdt_Autorization(String ls_Login, String ls_Password)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + g_GV.ps_MainUsersRegistrationBasePath() + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT Login FROM UserRegistration WHERE Login='" + ls_Login + "' AND Password='" + ls_Password + "' AND Attribute != 'BLOCKED'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }
        public Object po_Count_UserRegistrationBase()
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + g_GV.ps_MainUsersRegistrationBasePath() + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT COUNT(*) FROM UserRegistration";
            return sql_SQL_Command.ExecuteScalar();
        }
        public void pv_Add_UserRegistrationBase(cl_XML_Data.str_Profile lstr_Profile,
            String ls_BaseFilePath, String ls_UserUID, String ls_UserAttribute, String ls_RegistDate)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BaseFilePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "INSERT INTO UserRegistration(Login, Password, UID, Name, Surname, RegistDate,"+
                " ChangeDate, Birthday, Workplace, Job, Image, Lifeplace, Gender, Attribute)"
                + "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            sql_SQL_Command.Parameters.AddWithValue("Login", lstr_Profile.Login);
            sql_SQL_Command.Parameters.AddWithValue("Password", lstr_Profile.Password);
            sql_SQL_Command.Parameters.AddWithValue("UID", ls_UserUID);
            sql_SQL_Command.Parameters.AddWithValue("Name", lstr_Profile.Name);
            sql_SQL_Command.Parameters.AddWithValue("Surname", lstr_Profile.Surname);
            sql_SQL_Command.Parameters.AddWithValue("RegistDate", ls_RegistDate);
            sql_SQL_Command.Parameters.AddWithValue("ChangeDate", ls_RegistDate);
            sql_SQL_Command.Parameters.AddWithValue("Birthday", lstr_Profile.BirthDay);
            sql_SQL_Command.Parameters.AddWithValue("Workplace", lstr_Profile.Workplace);
            sql_SQL_Command.Parameters.AddWithValue("Job", lstr_Profile.Job);
            sql_SQL_Command.Parameters.AddWithValue("Image", lstr_Profile.ImageFileName);
            sql_SQL_Command.Parameters.AddWithValue("Lifeplace", lstr_Profile.Lifeplace);
            sql_SQL_Command.Parameters.AddWithValue("Gender", lstr_Profile.Gender);
            sql_SQL_Command.Parameters.AddWithValue("Attribute", ls_UserAttribute);
            sql_SQL_Command.ExecuteScalar();
            sql_SQL_Connection.Close();
        }
        public DataTable ps_ReadUserData_UserRegistrationBase(String ls_Login)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + g_GV.ps_MainUsersRegistrationBasePath() + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT UID, Name, Surname, Birthday, Image, Job, Workplace, Lifeplace, Gender, Login FROM UserRegistration WHERE Login='" + ls_Login + "'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            return n_dt;
        }
        public void pv_Edit_UserRegistrationData(String ls_BaseFilePath, cl_XML_Data.str_Profile lstr_Profile)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_BaseFilePath + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();

            sql_SQL_Command.CommandText = "UPDATE UserRegistration SET " +
                "Name ='" + lstr_Profile.Name + "', " +
                "Surname ='" + lstr_Profile.Surname + "', " +
                "Birthday ='" + lstr_Profile.BirthDay + "', " +
                "Image ='" + lstr_Profile.ImageFileName + "', " +
                "Job ='" + lstr_Profile.Job + "', " +
                "Workplace ='" + lstr_Profile.Workplace + "', " +
                "Lifeplace ='" + lstr_Profile.Lifeplace + "', " +
                "Gender ='" + lstr_Profile.Gender + "', " +
                "Password ='" + lstr_Profile.Password + "', " +
                "ChangeDate ='" + g_GV.ps_CurrentDate + "' " +
                "WHERE Login = '" + lstr_Profile.Login + "'";
            sql_SQL_Command.ExecuteScalar();
            sql_SQL_Connection.Close();
        }
        public Boolean pb_FoundUserUID(String ls_Path, String ls_UserUID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_Path + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "SELECT UID FROM UserRegistration WHERE UID='" + ls_UserUID + "'";
            SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
            DataTable n_dt = new DataTable();
            n_dt.Load(n_SQL_DataReader);
            sql_SQL_Connection.Close();
            if (n_dt.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }
        public Int32 pi_EditUserPassword(String ls_Path, String ls_UserUID, String ls_UserPassword)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_Path + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "UPDATE UserRegistration SET Password = '" + ls_UserPassword + "' WHERE UID='" + ls_UserUID + "'";
            return sql_SQL_Command.ExecuteNonQuery();
        }

        public DataTable pdt_ReadUserContacts(String ls_Path, DataTable ldt_UserContacts, String ls_Mode)
        {
            if (ldt_UserContacts.Rows.Count > 0)
            {
                sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_Path + "';");
                sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
                sql_SQL_Connection.Open();
                DataTable n_dt = new DataTable();
                foreach (DataRow ldr_Row in ldt_UserContacts.Rows)
                {
                    sql_SQL_Command = sql_SQL_Connection.CreateCommand();
                    sql_SQL_Command.CommandText = "SELECT UID, Name, Surname, Birthday, Image, Job, Workplace, Lifeplace, Gender, Attribute FROM UserRegistration WHERE UID ='" + ldr_Row["UID"].ToString() + "' AND Attribute != 'BLOCKED'";
                    SqlCeDataReader n_SQL_DataReader = sql_SQL_Command.ExecuteReader();
                    n_dt.Load(n_SQL_DataReader);
                }
                sql_SQL_Connection.Close();
                return n_dt;
            }
            else { return ldt_UserContacts; }
        }
        //функции администратора
        ////////////////////////////////////////
        public Int32 pv_BlockUserInBase(String ls_Path, String ls_UserUID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_Path + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "UPDATE UserRegistration SET Attribute = 'BLOCKED' WHERE UID='" + ls_UserUID + "'";
            return sql_SQL_Command.ExecuteNonQuery();
        }
        public Int32 pv_UnBlockUserInBase(String ls_Path, String ls_UserUID)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_Path + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "UPDATE UserRegistration SET Attribute = 'READY' WHERE UID='" + ls_UserUID + "'";
            return sql_SQL_Command.ExecuteNonQuery();
        }
        ////////////////////////////////////////

        public Int32 pv_AddColumnToBase(String ls_Path)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_Path + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "ALTER TABLE UserRegistration ADD SignOnlyWithLogin nvarchar(50)";
            return sql_SQL_Command.ExecuteNonQuery();
        }

        public Int32 pv_ChangeDataInBase(String ls_Path)
        {
            sql_SQL_Engine = new SqlCeEngine("Data Source='" + ls_Path + "';");
            sql_SQL_Connection = new SqlCeConnection(sql_SQL_Engine.LocalConnectionString);
            sql_SQL_Connection.Open();
            sql_SQL_Command = sql_SQL_Connection.CreateCommand();
            sql_SQL_Command.CommandText = "UPDATE UserRegistration SET SignOnlyWithLogin = 'true'"; ;
            return sql_SQL_Command.ExecuteNonQuery();
        }
    }
}

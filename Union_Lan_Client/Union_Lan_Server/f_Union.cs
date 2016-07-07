using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;

namespace Union_Lan_Client
{
    public partial class f_Union : Form
    {
        cl_SystemHook g_SH = new cl_SystemHook();
        cl_GlobalVariables g_GV = new cl_GlobalVariables();
        cl_FileWorker g_FW = new cl_FileWorker();
        cl_FileWorker.cl_Settings g_Settings = new cl_FileWorker.cl_Settings();
        cl_XML_Data g_XML = new cl_XML_Data();
        cl_Swap g_Swap = new cl_Swap();
        public f_Main pf_Main;
        public cl_DataWorkerClient g_DW;
        cl_GlobalVariables.str_PersonalData g_PD = new cl_GlobalVariables.str_PersonalData();
        f_UserRegistration gf_UR;
        public DataTable gdt_MyContacts = new DataTable();
        //окна уведомления о сообщениях
        Int32 gi_NotificationNumber = 0;
        f_Notification[] gf_Notifications = new f_Notification[3];
        //сведения о контакте
        public cl_GlobalVariables.str_Contact[] g_str_Contacts = new cl_GlobalVariables.str_Contact[] { };
        //нужно для передачи старых параметров конкретно закр или откр окно чата
        public cl_GlobalVariables.str_Contact[] g_str_OldContact = new cl_GlobalVariables.str_Contact[] { };
        public Int32 gi_RowSelected = 0;

        public String ps_Login;
        public String ps_Password;
        ////////////////////////////////
        Boolean gb_NewMessages = false;
        Int32 gi_NewMessagesCount = 0;
        ////////////////////////////////
        Boolean gb_SwapModeEnabled = false;
        Boolean gb_CellMouseDown = false;
        delegate void del_SwapEnabled(DataGridViewCellMouseEventArgs e);
        System.Threading.Timer gt_Timer_CellMouseDown;
        DataGridViewCellMouseEventArgs gdgc_CellMouseEvent;
        public f_Union()
        {
            InitializeComponent();
        }
        private void button_Search_Click(object sender, EventArgs e)
        {
            f_UserList lf_UL = new f_UserList();
            lf_UL.pf_Union = this;
            lf_UL.g_DW = g_DW;
            lf_UL.pdt_MyContacts = gdt_MyContacts;
            lf_UL.ps_MyUID = g_PD.UID;
            lf_UL.ShowDialog();
        }
        private void f_Union_Load(object sender, EventArgs e)
        {
            toolTip_Union.SetToolTip(pictureBox_Profile, "Редактировать профиль");
            toolTip_Union.SetToolTip(button_Search, "Поиск контактов");
            toolTip_Union.SetToolTip(button_Settings, "Настройки");
            toolTip_Union.SetToolTip(button_Shutdown, "Выход");
            label_Version.Text = "Version " + g_GV.ps_ClientVersion;
            g_Settings = g_FW.p_cl_ReadSettings();
            this.Location = g_Settings.po_UnionFormPosition;
            g_DW.pf_Union = this;
            pv_GetProfileInfo();
            v_DataGridPrepare();
            g_DW.pv_DownloadMyContacts();
           
            g_DW.pv_DownloadTempMessageArhive();
            ///////////////////////////////////////////
            if (g_GV.pb_UF_TimerUpdateContactsInfoEnable == true)
            {
                timer_UpdateContacts.Interval = g_GV.pi_UpdateUpdateContactsInfo;
                timer_UpdateContacts.Start();
            }
            if (g_GV.pb_UF_TimerUpdateContactsStatusEnable == true)
            {
                timer_UpdateContactStatus.Interval = g_GV.pi_UpdateContactsStatus;
                timer_UpdateContactStatus.Start();
            }
            ///////////////////////////////////////////
            SetDoubleBuffered(dataGridView_Main, true);

            if (g_GV.pb_UF_TimerUserActivityEnable == true)
            {
                g_SH.g_DW = g_DW;
                g_SH.pf_Union = this;
                timer_UserActivity.Interval = g_GV.pi_UserActivity;
                timer_UserActivity.Start();
            }

            g_Swap.pf_Union = this;
            g_Swap.g_DW = g_DW;
        }

        public void pv_GetProfileInfo()
        {
            pictureBox_LoadProfileInfo.Visible = true;
            g_DW.pv_ProfileInfo();
        }
        public void _PROFILE_INFO(String ls_Data)
        {
            pictureBox_LoadProfileInfo.Visible = false;
            cl_XML_Data.str_Profile lstr_UserData = new cl_XML_Data.str_Profile();
            lstr_UserData = g_XML.pstr_ReadXMLUserRegistration(ls_Data);
            g_PD.UID = lstr_UserData.UID;
            g_PD.Name = lstr_UserData.Name;
            g_PD.Surname = lstr_UserData.Surname;
            g_PD.Birthday = lstr_UserData.BirthDay;
            g_PD.ImageFileName = lstr_UserData.ImageFileName;
            File.WriteAllBytes(Application.StartupPath + "\\cache\\" + lstr_UserData.ImageFileName, lstr_UserData.ImageFile);
            g_PD.Job = lstr_UserData.Job;
            g_PD.Workplace = lstr_UserData.Workplace;
            g_PD.Lifeplace = lstr_UserData.Lifeplace;
            g_PD.Gender = lstr_UserData.Gender;
            g_PD.Login = ps_Login;
            g_PD.Password = ps_Password;
            g_DW.g_PD = g_PD;
            pv_LoadUserData();
        }
        void SetDoubleBuffered(Control c, bool value)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null)
            {
                pi.SetValue(c, value, null);
            }
        }
        void v_DataGridPrepare()
        {
            dataGridView_Main.AllowUserToAddRows = false;
            dataGridView_Main.AllowUserToDeleteRows = false;
            dataGridView_Main.AllowUserToResizeColumns = false;
            dataGridView_Main.AllowUserToResizeRows = false;
            dataGridView_Main.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView_Main.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_Main.MultiSelect = false;
            dataGridView_Main.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Main.ReadOnly = true;
            dataGridView_Main.ColumnHeadersVisible = false;
            dataGridView_Main.RowHeadersVisible = false;
            dataGridView_Main.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            ///////////////////////////////
            DataGridViewTextBoxColumn dg_ContactStatusColumn = new DataGridViewTextBoxColumn();
            dataGridView_Main.Columns.Add(dg_ContactStatusColumn);
            dataGridView_Main.Columns[0].Name = "Status";
            dataGridView_Main.Columns["Status"].Width = 10;
            ///////////////////////////////
            DataGridViewImageColumn dg_ContactImageColumn = new DataGridViewImageColumn();
            dg_ContactImageColumn.ImageLayout = DataGridViewImageCellLayout.NotSet;
            dataGridView_Main.Columns.Add(dg_ContactImageColumn);
            dataGridView_Main.Columns[1].Name = "Image";
            dataGridView_Main.Columns["Image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ///////////////////////////////
            DataGridViewTextBoxColumn dg_ContactInfoColumn = new DataGridViewTextBoxColumn();
            dataGridView_Main.Columns.Add(dg_ContactInfoColumn);
            dataGridView_Main.Columns[2].Name = "Info";
            dataGridView_Main.Columns["Info"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridView_Main.Columns["Info"].Width = 130;
            dataGridView_Main.Columns["Info"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView_Main.Columns["Info"].DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView_Main.Columns["Info"].DefaultCellStyle.ForeColor = Color.DarkSlateGray;
            dataGridView_Main.Columns["Info"].DefaultCellStyle.SelectionForeColor = Color.DarkSlateGray;
            dataGridView_Main.Columns["Info"].DefaultCellStyle.Font = new System.Drawing.Font("times", 9, FontStyle.Regular);
            ///////////////////////////////
            DataGridViewImageColumn dg_ContactAttributesColumn = new DataGridViewImageColumn();
            dataGridView_Main.Columns.Add(dg_ContactAttributesColumn);
            dataGridView_Main.Columns[3].Name = "Attributes";
            dataGridView_Main.Columns["Attributes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_Main.Columns["Attributes"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView_Main.Columns["Attributes"].DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            ///////////////////////////////
            DataGridViewImageColumn dg_ContactMessageColumn = new DataGridViewImageColumn();
            dg_ContactMessageColumn.ImageLayout = DataGridViewImageCellLayout.NotSet;
            dataGridView_Main.Columns.Add(dg_ContactMessageColumn);
            dataGridView_Main.Columns[4].Name = "Message";
            dataGridView_Main.Columns["Message"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_Main.Columns["Message"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView_Main.Columns["Message"].DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            ///////////////////////////////
            DataGridViewTextBoxColumn dg_ScrollingColumn = new DataGridViewTextBoxColumn();
            dataGridView_Main.Columns.Add(dg_ScrollingColumn);
            dataGridView_Main.Columns[5].Name = "Scrolling";
            dataGridView_Main.Columns["Scrolling"].Width = 15;
            dataGridView_Main.Columns["Scrolling"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView_Main.Columns["Scrolling"].DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            ///////////////////////////////
            
        }
        public void pv_LoadUserData()
        {
            FileStream l_FS = new FileStream(Application.StartupPath + "\\cache\\" + g_PD.ImageFileName, FileMode.Open);
            pictureBox_MyImage.Image = Image.FromStream(l_FS);
            l_FS.Close();
            label_MyName.Text = g_PD.Name;
            label_MySurname.Text = g_PD.Surname;
            label_MyJob.Text = g_PD.Job;
        }
        private void button_Settings_Click(object sender, EventArgs e)
        {
            f_Settings lf_Settings = new f_Settings();
            lf_Settings.gf_Union = this;
            lf_Settings.Show();
        }
        public void pv_LoadContacts(DataTable ldt_DataTable)
        {
            g_str_OldContact = g_str_Contacts;
            dataGridView_Main.Rows.Clear();
            gdt_MyContacts = ldt_DataTable;
            pictureBox_Loading.Visible = false;
            g_str_Contacts = new cl_GlobalVariables.str_Contact[] { };

            if (ldt_DataTable.Rows.Count > 0)
            {
                g_str_Contacts = new cl_GlobalVariables.str_Contact[ldt_DataTable.Rows.Count];
                imageList_ContactsImages.Images.Clear();

                dataGridView_Main.Rows.Add(gdt_MyContacts.Rows.Count);


                for (int i = 0; i < gdt_MyContacts.Rows.Count; i++)
                {
                    dataGridView_Main["Status", i].Style.BackColor = Color.LightGray;
                    dataGridView_Main["Status", i].Style.SelectionBackColor = Color.LightGray;
                    dataGridView_Main["Attributes", i].Value = imageList_Misc.Images[0];

                    FileStream lfs_Stream = new FileStream(Application.StartupPath + "\\cache\\" + gdt_MyContacts.Rows[i]["Image"].ToString(), FileMode.Open);
                    Bitmap lbm_Bitmap = new Bitmap(Image.FromStream(lfs_Stream));
                    imageList_ContactsImages.Images.Add(lbm_Bitmap);
                    lfs_Stream.Close();
                    dataGridView_Main["Image", i].Value = imageList_ContactsImages.Images[i];

                    //конкретизируем всю инфу о клиенте в одной ячейке
                    String ls_InfoToGrid = gdt_MyContacts.Rows[i]["Surname"].ToString() + " "
                        + gdt_MyContacts.Rows[i]["Name"].ToString() + "\n"
                        + gdt_MyContacts.Rows[i]["Job"].ToString();
                    dataGridView_Main["Info", i].Value = ls_InfoToGrid;
                    dataGridView_Main["Message", i].Value = imageList_Misc.Images[0];
                }
                Int32 i_RowsNumber = 0;

                foreach (DataRow dr_Row in ldt_DataTable.Rows)
                {
                    g_str_Contacts[i_RowsNumber].s_Number = i_RowsNumber;
                    g_str_Contacts[i_RowsNumber].s_UID = dr_Row["UID"].ToString();
                    g_str_Contacts[i_RowsNumber].s_ImagePath = dr_Row["Image"].ToString();
                    g_str_Contacts[i_RowsNumber].s_Name = dr_Row["Name"].ToString();
                    g_str_Contacts[i_RowsNumber].s_Surname = dr_Row["Surname"].ToString();
                    g_str_Contacts[i_RowsNumber].s_Job = dr_Row["Job"].ToString();
                    g_str_Contacts[i_RowsNumber].s_Status = "off-line";
                    g_str_Contacts[i_RowsNumber].b_NewMessagesIncoming = false;
                    g_str_Contacts[i_RowsNumber].i_NewMessagesCountIncoming = 0;
                    g_str_Contacts[i_RowsNumber].plist_NewMessagesOutcoming = new List<String>();
                    i_RowsNumber++;
                }

                if (g_str_OldContact.Length > 0)
                {
                    for (int i = 0; i < g_str_Contacts.Length; i++)
                    {
                        for (int j = 0; j < g_str_OldContact.Length; j++)
                        {
                            if (g_str_Contacts[i].s_UID == g_str_OldContact[j].s_UID)
                            {
                                g_str_Contacts[i].f_Form = g_str_OldContact[j].f_Form;
                                g_str_Contacts[i].b_ChatFormOpened = g_str_OldContact[j].b_ChatFormOpened;
                                g_str_Contacts[i].b_NewMessagesIncoming = g_str_OldContact[j].b_NewMessagesIncoming;
                                g_str_Contacts[i].i_NewMessagesCountIncoming = g_str_OldContact[j].i_NewMessagesCountIncoming;
                                g_str_Contacts[i].plist_NewMessagesOutcoming = g_str_OldContact[j].plist_NewMessagesOutcoming;
                                if (g_str_Contacts[i].b_NewMessagesIncoming == true)
                                {
                                    dataGridView_Main.Rows[g_str_Contacts[i].s_Number].Cells["Message"].Value = imageList_Misc.Images[1];
                                }
                            }

                        }
                    }
                }

            }
            if (dataGridView_Main.Rows.Count > 0)
            {
                dataGridView_Main.Rows[gi_RowSelected].Selected = true;
                dataGridView_Main.FirstDisplayedScrollingRowIndex = gi_RowSelected;
            }

            g_DW.pv_ContatsStatus(g_PD.UID);
        }
        public void pv_TempMessageArhive(DataTable ldt_TempMessageArhive)
        {
            foreach (DataRow ldr_Row in ldt_TempMessageArhive.Rows)
            {
                for (int i = 0; i < g_str_Contacts.Length;i++ )
                {
                    if (ldr_Row["UID"].ToString() == g_str_Contacts[i].s_UID)
                    {
                        dataGridView_Main.Rows[g_str_Contacts[i].s_Number].Cells["Message"].Value = imageList_Misc.Images[1];
                        g_str_Contacts[i].b_NewMessagesIncoming = true;
                        g_str_Contacts[i].i_NewMessagesCountIncoming++;
                        gb_NewMessages = true;
                        gi_NewMessagesCount++;
                    }
                }
            }
            if (gb_NewMessages == true)
            {
                button_NewMessages.Visible = true;
                label_NewMessages.Visible = true;
                label_NewMessages.Text = gi_NewMessagesCount.ToString();
            }
        }
        #region UnionFormMove
        ///////////////////////////////////////////////
        Boolean b_MouseDown = false;
        Int32 X;
        Int32 Y;
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDown = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            Int32 li_X, li_Y;
            if (b_MouseDown == true)
            {
                li_X = this.Location.X + e.X - X;
                li_Y = this.Location.Y + e.Y - Y;
                this.Location = new Point(li_X, li_Y);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDown = true;
            X = e.X;
            Y = e.Y;
        }


        /////////////////////////////////////////////// 
        #endregion
        public void pv_OpenChatForm(String ls_UID)
        {
            Int32 li_Index = 0;
            foreach (cl_GlobalVariables.str_Contact lstr_Contact in g_str_Contacts)
            {
                if (lstr_Contact.s_UID == ls_UID)
                {
                    li_Index = lstr_Contact.s_Number;
                }
            }

            if (g_str_Contacts[li_Index].b_ChatFormOpened == true)
            {
                // если форма открыто то фокус
                g_str_Contacts[li_Index].f_Form.Focus();
            }

            if (g_str_Contacts[li_Index].b_ChatFormOpened == false)
            {
                //убираем значок - новое сообщ
                dataGridView_Main["Message", g_str_Contacts[li_Index].s_Number].Value = imageList_Misc.Images[0];
                gi_NewMessagesCount -= g_str_Contacts[li_Index].i_NewMessagesCountIncoming;
                label_NewMessages.Text = gi_NewMessagesCount.ToString();
                g_str_Contacts[li_Index].b_NewMessagesIncoming = false;
                g_str_Contacts[li_Index].i_NewMessagesCountIncoming = 0;
                if (g_GV.pb_UF_ChatOpenSend == true)
                {
                    //серверу окно чата открыто
                    g_DW.pv_ChatOpen(g_str_Contacts[li_Index].s_UID);
                }
                g_str_Contacts[li_Index].f_Form = new f_Chat();
                g_str_Contacts[li_Index].f_Form.g_PD = g_PD;
                g_str_Contacts[li_Index].f_Form.g_str_Contact = g_str_Contacts[li_Index];
                g_str_Contacts[li_Index].b_ChatFormOpened = true;
                g_str_Contacts[li_Index].f_Form.g_DW = g_DW;
                g_str_Contacts[li_Index].f_Form.pf_Union = this;
                g_str_Contacts[li_Index].f_Form.plist_NewMessagesOutcoming = g_str_Contacts[li_Index].plist_NewMessagesOutcoming;
                g_str_Contacts[li_Index].f_Form.Show();

            }
            if (gi_NewMessagesCount == 0)
            {
                gb_NewMessages = false;
                label_NewMessages.Visible = false;
                button_NewMessages.Visible = false;
            }
        }
        public void pv_InsertIncomingMessageToChatForm(Int32 li_Index, String ls_Direction, String ls_Data, DateTime ldt_DateTime, String ls_Message_ID, String ls_Attribute)
        {
            if (g_str_Contacts[li_Index].b_ChatFormOpened == true)
            {
                //добавляет сообщ в окно чата напрямую
                g_str_Contacts[li_Index].f_Form.webBrowser_MainChat.DocumentText +=
                    g_str_Contacts[li_Index].f_Form.ps_MessageToChat(ls_Data, ls_Direction, ldt_DateTime, ls_Message_ID, ls_Attribute);
            }

            //приполучении сообщ от контакта убрат статус - пишет
            if (ls_Direction == "IN")
            {
                dataGridView_Main.Rows[li_Index].Cells["Attributes"].Value = imageList_Misc.Images[0];
                if (g_str_Contacts[li_Index].b_ChatFormOpened == true)
                {
                    g_str_Contacts[li_Index].f_Form.pictureBox_ContactWriting.Visible = false;
                }
            }
        }
        public void pv_ContactOpenedChatForm(String ls_UID) //собесед октрыл окно чата
        {
            //обновляет аттриб прочтено новых сообщений
            foreach (cl_GlobalVariables.str_Contact lstr_Contact in g_str_Contacts)
            {
                if (lstr_Contact.s_UID == ls_UID & lstr_Contact.b_ChatFormOpened == true)
                {
                    lstr_Contact.f_Form.pb_ChatOpenedOnContactSide = true;
                    lstr_Contact.f_Form.pv_AddAttributesToMessages();
                }
            }
        }
        public void pv_ContactClosedChatForm(String ls_ContactUID)
        {
            //если конт закрыл окно - написанн сооб без статуса прочтено
            foreach (cl_GlobalVariables.str_Contact lstr_Contact in g_str_Contacts)
            {
                if (lstr_Contact.s_UID == ls_ContactUID & lstr_Contact.b_ChatFormOpened == true)
                {
                    lstr_Contact.f_Form.pb_ChatOpenedOnContactSide = false;
                }
            }
        }
        //нахождение окна чата с треб контактом  и передача ему архива сообщ
        public void pv_InsertDownloadedMessageArhive(String ls_Data)
        {
            cl_XML_Data.str_MessageArhive lstr_MessageArhive = g_XML.pstr_ReadXMLMessageArhive(ls_Data);
            foreach (cl_GlobalVariables.str_Contact lstr_Contact in g_str_Contacts)
            {
                if (lstr_Contact.s_UID == lstr_MessageArhive.s_UID & lstr_Contact.b_ChatFormOpened == true)
                {
                    lstr_Contact.f_Form.pb_ChatOpenedOnContactSide = lstr_MessageArhive.ContactChatFormOpened;
                    DataTable ldt_Table = g_XML.pdt_XML_To_DataTable(lstr_MessageArhive.s_Arhive);
                    lstr_Contact.f_Form.pv_LoadMessageArhive(ldt_Table);
                }
            }


        }

        public void pv_MessagesDeleted(String ls_UID)
        {
            foreach (cl_GlobalVariables.str_Contact lstr_Contact in g_str_Contacts)
            {
                if (lstr_Contact.s_UID == ls_UID & lstr_Contact.b_ChatFormOpened == true)
                {
                    lstr_Contact.f_Form.pv_MessagesDeleted();
                }
            }
        }
        private void dataGridView_Main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gf_Notifications[gi_NotificationNumber] != null)
            {
                if (gf_Notifications[gi_NotificationNumber].CanSelect == true)
                {
                    gf_Notifications[gi_NotificationNumber].Close();
                }
            }

            foreach (cl_GlobalVariables.str_Contact lstr_Contact in g_str_Contacts)
            {
                if (lstr_Contact.s_Number == dataGridView_Main.SelectedRows[0].Index)
                {
                    pv_OpenChatForm(lstr_Contact.s_UID);
                }
            }

            gi_RowSelected = dataGridView_Main.SelectedRows[0].Index;
        }
        private void timer_UpdateContacts_Tick(object sender, EventArgs e)
        {
            g_DW.pv_DownloadMyContacts();
        }
        private void timer_UpdateContactStatus_Tick(object sender, EventArgs e)
        {
            g_DW.pv_ContatsStatus(g_PD.UID);
        }
        public void pv_UpdateContactsStatus(String ls_Data)
        {
            cl_XML_Data.str_ContactsStatus lstr_CS = g_XML.pstr_ReadXML_ContactsStatus(ls_Data);

            foreach (cl_GlobalVariables.str_Contact lstr_Contact in g_str_Contacts)
            {
                for (int i = 0; i < lstr_CS.sm_UIDs.Length; i++)
                {
                    if (lstr_Contact.s_UID == lstr_CS.sm_UIDs[i])
                    {
                        if (lstr_CS.sm_Status[i] == "ON_LINE")
                        {
                            dataGridView_Main["Status", lstr_Contact.s_Number].Style.BackColor = Color.DeepSkyBlue;
                            dataGridView_Main["Status", lstr_Contact.s_Number].Style.SelectionBackColor = Color.DeepSkyBlue;
                        }
                        if (lstr_CS.sm_Status[i] == "OFF_LINE")
                        {
                            dataGridView_Main["Status", lstr_Contact.s_Number].Style.BackColor = Color.LightGray;
                            dataGridView_Main["Status", lstr_Contact.s_Number].Style.SelectionBackColor = Color.LightGray;
                        }
                        if (lstr_CS.sm_Status[i] == "NOT_ACTIVE")
                        {
                            dataGridView_Main["Status", lstr_Contact.s_Number].Style.BackColor = Color.Gold;
                            dataGridView_Main["Status", lstr_Contact.s_Number].Style.SelectionBackColor = Color.Gold;
                        }
                    }
                }
            }
        }

        private void button_Shutdown_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < g_str_Contacts.Length; i++)
            {
                if (g_str_Contacts[i].b_ChatFormOpened == true)
                {
                    g_str_Contacts[i].f_Form.Close();
                }
            }
            g_Settings = g_FW.p_cl_ReadSettings();
            g_Settings.po_UnionFormPosition = this.Location;
            g_FW.pv_WriteSettings(g_Settings);
            this.Hide();
            pf_Main.pv_ApplicationExit("EXIT");
            
        }
        public void pv_MessageNotification(cl_XML_Data.str_Message lstr_Message)
        {
            if (gf_Notifications[gi_NotificationNumber] != null)
            {
                if (gf_Notifications[gi_NotificationNumber].CanSelect == true)
                {
                    gf_Notifications[gi_NotificationNumber].timer_Closing.Start();
                }
            }

            gf_Notifications[gi_NotificationNumber] = new f_Notification();

            for (int i = 0; i < g_str_Contacts.Length; i++ )
            {

                if (g_str_Contacts[i].s_UID == lstr_Message.s_From_UID)
                {
                    if (g_str_Contacts[i].b_ChatFormOpened == false)
                    {
                        gf_Notifications[gi_NotificationNumber].gf_Union = this;
                        gf_Notifications[gi_NotificationNumber].ps_ContactUID = g_str_Contacts[i].s_UID;
                        gf_Notifications[gi_NotificationNumber].ps_ImagePath = Application.StartupPath + "\\cache\\" + g_str_Contacts[i].s_ImagePath;
                        gf_Notifications[gi_NotificationNumber].ps_Text = "Сообщение от \n" +
                        g_str_Contacts[i].s_Surname + " " + g_str_Contacts[i].s_Name;
                        gf_Notifications[gi_NotificationNumber].Show();
                        dataGridView_Main["Message", g_str_Contacts[i].s_Number].Value = imageList_Misc.Images[1];
                        g_str_Contacts[i].b_NewMessagesIncoming = true;
                        g_str_Contacts[i].i_NewMessagesCountIncoming++;


                        button_NewMessages.Visible = true;
                        label_NewMessages.Visible = true;
                        gb_NewMessages = true;
                        gi_NewMessagesCount++;
                        label_NewMessages.Text = gi_NewMessagesCount.ToString();
                    }
                    if (g_str_Contacts[i].b_ChatFormOpened == true)
                    { g_str_Contacts[i].f_Form.Focus(); }
                }

            }
           
        }
        private void contextMenuStrip_Union_Opening(object sender, CancelEventArgs e)
        {
            dataGridView_Main.Rows[gi_RowSelected].Selected = true;
        }

        private void dataGridView_Main_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            gi_RowSelected = e.RowIndex;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                gdgc_CellMouseEvent = e;
                gb_CellMouseDown = true;
                gt_Timer_CellMouseDown = new System.Threading.Timer(new TimerCallback(prv_Timer_CellMouseDown));
                gt_Timer_CellMouseDown.Change(800, 0);
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (gb_SwapModeEnabled == true)
                {
                    gb_SwapModeEnabled = false;
                    g_Swap.pv_SwapMode_Disabled(e,false);
                }
            }
        }

        private void dataGridView_Main_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gb_CellMouseDown == true & gb_SwapModeEnabled == false)
            {
                gb_CellMouseDown = false;
                gt_Timer_CellMouseDown.Dispose();
            }

            if (gb_SwapModeEnabled == true)
            {
                gb_SwapModeEnabled = false;
                g_Swap.pb_SwapMode = false;
                g_Swap.pv_SwapMode_Disabled(e, true); 
            }
        }


        private void prv_Timer_CellMouseDown(object sender)
        {
            gb_SwapModeEnabled = true;
            g_Swap.pb_SwapMode = true;
            del_SwapEnabled ldel_Swap = new del_SwapEnabled(g_Swap.pv_SwapMode_Enabled);
            this.Invoke(ldel_Swap, new object[] { gdgc_CellMouseEvent });
            System.Threading.Timer lt = (System.Threading.Timer)sender;
            lt.Dispose();
        }

        private void отправитьСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView_Main_MouseDoubleClick(null, null);

            foreach (cl_GlobalVariables.str_Contact lstr_Contact in g_str_Contacts)
            {
                if (lstr_Contact.s_Number == gi_RowSelected) 
                {
                    pv_OpenChatForm(lstr_Contact.s_UID);
                }
            }
        }
        private void button_Info_Click(object sender, EventArgs e)
        {
            v_OpenInfoForm(g_PD);
        }
        void v_OpenInfoForm(cl_GlobalVariables.str_PersonalData l_PD)
        {
            f_Info lf_Info = new f_Info();
            lf_Info.p_PD = l_PD;
            lf_Info.ShowDialog();
        }
        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cl_GlobalVariables.str_PersonalData l_PD = new cl_GlobalVariables.str_PersonalData();
            l_PD.UID = gdt_MyContacts.Rows[gi_RowSelected]["UID"].ToString();
            l_PD.ImageFileName = gdt_MyContacts.Rows[gi_RowSelected]["Image"].ToString();
            l_PD.Name = gdt_MyContacts.Rows[gi_RowSelected]["Name"].ToString();
            l_PD.Surname = gdt_MyContacts.Rows[gi_RowSelected]["Surname"].ToString();
            l_PD.Birthday = gdt_MyContacts.Rows[gi_RowSelected]["Birthday"].ToString();
            l_PD.Job = gdt_MyContacts.Rows[gi_RowSelected]["Job"].ToString();
            l_PD.Workplace = gdt_MyContacts.Rows[gi_RowSelected]["Workplace"].ToString();
            l_PD.Lifeplace = gdt_MyContacts.Rows[gi_RowSelected]["Lifeplace"].ToString();
            l_PD.Gender = gdt_MyContacts.Rows[gi_RowSelected]["Gender"].ToString();
            v_OpenInfoForm(l_PD);
        }

        public void pv_MessageWrite_Write(String ls_UID)
        {
            for (int i = 0; i< g_str_Contacts.Length; i++)
            {
                if (g_str_Contacts[i].s_UID == ls_UID)
                {
                    g_str_Contacts[i].WritingMessage = true;
                    g_str_Contacts[i].WritingTimeOutTimer = new System.Threading.Timer(new System.Threading.TimerCallback(pv_WritingTimeOutTimerUnion), g_str_Contacts[i].s_UID, 5000, 0);
                    dataGridView_Main.Rows[g_str_Contacts[i].s_Number].Cells["Attributes"].Value = pictureBox_MessageWriting.Image;
                    g_str_Contacts[i].WritingAnimation = new System.Threading.Timer(new TimerCallback(prv_MessageWritingAnimation),g_str_Contacts[i],150,1);
                    if (g_str_Contacts[i].b_ChatFormOpened == true)
                    {
                        g_str_Contacts[i].f_Form.pictureBox_ContactWriting.Visible = true;
                    }
                }
            } 

        }

        private void prv_MessageWritingAnimation(object sender)
        {
            try
            {
                cl_GlobalVariables.str_Contact Contact = (cl_GlobalVariables.str_Contact)sender;
                dataGridView_Main.InvalidateCell(dataGridView_Main.Rows[Contact.s_Number].Cells["Attributes"]);
            }
            catch { }
        }

        #region ContactWritingTimeOut
        delegate void del_WritingTimeOutTimerUnion(cl_GlobalVariables.str_Contact lstr_Contact);
        delegate void del_WritingTimeOutTimerChat(cl_GlobalVariables.str_Contact lstr_Contact);
        private void pv_WritingTimeOutTimerUnion(object lo_UID)
        {
            foreach (cl_GlobalVariables.str_Contact lstr_Contact in g_str_Contacts)
            {
                if (lstr_Contact.s_UID == lo_UID.ToString())
                {
                    del_WritingTimeOutTimerUnion ldel_TimeOutUnion = new del_WritingTimeOutTimerUnion(pv_WritingTimeOutTimerUnion);
                    this.Invoke(ldel_TimeOutUnion, new object[] { lstr_Contact });
                    if (lstr_Contact.b_ChatFormOpened == true)
                    {
                        del_WritingTimeOutTimerChat ldel_TimeOutChat = new del_WritingTimeOutTimerChat(pv_WritingTimeOutTimerChat);
                        lstr_Contact.f_Form.Invoke(ldel_TimeOutChat, new object[] { lstr_Contact });
                    }
                }
            }
        }

        private void pv_WritingTimeOutTimerChat(cl_GlobalVariables.str_Contact lstr_Contact)
        {
            lstr_Contact.f_Form.pictureBox_ContactWriting.Visible = false;
        }

        private void pv_WritingTimeOutTimerUnion(cl_GlobalVariables.str_Contact lstr_Contact)
        {
            dataGridView_Main.Rows[lstr_Contact.s_Number].Cells["Attributes"].Value = imageList_Misc.Images[0];
            if (lstr_Contact.WritingAnimation != null)
            {
                lstr_Contact.WritingAnimation.Dispose();
            }
        } 
        #endregion

        private void pictureBox_Hide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void f_Union_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < g_str_Contacts.Length; i++)
            {
                if (g_str_Contacts[i].b_ChatFormOpened == true)
                {
                    g_str_Contacts[i].f_Form.Close();
                }
            }
            pf_Main.pv_ApplicationExit("EXIT");
        }

        private void button_AddFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", Application.StartupPath + "\\file\\");
        }

        private void pictureBox_Profile_Click(object sender, EventArgs e)
        {
            gf_UR = new f_UserRegistration();
            gf_UR.g_DW = g_DW;
            gf_UR.pv_LoadData(g_PD);
            gf_UR.ps_WorkStatus = "EDIT";
            gf_UR.ShowDialog();
            pv_GetProfileInfo();
        }

        private void dataGridView_Main_MouseEnter(object sender, EventArgs e)
        {
            dataGridView_Main.Focus();
        }

        private void timer_UserActivity_Tick(object sender, EventArgs e)
        {
            if (g_SH.pb_HookEnabled == false) { timer_UserActivity.Stop(); }
            if (g_SH.pb_HookActive == false)
            {
                g_SH.pv_SetMouseHook();
            }

            if (g_SH.pb_HookActive == true & g_SH.pb_UserActive == true)
            {
                g_SH.pb_UserActive = false;
                g_DW.pv_UserActivity(false);
            }
        }

        private void button_NewMessages_Click(object sender, EventArgs e)
        { 
            //Boolean lb_IncomingMessageTab = false;
            //foreach (TabPage ltb in tabControl1.TabPages)
            //{
            //    if (ltb.Name == "incoming_message_tab")
            //    {
            //        lb_IncomingMessageTab = true;
            //    }
            //}
            //if (lb_IncomingMessageTab == false)
            //{
            //    tabControl1.TabPages.Add("incoming_message_tab", "новые сообщения");
            //}
        }

    }
}

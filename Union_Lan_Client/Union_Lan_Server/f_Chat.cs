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
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using System.Reflection;

namespace Union_Lan_Client
{
    
    public partial class f_Chat : Form
    {
        cl_GlobalVariables g_GV = new cl_GlobalVariables();
        public cl_GlobalVariables.str_Contact g_str_Contact;
        Boolean pb_WebSmileNavigation = true;
        Boolean pb_SmileShow = false;
        String gs_SmilesData = null;
        public cl_DataWorkerClient g_DW;
        public cl_GlobalVariables.str_PersonalData g_PD;
        public f_Union pf_Union;
        public DataTable gdt_Messages;
        Boolean gb_ArhiveReaded = false;
        Boolean gb_LoadPrevMessages = false;
        String gs_ArhiveMessages = String.Empty;
        public List<String> plist_NewMessagesOutcoming;
        public Boolean pb_ChatOpenedOnContactSide = false;
        Boolean gb_BlockSendMessage = false;
        String gs_MessageReadedImage;
        DateTime gdt_LastArhiveMessageDateTime;
        String ls_httpStyle = "<style>div{padding: 2px;} #center{ text-align: center; } .content_center {border: solid 1px #006699; width: 50%; background: #E6E6E6;text-align: center;}</style>" +
                              "<style>div{padding: 2px;} #left{ text-align: left; } .content_left {border: solid 1px #006699; width: 60%; background: #b1dcfc;}</style>" +
                              "<style>div{padding: 2px;} #right { text-align: right; } .content_right {border: solid 1px #339933; width: 60%; background: #c2ff99;}</style>";
        public f_Chat()
        {
            InitializeComponent();
        }

        private void f_Chat_Load(object sender, EventArgs e)
        {
            label_MySurname.Text = g_str_Contact.s_Surname;
            label_MyName.Text = g_str_Contact.s_Name;
            label_MyJob.Text = g_str_Contact.s_Job;
            FileStream lfs_Stream = new FileStream(Application.StartupPath + "\\cache\\" + g_str_Contact.s_ImagePath, FileMode.Open);
            pictureBox_Contact.Image = Image.FromStream(lfs_Stream);
            lfs_Stream.Close();
            this.Width = 476;
            panel_Smile.Enabled = false;

            gs_MessageReadedImage = Application.StartupPath.Replace(" ", "%20");
            gs_MessageReadedImage = gs_MessageReadedImage.Replace("\\", "/");
            gs_MessageReadedImage = "<img src=file:///" + gs_MessageReadedImage + "/misc/read.png>";
            SetDoubleBuffered(webBrowser_Smile, true);
            SetDoubleBuffered(webBrowser_MainChat, true);
        }

        void SetDoubleBuffered(Control c, bool value)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null)
            {
                pi.SetValue(c, value, null);
            }
        }

        public void pv_LoadSmile()
        {
            String s_Path = Application.StartupPath + "\\Smile";
            String[] s_Smiles = Directory.GetFiles(s_Path, "*.png", SearchOption.TopDirectoryOnly);
            String s_Document = "";
            foreach (String s_temp1 in s_Smiles)
            {
                String s_temp2 = s_temp1.Replace(" ", "%20");
                s_temp2 = s_temp2.Replace("\\", "/");
                String s_FileName = Path.GetFileName(s_temp1);
                s_Document += "<a href=" + s_FileName + "><img src=file:///" + s_temp2 + " border=0></a> ";
            }

            gs_SmilesData = s_Document;
        }

        public void pv_LoadMainBrowser()
        {
            webBrowser_MainChat.DocumentText = ls_httpStyle;
        }

        private void webBrowser_Smile_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (pb_WebSmileNavigation == false)
            {
                e.Cancel = true;
                String[] s_TextToRich = e.Url.ToString().Split(new String[] { "about:"}, StringSplitOptions.RemoveEmptyEntries);
                wpf_ChatControl1.pv_Add_Smile(s_TextToRich[0]);
            }
        }


        public String ps_MessageToChat(String ls_Data, String ls_Direction, DateTime dt_SendTime, String ls_Message_ID, String ls_Attribute)
        {
            //автовставка пробелов в длинных словах
            Font lf_Font = new System.Drawing.Font(new FontFamily("times"), 10);
            Int32 li_Space = 0;
            Int32 li_CharNumber = 0;
            Int32 li_Width = (webBrowser_MainChat.Width * 60)/100;
            foreach (Char l_Char in ls_Data)
            {
                if (l_Char == ' ')
                {
                    li_Space = li_CharNumber;
                }
                Size ls_TextSize = TextRenderer.MeasureText(ls_Data.Substring(li_Space, li_CharNumber - li_Space), lf_Font);
                if (ls_TextSize.Width > li_Width)
                {
                    ls_Data = ls_Data.Insert(li_CharNumber, " ");
                }
                li_CharNumber++;
            }


            //преобрование пути изобр для хтлм
            String ls_SmileFilePath = g_GV.ps_SmileFolder().Replace(" ", "%20");
            ls_SmileFilePath = ls_SmileFilePath.Replace("\\", "/");

            ls_Data = ls_Data.Replace("[smile>", "<img src=file:///" + ls_SmileFilePath + "/");
            ls_Data = ls_Data.Replace("<]", ">");

            //вход или исходя сообщение

            String ls_ReadedImageAttribute = "";
            if (ls_Attribute == "READED" || ls_Attribute == "FILE_READED")
            { ls_ReadedImageAttribute = gs_MessageReadedImage; }
            if (ls_Attribute == "FILE" || ls_Attribute == "FILE_READED")
            {
                if (ls_Direction == "OUT")
                {
                    ls_Data = "<a href=" + g_PD.UID + "]|[" + ls_Message_ID + ">" + ls_Data + "</a>";
                }
                if (ls_Direction == "IN")
                {
                    ls_Data = "<a href=" + g_str_Contact.s_UID + "]|[" + ls_Message_ID + ">" + ls_Data + "</a>";
                }
            }
            if (ls_Direction == "OUT")
            {
                ls_Data = 
                    "<div id=" + ls_Message_ID + "><div class=content_left>"+ls_ReadedImageAttribute+"<font size=1 color=#006699 face=times>" +
                           dt_SendTime.ToShortTimeString() + "</font><br>"
                        + "<font size=2 face=arial>" + ls_Data + "</font><br></div></div></html>";
            }

            if (ls_Direction == "IN")
            {
                ls_Data = 
                    "<div id=right><div class=content_right><font size=1 color=#339933 face=times>" +
                           dt_SendTime.ToShortTimeString() + "</font><br>"
                        + "<font size=2 face=arial>" + ls_Data + "</font><br></div></div></html>";
            }

            //pb_ChatOpenedOnContactSide - во время того как окно чата откыто у собес
            if (gb_ArhiveReaded == true & pb_ChatOpenedOnContactSide == false)
            {
                plist_NewMessagesOutcoming.Add(ls_Data);
            }

            return ls_Data;
        }

        public void pv_AddAttributesToMessages()
        {
            if (gb_ArhiveReaded == false)// если обновл аттрибуты в архиве сообщ
            {
                String[] ls_Messages = gs_ArhiveMessages.Split(new String[] { "<style>" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (DataRow dr_Row in gdt_Messages.Rows)
                {
                    if (dr_Row["Attribute"].ToString() == "FILE_READED" || dr_Row["Attribute"].ToString() == "READED" & dr_Row["UID"].ToString() == g_PD.UID)
                    {
                        for (int i = 0; i < ls_Messages.Length; i++)
                        {
                            if (ls_Messages[i].Contains(dr_Row["Message_ID"].ToString()) == true)
                            {
                                ls_Messages[i] = ls_Messages[i].Replace("<div class=content_left>", "<div class=content_left>" + gs_MessageReadedImage);
                            }
                        }
                    }
                }
                String ls_All = String.Empty;
                foreach (String ls_Message in ls_Messages)
                {
                    ls_All += "<style>" + ls_Message;
                }

                webBrowser_MainChat.DocumentText = ls_All;
                webBrowser_MainChat.Document.Write(ls_All);
                webBrowser_MainChat.Document.Window.ScrollTo(webBrowser_MainChat.Document.Body.ScrollRectangle.Width, webBrowser_MainChat.Document.Body.ScrollRectangle.Height);
            }
            if (gb_ArhiveReaded == true & pb_ChatOpenedOnContactSide == true)
            {
                String ls_Message = String.Empty;
                String ls_AllMessages = webBrowser_MainChat.DocumentText;
                for (int i = 0; i < plist_NewMessagesOutcoming.Count; i++)
                {
                    ls_Message = plist_NewMessagesOutcoming[i].Replace("<div class=content_left>", "<div class=content_left>" + gs_MessageReadedImage);
                    ls_AllMessages = ls_AllMessages.Replace(plist_NewMessagesOutcoming[i], ls_Message);
                }
                webBrowser_MainChat.DocumentText = ls_AllMessages;
                webBrowser_MainChat.Document.Write(ls_AllMessages);
                plist_NewMessagesOutcoming.Clear();
            }
        }

        #region UnionFormMove
        ///////////////////////////////////////////////
        Boolean b_MouseDown = false;
        Int32 X;
        Int32 Y;
        private void panel_Label_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDown = true;
            X = e.X;
            Y = e.Y;
        }

        private void panel_Label_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDown = false;
        }

        private void panel_Label_MouseMove(object sender, MouseEventArgs e)
        {
            Int32 li_X, li_Y;
            if (b_MouseDown == true)
            {
                li_X = this.Location.X + e.X - X;
                li_Y = this.Location.Y + e.Y - Y;
                this.Location = new Point(li_X, li_Y);
            }
        }

        /////////////////////////////////////////////// 
        #endregion

        private void webBrowser_MainChat_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (gb_LoadPrevMessages == false)
            {
                webBrowser_MainChat.Document.Window.ScrollTo(webBrowser_MainChat.Document.Body.ScrollRectangle.Width, webBrowser_MainChat.Document.Body.ScrollRectangle.Height);
            }
            if (gb_LoadPrevMessages == true)
            {
                webBrowser_MainChat.Document.Window.ScrollTo(0,0);
                gb_LoadPrevMessages = false;
            }
        }

        //загрузка архива сооб в окно чата
        public void pv_LoadMessageArhive(DataTable ldt_DataTable)
        {
            pictureBox_Loading.Visible = false;
            String ls_Data = null;
            String ls_Center = "<div id=center><div class=content_center><font size=2 face=times><a href=LOAD_PREV_MESSAGES>загрузить предыдущие сообщения</a></font></div></div>";
            if (gb_ArhiveReaded == false)
            {
                if (ldt_DataTable.Rows.Count > 0)
                {
                    ls_Data += ls_Center;
                    foreach (DataRow ldr_DataRow in ldt_DataTable.Rows)
                    {
                        if (ldr_DataRow["UID"].ToString() == g_PD.UID)
                        {
                            ls_Data += ps_MessageToChat(ldr_DataRow["Message"].ToString(), "OUT", Convert.ToDateTime(ldr_DataRow["Date"]), ldr_DataRow["Message_ID"].ToString(), ldr_DataRow["Attribute"].ToString());
                        }
                        if (ldr_DataRow["UID"].ToString() == g_str_Contact.s_UID) { ls_Data += ps_MessageToChat(ldr_DataRow["Message"].ToString(), "IN", Convert.ToDateTime(ldr_DataRow["Date"]), ldr_DataRow["Message_ID"].ToString(), ldr_DataRow["Attribute"].ToString()); }
                    }
                    gdt_LastArhiveMessageDateTime = Convert.ToDateTime(ldt_DataTable.Rows[0]["Date"]);
                    webBrowser_MainChat.DocumentText += ls_Data;
                    gs_ArhiveMessages = ls_Data;
                    gdt_Messages = ldt_DataTable;
                }
                gb_ArhiveReaded = true;
                webBrowser_Smile.DocumentText = gs_SmilesData;
                pb_WebSmileNavigation = false;
            }
            else
            {
                if (ldt_DataTable.Rows.Count > 0)
                {
                    ls_Data = webBrowser_MainChat.DocumentText;
                    ls_Data = ls_Data.Replace(ls_Center,
                        "<div id=center><div class=content_center><font size=2 face=times>" + gdt_LastArhiveMessageDateTime.ToShortDateString() + "</font></a></div></div>");
                    String ls_Prev = ls_Center;
                    foreach (DataRow ldr_DataRow in ldt_DataTable.Rows)
                    {
                        if (ldr_DataRow["UID"].ToString() == g_PD.UID)
                        {
                            ls_Prev += ps_MessageToChat(ldr_DataRow["Message"].ToString(), "OUT", Convert.ToDateTime(ldr_DataRow["Date"]), ldr_DataRow["Message_ID"].ToString(), ldr_DataRow["Attribute"].ToString());
                        }
                        if (ldr_DataRow["UID"].ToString() == g_str_Contact.s_UID)
                        {
                            ls_Prev += ps_MessageToChat(ldr_DataRow["Message"].ToString(), "IN", Convert.ToDateTime(ldr_DataRow["Date"]), ldr_DataRow["Message_ID"].ToString(), ldr_DataRow["Attribute"].ToString());
                        }
                    }
                    gdt_LastArhiveMessageDateTime = Convert.ToDateTime(ldt_DataTable.Rows[0]["Date"]);
                    ls_Data = ls_httpStyle + ls_Prev + ls_Data;
                    webBrowser_MainChat.DocumentText = ls_Data;
                }
                if (ldt_DataTable.Rows.Count == 0) 
                {
                    ls_Data = webBrowser_MainChat.DocumentText;
                    ls_Data = ls_Data.Replace(ls_Center,
                        "<div id=center><div class=content_center><font size=2 face=arial>" + gdt_LastArhiveMessageDateTime.ToShortDateString() + "</font></a></div></div>");
                    webBrowser_MainChat.DocumentText = ls_Data;
                }
                gb_LoadPrevMessages = true;
            }

        }

        private void f_Chat_Shown(object sender, EventArgs e)
        {
            elementHost1.Focus();
            SendKeys.SendWait("{TAB}");
            timer_ChatFormLoad.Start();
        }

        private void pictureBox_Exit_Click(object sender, EventArgs e)
        {
            pf_Union.g_str_Contacts[g_str_Contact.s_Number].b_ChatFormOpened = false;
            Close();
        }

        private void pictureBox_ClearMessages_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите очистить список сообщений?", "Очистить сообщения", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                g_DW.pv_DeleteMessages(g_str_Contact.s_UID);
                gb_BlockSendMessage = true;
            }
        }

        private void pictureBox_Smile_Click(object sender, EventArgs e)
        {
            if (pb_SmileShow == true)
            {
                panel_Smile.Left = 474;
            }

            if (pb_SmileShow == false)
            {
                panel_Smile.Left = 300;
            }

            pb_SmileShow = !pb_SmileShow;
            panel_Smile.Enabled = true;
        }

        private void pictureBox_Send_Click(object sender, EventArgs e)
        {
            pv_SendMessage();
        }

        public void pv_SendMessage()
        {
            if (gb_BlockSendMessage == false)
            {
                if (pb_SmileShow == true)
                {
                    panel_Smile.Left = 476;
                    pb_SmileShow = false;
                    panel_Smile.Enabled = false;
                }

                //преобразование текста и смайлов в строку
                String ls_Message = wpf_ChatControl1.ps_MessageData();
                if (ls_Message != "" & ls_Message != " ")
                {

                    //отправка своего сообщ контакту
                    g_DW.pv_SendMessage(g_str_Contact.s_UID, ls_Message, null, "none");
                }
            }
        }

        private void f_Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            pf_Union.g_str_Contacts[g_str_Contact.s_Number].b_ChatFormOpened = false;
            pf_Union.g_str_Contacts[g_str_Contact.s_Number].plist_NewMessagesOutcoming = plist_NewMessagesOutcoming;
            g_DW.pv_ChatClosed(g_str_Contact.s_UID);
        }

        public void pv_WriteMessage_Write()
        {
            g_DW.pv_WriteMessage_Write(g_str_Contact.s_UID);
        }

        public void pv_MessagesDeleted()
        {
            webBrowser_MainChat.DocumentText = "";
            gb_BlockSendMessage = false;
            String ls_httpStyle = "<style>div{padding: 2px;} #left{ text-align: left; } .content_left {border: solid 1px #006699; width: 60%; background: #b1dcfc;}</style>" +
                "<style>div{padding: 2px;} #right { text-align: right; } .content_right {border: solid 1px #339933; width: 60%; background: #c2ff99;}</style>";
            webBrowser_MainChat.DocumentText = ls_httpStyle;
        }

        private void timer_ChatFormLoad_Tick(object sender, EventArgs e)
        {
            pv_LoadSmile();
            pv_LoadMainBrowser();
            
            wpf_ChatControl1.pv_Timers();
            wpf_ChatControl1.pf_Chat = this;
            g_DW.pv_DownloadMessageArhive(g_str_Contact.s_UID);
            this.Enabled = true;
            timer_ChatFormLoad.Stop();
        }

        private void pictureBox_AddFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog_SelectFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo lfi = new FileInfo(openFileDialog_SelectFile.FileName);
                if (lfi.Length > 2097152)
                {
                    MessageBox.Show("Размер выбранного файла превышает 2 мб. Выберете другой файл.");
                }

                else
                {
                    String ls_FileName = Path.GetFileName(openFileDialog_SelectFile.FileName);
                    Byte[] bm_SelectedFile = File.ReadAllBytes(openFileDialog_SelectFile.FileName);
                    g_DW.pv_SendMessage(g_str_Contact.s_UID, ls_FileName, bm_SelectedFile, "FILE");
                }
            }
        }

        private void webBrowser_MainChat_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString() != "about:blank")
            {
                e.Cancel = true;
                String[] ls_Data = e.Url.ToString().Split(new String[]{"about:"}, StringSplitOptions.RemoveEmptyEntries);
                if (ls_Data[0] == "LOAD_PREV_MESSAGES")
                {
                    g_DW.pv_LoadPrevMessages(gdt_LastArhiveMessageDateTime, g_str_Contact.s_UID);
                }
                else
                {
                    g_DW.pv_DownloadFile(ls_Data[0]);
                }
            }
        }

    }
}

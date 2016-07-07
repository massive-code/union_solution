using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Union_Lan_Client
{
    public partial class f_UserRegistration : Form
    {
        public cl_DataWorkerClient g_DW;
        cl_XML_Data.str_Profile gstr_UR = new cl_XML_Data.str_Profile();
        cl_GlobalVariables g_GV = new cl_GlobalVariables();
        public String ps_WorkStatus = String.Empty;
        cl_GlobalVariables.str_PersonalData gstr_PD;

        Boolean gb_ProfileImageSelected;
        String gs_ProfileImagePath;
        public f_UserRegistration()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Register_Click(object sender, EventArgs e)
        {
            pv_CheckRegistrationData();
        }

        public void pv_CheckRegistrationData()
        {
            Boolean lb_Check = true;

            if (textBox_Name.Text.Length != 0)
            {
                gstr_UR.Name = textBox_Name.Text;
            }
            else
            {
                textBox_Name.BackColor = Color.Coral;
                lb_Check = false;
            }

            if (textBox_Surname.Text.Length != 0)
            {
                gstr_UR.Surname = textBox_Surname.Text;
            }
            else
            {
                textBox_Surname.BackColor = Color.Coral;
                lb_Check = false;
            }

            if (textBox_Job.Text.Length != 0)
            {
                gstr_UR.Job = textBox_Job.Text.ToLower();
            }

            else
            {
                textBox_Job.BackColor = Color.Coral;
                lb_Check = false;
            }

            if (textBox_Lifeplace.Text.Length != 0)
            { gstr_UR.Lifeplace = textBox_Lifeplace.Text; }
            else
            {
                textBox_Lifeplace.BackColor = Color.Coral;
                lb_Check = false;
            }

            if (textBox_Workplace.Text.Length != 0)
            { gstr_UR.Workplace = textBox_Workplace.Text; }
            else
            {
                textBox_Workplace.BackColor = Color.Coral;
                lb_Check = false;
            }

            if (textBox_Login.Text.Length != 0)
            { gstr_UR.Login = textBox_Login.Text; }
            else
            {
                textBox_Login.BackColor = Color.Coral;
                lb_Check = false;
            }

            if (textBox_Password.Text.Length == 0)
            {
                textBox_Password.BackColor = Color.Coral;
                lb_Check = false;
            }

            if (textBox_Re_Password.Text.Length == 0)
            {
                textBox_Re_Password.BackColor = Color.Coral;
                lb_Check = false;
            }

            if (radioButton_Male.Checked == false & radioButton_Female.Checked == false)
            {
                panel_Gender.BackColor = Color.Coral;
                lb_Check = false;
            }
            else
            {
                if (radioButton_Male.Checked == true)
                {
                    gstr_UR.Gender = "MALE";
                }

                if (radioButton_Female.Checked == true)
                {
                    gstr_UR.Gender = "FEMALE";
                }
            }

            if (textBox_Password.Text != textBox_Re_Password.Text)
            {
                textBox_Re_Password.BackColor = Color.Coral;
                lb_Check = false;
            }
            else
            {
                if (ps_WorkStatus == "REGISTRATION")
                {
                    gstr_UR.Password = Cryptor.cl_Crypting_Rijndael.psvm_RijndaelEncryptedMethod(Encoding.Default.GetBytes(textBox_Password.Text), g_GV.ps_CryptKey);
                }

                if (ps_WorkStatus == "EDIT")
                {
                    //при редактир инфо задается станд текст в поле пароля
                    if (textBox_Password.Text != "password")
                    {
                        gstr_UR.Password = Cryptor.cl_Crypting_Rijndael.psvm_RijndaelEncryptedMethod(Encoding.Default.GetBytes(textBox_Password.Text), g_GV.ps_CryptKey);
                    }

                    else { gstr_UR.Password = gstr_PD.Password; }
                }
            }
            gstr_UR.BirthDay = dateTimePicker_Birthday.Value.ToShortDateString();

            //////////////////////////////////
            if (ps_WorkStatus == "EDIT")
            {
                gstr_UR.ImageFileName = gstr_PD.UID;
            }
            if (ps_WorkStatus == "REGISTRATION" & gb_ProfileImageSelected == false)
            {
                Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Union_Lan_Client.Resources.pict_Default.jpg");
                BinaryReader br = new BinaryReader(stream);
                gstr_UR.ImageFile = br.ReadBytes((int)stream.Length);
                stream.Close();
            }

            if (gb_ProfileImageSelected == true)
            {
                FileStream lfs = new FileStream(gs_ProfileImagePath, FileMode.Open);
                BinaryReader br = new BinaryReader(lfs);
                gstr_UR.ImageFile = br.ReadBytes((int)lfs.Length);
                lfs.Close();
            }

            if (ps_WorkStatus == "EDIT" & gb_ProfileImageSelected == false)
            {
                FileStream lfs = new FileStream(Application.StartupPath + "\\cache\\" + gstr_PD.ImageFileName, FileMode.Open);
                BinaryReader br = new BinaryReader(lfs);
                gstr_UR.ImageFile = br.ReadBytes((int)lfs.Length);
                lfs.Close();
            }
            //////////////////////////////////
            if (lb_Check == true)
            {
                g_DW.pf_UR = this;
                button_Register.Enabled = false;
                button_Cancel.Enabled = false;
                button_Cancel.Visible = false;
                pictureBox_Loading.Visible = true;
                
                if (ps_WorkStatus == "REGISTRATION")
                {
                    g_DW.pv_SendURData(gstr_UR);
                }

                if (ps_WorkStatus == "EDIT")
                {
                    g_DW.pv_SendUDToEdit(gstr_UR);
                }
            }

        }

        private void f_UserRegistration_Load(object sender, EventArgs e)
        {
            pictureBox_Loading.Visible = false;

            switch (ps_WorkStatus)
            {
                case "REGISTRATION": break;
                case "EDIT":
                    textBox_Login.Enabled = false;
                    button_Register.Text = "РЕДАКТИРОВАТЬ"; break;
            }

        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            textBox_Name.BackColor = Color.White;
        }

        private void textBox_Surname_TextChanged(object sender, EventArgs e)
        {
            textBox_Surname.BackColor = Color.White;
        }

        private void textBox_Job_TextChanged(object sender, EventArgs e)
        {
            textBox_Job.BackColor = Color.White;
        }

        private void textBox_Workplace_TextChanged(object sender, EventArgs e)
        {
            textBox_Workplace.BackColor = Color.White;
        }

        private void textBox_Lifeplace_TextChanged(object sender, EventArgs e)
        {
            textBox_Lifeplace.BackColor = Color.White;
        }

        private void radioButton_Male_CheckedChanged(object sender, EventArgs e)
        {
            panel_Gender.BackColor = Color.White;
        }
        private void radioButton_Female_CheckedChanged(object sender, EventArgs e)
        {
            panel_Gender.BackColor = Color.White;
        }

        private void textBox_Login_TextChanged(object sender, EventArgs e)
        {
            textBox_Login.BackColor = Color.White;
        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {
            textBox_Password.BackColor = Color.White;
            textBox_Re_Password.BackColor = Color.White;
        }

        private void textBox_Re_Password_TextChanged(object sender, EventArgs e)
        {
            textBox_Password.BackColor = Color.White;
            textBox_Re_Password.BackColor = Color.White;
        }

        public void pv_ProfileEdited()
        {
            Close();
        }

        public void pv_RegistrationStatus(String ls_Status)
        {
            button_Register.Enabled = true;
            button_Register.Text = "РЕГИСТРАЦИЯ";
            pictureBox_Loading.Visible = false;
            button_Cancel.Visible = true;
            button_Cancel.Enabled = true;
            if (ls_Status == "LOGIN_EXIST")
            {
                textBox_Login.BackColor = Color.Coral;
            }

            if (ls_Status == "SUCCESS")
            {
                MessageBox.Show("Регистрация прошла успешно!", "Регистрация нового пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        public void pv_LoadData(cl_GlobalVariables.str_PersonalData lstr_PD)
        {
            gstr_PD = lstr_PD;
            textBox_Job.Text = lstr_PD.Job;
            textBox_Lifeplace.Text = lstr_PD.Lifeplace;
            textBox_Login.Text = lstr_PD.Login;
            textBox_Name.Text = lstr_PD.Name;
            textBox_Password.Text = "password";
            textBox_Re_Password.Text = "password";
            textBox_Surname.Text = lstr_PD.Surname;
            textBox_Workplace.Text = lstr_PD.Workplace;
            if (lstr_PD.Gender == "MALE")
            {
                radioButton_Male.Checked = true;
            }

            if (lstr_PD.Gender == "FEMALE")
            {
                radioButton_Female.Checked = true;
            }

            dateTimePicker_Birthday.Value = Convert.ToDateTime(lstr_PD.Birthday);
            gstr_UR.ImageFileName = gstr_PD.ImageFileName;
            String ls_FilePath = Application.StartupPath + "\\cache\\" + lstr_PD.ImageFileName;
            FileStream l_FS = new FileStream(ls_FilePath, FileMode.Open);
            pictureBox_Image.Image = Image.FromStream(l_FS);
            l_FS.Close();
        }

        private void pictureBox_Image_Click(object sender, EventArgs e)
        {
            openFileDialog_ProfileImageSelection.InitialDirectory = Application.StartupPath + "\\images";
            if (openFileDialog_ProfileImageSelection.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileInfo fi_Info = new FileInfo(openFileDialog_ProfileImageSelection.FileName);
                    if (fi_Info.Length < 2097152)
                    {
                        gb_ProfileImageSelected = true;
                        FileStream lfs_Stream = new FileStream(openFileDialog_ProfileImageSelection.FileName, FileMode.Open);
                        pictureBox_Image.Image = Image.FromStream(lfs_Stream);
                        lfs_Stream.Close();
                        gs_ProfileImagePath = openFileDialog_ProfileImageSelection.FileName;
                    }
                    else { MessageBox.Show("Размер файла превышает установленное ограничение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                catch { MessageBox.Show("Ошибка доступа к файлу"); }
            }
        }
    }
}

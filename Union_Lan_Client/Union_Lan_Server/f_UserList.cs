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

namespace Union_Lan_Client
{
    public partial class f_UserList : Form
    {
        public f_Union pf_Union;
        public cl_DataWorkerClient g_DW;
        public Int32 pi_UsersCount = 0;
        public DataTable pdt_MyContacts = new DataTable();
        public String ps_MyUID = String.Empty;
        cl_GlobalVariables g_GV = new cl_GlobalVariables();
        cl_XML_Data g_XML = new cl_XML_Data();
        DataTable gdt_AllContacts = new DataTable();

        String[] sm_Operations;

        const String gs_OperationAdd = "добавить";
        const String gs_OperationDelete = "удалить";
        const String gs_OperationWaiting = "ожидание";
        const String gs_OperationBlocked = "заблокировано";
        public f_UserList()
        {
            InitializeComponent();
        }

        public void pv_UserCount(Int32 li_UserCount)
        {
            label_UsersCount.Text = "Зарегистрированных пользователей: " + li_UserCount;
            g_DW.pv_SendDataToShowUsers(0, li_UserCount);
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            pf_Union.pictureBox_Loading.Visible = true;
            g_DW.pv_DownloadMyContacts();
            Close();
        }

        public void pv_LoadDataGrid(DataTable ldt_DataTable)
        {
            pictureBox_Loading.Visible = false;
            imageList_Images.Images.Clear();

            
            dataGridView_Users.AllowUserToAddRows = false;
            dataGridView_Users.AllowUserToDeleteRows = false;
            dataGridView_Users.AllowUserToResizeColumns = false;
            dataGridView_Users.AllowUserToResizeRows = false;
            dataGridView_Users.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView_Users.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_Users.MultiSelect = false;
            dataGridView_Users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Users.ReadOnly = true;
            dataGridView_Users.ColumnHeadersVisible = false;
            dataGridView_Users.RowHeadersVisible = false;



            DataGridViewImageColumn dg_OperationImageColumn = new DataGridViewImageColumn();
            dg_OperationImageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
            dataGridView_Users.Columns.Add(dg_OperationImageColumn);
            dataGridView_Users.Columns[0].Name = "Operation";

            DataGridViewImageColumn dg_ContactImageColumn = new DataGridViewImageColumn();
            dg_ContactImageColumn.ImageLayout = DataGridViewImageCellLayout.NotSet;
            dataGridView_Users.Columns.Add(dg_ContactImageColumn);
            dataGridView_Users.Columns[1].Name = "Image";

            gdt_AllContacts = ldt_DataTable.Copy();

            sm_Operations = new String[gdt_AllContacts.Rows.Count];
            dataGridView_Users.Columns.Add("Info", "");

            ///////////////////////////////////////////////
            dataGridView_Users.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView_Users.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            ///////////////////////////////////////////////

            dataGridView_Users.Rows.Add(gdt_AllContacts.Rows.Count);

            for (int i = 0; i < gdt_AllContacts.Rows.Count; i++)
            {
                FileStream lfs_Stream = new FileStream(Application.StartupPath + "\\cache\\" + gdt_AllContacts.Rows[i]["Image"].ToString(), FileMode.Open);
                Bitmap lbm_Bitmap = new Bitmap(Image.FromStream(lfs_Stream));
                lfs_Stream.Close();
                    imageList_Images.Images.Add(lbm_Bitmap);
                    dataGridView_Users["Image", i].Value = imageList_Images.Images[i];

                dataGridView_Users["Operation", i].Value = imageList_Operations.Images[0];
                sm_Operations[i] = gs_OperationAdd;

                //конкретизируем всю инфу о клиенте в одной ячейке
                String ls_InfoToGrid = gdt_AllContacts.Rows[i]["Surname"].ToString() + " "
                    + gdt_AllContacts.Rows[i]["Name"].ToString() + "\n"
                    + "Дата рождения: " + gdt_AllContacts.Rows[i]["Birthday"].ToString() + "\n"
                    + "Город: " + gdt_AllContacts.Rows[i]["Lifeplace"].ToString() + "\n"
                    + "Должность: " + gdt_AllContacts.Rows[i]["Job"].ToString() + "\n"
                    + "Место работы: " + gdt_AllContacts.Rows[i]["Workplace"].ToString();
                dataGridView_Users["Info", i].Value = ls_InfoToGrid;
            }

            //найти свой UID
            for (int i = 0; i < gdt_AllContacts.Rows.Count; i++)
            {
                String ls_CellValue = gdt_AllContacts.Rows[i]["UID"].ToString();
                if (ls_CellValue == ps_MyUID)
                {
                    sm_Operations[i] = gs_OperationBlocked;
                    dataGridView_Users["Operation", i].Value = imageList_Operations.Images[3];
                }
            }

            //сравнить свой список контактов с полученным
            for (int i = 0; i < gdt_AllContacts.Rows.Count; i++)
            {
                for (int j = 0; j < pdt_MyContacts.Rows.Count; j++)
                {
                    if (gdt_AllContacts.Rows[i]["UID"].ToString() == pdt_MyContacts.Rows[j]["UID"].ToString())
                    {
                        dataGridView_Users["Operation", i].Value = imageList_Operations.Images[1];
                        sm_Operations[i] = gs_OperationDelete;
                    }
                }
            }


            dataGridView_Users.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_Users.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_Users.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridView_Users_Scroll(object sender, ScrollEventArgs e)
        {
            //if (e.OldValue == 4*gi_ScrollStep)
            //{
            //    gdt_AllContacts.Rows.Add(dataGridView_Users.Rows[2]);
            //    gi_ScrollStep++;
            //}
        }

        public void pv_AddOperationRezult(String ls_ContactUID, String ls_Rezult)
        {
            for (int i = 0; i < dataGridView_Users.Rows.Count; i++)
            {
                if (gdt_AllContacts.Rows[i]["UID"].ToString() == ls_ContactUID)
                {
                    sm_Operations[i] = gs_OperationDelete;
                    dataGridView_Users[0, i].Value = imageList_Operations.Images[1];
                }
            }
        }

        public void pv_DeleteOperationRezult(String ls_ContactUID, String ls_Rezult)
        {
            for (int i = 0; i < dataGridView_Users.Rows.Count; i++)
            {
                if (gdt_AllContacts.Rows[i]["UID"].ToString() == ls_ContactUID)
                {
                    sm_Operations[i] = gs_OperationAdd;
                    dataGridView_Users[0, i].Value = imageList_Operations.Images[0];
                }
            }
        }

        private void f_UserList_Shown(object sender, EventArgs e)
        {
            g_DW.pf_UL = this;
            g_DW.pv_SendDataToShowUsersCount();
        }

        private void f_UserList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_Users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            g_DW.pf_UL = this;
            String ls_ContactUID = String.Empty;

            if (e.ColumnIndex == 0) 
            {
                ls_ContactUID = gdt_AllContacts.Rows[e.RowIndex][0].ToString();
                if (sm_Operations[e.RowIndex] == gs_OperationAdd)
                {
                    sm_Operations[e.RowIndex] = gs_OperationWaiting;
                    dataGridView_Users[0, e.RowIndex].Value = imageList_Operations.Images[2];
                    g_DW.pv_SendDataToOperateContacts(ls_ContactUID, "CONTACT_ADD");
                }

                if (sm_Operations[e.RowIndex] == gs_OperationDelete)
                {
                    sm_Operations[e.RowIndex] = gs_OperationWaiting;
                    dataGridView_Users[0, e.RowIndex].Value = imageList_Operations.Images[2];
                    g_DW.pv_SendDataToOperateContacts(ls_ContactUID, "CONTACT_DELETE");
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Union_Lan_Client
{
    public class cl_Swap
    {
        public f_Union pf_Union;
        public cl_DataWorkerClient g_DW;
        Int32 gi_DataGrid_SelectedRow = -1;
        DataRow gdr_DataGrid_CopyRow;
        List<Object[]> glist_DataRows = new List<Object[]>();
        Int32 gi_DataGrid_RowMarked = -1;
        public Boolean pb_SwapMode = false;
        public void pv_SwapMode_Enabled(System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (pb_SwapMode == true)
            {
                pf_Union.contextMenuStrip_Union.Enabled = false;
                pf_Union.button_Search.Enabled = false;
                pf_Union.dataGridView_Main.Cursor = Cursors.SizeNS;
                pf_Union.dataGridView_Main.CellMouseEnter += dataGridView_Main_CellMouseEnter;
                pf_Union.dataGridView_Main.CellMouseLeave += dataGridView_Main_CellMouseLeave;
                glist_DataRows.Clear();
                foreach (DataRow ldr in pf_Union.gdt_MyContacts.Rows)
                {
                    glist_DataRows.Add(ldr.ItemArray);
                }
                pf_Union.dataGridView_Main.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.PowderBlue;
                gi_DataGrid_SelectedRow = e.RowIndex;
                gdr_DataGrid_CopyRow = pf_Union.gdt_MyContacts.Rows[gi_DataGrid_SelectedRow];
            }
        }

        void dataGridView_Main_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (gi_DataGrid_RowMarked != -1)
            {
                pf_Union.dataGridView_Main.Rows[gi_DataGrid_RowMarked].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
        }

        void dataGridView_Main_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != gi_DataGrid_SelectedRow)
            {
                gi_DataGrid_RowMarked = e.RowIndex;
                pf_Union.dataGridView_Main.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        public void pv_SwapMode_Disabled(DataGridViewCellMouseEventArgs e, Boolean lb_SwapMode)
        {
            pf_Union.contextMenuStrip_Union.Enabled = true;
            pf_Union.button_Search.Enabled = true;
            pf_Union.dataGridView_Main.Cursor = Cursors.Hand;

            pf_Union.dataGridView_Main.CellMouseEnter -= dataGridView_Main_CellMouseEnter;
            pf_Union.dataGridView_Main.CellMouseLeave -= dataGridView_Main_CellMouseLeave;

            if (e.RowIndex != gi_DataGrid_SelectedRow & e != null & lb_SwapMode == true & gi_DataGrid_SelectedRow !=-1)
            {
                glist_DataRows.RemoveAt(gi_DataGrid_SelectedRow);
                glist_DataRows.Insert(e.RowIndex, gdr_DataGrid_CopyRow.ItemArray);
                pf_Union.gi_RowSelected = e.RowIndex;
                pf_Union.gdt_MyContacts.Clear();

                foreach (Object[] lom in glist_DataRows)
                {
                    pf_Union.gdt_MyContacts.Rows.Add(lom);
                }

                pf_Union.pv_LoadContacts(pf_Union.gdt_MyContacts);
                List<String> list_UIDs = new List<String>();
                foreach (DataRow ldr in pf_Union.gdt_MyContacts.Rows)
                {
                    list_UIDs.Add(ldr["UID"].ToString());
                }
                g_DW.pv_UpdateUsersInGroup(list_UIDs);
            }
        }

    }
}

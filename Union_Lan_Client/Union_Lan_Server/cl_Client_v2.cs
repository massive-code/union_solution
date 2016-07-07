using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Union_Lan_Client
{
    public class cl_Client_v2
    {
        public cl_DataWorkerClient g_DW;
        public f_Main pf_Main;
        public Thread pth_Client;
        public TcpClient ptcp_Client = new TcpClient();
        public Boolean pb_ClientBlocked = false;
        public Boolean pb_Connected = false;
        public Boolean pb_ClientReconnect = true;
        NetworkStream ns_Stream;
        BinaryReader br_Reader;
        BinaryWriter bw_Writer;
        Int32 gi_GetData_ErrorCount = 0;
        Int32 gi_SendData_ErrorCount = 0;
        cl_FileWorker g_FW = new cl_FileWorker();
        cl_FileWorker.cl_Settings g_SettingsData;
        public List<String> list_SendData = new List<String>();
        public void pv_ConnectThread(object sender)
        {
            while (pb_Connected == false & pb_ClientReconnect == true)
            {
                prv_Connect();
                Thread.Sleep(100);
            }
        }

        private void prv_Connect()
        {
            g_SettingsData = g_FW.p_cl_ReadSettings();
            if (g_SettingsData.pb_ProxyEnabled == false)
            {
                IPEndPoint lip_RemotePoint = new IPEndPoint(IPAddress.Parse(g_SettingsData.ps_ServerIP), Convert.ToInt32(g_SettingsData.ps_ServerPort));
                try
                {
                    ptcp_Client.Connect(lip_RemotePoint);
                    ns_Stream = new NetworkStream(ptcp_Client.Client);
                    br_Reader = new BinaryReader(ns_Stream);
                    bw_Writer = new BinaryWriter(ns_Stream);
                    pb_Connected = true;
                }

                catch 
                {
                    pb_Connected = false;
                }
            }
            if (g_SettingsData.pb_ProxyEnabled == true)
            {

            }

            if (pb_Connected == true)
            {
                Thread th_GetData = new Thread(new ParameterizedThreadStart(prv_GetData));
                th_GetData.Start();
                Thread th_SendData = new Thread(new ParameterizedThreadStart(pv_SendData));
                th_SendData.Start();
                g_DW.pv_CheckServerStatus();
            }

        }

        private void prv_GetData(object sender)
        {
            Boolean lb_GetSize = false;
            Int32 i_Size = 0;
            while (pb_ClientBlocked == false)
            {
                Boolean lb_GetData = false;
                Byte[] bm_Data = new Byte[] { };
                try
                {
                    if (ptcp_Client.Available > 0 & lb_GetSize == false)
                    {
                        Byte[] bm_Size = br_Reader.ReadBytes(16);
                        i_Size = Convert.ToInt32(Encoding.UTF8.GetString(bm_Size).Split(new String[] { ">>" }, StringSplitOptions.RemoveEmptyEntries)[1]);
                        lb_GetSize = true;
                    }

                    if (ptcp_Client.Available > 0 & lb_GetSize == true)
                    {
                        bm_Data = br_Reader.ReadBytes(i_Size);
                        lb_GetData = true;
                        lb_GetSize = false;
                    }
                }
                catch (IOException)
                {
                    if (gi_GetData_ErrorCount == 3)
                    {
                        pf_Main.pv_ApplicationExit("RESTART");
                    }
                    gi_GetData_ErrorCount++;
                }

                if (lb_GetData == true)
                {
                    g_DW.pv_IncomindData(Encoding.UTF8.GetString(bm_Data));
                }
                Thread.Sleep(100);
            }
        }

        public void pv_SendData(object sender)
        {
            while (pb_ClientBlocked == false)
            {
                if (list_SendData.Count > 0)
                {
                    Byte[] bm_Data = Encoding.UTF8.GetBytes(list_SendData[0]);
                    Int32 li_I = bm_Data.Length;
                    Int32 li_length = 10 - li_I.ToString().Length;
                    String ls_Space = String.Empty;
                    for (int i = 0; i < li_length; i++)
                    {
                        ls_Space += " ";
                    }
                    String ls_Size = "size>>" + bm_Data.Length + ls_Space;
                    Byte[] bm_Size = Encoding.UTF8.GetBytes(ls_Size);
                    Boolean lb_SendData = false;
                    try
                    {
                        bw_Writer.Write(bm_Size);
                        bw_Writer.Write(bm_Data);
                        lb_SendData = true;
                    }
                    catch(IOException)
                    {
                        if (gi_SendData_ErrorCount == 3)
                        {
                            pf_Main.pv_ApplicationExit("RESTART");
                        }
                        gi_SendData_ErrorCount++;
                    }

                    if (lb_SendData == true)
                    {
                        list_SendData.RemoveAt(0);
                    }
                }
                Thread.Sleep(100);
            }
        }
        public void pv_Error(Boolean lb_BlockClient, Boolean lb_Error, String ls_Error, Boolean lb_Restart )
        {
            if (lb_BlockClient == true)
            {
                pb_ClientBlocked = true;
            }

            if (lb_Error == true)
            {
                g_FW.pv_WriteToLogFile(DateTime.Now.ToString() + "  " +ls_Error);
            }

            if (lb_Restart == true)
            {
                Application.Restart();
            }
        }
    }
}

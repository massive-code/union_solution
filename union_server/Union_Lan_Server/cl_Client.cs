using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Union_Lan_Server
{
    public class cl_Client
    {
         NetworkStream ns_Stream;
         BinaryReader br_Reader;
         BinaryWriter bw_Writer;
         Int32 gi_GetData_ErrorCount = 0;
         Int32 gi_SendData_ErrorCount = 0;
         Int32 gi_Timer_TimeOutInterval = 15 * 60000;
        public cl_DataWorkerServer g_DW;
        public f_Main pf_Main;
        public cl_GlobalVariables g_GV;
        public Thread th_ClientThread;
        public Thread pthr_SendDataRound;
        public Thread pthr_GetDataRound;
        public TcpClient tcp_Client;
        public Boolean Blocked;
        public System.Threading.Timer TimeOutTimer;
        public List<String> list_SendData = new List<String>();
        delegate void del_ClientDisconnect(cl_Client Client);
        public void prv_ClientThread(object sender)
        {
            ns_Stream = new NetworkStream(tcp_Client.Client);
            br_Reader = new BinaryReader(ns_Stream);
            bw_Writer = new BinaryWriter(ns_Stream);
            pthr_GetDataRound = new Thread(new ParameterizedThreadStart(prv_GetData));
            pthr_GetDataRound.Start();
            pthr_SendDataRound = new Thread(new ParameterizedThreadStart(pv_SendData));
            pthr_SendDataRound.Start();
            TimeOutTimer = new System.Threading.Timer(new TimerCallback(prv_ClientTimeOut), null, gi_Timer_TimeOutInterval, 500);
        }

        private void prv_GetData(object sender)
        {
            while (Blocked == false)
            {
                if (tcp_Client.Available > 0)
                {
                    Boolean lb_GetData = false;
                    Byte[] bm_Data = new Byte[] { };
                    try
                    {
                        Byte[] bm_Size = br_Reader.ReadBytes(16);
                        Int32 i_Size = Convert.ToInt32(Encoding.UTF8.GetString(bm_Size).Split(new String[] { ">>" }, StringSplitOptions.RemoveEmptyEntries)[1]);
                        bm_Data = br_Reader.ReadBytes(i_Size);
                        lb_GetData = true;
                    }
                    catch
                    {
                        if (gi_GetData_ErrorCount == 3)
                        {
                            prv_CloseConnection();
                        }
                        gi_GetData_ErrorCount++;
                        g_DW.pv_GetData_Error();
                    }

                    if (lb_GetData == true)
                    {
                        TimeOutTimer.Change(gi_Timer_TimeOutInterval, 500);
                        g_DW.pv_IncomindData(Encoding.UTF8.GetString(bm_Data));
                    }
                }
                Thread.Sleep(100); 
            }
        }

        public void pv_SendData(object sender)
        {
            while (Blocked == false)
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
                    catch 
                    {
                        if (gi_SendData_ErrorCount == 3)
                        {
                            prv_CloseConnection();
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

        private void prv_ClientTimeOut(object sender)
        {
            if (Blocked == false)
            {
                prv_CloseConnection();
            }
            else { TimeOutTimer.Dispose(); }
        }

        private void prv_CloseConnection()
        {
            g_DW.pv_SEND_CLOSE_CHAT_FORM();
            del_ClientDisconnect ldel = new del_ClientDisconnect(pf_Main.pv_ClientDisconnect);
            pf_Main.Invoke(ldel, new object[] { this });
        }
    }
}

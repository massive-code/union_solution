//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//using System.Windows.Forms;
//using System.IO;

//namespace Union_Lan_Client
//{
//    public class cl_Client
//    {
//        public f_Main gf_MF;
//        public cl_DataWorkerClient g_DW;
//        cl_FileWorker g_FW = new cl_FileWorker();
//        cl_FileWorker.cl_Settings g_Settings = new cl_FileWorker.cl_Settings();
//        delegate void dg_ConnectionError();
//        public TcpClient gtcp_Client;
//        cl_GlobalVariables g_GV = new cl_GlobalVariables();
//        public String ps_ConnectToServer = "NOT_CONNECTED";
//        public Thread pthr_Connection;
//        public Thread pthr_SendDataRound;
//        public Boolean pb_GetDataRound = true;
//        Byte[] gbm_SendingMessage = new Byte[] { };

//        public void pv_Connect()
//        {
//            pthr_Connection = new Thread(pv_ConnectToServer);
//            pthr_Connection.IsBackground = true;
//            pthr_Connection.Start();
//        }

//        public void pv_SendDataToServer(TcpClient ltcp_Client, String ls_Data)
//        {
//            gbm_SendingMessage = Encoding.UTF8.GetBytes(ls_Data);
//            byte[] size = Encoding.UTF8.GetBytes("size>>" + gbm_SendingMessage.Length.ToString());
//            try
//            {
//                ltcp_Client.Client.Send(size);
//            }
//            catch
//            {
//                g_DW.pv_ApplicationExit(null);
//            }
//        }


//        public void pv_ConnectToServer()
//        {
//            g_Settings = g_FW.p_cl_ReadSettings();

//            try
//            {
//                if (g_Settings.pb_ProxyEnabled == true)
//                {
//                    TcpClient _tcpClient = new System.Net.Sockets.TcpClient();
//                    _tcpClient.Connect(g_Settings.ps_ProxyIP, Convert.ToInt32(g_Settings.ps_ProxyPort));
//                    NetworkStream stream = _tcpClient.GetStream();
//                    String connectCmd = String.Format("CONNECT {0}:{1} HTTP/1.0\r\nHOST {0}:{1}\r\n\r\n" + "\r\n", g_Settings.ps_ServerIP, g_Settings.ps_ServerPort);
//                    byte[] request = ASCIIEncoding.ASCII.GetBytes(connectCmd);
//                    stream.Write(request, 0, request.Length);

//                    String s_Data = null;
//                    if (_tcpClient.Available > 0)
//                    {
//                        Byte[] b_Byte = new byte[_tcpClient.Available];

//                        _tcpClient.Client.Receive(b_Byte);
//                        s_Data = Encoding.UTF8.GetString(b_Byte, 0, b_Byte.Length);

//                    }
//                    gtcp_Client = _tcpClient;
//                    _tcpClient = null;
//                }

//                if (g_Settings.pb_ProxyEnabled == false)
//                {
//                    gtcp_Client = new TcpClient(g_Settings.ps_ServerIP, Convert.ToInt32(g_Settings.ps_ServerPort));
//                }
//                ps_ConnectToServer = "CONNECTED";
//            }
//            catch
//            {
//                dg_ConnectionError ndg_ConnectionError = new dg_ConnectionError(gf_MF.pv_ConnectionError);
//                gf_MF.Invoke(ndg_ConnectionError);
//                ps_ConnectToServer = "CONNECTION_FAILED";
//                Thread.Sleep(3000);
//                pv_ConnectToServer();
//            }

//            if (ps_ConnectToServer == "CONNECTED")
//            {
//                g_DW.gtcp_Client = gtcp_Client;
//                //pthr_SendDataRound = new Thread(new ParameterizedThreadStart(g_DW.pv_SendingDataRound));
//                //pthr_SendDataRound.Start();
//                g_DW.pv_CheckServerStatus();
//                pv_GetData(null);
//            }
//        }

        
//        private void pv_GetData(object sender)
//        {
            
//            Boolean b_MessageSizeReceived = false;
//            Int32 i_MessageSize = 0;
//            while (pb_GetDataRound == true)
//            {
//                if (gtcp_Client.Client.Available > 0 & b_MessageSizeReceived == false)
//                {
//                    NetworkStream ns = new NetworkStream(gtcp_Client.Client);
//                    BinaryReader br = new BinaryReader(ns);
//                    Byte[] b_Byte = new Byte[gtcp_Client.Client.Available];
//                    b_Byte = br.ReadBytes(gtcp_Client.Client.Available);
//                    String s_Data = Encoding.UTF8.GetString(b_Byte, 0, b_Byte.Length);
//                    String[] ls_Temp = s_Data.Split(new String[] { ">>" }, StringSplitOptions.None);
//                    switch (ls_Temp[0])
//                    {
//                        case "size": gtcp_Client.Client.Send(Encoding.UTF8.GetBytes("ready"));
//                            i_MessageSize = Convert.ToInt32(ls_Temp[1]);
//                            b_MessageSizeReceived = true; break;
//                        case "ready": gtcp_Client.Client.Send(gbm_SendingMessage); break;
//                    }
//                }
               
//                if (gtcp_Client.Client.Available > 0 & b_MessageSizeReceived == true)
//                {
//                    NetworkStream ns = new NetworkStream(gtcp_Client.Client);
//                    BinaryReader br = new BinaryReader(ns);
//                    Byte[] b_Byte = br.ReadBytes(i_MessageSize);
//                    String s_Message = Encoding.UTF8.GetString(b_Byte, 0, b_Byte.Length);
//                    g_DW.pv_IncomindData(s_Message);
//                    b_MessageSizeReceived = false;
//                }
//                Thread.Sleep(5);
//            }

//        }
//    }
//}
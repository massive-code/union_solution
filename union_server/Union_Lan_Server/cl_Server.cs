//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//using System.Windows.Forms;
//using System.IO;

//namespace Union_Lan_Server
//{
//    public class cl_Server
//    {
//        public cl_GlobalVariables g_GV;

//        delegate void dg_MainSocketStatus(Boolean b_Status, String s_IP, String s_Port);
//        delegate void dg_IncomingData(String s_Data);
//        delegate void dg_Connections(List<gc_ClientConnection> list_UsersList);
//        public Socket socket_Listener;
//        public String ps_SocketStatus = "SOCKET_CLOSED";
//        public Boolean gb_CloseSocketListener = false;
//        public Thread thr_ServerSocket;
//        public f_Main pf_Main;
//        Byte[] gbm_SendingMessage = new Byte[] { };

//        public class lc_Settings
//        {
//            public IPAddress IPAdress;
//            public Int32 Port;
//        }

//        public class gc_ClientConnection
//        {
//            public cl_DataWorkerServer g_DW;
//            public Thread MainThread;
//            public Thread pthr_SendDataRound;
//            public Thread pthr_GetDataRound;
//            public Socket Socket;
//            public Boolean Listening;
//            public System.Threading.Timer TimeOutTimer;
//        }

//        public List<gc_ClientConnection> list_CC = new List<gc_ClientConnection>();
//        public void pv_SendData(String ls_SendingData, gc_ClientConnection lc_Client)
//        {
//            gbm_SendingMessage = Encoding.UTF8.GetBytes(ls_SendingData);
//            byte[] size = Encoding.UTF8.GetBytes("size>>" + gbm_SendingMessage.Length.ToString());
//            try
//            {
//                lc_Client.Socket.Send(size);
//            }
//            catch { lc_Client.g_DW.Client.pb_BlockedConnection = true; }
//        }

//        public void pv_SocketOpen(IPAddress ls_IPAdress, Int32 li_Port)
//        {
//            lc_Settings n_lc_Settings = new lc_Settings();
//            n_lc_Settings.IPAdress = ls_IPAdress;
//            n_lc_Settings.Port = li_Port;
//            thr_ServerSocket = new Thread(v_OpenSocketListening);
//            thr_ServerSocket.Start(n_lc_Settings);
//        }

//        void v_OpenSocketListening(Object o_Settings)
//        {
//            gb_CloseSocketListener = false;
//            lc_Settings n_GD_Settings = new lc_Settings();
//            n_GD_Settings = (lc_Settings)o_Settings;

//            IPAddress ipAddress = n_GD_Settings.IPAdress;
//            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, n_GD_Settings.Port);
//            socket_Listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
//            Boolean b_IPCorrect = true;
//            try
//            {
//                socket_Listener.Bind(ipEndPoint);
//            }
//            catch { MessageBox.Show("Неверный IP в настройках сервера", "Сетевая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); b_IPCorrect = false; }
//            if (b_IPCorrect == true)
//            {
//                socket_Listener.Listen(10);
//                ps_SocketStatus = "SOCKET_OPENED";
//                dg_MainSocketStatus ndg_MainSocketStatus = new dg_MainSocketStatus(pf_Main.pv_MainSocketStatusChange);
//                pf_Main.Invoke(ndg_MainSocketStatus, new object[] { true, n_GD_Settings.IPAdress.ToString(), n_GD_Settings.Port.ToString() });

//                while (gb_CloseSocketListener == false)
//                {
//                    gc_ClientConnection lc_CC = new gc_ClientConnection();
//                    Boolean b_SocketReady = false;
//                    try
//                    {
//                        lc_CC.Socket = socket_Listener.Accept();
//                        b_SocketReady = true;
//                    }
//                    catch (SocketException)
//                    {
//                        // Стандартная ошибка при принудителном закрытии при прослушивании сокета
//                        b_SocketReady = false;
//                    }
//                    if (b_SocketReady == true)
//                    {
//                        lc_CC.Listening = true;
//                        lc_CC.MainThread = new Thread(pv_ClientListening);
//                        lc_CC.MainThread.Start(lc_CC);
//                        list_CC.Add(lc_CC);
//                        dg_Connections ndg_Connections = new dg_Connections(pf_Main.pv_Connections);
//                        pf_Main.Invoke(ndg_Connections, new object[] { list_CC });
//                    }
//                    Thread.Sleep(5);
//                }
//            }
//        }
//        public void pv_ClientListening(Object lo_Connection)
//        {
//            gc_ClientConnection Client = new gc_ClientConnection();
//            Client = (gc_ClientConnection)lo_Connection;
//            Client.g_DW = new cl_DataWorkerServer();
//            Client.g_DW.g_GV = g_GV;
//            //Client.g_DW.g_Server = this;
//            //Client.g_DW.pf_Main = pf_Main;
//            //Client.g_DW.gc_CC = Client;
//            //Client.g_DW.pv_StartTimer();
//            //Client.pthr_SendDataRound = new Thread(new ParameterizedThreadStart(Client.g_DW.pv_SendingDataRoundThread));
//            //Client.pthr_SendDataRound.Start();
//            pv_GetData(Client);
//            //Client.pthr_GetDataRound = new Thread(new ParameterizedThreadStart(pv_GetData));
//            //Client.pthr_GetDataRound.Start(Client);
//        }

//        public void pv_GetData(object sender)
//        {
//            gc_ClientConnection Client = (gc_ClientConnection)sender;
//            Boolean gb_MessageSizeReceived = false;
//            String gs_SizeData;
//            String[] gs_Temp = new String[]{};

//            while (Client.Listening == true)
//            {
//                if (Client.Socket.Available > 0 & gb_MessageSizeReceived == false)
//                {
//                    Byte[] b_Byte = new byte[Client.Socket.Available];
//                    NetworkStream ns = new NetworkStream(Client.Socket);
//                    BinaryReader br = new BinaryReader(ns);
//                    b_Byte = br.ReadBytes(Client.Socket.Available);
//                    gs_SizeData = Encoding.UTF8.GetString(b_Byte, 0, b_Byte.Length);
//                    gs_Temp = gs_SizeData.Split(new String[] { ">>" }, StringSplitOptions.None);
//                    switch (gs_Temp[0])
//                    {
//                        case "size": Client.Socket.Send(Encoding.UTF8.GetBytes("ready")); gb_MessageSizeReceived = true; break;
//                        case "ready": Client.Socket.Send(Client.g_DW.g_Server.gbm_SendingMessage);break;
//                        //case "waiting": Client.g_DW.pb_ClientReadyToReceive = true; break;
//                    }

//                }

//                if (Client.Socket.Available > 0 & gb_MessageSizeReceived == true)
//                {
//                    String s_IncomingData = null;
//                    NetworkStream ns = new NetworkStream(Client.Socket);
//                    BinaryReader br = new BinaryReader(ns);
//                    Byte[] b_Byte = new Byte[] { };
//                    b_Byte = br.ReadBytes(Convert.ToInt32(gs_Temp[1]));
//                    s_IncomingData = Encoding.UTF8.GetString(b_Byte, 0, b_Byte.Length);
//                    Client.g_DW.pv_IncomindData(s_IncomingData);
//                    gb_MessageSizeReceived = false;
//                }
//                Thread.Sleep(5);
//            }
            
//        }
//    }
//}

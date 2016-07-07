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
    public class cl_Server_v2
    {
        public f_Main pf_Main;
        public cl_GlobalVariables g_GV;
        public Thread pth_ServerThread;
        public TcpListener ptcp_Server;
        public Boolean pb_ServerListening;
        cl_Settings g_Setting = new cl_Settings();
        cl_Settings.cl_Data g_SettingsData = new cl_Settings.cl_Data();
        delegate void dg_MainSocketStatus(Boolean b_Status, String s_IP, String s_Port);
        public List<cl_Client> list_Client = new List<cl_Client>();
        public void pv_ServerStartThread()
        {
            pth_ServerThread = new Thread(new ParameterizedThreadStart(prv_ServerStartListening));
            pth_ServerThread.Start();
        }
        private void prv_ServerStartListening(object sender)
        {
            g_SettingsData = g_Setting.p_cl_ReadSettings();
            Boolean lb_SocketExcepton = false;
            try
            {
                ptcp_Server = new TcpListener(IPAddress.Parse(g_SettingsData.ps_SocketIP), Convert.ToInt32(g_SettingsData.ps_SocketPort));
                ptcp_Server.Start();
                dg_MainSocketStatus ndg_MainSocketStatus = new dg_MainSocketStatus(pf_Main.pv_MainSocketStatusChange);
                pf_Main.Invoke(ndg_MainSocketStatus, new object[] { true, g_SettingsData.ps_SocketIP, g_SettingsData.ps_SocketPort });
                pb_ServerListening = true;
            }
            catch (Exception le_Exception)
            {
                if (le_Exception is FormatException || le_Exception is SocketException)
                {
                    lb_SocketExcepton = true;
                    dg_MainSocketStatus ndg_MainSocketStatus = new dg_MainSocketStatus(pf_Main.pv_MainSocketStatusChange);
                    pf_Main.Invoke(ndg_MainSocketStatus, new object[] { false, null, null });
                }
            }
            if (lb_SocketExcepton == false)
            {
                while (pb_ServerListening == true)
                {
                    //для отключения прослушивания порта
                    Boolean lb_ServerError = false;
                    cl_Client l_Client = new cl_Client();
                    try
                    {
                        l_Client.tcp_Client = ptcp_Server.AcceptTcpClient();
                    }
                    catch
                    {
                        lb_ServerError = true;
                    }
                    if (lb_ServerError == false)
                    {
                        l_Client.g_DW = new cl_DataWorkerServer();
                        l_Client.g_DW.g_Server_v2 = this;
                        l_Client.pf_Main = pf_Main;
                        l_Client.g_DW.pf_Main = pf_Main;
                        l_Client.g_DW.g_GV = g_GV;
                        l_Client.g_DW.g_Client = l_Client;
                        l_Client.Blocked = false;
                        l_Client.th_ClientThread = new Thread(new ParameterizedThreadStart(l_Client.prv_ClientThread));
                        l_Client.th_ClientThread.Start(l_Client);
                        list_Client.Add(l_Client);
                    }
                    Thread.Sleep(5);
                }
            }
        }
    }
}

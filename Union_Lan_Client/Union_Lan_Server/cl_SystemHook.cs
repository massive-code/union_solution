using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Union_Lan_Client
{
    public class cl_SystemHook
    {
        public cl_DataWorkerClient g_DW;
        public f_Union pf_Union;
        public Boolean pb_UserActive = true;
        public Int32 pi_MouseHookNumber = 0;
        public Boolean pb_HookActive = false;
        public Boolean pb_HookEnabled = false;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int UnhookWindowsHookEx(int idHook);

        private delegate void HookProc(int nCode, int wParam, IntPtr lParam);
        private HookProc s_MouseDelegate;
        private const int WH_MOUSE_LL = 14;

        public void pv_SetMouseHook()
        {
            try
            {
                s_MouseDelegate = MouseHookProc;
                pi_MouseHookNumber = SetWindowsHookEx(WH_MOUSE_LL, s_MouseDelegate, new IntPtr(), 0);
                if (pi_MouseHookNumber != 0)
                {
                    pb_HookActive = true;
                }
                if (pi_MouseHookNumber == 0)
                {
                    pb_HookEnabled = false;
                }
            }
            catch { pb_HookEnabled = false; }
        }

        private void MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if (pb_UserActive == false)
            {
                pf_Union.timer_UserActivity.Stop();
                pf_Union.timer_UserActivity.Start();
                g_DW.pv_UserActivity(true);
                pb_UserActive = true;
                UnhookWindowsHookEx(pi_MouseHookNumber);
                pb_HookActive = false;
            }
        }

    }
}

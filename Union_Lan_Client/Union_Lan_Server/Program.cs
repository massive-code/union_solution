using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Union_Lan_Client
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Boolean b_Application = false; //блокировка второго запуска программы при помощи мьютекса
            Mutex mutex_Mutex = new Mutex(true, "UnionLanClient", out b_Application);
            //if (b_Application == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new f_Main());
            }
        }
    }
}

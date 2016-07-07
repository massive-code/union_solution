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
using System.Diagnostics;
using System.Threading;


namespace Union_Lan_Updater
{
    public partial class Form1 : Form
    {
        String ls_MainAppPath;
        String ls_ClientFile;
        Int32 li_Steps = 0;
        Boolean lb_KillMainUnion = true;
        Boolean lb_MainUnionProcessWork = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\update._ul") == true)
            {
                ls_MainAppPath = File.ReadAllText(Application.StartupPath + "\\update._ul");
                ls_ClientFile = ls_MainAppPath + "\\Union_Lan_Client.exe";
                timer_WaitUntilMainAppClose.Start();
            }
            else { MessageBox.Show("Не найден файл настроек"); Close(); }

        }

        private void timer_WaitUntilMainAppClose_Tick(object sender, EventArgs e)
        {
            if (li_Steps >= 5)
            {
                Close();
            }

            //Mutex ff = Mutex.OpenExisting("UnionLanClient");
            //ff.
            //Boolean b_Application = false; //блокировка второго запуска программы при помощи мьютекса
            //Mutex mutex_Mutex = new Mutex(false, "UnionLanClient", out b_Application);
            //if (b_Application == true)
            //{
            //    mutex_Mutex.Close();
            //}

            Process[] lpr_Union = Process.GetProcessesByName("Union_Lan_Client");
            if (lpr_Union.Length > 0)
            {
                lpr_Union[0].Kill();
                Thread.Sleep(1000);
                prv_MoveFile();
            }
            else { prv_MoveFile(); }
            li_Steps++;
        }
        private void prv_MoveFile()
        {
            timer_WaitUntilMainAppClose.Stop();
            File.Delete(ls_ClientFile); 
            File.Move(Application.StartupPath + "\\Union_Lan_Client.exe", ls_ClientFile); 
            Process lp_Process = new Process();
            lp_Process.StartInfo.FileName = ls_ClientFile;
            lp_Process.Start();
            Close();
        }
    }
}

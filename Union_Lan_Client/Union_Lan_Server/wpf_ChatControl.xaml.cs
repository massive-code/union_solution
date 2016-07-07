using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace Union_Lan_Client
{
    /// <summary>
    /// Логика взаимодействия для wpf_ChatControl.xaml
    /// </summary>
    public partial class wpf_ChatControl : UserControl
    {
        cl_GlobalVariables g_GV = new cl_GlobalVariables();
        public f_Chat pf_Chat;

        //////////////////////////////////
        DispatcherTimer t_TimerWrite = new DispatcherTimer();
        Boolean gb_WriteMessage_Sended = false;
        //////////////////////////////////
        public wpf_ChatControl()
        {
            InitializeComponent();
        }

        public void pv_Add_Smile(String ls_SmileName)
        {
            if (gb_WriteMessage_Sended == false)
            {
                pf_Chat.pv_WriteMessage_Write();
                gb_WriteMessage_Sended = true;
                t_TimerWrite.Start();
            }

            String ls_SmilePath = g_GV.ps_SmileFolder() + ls_SmileName;
            Image image = new Image();
            BitmapImage bimg = new BitmapImage();
            bimg.BeginInit();
            bimg.UriSource = new Uri(ls_SmilePath, UriKind.Relative);
            bimg.EndInit();
            image.Source = bimg;
            image.Width = 16;

            TextPointer tp = rtb1.CaretPosition;
            InlineUIContainer iui = new InlineUIContainer(image, tp);
            iui.BaselineAlignment = BaselineAlignment.TextBottom;
            rtb1.Focus();
            rtb1.CaretPosition = rtb1.Document.ContentEnd;
        }

        public String ps_MessageData()
        {
            StringBuilder result = new StringBuilder();
            foreach (Block b in rtb1.Document.Blocks)
            {
                Paragraph p = b as Paragraph;
                if (p != null)
                {
                    foreach (Inline i in p.Inlines)
                    {
                        if (i is Run)
                        {
                            Run r = i as Run;
                            result.Append(r.Text);
                        }
                        else if (i is InlineUIContainer)
                        {
                            InlineUIContainer ic = i as InlineUIContainer;
                            if (ic.Child is Image)
                            {
                                BitmapImage img = (ic.Child as Image).Source as BitmapImage;
                                String ls_SmileFileName = System.IO.Path.GetFileName((ic.Child as Image).Source.ToString());
                                result.Append(" [smile>"+ls_SmileFileName+"<]");
                            }
                        }
                    }
                }
            }
            rtb1.Document.Blocks.Clear();
            return result.ToString();
        }

        private void rtb1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SolidColorBrush scb = new SolidColorBrush(Color.FromRgb(255, 250, 250));
                rtb1.CaretBrush = scb;
                pf_Chat.pv_SendMessage();
            }
            
        }

        private void rtb1_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SolidColorBrush scb = new SolidColorBrush(Color.FromRgb(10, 94, 126));
                rtb1.CaretBrush = scb;
                rtb1.Document.Blocks.Clear();
                rtb1.Focus();
            }
        }

        public void pv_Timers()
        {
            t_TimerWrite.Tick += new EventHandler(t_TimerWrite_Tick);
            t_TimerWrite.Interval = new TimeSpan(0, 0, 3);
        }

        private void rtb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gb_WriteMessage_Sended == false)
            {
                pf_Chat.pv_WriteMessage_Write();
                gb_WriteMessage_Sended = true;
                t_TimerWrite.Start();
            }
           
        }

        private void t_TimerWrite_Tick(object sender, EventArgs e)
        {
            gb_WriteMessage_Sended = false;
            t_TimerWrite.Stop();
        }

    }
}

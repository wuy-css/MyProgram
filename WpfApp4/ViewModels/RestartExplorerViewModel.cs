using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp4.Models;
using WpfApp4.Views;

namespace WpfApp4.ViewModels
{
    public class RestartExplorerViewModel : Screen
    {
        public RichTextBox richTextBox;
        //private FlowDocument richTextBox;

        //public FlowDocument RichTextBox
        //{
        //    get { return richTextBox; }
        //    set { richTextBox = value; NotifyOfPropertyChange(() => RichTextBox); }
        //}
        private ICommand buttonCommand;

        public ICommand ButtonCommand
        {
            get { return buttonCommand; }
            set { buttonCommand = value; NotifyOfPropertyChange(() => ButtonCommand); }
        }

        public RestartExplorerViewModel()
        {
            //Models.Unity.cmdkill(true);
            //Process.Start("explorer.exe", System.AppDomain.CurrentDomain.BaseDirectory);
            //Models.Unity.cmdkill(false);
            //Process p = new Process();
            //p.StartInfo.FileName = "explorer.exe";
            //p.StartInfo.Arguments = @"C:\Users\DELL\Pictures\2222.png";
            //p.Start();
            //ArrayList arrayList1 = new ArrayList();
            //arrayList1.Add("a");
            //arrayList1.Add(1);
            //arrayList1.Add("b");
            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("1", "2");
            //hashtable.Add(4, 5);
            ButtonCommand = new DelegateCommand(CommandHandle);
        }

        public int CommandHandle()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                Run run = new Run() { Text = p.ProcessName, FontSize = 14 };
                if (p.ProcessName == "ATGO")
                { 
                    run.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }
                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(run);
                richTextBox.Document.Blocks.Add(paragraph);
                //RichTextBox = RichTextBox + p.ProcessName + "\r\n";
            }
            return 520;
        }
        protected override void OnViewLoaded(object view)
        {
            richTextBox = (view as RestartExplorerView).richtextbox;
        }
        //“查看所有进程”按钮的单击事件
        //private void btnOk_Click(object sender, EventArgs e)
        //{
        //    Process[] processes = Process.GetProcesses();
        //    foreach (Process p in processes)
        //    {
        //        //RichTextBox = RichTextBox + p.ProcessName + "\r\n";
        //    }
        //}
    }

}

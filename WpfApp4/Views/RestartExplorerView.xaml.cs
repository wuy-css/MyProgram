using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp4.Views
{
    /// <summary>
    /// RestartExplorerView.xaml 的交互逻辑
    /// </summary>
    public partial class RestartExplorerView : UserControl
    {
        public RestartExplorerView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            //string Str = string.Format("{0}", null);
            //try
            //{

            //    Process[] processes = Process.GetProcesses();
            //    foreach (Process p in processes)
            //    {

            //        if (p.ProcessName == "ATGO")
            //        {
            //            p.Kill();
            //        }
            //        //RichTextBox = RichTextBox + p.ProcessName + "\r\n";
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}

        }
    }
}

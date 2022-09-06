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

namespace RoutedEventDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //this.timeButton.Click += TimeButton_Click;
        }

        //private void TimeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void ReportTimeHandler(object sender, ReportTimeEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            string timeStr = e.ClickTime.ToLongTimeString();
            string content = $"{timeStr} 到达 {element.Name}";
            listBox.Items.Add(content);
        }
        //private void ReportTimeHandler(object sender, RoutedEventArgs e)
        //{

        //}
    }
}

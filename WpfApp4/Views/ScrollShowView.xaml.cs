using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp4.Views
{
    /// <summary>
    /// ScrollShowView.xaml 的交互逻辑
    /// </summary>
    public partial class ScrollShowView : Window
    {
        public ScrollShowView()
        {
            InitializeComponent();
        }
        public void MyTestMethod()
        {
             Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
            });

            System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
            }));
 
        }
    }
}

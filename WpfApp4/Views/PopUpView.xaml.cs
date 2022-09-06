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

namespace WpfApp4.Views
{
    /// <summary>
    /// PopUpView.xaml 的交互逻辑
    /// </summary>
    public partial class PopUpView : UserControl
    {
        public PopUpView()
        {
            InitializeComponent();
        }

        private void PopButton_Click(object sender, RoutedEventArgs e)
        {
            Pop.IsOpen = true;//设置为打开状态
        }
    }
}

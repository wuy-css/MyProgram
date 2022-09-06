using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp4.Views
{
    /// <summary>
    /// ForView.xaml 的交互逻辑
    /// </summary>
    public partial class ForView : Window
    {
        public ForView()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.pb.Password);
        }

        private void PART_SeePassword_Click(object sender, RoutedEventArgs e)
        {
            //var a = sender as ToggleButton;
            //MessageBox.Show(a.IsChecked.ToString());
        }
        void Increase(object sender, RoutedEventArgs e)
        {
            Int32 Num = Convert.ToInt32(valueText.Text);

            valueText.Text = ((Num + 1).ToString());
        }

        void Decrease(object sender, RoutedEventArgs e)
        {
            Int32 Num = Convert.ToInt32(valueText.Text);

            valueText.Text = ((Num - 1).ToString());
        }

 

        private void RepeatButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            valueText.Text = "0";
        }
    }
}

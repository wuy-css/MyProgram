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
    /// PrintRichView.xaml 的交互逻辑
    /// </summary>
    public partial class PrintRichView : UserControl
    {
        public PrintRichView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            //显示打印框，选择份数和打印机
            if (dialog.ShowDialog() == true)
            {
                //  dialog.PrintVisual(printArea, "Print Test");
                dialog.PrintVisual(richText, "测试");
            }

            //直接打印
            // dialog.PrintVisual(richText, "测试");
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

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
using WpfTabControl.Controls;

namespace WpfTabControl
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //动态添加子菜单
            TabItemClose myDnymicTab = new TabItemClose() { Header = "用户管理"};
            ////设置图片
            //ImageBrush myImageBrush = new ImageBrush(new BitmapImage(new Uri(@"../../skin/ico/ico_PluginCleaner.png", UriKind.Relative)));
            //myDnymicTab.Background = myImageBrush;
            //设置位置
            //Thickness myThickness = new Thickness(120, 0, 0, 0);
            //myDnymicTab.Margin = myThickness;
            //设置样式
            //Style myStyle = (Style)this.FindResource("TabItemStyle");//TabItemStyle这个样式是引用的资源文件中的样式名称
            //myDnymicTab.Style = myStyle;
            //添加TabItem到TabControl中
            TabCorl.Items.Add(myDnymicTab);
            TabCorl.SelectedItem = myDnymicTab;
        }
    }
}

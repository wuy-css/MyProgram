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
using System.Windows.Shapes;

namespace WpfApp4.Views
{
    /// <summary>
    /// TreeViewWindow2View.xaml 的交互逻辑
    /// </summary>
    public partial class TreeViewWindow2View : Window
    {
        public TreeViewWindow2View()
        {
            InitializeComponent();
           
            Loaded += TreeViewWindow2View_Loaded;
        }

        private void TreeViewWindow2View_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        private void init()
        {
            myTV.Items.Add("I'm the rootNode"); // 可以是任何类型, 这里是 string
            DockPanel dp = new DockPanel();
            TextBlock tb = new TextBlock();
            tb.Text = "I'm the child node";
            tb.VerticalAlignment = VerticalAlignment.Center;
            //Image img = new Image();
            //img.Stretch = Stretch.None;
            //img.Source = new BitmapImage(new Uri(@"C:\wpf.bmp", UriKind.Absolute));
            //dp.Children.Add(img);
            dp.Children.Add(tb);
            (myTV.ItemContainerGenerator.ContainerFromIndex(0) as TreeViewItem).Items.Add(dp);
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            TreeView item = e.OriginalSource as TreeView;
            TreeViewItem selectitem = (TreeViewItem)myTV.SelectedItem;
            string itemstr = selectitem.Header.ToString();
            MessageBox.Show(itemstr);
        }
    }
}

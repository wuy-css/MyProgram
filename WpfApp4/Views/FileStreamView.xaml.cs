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
    /// FileStreamView.xaml 的交互逻辑
    /// </summary>
    public partial class FileStreamView : Window
    {
        public FileStreamView()
        {
            InitializeComponent();
            this.DataContext = this;
            var array = new List<ItemModel>();
            for (int i = 0; i < 11; i++)
            {
                array.Add(new ItemModel { ImagesPath = new BitmapImage(new Uri(string.Format("pack://application:,,,/WpfApp4;component/Images/close.png"))), Text = "Item" + i.ToString() });
            }
            this.comboBoxArray.ItemsSource = array;

        }
        public class ItemModel
        {
            public ImageSource ImagesPath { get; set; }
            public string Text { get; set; }
        }
    }
}

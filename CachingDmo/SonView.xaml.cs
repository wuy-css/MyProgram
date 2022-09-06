using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Caching;
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

namespace CachingDmo
{
    /// <summary>
    /// SonView.xaml 的交互逻辑
    /// </summary>
    public partial class SonView : Window, INotifyPropertyChanged
    {
        ObjectCache cache = MemoryCache.Default;
        private string textValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public string TextValue
        {
            get { return textValue; }
            set { textValue = value; NotifyOfPropertyChanged("TextValue"); }
        }

        public SonView()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += SonView_Loaded;
        }
        public void NotifyOfPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void SonView_Loaded(object sender, RoutedEventArgs e)
        {
            TextValue = cache["filecontents"] as string;
        }
    }
}

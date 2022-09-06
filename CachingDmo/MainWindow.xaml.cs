using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CachingDmo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            ObjectCache cache = MemoryCache.Default;
            cache["filecontents"] = "hello,women jianmian 了";
            SonView sonView = new SonView();
            sonView.ShowDialog();

            //List<int> lists = new List<int>();
            //lists.Add(1);
            //lists.Add(2);
            //lists.Add(3);
            //lists.Add(4);
            //lists.Add(5);
            //lists.Add(6);
            //lists.ForEach((i) =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine(i + DateTime.Now.ToString());
            //});
            //MessageBox.Show("nihao", "ehee");

            //string fileContents = cache["filecontents"] as string;

            //if (fileContents == null)
            //{
            //    CacheItemPolicy policy = new CacheItemPolicy();
            //    policy.AbsoluteExpiration =
            //        DateTimeOffset.Now.AddSeconds(10.0);

            //    List<string> filePaths = new List<string>();
            //    filePaths.Add("c:\\cache\\cacheText.txt");

            //    policy.ChangeMonitors.Add(new
            //        HostFileChangeMonitor(filePaths));

            //    // Fetch the file contents.
            //    fileContents = File.ReadAllText("c:\\cache\\cacheText.txt") + "\n" + DateTime.Now.ToString();

            //    cache.Set("filecontents", fileContents, policy);
            //}
            // MessageBox.Show(fileContents);
        }
    }
}

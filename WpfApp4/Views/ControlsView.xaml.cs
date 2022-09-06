using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// ControlsView.xaml 的交互逻辑
    /// </summary>
    public partial class ControlsView : UserControl
    {
        public ControlsView()
        {
            InitializeComponent();
            this.Loaded += ControlsView_Loaded;
            //var a = 1000 / 2 * 50;
            //var b = 1000 / (2 * 50);
            //MessageBox.Show("a:" + a + ",b:" + b);
        }

        private void ControlsView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDocument();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = sender as Hyperlink;
            Process.Start(new ProcessStartInfo(link.NavigateUri.AbsoluteUri));
        }

        private void myMediaElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var renderingTier = System.Windows.Media.RenderCapability.Tier >> 16;
            //通过 renderingTier 的值就可以判断当前显卡渲染级别0 没有显卡加速功能1 只有部分有显卡加速2 所有功能由显卡加速
        }

        //由于HyperLink不是UIElement，所以需要用一个Label控件包裹它实现超链接功能
        //public void GetControl()
        //{
        //    Label linkLabel = new Label();
        //    Run linkText = new Run("百度一下");
        //    Hyperlink link = new Hyperlink(linkText);

        //    link.NavigateUri = new Uri("http://www.baidu.com");

        //    link.RequestNavigate += new RequestNavigateEventHandler(delegate (object sender, RequestNavigateEventArgs e)
        //    {
        //        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
        //        e.Handled = true;
        //    });
        //    linkLabel.Content = link;
        //    myStackPanel.Children.Add(linkLabel);  // 在Xaml中创建一个StackPanel控件 名字myStackPanel
        //}

        private void LoadDocument()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"Disclaimer\Disclaimer.txt";//文件路径
            if (File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);//以只读方式打开源文件
                try
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        FlowDocument document = new FlowDocument();//承载文件内容
                        string content = sr.ReadToEnd();
                        string[] split = content.Split(new char[2] { '\r', '\n' });
                        foreach (string para in split)
                        {
                            if (para != "")
                            {
                                Paragraph paragraph = new Paragraph(new Run(para));
                                paragraph.FontFamily = new FontFamily("微软雅黑");//修改样式
                                paragraph.Foreground = new SolidColorBrush(Colors.Black);
                                if (para == "f")
                                {
                                    paragraph.FontSize = 26;
                                    paragraph.TextAlignment = TextAlignment.Center;
                                }
                                else
                                    paragraph.FontSize = 20;
                                document.Blocks.Add(paragraph);
                            }
                        }
                        this.showInfo.Document = document;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    fs.Close();
                }
            }
        }
    }
}

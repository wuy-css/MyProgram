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

namespace MediaDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            string abc = hashhelper.FileMD5(@"C:\Users\DELL\Desktop\新建文件夹 (2)\CS终端安装包-1.6.4.011-112.93.253.171.exe");
            string ebc = hashhelper.FileMD5(@"C:\Users\DELL\Desktop\新建文件夹 (2)\国信证券-生产环境-20220725.exe");
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetPath();
        }
        /// <summary>
        /// 线形
        /// </summary>
        public void GetLine()
        {
            // Add a Line Element
            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Red;
            myLine.X1 = 10;
            myLine.X2 = 50;
            myLine.Y1 = 10;
            myLine.Y2 = 50;
            //myLine.HorizontalAlignment = HorizontalAlignment.Left;
            //myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            myGrid.Children.Add(myLine);
        }
        /// <summary>
        /// 椭圆
        /// </summary>
        public void GetEllipse()
        {
            // Add an Ellipse Element
            Ellipse myEllipse = new Ellipse();
            myEllipse.Stroke = System.Windows.Media.Brushes.Black;
            myEllipse.Fill = System.Windows.Media.Brushes.DarkBlue;
            //myEllipse.HorizontalAlignment = HorizontalAlignment.Left;
            //myEllipse.VerticalAlignment = VerticalAlignment.Center;
            myEllipse.Width = 50;
            myEllipse.Height = 75;
            myGrid.Children.Add(myEllipse);
        }
        /// <summary>
        /// 矩形
        /// </summary>
        public void GetRect()
        {
            // Add a Rectangle Element
            Rectangle myRect = new System.Windows.Shapes.Rectangle();
            myRect.Stroke = System.Windows.Media.Brushes.Black;
            myRect.Fill = System.Windows.Media.Brushes.SkyBlue;
            myRect.HorizontalAlignment = HorizontalAlignment.Left;
            myRect.VerticalAlignment = VerticalAlignment.Center;
            myRect.Height = 50;
            myRect.Width = 50;
            myGrid.Children.Add(myRect);
        }
        /// <summary>
        /// 多边形
        /// </summary>
        public void GetPolygon()
        {
            //Add the Polygon Element
            Polygon myPolygon = new Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            myPolygon.StrokeThickness = 2;
            //myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            //myPolygon.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(1, 50);
            System.Windows.Point Point2 = new System.Windows.Point(10, 80);
            System.Windows.Point Point3 = new System.Windows.Point(50, 50);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPolygon.Points = myPointCollection;
            myGrid.Children.Add(myPolygon);
        }
        /// <summary>
        /// 绘制一系列相互连接的直线和曲线
        /// </summary>
        public void GetPath()
        {
            //Add the Path Element
            Path myPath = new Path();
            myPath.Stroke = System.Windows.Media.Brushes.Black;
            myPath.Fill = System.Windows.Media.Brushes.MediumSlateBlue;
            myPath.StrokeThickness = 14;
            //myPath.HorizontalAlignment = HorizontalAlignment.Left;
            //myPath.VerticalAlignment = VerticalAlignment.Center;
            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new System.Windows.Point(50, 50);
            myEllipseGeometry.RadiusX = 25;
            myEllipseGeometry.RadiusY = 25;
            myPath.Data = myEllipseGeometry;
            myGrid.Children.Add(myPath);
        }
    }
}

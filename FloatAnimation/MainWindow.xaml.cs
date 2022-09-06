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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FloatAnimation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Class1 my = new Class1();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //FloatInElement(100, 100, tb);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DoubleAnimation animation = new DoubleAnimation(
                button2.ActualHeight,                       // From        从按钮的 高度 开始
                button2.ActualHeight + 30,                  // To          到按钮的 高度 + 30 结束
                new Duration(TimeSpan.FromSeconds(1)))      // Duration    间隔是 1s
            {
                AccelerationRatio = 0,       // 设置加速占比为一半, 即 0.5
                DecelerationRatio = 1,       // 设置减速占比为0, 其实这里可以省略, 因为默认是0
            };

            button2.BeginAnimation(
                Button.HeightProperty,       // DependencyProperty      动画是针对于高度的
                animation);                  // AnimationTimeline       指定刚刚创建好的动画
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            my.Appear(button1);
            my.Disappear(button);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            my.Appear(button);
            my.Disappear(button1);
        }

        /// <summary>
        /// 移动动画
        /// </summary>
        /// <param name="top">目标点相对于上端的位置</param>
        /// <param name="left">目标点相对于左端的位置</param>
        /// <param name="elem">移动元素</param>
        public static void FloatInElement(double top, double left, UIElement elem)
        {
            try
            {
                DoubleAnimation floatY = new DoubleAnimation()
                {
                    To = top,
                    Duration = new TimeSpan(0, 0, 0, 1, 0),
                };
                DoubleAnimation floatX = new DoubleAnimation()
                {
                    To = left,
                    Duration = new TimeSpan(0, 0, 0, 1, 0),
                };

                elem.BeginAnimation(Canvas.TopProperty, floatY);
                elem.BeginAnimation(Canvas.LeftProperty, floatX);
            }
            catch (Exception)
            {

                throw;
            }

        }
        ///FloatInElement(mImage,0);
        /// <summary>
        /// 透明度动画
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="to"></param>
        public static void FloatElement2(UIElement elem, double to)
        {
            lock (elem)
            {
                if (to == 1)
                {
                    elem.Visibility = Visibility.Visible;
                }
                DoubleAnimation opacity = new DoubleAnimation()
                {
                    To = to,
                    Duration = new TimeSpan(0, 0, 0, 1, 0)
                };
                EventHandler handler = null;
                opacity.Completed += handler = (s, e) =>
                {
                    opacity.Completed -= handler;
                    if (to == 0)
                    {
                        elem.Visibility = Visibility.Collapsed;
                    }
                    opacity = null;
                };
                elem.BeginAnimation(UIElement.OpacityProperty, opacity);
            }
        }
        ///ScaleEasingAnimationShow(mImage,new Point(0.5,0.5),1,0);
        /// <summary>
        /// 用户控件是的动画
        /// </summary>
        /// <param name="element">控件名</param>
        /// <param name="point">元素开始动画的位置</param>
        /// <param name="from">元素开始的大小</param>
        /// <param name="from">元素到达的大小</param>
        public static void ScaleEasingAnimationShow(FrameworkElement element, Point point, double from, double to)
        {
            lock (element)
            {
                ScaleTransform scale = new ScaleTransform();
                element.RenderTransform = scale;
                element.RenderTransformOrigin = point;//定义圆心位置        
                EasingFunctionBase easeFunction = new PowerEase()
                {
                    EasingMode = EasingMode.EaseOut,
                    Power = 5
                };
                DoubleAnimation scaleAnimation = new DoubleAnimation()
                {
                    From = from,                                   //起始值
                    To = to,                                     //结束值
                    EasingFunction = easeFunction,                    //缓动函数
                    Duration = new TimeSpan(0, 0, 0, 1, 0)  //动画播放时间
                };
                AnimationClock clock = scaleAnimation.CreateClock();
                scale.ApplyAnimationClock(ScaleTransform.ScaleXProperty, clock);
                scale.ApplyAnimationClock(ScaleTransform.ScaleYProperty, clock);
            }
        }

        /// <summary>
        /// 支撑同时旋转和缩放的动画
        /// </summary>
        /// <param name="element">控件</param>
        /// <param name="from">元素开始的大小</param>
        /// <param name="to">元素到达的大小</param>
        /// <param name="time">动画时间</param>
        /// <param name="completed">结束事件</param>
        public static void ScaleRotateEasingAnimationShow(UIElement element, double from, double to, TimeSpan time, EventHandler completed)
        {
            //旋转
            RotateTransform angle = new RotateTransform();

            //缩放
            ScaleTransform scale = new ScaleTransform();
            TransformGroup group = new TransformGroup();
            group.Children.Add(scale);
            group.Children.Add(angle);
            element.RenderTransform = group;

            //定义圆心位置
            element.RenderTransformOrigin = new Point(0.5, 0.5);
            EasingFunctionBase easeFunction = new PowerEase()
            {
                EasingMode = EasingMode.EaseInOut,
                Power = 2
            };

            // 动画参数
            DoubleAnimation scaleAnimation = new DoubleAnimation()
            {
                From = from,
                To = to,
                EasingFunction = easeFunction,
                Duration = time,
                FillBehavior = FillBehavior.Stop
            };

            // 动画参数
            DoubleAnimation angleAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 360,
                EasingFunction = easeFunction,
                Duration = time,
                FillBehavior = FillBehavior.Stop,

            };
            angleAnimation.Completed += completed;

            // 执行动画
            scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
            angle.BeginAnimation(RotateTransform.AngleProperty, angleAnimation);
        }
    }
}

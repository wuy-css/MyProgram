using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// DataGridControlView.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridControlView : UserControl
    {
        delegate string calculator(int x, int y); //委托类型
        public DataGridControlView()
        {
            InitializeComponent();

            calculator cal = new calculator(Adding);
            string He = cal(1, 1);
            Console.Write(He);
            //拥有者Button
            this.Button1.Click += Button1_Click1; //事件订阅
            //事件响应者：Window
            //事件响应者则安装事件侦听器
            //注册侦听器
            //this.window.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.Button1_Click1));
        }
        //事件处理器
        private void Button1_Click1(object sender, RoutedEventArgs e)
        {
        }

        public static string Adding(int x, int y)
        {
            return x + y.ToString();
        }

        private void ComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            //var a = sender as ComboBox;
            //a.IsDropDownOpen = true;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            callObjectEvent(Button1, "OnClick");
        }
        #region 反射
        private void callObjectEvent(Object obj, string EventName)
        {
            //建立一个类型，AssemblyQualifiedName拿出有效的名字     
            Type t = Type.GetType(obj.GetType().AssemblyQualifiedName);
            Type b = obj.GetType();
            //参数对象      
            object[] p = new object[1];
            //产生方法      
            MethodInfo m = t.GetMethod(EventName, BindingFlags.NonPublic | BindingFlags.Instance);
            //参数赋值。传入函数      
            //获得参数资料  
            ParameterInfo[] para = m.GetParameters();
            //根据参数的名字，拿参数的空值。  
            //if (para!=null)
            //{
            //    p[0] = Type.GetType(para[0].ParameterType.BaseType.FullName).GetProperty("Empty");
            //}
            //调用      
            m.Invoke(obj, null);
            return;
        }
        #endregion
    }
}

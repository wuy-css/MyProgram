using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4.Models
{
    class Event
    {

        public delegate void MyDelegate();
        //创建一个委托实例 
        public MyDelegate myDel;
        //声明一个事件
        public event MyDelegate EventMyDel;
        //事件触发机制(必须和事件在同一个类中) 外界无法直接用EventMyDel()来触发事件
        public void DoEventDel()
        {
            EventMyDel();
        }
        public Event()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        //方法A 
        public void Fun_A()
        {
            Console.WriteLine("A 方法触发了");
        }
        //方法B 
        public void Fun_B()
        {
            Console.WriteLine("B 方法触发了");
        }
        //方法C 
        public void Fun_C()
        {
            Console.WriteLine("C 方法触发了");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //注册委托(挂载方法) 
            myDel += Fun_A;
            myDel += Fun_B;
            //注册事件
            EventMyDel += myDel;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            myDel();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            myDel = null;
            myDel += Fun_C;
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            DoEventDel();
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            EventMyDel = null;//**不会报错** 
            EventMyDel += Fun_C;
        }

    }
}

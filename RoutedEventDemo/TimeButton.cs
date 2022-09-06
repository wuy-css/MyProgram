using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RoutedEventDemo
{
    class TimeButton : Button
    {
        //路由事件和依赖属性一样，都是注册到了 Hastable 里面去了。
        //路由事件的好处：不再受直接事件那种，需要一层一层往外传递的麻烦，能直接"飞来飞去"。
        // 声明和注册路由事件
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent
            ("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeEventArgs>), typeof(TimeButton));

        //CLR 事件包装器
        public event RoutedEventHandler ReportTime
        {
            add { AddHandler(ReportTimeEvent, value); }
            remove { RemoveHandler(ReportTimeEvent, value); }
        }

        // 激发路由事件，借用 Click 事件的激发方法
        protected override void OnClick()
        {
            base.OnClick(); //  保证 Button 原有的功能正常使用， CLick 事件能被激发
            ReportTimeEventArgs args = new ReportTimeEventArgs(ReportTimeEvent, this);
            args.ClickTime = DateTime.Now;
            RaiseEvent(args);
        }
    }
    // 用于承载事件消息的时间参数
    class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
        public DateTime ClickTime { get; set; }
    }
    //EventHandler表示不带任何信息的事件
    //RoutedEventHandler就是“路由事件”，参数RoutedEventArgs带了路由信息，例如原始发送人等。
    //WPF路由事件看成一个小蚂蚁，它可以从树的 基部 向 顶部 目标（或反向）爬行，每路过一个树枝的分叉点，就会把消息带给这个分叉点。
}

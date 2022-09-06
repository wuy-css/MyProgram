using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp4.Models;

namespace WpfApp4.ViewModels
{

    //第一步
    public delegate int AddHandler(int a, int b);
    public class 加法类
    {
        //第二步
        public static int Add(int a, int b)
        {
            Console.WriteLine("开始计算：" + a + "+" + b);
            Thread.Sleep(3000); //模拟该方法运行三秒
            Console.WriteLine("计算完成！");
            return a + b;
        }
    }
    public class WindowCommandViewModel : Screen
    {
        private string buttonOperation = "Start";

        public string ButtonOperation
        {
            get { return buttonOperation; }
            set { buttonOperation = value; NotifyOfPropertyChange(() => ButtonOperation); }
        }


        private ICommand buttonCommand;

        public ICommand ButtonCommand
        {
            get { return buttonCommand; }
            set { buttonCommand = value; NotifyOfPropertyChange(() => ButtonCommand); }
        }
        public WindowCommandViewModel()
        {
            ButtonCommand = new DelegateCommand(ButtonCommandHandler);
        }
        public int ButtonCommandHandler()
        {
            //System.Windows.Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(() =>
            //{
            //}));

            ButtonOperation = "Finish";
            //第三步
            AddHandler handler = new AddHandler(加法类.Add);
            //IAsyncResult: 异步操作接口(interface)
            //BeginInvoke: 委托(delegate)的一个异步方法的开始
            IAsyncResult result = handler.BeginInvoke(1, 2, null, null);
            Console.WriteLine("继续做别的事情。。。");
            //异步操作返回
            Console.WriteLine(handler.EndInvoke(result));
            return 520;

        }
    }
}

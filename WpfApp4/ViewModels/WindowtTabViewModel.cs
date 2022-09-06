using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4.ViewModels
{
    class WindowtTabViewModel : Screen
    {


        private string texboxvalue = string.Empty;

        public string Texboxvalue
        {
            get { return texboxvalue; }
            set
            {
                texboxvalue = value;
                NotifyOfPropertyChange(() => Texboxvalue);
            }
        }
        // Thread thread = new Thread(new ThreadStart(testc));
        public List<int> lists = new List<int>();

        IWindowManager _windowManager;

        [ImportingConstructor]
        public WindowtTabViewModel()
        {
            _windowManager = IoC.Get<IWindowManager>();
            int t = 0;
            for (int i = 0; i < 1000; i++)
            {
                lists.Add(i);
            }
            foreach (var item in lists)
            {
                t++;
                if (t > 100)
                {
                    //lists.Add(0);
                }
                Thread.Sleep(1);
            }
            //Application.Current.Dispatcher.InvokeAsync(new System.Action(() =>
            //{
            //    thread.Start();
            //}));


        }
        //public void Btn()
        //{

        //    lists.Add(88888888);
        //    lists.Add(33333333); 
        //    lists.Add(66666666);
        //}

        //public static void testc()
        //{
        //    foreach (var item in new WindowtTabViewModel().lists)
        //    {

        //        //new WindowtTabViewModel().Texboxvalue = item.ToString();
        //    }
        //}
    }
}

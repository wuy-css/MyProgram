using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp4.Models;

namespace WpfApp4.ViewModels
{
    public class DataGridControlViewModel : Screen
    {

        private BindableCollection<Person> persons;

        public BindableCollection<Person> Persons
        {
            get { return persons; }
            set { persons = value; NotifyOfPropertyChange(() => Persons); }
        }


        public DataGridControlViewModel()
        {
            decimal a = 1.666M;
            //string T = String.Format("{0:N2}", 3.146);
            string t = a.ToString("f2");
            Persons = new BindableCollection<Person>();
            Persons.Add(new Person { Name = "nunum1num1num1num1num1num1num1num1m1", Adress = "hhhh1" });
            Persons.Add(new Person { Name = "num2", Adress = "hhhh2" });
            Persons.Add(new Person { Name = "num3", Adress = "hhhh3" });
            Persons.Add(new Person { Name = "num4", Adress = "hhhh4" });
            Persons.Add(new Person { Name = "num5", Adress = "hhhh5" });
            for (int i = 0; i < 1000; i++)
            {
                Persons.Add(new Person { Name = i.ToString(), Adress = i.ToString() });
            }
            //System.Threading.Timer times = new System.Threading.Timer(test);
            //times.Change(1000, 1000);
            //定义一个对象
            //System.Threading.Timer timer = new System.Threading.Timer(new System.Threading.TimerCallback(test), null,0, 1000);//1S定时器
            //int[] a = { 5, 1, 7, 2, 3 };
            //for (int i = 0; i < a.Length; i++)
            //{
            //    for (int j = 0; j < a.Length - i - 1; j++)
            //    {
            //        if (a[j] > a[j + 1])
            //        {
            //            int temp = a[j];
            //            a[j] = a[j + 1];
            //            a[j + 1] = temp;
            //        }
            //    }
            //}
            //Console.WriteLine("升序排序后的结果为：");
            //foreach (int b in a)
            //{
            //    Console.Write(b + "");
            //}
            //Console.WriteLine();

            //MyboxClass.Mybox();
            Task t1 = new Task(() =>
            {
                Console.WriteLine("任务开始工作……");
                //模拟工作过程
                Thread.Sleep(5000);
            });
            t1.Start();
            t1.ContinueWith((task) =>
            {
                Console.WriteLine("任务完成，完成时候的状态为：");
                Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}", task.IsCanceled, task.IsCompleted, task.IsFaulted);
            });
        }
    }
}

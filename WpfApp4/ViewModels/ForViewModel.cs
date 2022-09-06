using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.ViewModels
{
    public class ForViewModel
    {
        System.Timers.Timer timer = new System.Timers.Timer { Interval = 100 };
        object b = new object ();
        public ForViewModel()
        {

            timer.Elapsed += Timer_Elapsed;
            //timer.Enabled = true;
            Console.WriteLine("a:" + timer.Enabled);

            //List<string> a = new List<string>();//父集合
            //List<List<string>> b = new List<List<string>>();//拆分的子集合
            //List<string> c = new List<string>();//中间量

            //for (int i = 0; i < 9972; i++)
            //{
            //    a.Add(i.ToString());//测试数据
            //}
            //int j = 999;//每个集合序号最大值
            //for (int i = 0; i < 1000; i++)
            //{
            //    if (i < 9972)
            //    {
            //        c.Add(a[i]);
            //    }
            //    if (i < j || i == 9972)
            //    {
            //        continue;
            //    }
            //    b.Add(c);
            //    c = new List<string>();
            //    j += 1000;
            //}
        }
        public void Btn()
        {
            timer.Stop();
            Console.WriteLine("b:" + timer.Enabled);
        }
        int index = 0;
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (b)
            {
              
                //timer.Enabled = false;
                var t = 0;
                for (int i = index; i < 2000+ index; i++)
                {
                    t = i;
                    Console.WriteLine(t);
                    System.Threading.Thread.Sleep(5);
                }
                index += 2000;

            }

        }
    }
}

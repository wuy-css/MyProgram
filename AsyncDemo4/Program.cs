using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //callMethod();
            Method4();
            Console.WriteLine("=================");
            Console.ReadKey();
        }

        public static void Method4()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            //创建一个任务
            Task<int> task = new Task<int>(() =>
            {
                int sum = 0;
                Console.WriteLine("使用Task执行异步操作.");//------2
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    sum += i;
                }
                return sum;
            }, cts.Token);
            //启动任务,并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
            task.Start();
            Console.WriteLine("主线程执行其他处理"); //----1
            //任务完成时执行处理。
            Task cwt = task.ContinueWith(t =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("任务完成后的执行结果：{0}", t.Result.ToString());//------4
            });
            Console.WriteLine("主线程执行其他处理2");
            //if(task.Wait(5000))
            //{
            //    Console.WriteLine("task執行超時---------");
            //    cts.Cancel();
            //}
            //task.Wait(); // 會阻塞主線程
            Console.WriteLine("task执行结束");//-----3
            //cwt.Wait();  // 阻塞当前线程，直到回调执行完毕
            Console.WriteLine("task回调执行结束");//-------5
            Console.WriteLine("主线程执行其他处理3");
        }
    }
}

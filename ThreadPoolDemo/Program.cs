using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task和ThreadPool是一样的，都是从线程池中取空闲的线程
            //用ThreadPool开启一个线程之后，线程执行完毕，会加入到线程池中，后续需要再次开启线程的时候查看线程池中有没有空闲的线程，有则调用，没有则创建，如此循环
            //for (int i = 0; i < 100; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(new WaitCallback(obj =>
            //    {
            //        Console.WriteLine("hello");
            //    })); 
            //}
            //每一个主线程表示id都是不同的，也就是说使用Thread开启线程每次都是新创建一个
            //for (int i = 0; i < 100; i++)
            //{
            //    new Thread(new ThreadStart(() => { Console.WriteLine("hello"); })).Start();  
            //}
            //---------------------------------------------------------------------------

            //ThreadPool可以操控线程的状态，比如等待线程完成，或者终止超时子线程操作
            //CancellationTokenSource cts = new CancellationTokenSource();
            //ThreadPool.QueueUserWorkItem(new WaitCallback(CanCancelMethod), cts.Token);
            //cts.Cancel();
            //Console.WriteLine("线程开始");
            //Console.ReadKey();
            //----------------------------------------------------------------------------
            ZhiXingParallel();
            Console.ReadKey();
        }
        static void CanCancelMethod(Object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            if (ct.IsCancellationRequested)
            {
                Console.WriteLine("该线程已取消");
            }
            else
            {
                Console.WriteLine("该线程wei取消");
            }
            //就算ct.IsCancellationRequested为真，接下来的代码还是会执行
            //因为该方法并没有ruturn
            Thread.Sleep(1000);
            Console.WriteLine($"子线程{Thread.CurrentThread.ManagedThreadId}结束");
        }

        //Parallel
        static void ZhiXingParallel()
        {
            //---------------------------------------------------------------------------------------------------
            ////将迭代的结果保存起来
            //ParallelLoopResult plr = Parallel.For(1, 10, (i) =>
            //{
            //    Console.WriteLine($"线程：{Thread.CurrentThread.ManagedThreadId}");
            //});
            //Console.WriteLine(plr.IsCompleted);
            //相当于
            //for (int i = 1; i < 10; i++)
            //{
            //    Task.Run(() =>
            //    {
            //        Console.WriteLine($"线程：{Thread.CurrentThread.ManagedThreadId}");
            //    });
            //}
            //---------------------------------------------------------------------------------------------------
            //方法和foreach类似，不过是采用的是异步方式遍历，要想被Parallel.ForEach()必须实现IEnumerable接口
            Parallel.ForEach<String>(new List<String>() { "a", "b", "c", "d", "e", "f", "g", "h", "i" }, (str) =>
            {
                Console.WriteLine(str);
            });
            //---------------------------------------------------------------------------------------------------
        }
    }
}

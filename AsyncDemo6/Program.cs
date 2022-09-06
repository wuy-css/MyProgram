using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo6
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.GetMaxThreads(out int abc, out int dcd);
            Console.WriteLine("ThreadPool.workerThreads:" + abc);
            Console.WriteLine("ThreadPool.completionPortThreads:" + dcd);
            TestTaskResult.Test();
            Console.ReadLine();
        }
    }
    /// <summary>
    /// 测试 用await和.Result有啥不同
    /// </summary>
    public class TestTaskResult
    {
        public static void Test()
        {
            Console.WriteLine("开始");
            test1();
            Console.WriteLine($"第一个任务结束了{Environment.NewLine}");

            test2();
            Console.WriteLine($"第二个任务结束了{Environment.NewLine}");

            test3Async();
            Console.WriteLine($"第三个任务结束了{Environment.NewLine}");
        }

        public static void test1()
        {
            Console.WriteLine("第一个任务开始了");
            Task.Run(() =>
            {
                Console.WriteLine(1111);
                Thread.Sleep(5000);

            }).GetAwaiter().GetResult(); //GetAwaiter().GetResult() 会阻塞调用线程
            Console.WriteLine("第一个任务快完了");
            Thread.Sleep(2000);
        }

        public static void test2()
        {
            var a = test2Async().Result;  //Result会阻塞调用线程
            Console.WriteLine("第二个任务快完了");
            Thread.Sleep(2000);
        }
        public static async Task<bool> test2Async()
        {
            Console.WriteLine("第二个任务开始了");
            await Task.Delay(5000);
            Console.WriteLine(2222);
            return true;
        }


        public static async Task test3Async()
        {
            Console.WriteLine("第三个任务开始了");
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine(3333);
            });   //await不会阻塞调用它的线程
            Console.WriteLine("第三个任务快完了");
            Thread.Sleep(2000);
        }


    }
}

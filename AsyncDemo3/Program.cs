using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo3
{
    class Program
    {
        public static void Main()
        {
            //test();
            //Runs();
            var ret1 = AsyncGetsum();
            Console.WriteLine("主线程执行其他处理");
            var ret2 = AsyncGetsum2();
            Console.WriteLine("任务AsyncGetsum2执行结果：{0}", ret2.Result);
            for (int i = 1; i <= 3; i++)
                Console.WriteLine("Call Main()");
            int result = ret1.Result;     //阻塞主线程
            Console.WriteLine("任务AsyncGetsum执行结果：{0}", result);
            Console.ReadKey();
        }

        public static void test()
        {
            //创建一个任务
            Task<int> task = new Task<int>(() =>
            {
                Thread.Sleep(5000);
                int sum = 0;
                Console.WriteLine("使用`Task`执行异步112操作.");
                for (int i = 0; i < 100; i++)
                {
                    sum += i;
                }
                Console.WriteLine("使用`Task`执行异步112操作.");
                return sum;
            });
            //启动任务,并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
            task.Start();
            Console.WriteLine("1221212121.");
           // Console.WriteLine("使用`Task`执行异步1121操作." + task.Result);
            List<Task> tasks = new List<Task>
            {
                Task.Run(() => log("张三",3000)),
                Task.Run(() => log("李四",1000)),
                Task.Run(() => log("王五",2000))
            };
            //Task.WaitAny(tasks.ToArray());
            //Task.WaitAll(tasks.ToArray());
            //Task.WhenAny(tasks.ToArray()).ContinueWith(x => Console.WriteLine("某个Task执行完毕"));
            //Task.WhenAll(tasks.ToArray()).ContinueWith(x => Console.WriteLine("所有Task执行完毕"));
            //Task.Factory.ContinueWhenAny(tasks.ToArray(), x => Console.WriteLine("某个Task执行完毕"));
            //Task.Factory.ContinueWhenAll(tasks.ToArray(), x => Console.WriteLine("所有Task执行完毕"));
        }
        private static void log(string v1, int v2)
        {
            Console.WriteLine(v1 + v2);
        }

        async static Task<int> AsyncGetsum()
        {
            await Task.Delay(10000);
            int sum = 0;
            Console.WriteLine("使用`Task`执行AsyncGetsum异步操作1." + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 100; i++)
            {
                sum += i;
            }
            //Thread.Sleep(5000);
            Console.WriteLine("使用`Task`执行AsyncGetsum异步操作2." + Thread.CurrentThread.ManagedThreadId);
            return sum;
        }
        static Task<int> AsyncGetsum2()
        {
            //await Task.Delay(1);
            int sum = 0;
            Console.WriteLine("使用`AsyncGetsum2Task`执行异步操作." + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 100; i++)
            {
                sum += i;
            }
            //Thread.Sleep(5000);
            return Task.FromResult(sum);
        }
        public static async Task Runs()
        {
            await Task.Run(() =>
            {
                // Just loop.
                int ctr = 0;
                for (ctr = 0; ctr <= 9000; ctr++)
                {
                    Thread.Sleep(1);
                }
                Console.WriteLine("Finished {0} loop iterations", ctr);
            });
        }
        static async Task Normal()
        {
            await Fun();
        }
        static Task Fun()
        {
            return Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("i={0}", i);
                    Thread.Sleep(200);
                }
            });
        }
    }
}





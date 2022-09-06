using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    #region 方式一：NEW实例化一个Task，通过Start方法启动
        //    Task task = new Task(() =>
        //    {
        //        Thread.Sleep(100);
        //        Console.WriteLine($"NEW实例化一个task，线程ID为{Thread.CurrentThread.ManagedThreadId}");
        //    });
        //    task.Start();
        //    #endregion

        //    #region 方式二：Task.Factory.StartNew(Action action)创建和启动一个Task           
        //    Task task2 = Task.Factory.StartNew(() =>
        //    {
        //        Thread.Sleep(100);
        //        Console.WriteLine($"Task.Factory.StartNew方式创建一个task，线程ID为{ Thread.CurrentThread.ManagedThreadId}");
        //    });
        //    #endregion

        //    #region 方式三：Task.Run(Action action)将任务放在线程池队列，返回并启动一个Task
        //    Task task3 = Task.Run(() =>
        //    {
        //        Thread.Sleep(100);
        //        Console.WriteLine($"Task.Run方式创建一个task，线程ID为{ Thread.CurrentThread.ManagedThreadId}");
        //    });
        //    #endregion
        //    Console.WriteLine("执行主线程！");
        //    Console.ReadKey();
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("主线程执行开始！,线程id=" + Thread.CurrentThread.ManagedThreadId);
            //Task提供了 Wait/WaitAny/WaitAll 方法，可以更方便地控制线程阻塞。
            Task task1 = new Task(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("线程1执行完毕！,线程id=" + Thread.CurrentThread.ManagedThreadId);
            });
            task1.Start();
            Task task2 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("线程2执行完毕！,线程id=" + Thread.CurrentThread.ManagedThreadId);
            });
            task2.Start();
            //阻塞主线程。task1,task2都执行完毕再执行主线程
            //执行【task1.Wait();task2.Wait();】可以实现相同功能
            Task.WaitAll(new Task[] { });
            Console.WriteLine("主线程执行完毕！,线程id=" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        //static void Main(string[] args)
        //{
        //    //我们看到WhenAll/WhenAny方法不会阻塞主线程，当使用WhenAll方法时所有的task都执行完毕才会执行后续操作；
        //    Task task1 = new Task(() =>
        //    {
        //        Thread.Sleep(500);
        //        Console.WriteLine("线程1执行完毕！");
        //    });
        //    task1.Start();
        //    Task task2 = new Task(() =>
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("线程2执行完毕！");
        //    });
        //    task2.Start();
        //    //task1，task2执行完了后执行后续操作
        //    Task.WhenAll(task1, task2).ContinueWith((t) =>
        //    {
        //        Thread.Sleep(100);
        //        Console.WriteLine("执行后续操作完毕！");
        //    });

        //    Console.WriteLine("主线程执行完毕！");
        //    Console.ReadKey();
        //}
        //static void Main(string[] args)
        //{
        //    var path = Environment.CurrentDirectory + @"/test.txt";
        //    Console.WriteLine($"主程序执行开始：{DateTime.Now}");
        //    if (!File.Exists(path))
        //    {
        //        File.WriteAllText(path, "Can I See you?");
        //    }
        //    string content = GetContentAsync(path).Result;
        //    Console.WriteLine($"主程序执行结束：{DateTime.Now}" + content);
        //    Console.ReadKey();
        //}
        //static void Main()
        //{
        //    TaskCompletionSource<List<int>> task = new TaskCompletionSource<List<int>>();
        //    Task<List<int>> myTask = task.Task;       // task 控制 myTask
        //    // 新开一个任务做实验
        //    Task mainTask = new Task(() =>
        //    {
        //        Console.WriteLine("我可以控制 myTask 任务");
        //        Console.WriteLine("按下任意键，我让 myTask 任务立即完成");
        //        //Console.ReadKey();
        //        task.TrySetResult(new List<int> { 1, 2, 3 });
        //    });
        //    mainTask.Start();

        //    Console.WriteLine("开始等待 myTask 返回结果");
        //    Console.WriteLine(myTask.Result[2]);
        //    Console.WriteLine("结束");
        //    Console.ReadKey();
        //}
        //同步读取文件内容
        static string GetContent(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            var bytes = new byte[fs.Length];
            //Read方法同步读取内容，阻塞线程
            int len = fs.Read(bytes, 0, bytes.Length);
            string result = Encoding.UTF8.GetString(bytes);
            return result;
        }
        //异步读取文件内容
        //void:如果调用方法仅仅只是调用一下异步方法，不和异步方法做其他交互，我们可以设置异步方法签名的返回值为void，这种形式也叫做“调用并忘记”。
        async static void GetLenAsync(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            var bytes = new byte[fs.Length];
            //ReadAync方法异步读取内容，不阻塞线程
            Console.WriteLine($"开始读取文件{DateTime.Now}");
            int len = await fs.ReadAsync(bytes, 0, bytes.Length);
            Console.WriteLine($"完成文件读取：{DateTime.Now}");
        }
        //异步读取文件内容
        //Task:如果调用方法不想通过异步方法获取一个值，仅仅想追踪异步方法的执行状态，那么我们可以设置异步方法签名的返回值为Task;
        static async Task<string> GetContentAsync(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            var bytes = new byte[fs.Length];
            //ReadAync方法异步读取内容，不阻塞线程
            Console.WriteLine($"开始读取文件{DateTime.Now}");
            int len = await fs.ReadAsync(bytes, 0, bytes.Length);
            Console.WriteLine($"完成文件读取：{DateTime.Now}");
            string result = Encoding.UTF8.GetString(bytes);
            var a = Encoding.UTF8.GetHashCode();
            return result;
        }
        //https://www.cnblogs.com/qtiger/p/13497807.html#autoid-2-1-0
    }
}

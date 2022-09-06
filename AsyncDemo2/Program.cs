using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("111 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            Task task = AsyncMethod();

            task.ContinueWith((t) =>
            {
                Thread.Sleep(100);
                Console.WriteLine("执行后续操作完毕！");
            });
            Console.WriteLine("222 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        private static async Task AsyncMethod()
        {
            var ResultFromTimeConsumingMethod = TimeConsumingMethod();
            string Result = await ResultFromTimeConsumingMethod + " + AsyncMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(Result);
            //返回值是`Task`的函数可以不用`return`，或者将`Task`改为void
        }

        //这个函数就是一个耗时函数，可能是`IO`操作，也可能是`cpu`密集型工作。
        private static Task<string> TimeConsumingMethod()
        {
            var task = Task.Run(() =>
            {
                Console.WriteLine("Helo I am TimeConsumingMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
                Console.WriteLine("Helo I am TimeConsumingMethod after Sleep(5000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                return "Hello I am TimeConsumingMethod";
            });
            return task;
        }

        // async/await 结构可分成三部分：

        //（1）调用方法：该方法调用异步方法，然后在异步方法执行其任务的时候继续执行；

        //（2）异步方法：该方法异步执行工作，然后立刻返回到调用方法；

        //（3）await 表达式：用于异步方法内部，指出需要异步执行的任务。一个异步方法可以包含多个 await 表达式（不存在 await 表达式的话 IDE 会发出警告）。
    }
}

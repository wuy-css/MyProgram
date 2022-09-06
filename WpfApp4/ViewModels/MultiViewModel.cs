using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp4.ViewModels
{
    public class MultiViewModel : Screen
    {
        private async Task<string> AsyncMethod()
        {
            var ResultFromTimeConsumingMethod = TimeConsumingMethod();
            string Result = await ResultFromTimeConsumingMethod + " + AsyncMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(Result);
            return Result;
            //返回值是Task的函数可以不用return
        }
        //这个函数就是一个耗时函数，可能是IO操作，也可能是cpu密集型工作。
        private Task<string> TimeConsumingMethod()
        {
            var task = Task.Run(() =>
            {
                Console.WriteLine("B :" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
                Console.WriteLine("D after Sleep(5000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                return "E";
            });
            return task;
        }
        protected override void OnActivate()
        {
            //Console.WriteLine("A balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            //var ResultTask = AsyncMethod();
            //Console.WriteLine(ResultTask.Result);
            //Console.WriteLine("C balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
        }

        
        public async void abc()
        {
            Console.WriteLine("A balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            var ResultTask = AsyncMethod();
            Console.WriteLine(await ResultTask);
            Console.WriteLine("C balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
        }
        //https://www.cnblogs.com/zhaoshujie/p/11192036.html
        //返回结果
        //111 balabala.My Thread ID is :1
        //Helo I am TimeConsumingMethod.My Thread ID is :3
        //222 balabala.My Thread ID is :1
        //Helo I am TimeConsumingMethod after Sleep(5000). My Thread ID is :3
        //Hello I am TimeConsumingMethod + AsyncMethod.My Thread ID is :1
    }
}

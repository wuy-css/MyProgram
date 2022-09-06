using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BackgroundTest shortTest = new BackgroundTest(10);
            Thread foregroundThread =
                new Thread(new ThreadStart(shortTest.RunLoop));
            foregroundThread.Name = "ForegroundThread";

            BackgroundTest longTest = new BackgroundTest(50);
            Thread backgroundThread =
                new Thread(new ThreadStart(longTest.RunLoop));
            backgroundThread.Name = "BackgroundThread";
            backgroundThread.IsBackground = true;

            foregroundThread.Start();
            backgroundThread.Start();
            //Console.ReadLine();
        }
    }
    class BackgroundTest
    {
        int maxIterations;

        public BackgroundTest(int maxIterations)
        {
            this.maxIterations = maxIterations;
        }

        public void RunLoop()
        {
            String threadName = Thread.CurrentThread.Name;

            for (int i = 0; i < maxIterations; i++)
            {
                Console.WriteLine("{0} count: {1}", threadName, i.ToString());
                Thread.Sleep(1000);
            }
            Console.WriteLine("{0} finished counting.", threadName);
        }
    }
}

using System;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace SubStrDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder astr = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
                               //  需要测试的代码 ....
            for (int i = 0; i < 15000; i++)
            {
                string str = "trttttrrttttb";

                int a = str.IndexOf("b");

                string s = str.Substring(a);
                //astr.Append(s);
            }
            //string a2 = astr.ToString();
            stopwatch.Stop(); //  停止监视
            //TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            //double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
            ComparisonString();
        }

        public static void ComparisonString()
        {

            string val = "";
            if (string.IsNullOrEmpty(val))
            {
                Console.WriteLine("IsNullOrEmpty:" + true);
            }
            else
            {
                Console.WriteLine("IsNullOrEmpty:" + false);
            }
            if (string.IsNullOrWhiteSpace(val))
            {
                Console.WriteLine("IsNullOrWhiteSpace:" + true);
            }
            else
            {
                Console.WriteLine("IsNullOrWhiteSpace:" + false);
            }
        }

        public static void CompareIf(int a)
        {
            if (1 == a)
            {
                //
            }
            if (a == 1)
            {
                //
            }
            //if (a = 1)
            //{
            //    //无法验证结果
            //}
        }

    }
}

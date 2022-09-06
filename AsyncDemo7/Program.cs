using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace AsyncDemo7
{
    class Program
    {
        static void Main(string[] args)
        {
            new MyClass();
        }
    }
    public class MyClass
    {
        public MyClass()
        {
            GetToday();
            //Test();
            //DisplayValue(); //这里不会阻塞
            //System.Diagnostics.Debug.WriteLine("MyClass() End.");
            //System.Diagnostics.Debug.Print("MyCla11111111111111111ss() End.");
            Console.ReadKey();
        }
        public Task<double> GetValueAsync(double num1, double num2)
        {


            return Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    num1 = num1 / num2;
                }
                return num1;
            });
        }
        public async void DisplayValue()
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            double result = await GetValueAsync(1234.5, 1.01);//此处会开新线程处理GetValueAsync任务，然后方法马上返回
                                                              //这之后的所有代码都会被封装成委托，在GetValueAsync任务完成时调用
            Console.WriteLine("Value is : " + result);
            st.Stop();
            Console.WriteLine("Stopwatch is : " + st.ElapsedMilliseconds);
        }

        public async static Task Test()
        {
            //https://www.cnblogs.com/fanfan-90/p/12660996.html
            CancellationTokenSource cts1 = new CancellationTokenSource();
            CancellationTokenSource cts2 = new CancellationTokenSource();
            var cts3 = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);

            cts1.Token.Register(() =>
            {
                Console.WriteLine("cts1 Canceling");
            });
            cts2.Token.Register(() =>
            {
                Console.WriteLine("cts2 Canceling");
                //if (cts2.Token.IsCancellationRequested)
                //{
                //    try
                //    {
                //        cts2.Token.ThrowIfCancellationRequested();
                //    }
                //    catch (Exception)
                //    {
                //        Console.WriteLine("cts2 已经取消");
                //    }

                //}
            });
            cts2.CancelAfter(1000);

            cts3.Token.Register(() =>
            {
                Console.WriteLine("root Canceling");
            });

            var res = await new HttpClient().GetAsync("http://www.weather.com.cn/data/sk/101110101.html", cts1.Token);
            var result = await res.Content.ReadAsStringAsync();
            Console.WriteLine("cts1:{0}", result);

            var res2 = await new HttpClient().GetAsync("http://www.weather.com.cn/data/sk/101110101.html", cts2.Token);
            var result2 = await res2.Content.ReadAsStringAsync();
            Console.WriteLine("cts2:{0}", result2);
            Thread.Sleep(10000);
            var res3 = await new HttpClient().GetAsync("http://www.weather.com.cn/data/sk/101110101.html", cts3.Token);
            var result3 = await res3.Content.ReadAsStringAsync();
            Console.WriteLine("cts3:{0}", result3);
        }

        public async static Task GetToday()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(3000);
            HttpClient client = new HttpClient();
            var res = await client.GetAsync("http://www.weather.com.cn/data/sk/101110101.html", cts.Token);
            var result = await res.Content.ReadAsStringAsync();
            Console.WriteLine(result);

            cts.Dispose();
            client.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Models
{
    class MyboxClass
    {
        delegate int culator(int x, int y); //委托类型
        delegate bool MyBol(int x, int y);
        delegate bool MyBol_2(int x, string y);
        delegate int calculator(int x, int y); //委托类型
        delegate void VS();
        public static void Mybox()
        {
            culator cal = new culator(Adding);
            int He = cal(1, 1);
            Console.Write(He);
            ///////////////////////8888888/////////////////////////
            MyBol Bol = (x, y) => x == y;
            Console.WriteLine(Bol(1, 2));
            MyBol_2 Bol_2 = (x, s) => s.Length > x;
            calculator C = (X, Y) => X * Y;

            VS S = () => Console.Write("我是无参数Labada表达式");
            //
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddNumbers = numbers.Count(n => n % 2 == 1);
            //
            List<People> people = LoadData();//初始化
            IEnumerable<People> results = people.Where(delegate (People p)
            {
                return p.age > 200;
            });
            var b = results;
            Func<int, string> bb = (a) => a + 9.ToString();

            ///////////////////////8888888/////////////////////////
            Func<int, int, bool> gwl = (p, j) => p + j == 9;
            //{
            //    //if (p + j == 10)
            //    //{
            //    //    return true;
            //    //}
            //    //return false;
            //    return p + j;
            //};
            Console.WriteLine(gwl(5, 4) + "");   //打印‘True’，z对应参数b，p对应参数a
            ///////////////////////8888888/////////////////////////
            List<string> Citys = new List<string>()
            {
               "BeiJing",
               "ShangHai",
               "Tianjin",
               "GuangDong"
            };
            var result = Citys.First((c) => c.Length > 7);
            ///////////////////////8888888/////////////////////////
            LambdaFun("BeiJing 2013", s =>
            {
                if (s.Contains("2013"))
                {
                    s = s.Replace("2013", "2014");
                }
                return s;
            });
            LambdaFun("22222", delegate (string s)
            {
                if (s.Contains("2013"))
                {
                    s = s.Replace("2013", "2014");
                }
                return s;
            });

            ///////////////////////8888888/////////////////////////
            Func<int, string> gwl1 = p => p + 10 + "--返回类型为string";
            Console.WriteLine(gwl1(10) + "");   //打印‘20--返回类型为string’，z对应参数b，p对应参数a
            ///////////////////////8888888/////////////////////////
            var arr = new string[] { "3", "4" };
            var list = new List<string>(arr) { "1", "2" };
            /////////////////////////888888///////////////////////////
        }

        private static int Adding(int x, int y)
        {
            return x + y;
        }
        public static void LambdaFun(string str, Func<string, string> func)
        {
            Console.WriteLine(func(str));
        }
        private static List<People> LoadData()
        {
            List<People> people = new List<People>();   //创建泛型对象  
            People p1 = new People { age = 11, name = "hahhaa" };       //创建一个对象 ;
            People p2 = new People(21, "wujunmin");     //创建一个对象  
            People p3 = new People(20, "muqing");       //创建一个对象  
            People p4 = new People(23, "lupan");        //创建一个对象  
            people.Add(p1);                     //添加一个对象  
            people.Add(p2);                     //添加一个对象  
            people.Add(p3);                     //添加一个对象  
            people.Add(p4);
            return people;
        }

    }

    public class People
    {
        public People()
        {

        }
        public int age { get; set; }                //设置属性  
        public string name { get; set; }            //设置属性  
        public People(int age, string name)      //设置属性(构造函数构造)  
        {
            this.age = age;                 //初始化属性值age  
            this.name = name;               //初始化属性值name  
        }
    }
}


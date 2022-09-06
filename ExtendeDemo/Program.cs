using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendeDemo
{
    //扩展方法
    public static class ExtentionMethods
    {
        public static bool IsEven(this int num)
        {
            return num % 2 == 0;
        }
        public static string GetNotNullStr(this string strRes)
        {
            if (strRes == null)
                return string.Empty;
            else
                return strRes;
        }
    }
    //https://www.cnblogs.com/mq0036/p/7418830.html
    //它必须在一个非嵌套、非泛型的静态类中
    //扩展方法一定是静态方法
    //它至少要有一个参数
    //第一个参数必须加上this关键字作为前缀，且第一个参数类型也称为扩展类型（extended type），表示该方法对这个类型进行扩展
    //第一个参数不能用其他任何修饰符（比如out或ref）
    //第一个参数的类型不能是指针类型
    //扩展方法的类最好和调用扩展方法的类在同一个命名空间下。
    //或使用using引用。(如：using TestWeb.Common;)
    class Program
    {
        static void Main(string[] args)
        {
            int num = 10;
            //直接调用扩展方法
            Console.WriteLine("Is {0} a even number? {1}", num, num.IsEven());
            num = 11;
            //直接调用扩展方法
            Console.WriteLine("Is {0} a even number? {1}", num, num.IsEven());
            //通过静态类调用静态方法
            Console.WriteLine("Is {0} a even number? {1}", num, ExtentionMethods.IsEven(num));
            //public static string GetNotNullStr(this string strRes)其中this string就表示给string对象添加扩展方法。
            //那么在同一个命名空间下面定义的所有的string类型的变量都可以.GetNotNullStr()这样直接调用。
            //strTest.GetNotNullStr();为什么这样调用不用传参数，是因为strTest就是作为参数传入到方法里面的。
            //使用起来就和.Net framework定义的方法一样
            string strTest = null;
            var strRes = strTest.GetNotNullStr();
            Console.Read();
        }
    }
}

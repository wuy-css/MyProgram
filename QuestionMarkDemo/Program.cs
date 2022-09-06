using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionMarkDemo
{
    //问号使用方式
    class Program
    {
        static void Main(string[] args)
        {
            //?单问号的两种用法
            //1、定义数据类型为空。可用于对int,double,bool等无法直接赋值为null的数据类型进行null的赋值
            int i; //默认值0   
            int? ii; //默认值null   在使用上有些区别，如果方法的参数中是该类型，可以不传参。

            //2、用户判断对象是否为空。如果对象为空，则无论该对象调用什么皆不会抛出异常，直接返回null（C#6.0）
            Person p = null;
            string s = p?.SayHi();//判断对象为null值时，不会去调用实例方法。
            Console.WriteLine(s);

            //??双问号的用法 
            //可用于判断一个变量在为null时返回一个指定的值
            Person p1 = null;
            Person p2 = new Person("lishi");
            Person p3 = p1 ?? p2;
            string ss = p3.SayHi();

            byte abc = Convert.ToByte(25.5);
            Console.WriteLine(ss);

        //abc:
        //    Console.WriteLine(123455);
        //    goto abc;

            Console.ReadKey();
        }
    }
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public string SayHi()
        {
            return $"My name is {this.Name}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedDemo
{
    //嵌套类的使用
    public class Program
    {
        public static void Main(string[] args)
        {
            // create instance of outside class --创建外部类的实例
            Outside_class outinstance = new Outside_class();
            outinstance.outerclassmethod();
            // you can't access inside class methods from outside class objects --不能从类对象外部访问类内方法
            // create instance of inside class --创建类内部的实例
            Outside_class.Inside_class insideinstance = new Outside_class.Inside_class();
            // accessing the method of inside class. --访问类内的方法
            insideinstance.insideclassmethod();
            Console.Read();
        }
    }
    //在 C# 中使用嵌套类的原因
    //使用嵌套类有几个强有力的理由。
    //这是一种只使用一次的分组类的实用技术。
    //改进了封装。
    //嵌套类可以使代码更易于阅读和维护。
    //它有助于逻辑类分组。
    //如果一个类仅对另一个类有价值，则将其包含在该类中以将两者保持在一起是有意义的。通过嵌套这样的辅助类可以更加简化。
    //除了公共和内部访问修饰符，嵌套类还可以包含私有和受保护的内部访问修饰符。
    //很明显，嵌套类使我们的代码易于阅读。我们可以将所有这些相互使用的类放在一起
    public class Outside_class
    {
        // Method of outside class --类外方法
        public void outerclassmethod()
        {
            Console.WriteLine("here is Outside class method");
        }
        // Inner class --内部类
        public class Inside_class
        {
            // Method of inside class --类内方法
            public void insideclassmethod()
            {
                Console.WriteLine("here is Inside class Method");
            }
        }
    }
}

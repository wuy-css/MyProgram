using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismDemo
{
    //多态性可以是静态的或动态的。
    //在静态多态性中，函数的响应是在编译时发生的。
    //在动态多态性中，函数的响应是在运行时发生的。
    //在 C# 中，每个类型都是多态的，因为包括用户定义类型在内的所有类型都继承自 Object。
    //多态就是同一个接口，使用不同的实例而执行不同操作
    class Program
    {
        static void Main(string[] args)
        {
            //在编译时，函数和对象的连接机制被称为早期绑定，也被称为静态绑定。C# 提供了两种技术来实现静态多态性。分别为：函数重载和运算符重载
            //通过关键字 operator 后跟运算符的符号来定义的。与其他函数一样，重载运算符有返回类型和参数列表。
            //静态关于运算符重载
            //运算符重载的实现
            Box Box1 = new Box();         // 声明 Box1，类型为 Box
            Box Box2 = new Box();         // 声明 Box2，类型为 Box
            Box Box3 = new Box();         // 声明 Box3，类型为 Box
            double volume = 0.0;          // 体积

            // Box1 详述
            Box1.setLength(6.0);
            Box1.setBreadth(7.0);
            Box1.setHeight(5.0);

            // Box2 详述
            Box2.setLength(12.0);
            Box2.setBreadth(13.0);
            Box2.setHeight(10.0);

            // Box1 的体积
            volume = Box1.getVolume();
            Console.WriteLine("Box1 的体积： {0}", volume);

            // Box2 的体积
            volume = Box2.getVolume();
            Console.WriteLine("Box2 的体积： {0}", volume);

            // 把两个对象相加
            Box3 = Box1 + Box2;

            // Box3 的体积
            volume = Box3.getVolume();
            Console.WriteLine("Box3 的体积： {0}", volume);
            Console.ReadKey();
        }
    }
    #region 静态多态性
    //一、函数重载
    //您可以在同一个范围内对相同的函数名有多个定义。函数的定义必须彼此不同，可以是参数列表中的参数类型不同，也可以是参数个数不同。不能重载只有返回类型不同的函数声明。

    public class TestData
    {
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }
        public string Add(int a, string b)
        {
            return a + b;
        }
        public void print(int i)
        {
            Console.WriteLine("输出整型: {0}", i);
        }

        public void print(double f)
        {
            Console.WriteLine("输出浮点型: {0}", f);
        }

        public void print(string s)
        {
            Console.WriteLine("输出字符串: {0}", s);
        }
    }
    //二、运算符重载
    //通过关键字 operator 后跟运算符的符号来定义的。与其他函数一样，重载运算符有返回类型和参数列表。
    public class Box
    {
        private double length;      // 长度
        private double breadth;     // 宽度
        private double height;      // 高度

        public double getVolume()
        {
            return length * breadth * height;
        }
        public void setLength(double len)
        {
            length = len;
        }

        public void setBreadth(double bre)
        {
            breadth = bre;
        }

        public void setHeight(double hei)
        {
            height = hei;
        }
        // 重载 + 运算符来把两个 Box 对象相加
        public static Box operator +(Box b, Box c)
        {
            Box box = new Box();
            box.length = b.length + c.length;
            box.breadth = b.breadth + c.breadth;
            box.height = b.height + c.height;
            return box;
        }

    }
    #endregion
    #region 动态多态性
    //C# 允许您使用关键字 abstract 创建抽象类，用于提供接口的部分类的实现。
    //当一个派生类继承自该抽象类时，实现即完成。
    //抽象类包含抽象方法，抽象方法可被派生类实现。派生类具有更专业的功能。

    //请注意，下面是有关抽象类的一些规则：
    //您不能创建一个抽象类的实例。
    //您不能在一个抽象类外部声明一个抽象方法。
    //通过在类定义前面放置关键字 sealed，可以将类声明为密封类。当一个类被声明为 sealed 时，它不能被继承。抽象类不能被声明为 sealed。
    abstract class Shape
    {
        abstract public int area();
    }
    class Rectangle : Shape
    {
        private int length;
        private int width;
        public Rectangle(int a = 0, int b = 0)
        {
            length = a;
            width = b;
        }
        public override int area()
        {
            Console.WriteLine("Rectangle 类的面积：");
            return (width * length);
        }
    }
    //当有一个定义在类中的函数需要在继承类中实现时，可以使用虚方法。
    //虚方法是使用关键字 virtual 声明的。
    //虚方法可以在不同的继承类中有不同的实现。
    //对虚方法的调用是在运行时发生的。
    //动态多态性是通过 抽象类 和 虚方法 实现的。
    public class ShapeA
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        // 虚方法
        public virtual void Draw()
        {
            Console.WriteLine("执行基类的画图任务");
        }
    }
    class CircleA : ShapeA
    {
        public override void Draw()
        {
            Console.WriteLine("画一个圆形");
            base.Draw();
        }
    }
    class RectangleA : ShapeA
    {
        public override void Draw()
        {
            Console.WriteLine("画一个长方形");
            base.Draw();
        }
    }
    #endregion


}

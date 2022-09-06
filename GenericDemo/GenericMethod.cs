//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GenericDemo
//{
//    class GenericMethod
//    {
//        static void Swap<T>(ref T lhs, ref T rhs)
//        {
//            T temp;
//            temp = lhs;
//            lhs = rhs;
//            rhs = temp;
//        }
//        static void Main(string[] args)
//        {
//            int a, b;
//            char c, d;
//            a = 10;
//            b = 20;
//            c = 'I';
//            d = 'V';

//            // 在交换之前显示值
//            Console.WriteLine("Int values before calling swap:");
//            Console.WriteLine("a = {0}, b = {1}", a, b);
//            Console.WriteLine("Char values before calling swap:");
//            Console.WriteLine("c = {0}, d = {1}", c, d);

//            // 调用 swap
//            Swap<int>(ref a, ref b);
//            Swap<char>(ref c, ref d);

//            // 在交换之后显示值
//            Console.WriteLine("Int values after calling swap:");
//            Console.WriteLine("a = {0}, b = {1}", a, b);
//            Console.WriteLine("Char values after calling swap:");
//            Console.WriteLine("c = {0}, d = {1}", c, d);
//            Console.ReadKey();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_ReferenceDemo
{
    public struct A
    {
        public int x { get; set; }
    }

    public class B
    {
        public int x { get; set; }
    }
    class Program
    {
        public static void UpdateStructValue(A a)
        {
            a.x = 10;
        }

        public static void UpdateObjectValue(B b)
        {
            b.x = 10;
        }

        static void Main(string[] args)
        {
            var a = new A { x = 1 };
            var b = new B { x = 1 };

            UpdateStructValue(a);
            UpdateObjectValue(b);

            Console.WriteLine($"a.x -> {a.x}");
            Console.WriteLine($"b.x -> {b.x}");
            Console.ReadKey();
        }
    }
}

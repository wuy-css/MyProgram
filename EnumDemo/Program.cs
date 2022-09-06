using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Enum.GetName(typeof(EnumList), 102);
            Console.WriteLine(name);

            Console.WriteLine("The names of the Day Enum are:");
            foreach (string str in Enum.GetNames(typeof(EnumList)))
                Console.Write(str + " ");
            Console.WriteLine();

            Console.WriteLine("The values of the Day Enum are:");
            foreach (int value in Enum.GetValues(typeof(EnumList)))
                Console.Write(value + " ");
            Console.WriteLine();


            Type type = Enum.GetUnderlyingType(typeof(EnumList));
            Console.WriteLine(type.Name + "  " + type.FullName);

            Enum.TryParse<EnumList>("ABC", out EnumList abc);

            Console.WriteLine("value:" + (int)abc);

            Console.ReadKey();
        }
    }


    public enum EnumList
    {
        ABC = 101,
        CDF = 102,
        RED = 103,
        ATD = 107
    }
}

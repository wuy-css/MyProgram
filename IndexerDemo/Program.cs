using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerDemo
{
    class Demo
    {
        static void Main(string[] args)
        {
            Demo names = new Demo();
            names[0] = "C语言中文网";
            names[1] = "http://c.biancheng.net/";
            names[2] = "C#教程";
            names[3] = "索引器";
            names[5]= "33";
            for (int i = 0; i < Demo.size; i++)
            {
                Console.WriteLine(names[i]);
            }
            Console.ReadKey();
        }
        static public int size = 10;
        private string[] namelist = new string[size];
        public Demo()
        {
            for (int i = 0; i < size; i++)
                namelist[i] = "NULL";
        }
        public string this[int index]
        {
            get
            {
                string tmp;

                if (index >= 0 && index <= size - 1)
                {
                    tmp = namelist[index];
                }
                else
                {
                    tmp = "";
                }

                return (tmp);
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    namelist[index] = value;
                }
            }
        }
    }

}

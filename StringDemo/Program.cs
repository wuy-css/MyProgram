using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDemo
{
    class Program
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {

            //字符串，字符串连接
            string fname, lname;
            fname = "Rowan";
            lname = "Atkinson";

            string fullname = fname + lname;
            Console.WriteLine("Full Name: {0}", fullname);

            //通过使用 string 构造函数
            char[] letters = { 'H', 'e', 'l', 'l', 'o' };
            string greetings = new string(letters);
            Console.WriteLine("Greetings: {0}", greetings);

            //方法返回字符串
            string[] sarray = { "Hello", "From", "Tutorials", "Point" };
            string message = String.Join(" ", sarray);
            Console.WriteLine("Message: {0}", message);

            //用于转化值的格式化方法
            DateTime waiting = new DateTime(2012, 10, 10, 17, 58, 1);
            string chat = String.Format("Message sent at {0:t} on {0:D}",
            waiting);
            Console.WriteLine("Message: {0}", chat);
            student stu = new student();
            student.Id = "2";
            student.names = "3333";
            stu.age = "7";
            student stu2 = new student();
            Console.WriteLine("A: {0}", stu2.age);
            Console.WriteLine("B: {0}", student.names);
            Console.WriteLine("C: {0}", student.Id);

            logger.Trace("trace message");
            logger.Debug("debug message");
            logger.Info("info message");
            logger.Error("error message");
            logger.Fatal("fatal message");
            Console.ReadKey();
        }
    }
    public class student
    {
        public static string names { get; set; }
        public static string Id = string.Empty;
        public string age { get; set; }
    }
}

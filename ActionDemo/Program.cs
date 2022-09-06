using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //循环调用，action不传参
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 10; i++)
            {
                //因为是按地址传递参数，所以要声明变量，不如结果都是10
                int k = i;
                actions.Add(() => Console.WriteLine(k));
            }
            foreach (Action a in actions)
            {
                a();
            }

            //传递两个参数
            Action<string, int> action = new Action<string, int>(ShowAction);
            Show("张三", 29, action);

            //传递一个参数
            Show("张三", o => { Console.WriteLine(o); });

            //不传递参数调用
            Show(() => Console.WriteLine("张三"));

            Console.ReadLine();
        }
        public static void ShowAction(string name, int age)
        {
            Console.WriteLine(name + "的年龄:" + age);
        }
        public static void Show(string name, int age, Action<string, int> action)
        {
            action(name, age);
        }
        public static void Show(string name, Action<string> action)
        {
            action(name);
        }
        public static void Show(Action action)
        {
            action();
        }

    }
}

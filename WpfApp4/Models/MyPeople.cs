using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Models
{
    public class User
    {
        /// <summary>
        /// 自动属性
        /// </summary>
        public string Name { get; set; }
        public string LoginName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string DeptId { get; set; }
        public User()
        {
        }
        //构造函数重载
        public User(string name)
        {
            this.Name = name;
        }
        public User(string name, string loginName)
        {
            this.Name = name;
            this.LoginName = loginName;
        }
        /// <summary>
        /// 默认参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="loginName"></param>
        /// <param name="age"></param>
        /// <param name="address"></param>
        /// <param name="password"></param>
        public User(string name, string loginName, int age, string address = "上海", string password = "1234")
        {
            this.Name = name;
            this.LoginName = loginName;
            this.Age = age;
            this.Address = address;
            this.Password = password;
        }
    }
    public class MyProgram
    {
        /// <summary>
        /// 声明委托
        /// </summary>
        /// <param name="s"></param>
        delegate void Printer(string s);
        public delegate void PrintEmployee(User u);
        public static void GetStr(string str)
        {
            Console.WriteLine(str);
        }
        public static void GetMyProgram()
        {
            //命名方法使用
            Printer _p = new Printer(GetStr);
            _p("33333");

            //匿名方法:必须结合委托使用
            Printer p =  delegate (string s)
            {
                Console.WriteLine(s);
            };
            //使用匿名方法
            p("Hello World");
            Printer p2 = a => { Console.WriteLine(a); };
            p2("Hello");
            List<User> listUser = new List<User>()
            {
                new User(){Name="张三",Password="1234",Age=12,DeptId="0001"},
                new User(){Name="张四",Password="1234",Age=16,DeptId="0002"},
                new User(){Name="张五",Password="1234",Age=29,DeptId="0003"},
                new User(){Name="张六",Password="1234",Age=18,DeptId="0001"},
                new User(){Name="张七",Password="1234",Age=12,DeptId="0001"}
            };


            //匿名方法只使用一次
            ChangeUserPwd(listUser, delegate (User u)
            {
                Console.WriteLine(u.Name + "的新密码是:" + u.Password);
            });
            //使用Lambda表达式
            ChangeUserPwd(listUser, a =>
            {
                Console.WriteLine(a.Name + "的新密码是:" + a.Password);
            });
            // Func<int, int, bool> gwl = (p, j) => p + j == 9;
        }

        //无参数
        Action action1 = () => Console.WriteLine("action");
        //有参数的话调用Action<T>
        Action<int> action2 = (i) => Console.WriteLine(i);
        //多个参数就在生命的时候<T,T,T>
        Action<int, string> action3 = (i, str) => Console.WriteLine(i + "\t" + str);
        //调用
        //action1();
        //action2(10);
        //action3(10,"s");

        //Func是没有Func类型的，只有Func<T>类型
        Func<string> func1 = () => "func";
        //如果需要参数 Func<T,T,T>  
        //最后一个T类型为返回值类型，前面的全都为参数的类型!!!
        Func<string, int> func2 = (i) => int.Parse(i);
        //如果有多个参数     最后一个T类型为返回值类型，前面的全都为参数的类型!!!
        Func<int, string, int> func3 = (i, str) => int.Parse(i + str);

        //调用
        //Console.WriteLine(func1());
        //Console.WriteLine(func2("123"));
        //Console.WriteLine(func3(1,"23"));



        /// <summary>
        /// 批量修改用户的密码并输出修改以后的密码
        /// </summary>
        /// <param name="list"></param>
        /// <param name="callback"></param>
        public static void ChangeUserPwd(List<User> list, PrintEmployee callback1)
        {
            int i = 0;
            foreach (User u in list)
            {
                u.Password = u.Password + i.ToString();
                i += 2;
                callback1(u);
            }
        }
    }
}

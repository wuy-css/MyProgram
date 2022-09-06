//#define DEBUG
//#define Do
//#define PI
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    class Program
    {
        //用于把一段代码标记为有给定名称的一个块
        #region Member Field Declarations
        int x;
        double d;
        #endregion

        static void function1()
        {
            Myclass.Message("In Function 1.");
        }
        static void Main(string[] args)
        {

            //这个预定义特性标记了一个条件方法，其执行依赖于指定的预处理标识符。
            //Conditional 特性允许我们包括或排斥特定方法的所有调用。为方法声明应用 Conditional 特性并把编译符作为参数来使用。
            //Myclass.SayHello();
            //Myclass.Message("In Main function.");
            #if (PI) //它用于测试符号是否为真
                                    Console.WriteLine("PI is defined");
            #else  //它用于创建复合条件指令。
                        Console.WriteLine("PI is not defined");
            #endif //指定一个条件指令的结束。
            //function1();
            //#warning 和 #error：
            //当编译器遇到它们时，会分别产生警告或错误。
            //如果编译器遇到#warning 指令，会给用户显示 #warning 指令后面的文本，之后编译继续进行。
            //如果编译器遇到 #error 指令，就会给用户显示后面的文本，作为一条编译错误消息，然后会立即退出编译。
            //使用这两条指令可以检查 #define 语句是不是做错了什么事，使用 #warning 语句可以提醒自己执行某个操作。
            //#if DEBUG
            //#error "You've defined DEBUG and RELEASE simultaneously!"  
            //#endif
            //#warning "Don't forget to remove this line before the boss tests the code!"  
            //Console.WriteLine("*I hate this job.*");
            Console.ReadKey();
        }
    }

    public class Myclass
    {
        [Conditional("DEBUG")]
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }
        [Conditional("Do")]
        public static void SayHello()
        {
            Console.WriteLine("hello");
        }
        [Obsolete("Don't use OldMethod, use NewMethod instead", true)]
        public static void OldMethod()
        {
            Console.WriteLine("It is the old method");
        }
    }
 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    //通常接口命令以 I 字母开头
    interface IParentInterface
    {
        void ParentInterfaceMethod();
    }

    interface IMyInterface 
    {
        void MethodToImplement();
    }
    class Program : IMyInterface, IParentInterface
    {
        //接口定义了所有类继承接口时应遵循的语法合同。接口定义了语法合同 "是什么" 部分，派生类定义了语法合同 "怎么做" 部分。
        //接口定义了属性、方法和事件，这些都是接口的成员。接口只包含了成员的声明。成员的定义是派生类的责任。接口提供了派生类应遵循的标准结构。
        //接口使得实现接口的类或结构在形式上保持一致。
        //抽象类在某种程度上与接口类似，但是，它们大多只是用在当只有少数方法由基类声明由派生类实现时。
        //接口本身并不实现任何功能，它只是和声明实现该接口的对象订立一个必须实现哪些行为的契约。
        //抽象类不能直接实例化，但允许派生出具体的，具有实际功能的类。
        static void Main(string[] args)
        {
            Program iImp = new Program();
            iImp.MethodToImplement();
        }

        public void MethodToImplement()
        {
            Console.WriteLine("MethodToImplement() called.");
            Console.ReadKey();
        }
        public void ParentInterfaceMethod()
        {
            Console.WriteLine("ParentInterfaceMethod() called.");
            Console.ReadKey();
        }
    }
}

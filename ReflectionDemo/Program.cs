using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //-------------------------------------反射-类操作-------------------------------------------
            //1.获取对象所有的属性名
            Student stu = new Student();
            //获取当前类名称
            Console.WriteLine(stu.GetType().Name);
            //命名空间 和名称
            Console.WriteLine(stu.GetType().FullName);
            //2.指定类型，动态创建对象
            Student stu2 = Activator.CreateInstance<Student>();
            Console.WriteLine("stu2:");
            Console.WriteLine(stu2.ToString());

            //-------------------------------------反射属性操作之PropertyInfo-------------------------------------------
            //反射属性操作 方式二
            Student stu3 = new Student();
            Type t = stu3.GetType();
            /*****操作所有属性*****/
            //1.获取指定名称的属性
            Console.WriteLine("GetProperties:");
            PropertyInfo[] pro2 = t.GetProperties();
            foreach (PropertyInfo item in pro2)
            {
                //Name----属性名称
                //PropertyType----字段类型 例如：System.Int32
                Console.WriteLine(item.Name + "--->" + item.MemberType + "--->" + item.PropertyType);
            }
            //2.获取或设置属性的值
            foreach (PropertyInfo item in pro2)
            {
                object value = null;
                if (item.Name == "ID")
                    value = 1;
                else
                    value = "张三";
                item.SetValue(stu3, value);
                //获取属性值
                Console.WriteLine(item.GetValue(stu3));
            }
            /**操作单个属性***/
            PropertyInfo id = t.GetProperty("ID");
            id.SetValue(stu3, 2);
            Console.WriteLine(id.GetValue(stu3));

            //-------------------------------------反射属性操作之MemberInfo-------------------------------------------
            Student stu4 = new Student();
            //反射属性操作 方式一
            Type t1 = stu4.GetType();
            //GetMembers() 返回当前 System.Type 的所有公共成员
            //获取对象的所有公共属性名称和属性值
            MemberInfo[] members = t1.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MemberInfo item in members)
            {
                if (item.MemberType != MemberTypes.Property)
                {
                    Console.WriteLine("当前属性为:" + item.MemberType);
                    continue;
                }
                Console.WriteLine(item.Name); //属性名称
                Console.WriteLine(item.MemberType);//属性类型
                                                   //获取属性的值
                object value = null;
                if (item.Name == "ID")
                    value = 1;
                else value = "张三";
                t1.InvokeMember(item.Name, BindingFlags.SetProperty, null, stu4, new object[] { value });
                //设置属性的值
                object result = t1.InvokeMember(item.Name, BindingFlags.GetProperty, null, stu4, null);
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
    }
}

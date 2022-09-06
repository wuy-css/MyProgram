using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CloneDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User();
            user1.name = "ceshi";
            user1.age = 20;
            User user2 = user1;
            var a = user1.DeepCloneObject();
            if (object.Equals(user1, a))
            {
                Console.WriteLine("User：原先对象和深度对象相等；");
            }
            else
            {
                Console.WriteLine("User：原先对象和深度对象不相等；");
            }
            //两个对象是否为同一个对象
            if (object.ReferenceEquals(user1, a))
            {
                Console.WriteLine("User：原先对象和深度对象一致；");
            }
            else
            {
                Console.WriteLine("User：原先对象和深度对象不一致；");
            }
            //两个对象是否为同一个对象
            if (object.ReferenceEquals(user1, user2))
            {
                Console.WriteLine("User：原先对象和赋值对象一致；");
            }
            else
            {
                Console.WriteLine("User：原先对象和赋值对象不一致；");
            }
            //Equals:内部是判断两个对象中的值是否一样。==：内部还是调用的equals方法，所以应该同上。
            string s1 = new string(new char[] { 'a', 'b' });
            string s2 = new string(new char[] { 'a', 'b' });
            Console.WriteLine(s1 == s2);//true
            Console.WriteLine(s1.Equals(s2));//true
            Console.WriteLine(object.ReferenceEquals(s1, s2));//false
            Console.ReadLine();
            //List<User> lists = new List<User>();
            //var b = lists.DeepCloneList();
        }
    }

    internal class User
    {
        public string name { get; set; }
        public int age { get; set; }
    }

    public static class CloneExtends
    {
        public static T DeepCloneObject<T>(this T t) where T : class
        {
            T model = System.Activator.CreateInstance<T>();                     //实例化一个T类型对象
            PropertyInfo[] propertyInfos = model.GetType().GetProperties();     //获取T对象的所有公共属性
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                //判断值是否为空，如果空赋值为null见else
                if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                    NullableConverter nullableConverter = new NullableConverter(propertyInfo.PropertyType);
                    //将convertsionType转换为nullable对的基础基元类型
                    propertyInfo.SetValue(model, Convert.ChangeType(propertyInfo.GetValue(t), nullableConverter.UnderlyingType), null);
                }
                else
                {
                    var a = propertyInfo.GetValue(t);
                    var b = propertyInfo.PropertyType;
                    var c = Convert.ChangeType(a, b);

                    propertyInfo.SetValue(model, Convert.ChangeType(propertyInfo.GetValue(t), propertyInfo.PropertyType), null);
                }
            }
            return model;
        }
        public static IList<T> DeepCloneList<T>(this IList<T> tList) where T : class
        {
            IList<T> listNew = new List<T>();
            foreach (var item in tList)
            {
                T model = System.Activator.CreateInstance<T>();                     //实例化一个T类型对象
                PropertyInfo[] propertyInfos = model.GetType().GetProperties();     //获取T对象的所有公共属性
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    //判断值是否为空，如果空赋值为null见else
                    if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                        NullableConverter nullableConverter = new NullableConverter(propertyInfo.PropertyType);
                        //将convertsionType转换为nullable对的基础基元类型
                        propertyInfo.SetValue(model, Convert.ChangeType(propertyInfo.GetValue(item), nullableConverter.UnderlyingType), null);
                    }
                    else
                    {
                        propertyInfo.SetValue(model, Convert.ChangeType(propertyInfo.GetValue(item), propertyInfo.PropertyType), null);
                    }
                }
                listNew.Add(model);
            }
            return listNew;
        }
    }
}

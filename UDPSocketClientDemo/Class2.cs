using System;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class CustomAttribute : Attribute
    {
        public int _Id { get; set; }
        public string _Name { get; set; }
        public CustomAttribute()
        {
            Console.WriteLine($"{this.GetType().Name} 无参数构造函数执行");
        }
        public CustomAttribute(int id)
        {
            Console.WriteLine($"{this.GetType().Name} int参数构造函数执行");
            this._Id = id;
        }
        public CustomAttribute(string name)
        {
            Console.WriteLine($"{this.GetType().Name} string参数构造函数执行");
            this._Name = name;
        }
    }
    [Custom]
    [Custom()]
    [Custom(0)]
    public class Student
    {
        [Custom]
        public int Id { get; set; }
        public string Name { get; set; }
        [Custom]
        public void Study()
        {
            Console.WriteLine($"这里是{this.Name}跟着Eleven老师学习");
        }

        [Custom(0)]
        public string Answer([Custom] string name)
        {
            return $"This is {name}";
        }
    }
    //https://blog.csdn.net/liyou123456789/article/details/119314247
}

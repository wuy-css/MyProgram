using System;
using System.Collections.Generic;
using System.Text;

namespace UDPSocketClientDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate, Inherited = false, AllowMultiple = false)]
    class MyAttribute : Attribute
    {
    }
    //[Animal(IsPrimate = true)]
    //[AttributeUsage(作用范围枚举, inherited = 是否继承, AllowMultiple = 是否允许多次描述。)]
}

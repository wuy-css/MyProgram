using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;
using System.Windows;
using WpfApp4.ViewModels;

namespace WpfApp4
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {

        
            DisplayRootViewFor<RestartExplorerViewModel>();

            //int abc = NumberOf1(11111);
            //System.Console.WriteLine(abc);
            //var a = System.Convert.ToString(2, 2).PadLeft(8, '0');
            //System.Console.WriteLine(a);
        }
      
        //public int NumberOf1(int n)
        //{
        //    // write code here
        //    //设二进制初始时1的个数为0个
        //    int x = 0;
        //    while (n != 0)
        //    {
        //        x++;
        //        //&为二进制取位符
        //        n = n & (n - 1);
        //    }
        //    return x;
        //}
    }
}





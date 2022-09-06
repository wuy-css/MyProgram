using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalibrunDemo
{

    class MyBootstrapper : BootstrapperBase
    {

        public MyBootstrapper()
        {
            Initialize();//初始化框架
        }


        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<StartViewModel>();//显示界面
        }
    }
}

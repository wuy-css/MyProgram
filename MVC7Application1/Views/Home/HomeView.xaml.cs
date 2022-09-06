using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ay.MvcFramework;
using Ay.MvcFramework.AyMarkupExtension;
using MVC7Application1.Controllers;

namespace MVC7Application1.Views.Home
{
    /// <summary>
    /// ResTestView.xaml 的交互逻辑
    /// </summary>
    public partial class HomeView : AyPage
    {
        public HomeView()
        {
            InitializeComponent();
        }





    }
































    public partial class HomeView : AyPage
    {
        #region 控制器
        private Actions<HomeController> _mvc;
        public Actions<HomeController> Mvc
        {
            get
            {
                if (_mvc == null)
                {
                    _mvc = new Actions<HomeController>(DataContext as HomeController);
                }
                return _mvc;
            }
        }
        #endregion
    }
}

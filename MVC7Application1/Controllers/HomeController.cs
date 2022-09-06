using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Ay.MvcFramework;
using MVC7Application1.Models;

namespace MVC7Application1.Controllers
{
    public class HomeController : Controller
    {
        public HomeModel Model { get; set; } = new HomeModel();
        public HomeController() : base()
        {

        }


        /// <summary>
        /// 无注释
        /// </summary>
        public ActionResult MyAction { get; private set; } = inParam =>
        {

        };



    }
}

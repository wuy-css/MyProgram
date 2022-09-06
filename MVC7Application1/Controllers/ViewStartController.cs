using System;
using System.Collections.ObjectModel;
using Ay.Framework.WPF.Controls;
using Ay.MvcFramework;
using MVC7Application1.Models;

namespace MVC7Application1.Controllers
{
    public class ViewStartController : Controller
    {
        public ViewStartModel Model { get; set; } = new ViewStartModel();

        public ViewStartController() : base()
        {


        }


    }

}

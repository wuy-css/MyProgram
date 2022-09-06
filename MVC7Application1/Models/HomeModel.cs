using Ay.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC7Application1.Models
{
    public class HomeModel : Model
    {
        private string _MyProperty;

        /// <summary>
        /// 未填写
        /// </summary>
        public string MyProperty
        {
            get { return _MyProperty; }
            set { Set(ref _MyProperty, value); }
        }
       

    }
}

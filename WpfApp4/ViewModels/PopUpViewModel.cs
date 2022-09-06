using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.ViewModels
{
   internal class PopUpViewModel
    {
        public static String GetHelloWord() => "Hello Word!";

        public string PubName { get; set; }

        private string priname;

        public string PriName
        {
            get { return priname; }
            set { priname = value; }
        }

    }
}

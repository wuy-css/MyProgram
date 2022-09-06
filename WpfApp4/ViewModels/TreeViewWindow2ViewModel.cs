using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Method;

namespace WpfApp4.ViewModels
{
   public class TreeViewWindow2ViewModel
    {
        public TreeViewWindow2ViewModel()
        {
            UDPclient a = UDPclient.Instance;
            a.ConnectStart(9050);
        }
    }
}

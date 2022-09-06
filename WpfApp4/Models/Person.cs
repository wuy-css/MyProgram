using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Models
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;

        public string Name
        {
            get { return name; }
            set{ name = value;if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Name"));}
        }

        private string adress;

        public string Adress
        {
            get { return adress; }
            set { adress = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Adress")); }
        }
    }
}

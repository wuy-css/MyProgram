using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp4.Models
{
    class DelegateCommand : ICommand
    {
        private Func<int> _action;

        public DelegateCommand(Func<int> action)
        {
            _action = action;
        }

#pragma warning disable CS0067 // 从不使用事件“DelegateCommand.CanExecuteChanged”
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // 从不使用事件“DelegateCommand.CanExecuteChanged”

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}

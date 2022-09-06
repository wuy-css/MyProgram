using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Windows.Input;

namespace CommandDemo
{
    public class MainWindowModel
    {
        private ICommand hiButtonCommand;

        private ICommand toggleExecuteCommand { get; set; }

        private bool canExecute = true;　　　　//初始化为true

        public string HiButtonContent　　　　  //定义公开属性
        {
            get
            {
                return "click to hi";
            }
        }

        public bool CanExecute               //定义公开属性
        {
            get
            {
                return this.canExecute;
            }

            set
            {
                if (this.canExecute == value)
                {
                    return;
                }

                this.canExecute = value;
            }
        }

        public ICommand ToggleExecuteCommand      //定义接口
        {
            get
            {
                return toggleExecuteCommand;
            }
            set
            {
                toggleExecuteCommand = value;
            }
        }

        public ICommand HiButtonCommand          //定义接口
        {
            get
            {
                return hiButtonCommand;
            }
            set
            {
                hiButtonCommand = value;
            }
        }

        public MainWindowModel()               //构造函数
        {
            HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        public void ShowMessage(object obj)       //消息 方法
        {
            MessageBox.Show(obj.ToString());
        }

        public void ChangeCanExecute(object obj)  //方法
        {
            canExecute = !canExecute;
        }
    }

    //class MainViewModel
    //{
    //    public DelegateCommand<Window> CloseWindowCommand { get; private set; }

    //    public MainViewModel()
    //    {
    //        CloseWindowCommand = new DelegateCommand<Window>(CloseWindow);
    //    }

    //    private void CloseWindow(Window window)
    //    {
    //        if (window != null)
    //        {
    //            window.Close();
    //        }
    //    }
    //}
}

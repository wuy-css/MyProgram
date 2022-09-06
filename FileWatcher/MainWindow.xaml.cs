using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace FileWatcher
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public virtual string DisplayName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            //PropertyChangedEventHandler handler = PropertyChanged;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private List<string> fileList = new List<string>();
        private ObservableCollection<FileInfo> fileCollection = new ObservableCollection<FileInfo>();
        public ObservableCollection<FileInfo> FileCollection
        {
            get { return fileCollection; }
            set
            {
                fileCollection = value;
                OnPropertyChanged("FileCollection");
            }
        }
        private bool isAllChecked;
        public bool IsAllChecked
        {
            get { return isAllChecked; }
            set
            {
                isAllChecked = value;
                OnPropertyChanged("IsAllChecked");

                for (int i = 0; i < FileCollection.Count; i++)
                {
                    FileCollection[i].IsChecked = isAllChecked;
                }
                //OnPropertyChanged("FilaCalibrationProtocols");
            }
        }
        FileSystemWatcher fsw = new FileSystemWatcher();
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.DataContext = this;
            fsw.Path = @"C:\";   //设置监控的文件目录
            fsw.Filter = "*.*";   //设置监控文件的类型
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;   //设置文件的文件名、目录名及文件的大小改动会触发Changed事件

            fsw.Created += new FileSystemEventHandler(this.fileSystemWatcher_EventHandle);  //绑定事件触发后处理数据的方法。

            fsw.Deleted += new FileSystemEventHandler(this.fileSystemWatcher_EventHandle);

            fsw.Changed += new FileSystemEventHandler(this.fileSystemWatcher_EventHandle);

            fsw.Renamed += new RenamedEventHandler(this.fileSystemWatcher_Renamed);  //重命名事件与增删改传递的参数不一样。

            fsw.IncludeSubdirectories = true;

        }
        private void fileSystemWatcher_EventHandle(object sender, FileSystemEventArgs e)  //文件增删改时被调用的处理方法
        {
            this.Dispatcher.BeginInvoke(
                new Action(() =>
                {

                    var fileInfo = new FileInfo() { Operation = e.ChangeType.ToString(), Date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), FileName = e.Name, FilePath = e.FullPath, IsChecked = false };

                    if (e.ChangeType.ToString() == "Created")
                    {
                        var fileName = from file in fileList.Distinct()
                                       where file == e.Name
                                       select file;
                        if (fileName.Count() > 0)
                        {
                            fileInfo.Note = $"{e.Name} have already been {e.ChangeType} before.";
                            MessageBox.Show($"{e.Name} have already been {e.ChangeType} before.");
                        }
                    }

                    fileCollection.Add(fileInfo);

                    fileList.Add(e.Name);
                })
         );

        }
        private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)   //文件重命名时被调用的处理方法
        {
            this.Dispatcher.BeginInvoke(
               new Action(() =>
               {
                   fileCollection.Add(new FileInfo() { Operation = e.ChangeType.ToString(), Date = DateTime.Now.ToLongTimeString(), FileName = e.OldName + " --> " + e.Name, FilePath = e.FullPath, IsChecked = false });
                   fileList.Add(e.Name);
               })
        );

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(tbxPath.Text))
            {
                fsw.Path = tbxPath.Text;
            }
            fsw.EnableRaisingEvents = true;
        }
    }
    public class FileInfo : ViewModelBase
    {
        private bool isChecked;

        public bool IsChecked
        { get { return isChecked; } set { isChecked = value; OnPropertyChanged("IsChecked"); } }


        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private string operation;
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

    }
}
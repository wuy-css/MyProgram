using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取应用程序的当前工作目录。  
            String path1 = System.IO.Directory.GetCurrentDirectory();


            //获取程序的基目录。  
            String path2 = System.AppDomain.CurrentDomain.BaseDirectory;

            //获取和设置包括该应用程序的目录的名称。  

            String path3 = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            //获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称。  

            String path4 = System.Windows.Forms.Application.StartupPath;



            //获取启动了应用程序的可执行文件的路径及文件名  

            String path5 = System.Windows.Forms.Application.ExecutablePath;

            textBox1.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}

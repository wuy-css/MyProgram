using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventArgsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //请求数据，就是订阅
        private void button1_Click(object sender, EventArgs e)
        {
            NewspaperOffice newspaperOffice = new NewspaperOffice(); 
            newspaperOffice.StartPublishPaper += SubscriptinPaper; //3、订阅事件
            newspaperOffice.Publish();
        }

        void SubscriptinPaper(object sender, PaperContentEventArgs e)
        {
            MessageBox.Show("阿辉接收到报纸，开始阅读！收到的传递数据为：" + e.Name);
        }
    }
}

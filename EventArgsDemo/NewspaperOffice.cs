using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventArgsDemo
{
    /// <summary>
    /// 报社
    /// </summary>
    class NewspaperOffice
    {
        //1、创建事件并发布
        public event EventHandler<PaperContentEventArgs> StartPublishPaper;

        public void Publish()
        {
            Console.WriteLine("已发布报纸！报社传递数据：阿辉");
            PaperContentEventArgs paperContent = new PaperContentEventArgs();
            paperContent.Name = "阿辉";

            //2、触发事件，通知订阅者收报纸进行阅读
            StartPublishPaper(this, paperContent);
        }
    }

}

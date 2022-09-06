using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventArgsDemo
{
    /// <summary>
    /// 派生自EventArgs的类，用于传递数据
    /// </summary>
    class PaperContentEventArgs : EventArgs
    {
        public string Name { get; set; }                    //用于存储数据，当事件被调用时，可利用其进行传递数据。
    }
}

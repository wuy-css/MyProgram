using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerProgram
{
    public class ClassInfoEventArgs : EventArgs
    {
        /// <summary>
        /// 班级所属年级
        /// </summary>
        public string ClassGrade { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ClassGrade"></param>
        /// <param name="ClassName"></param>
        public ClassInfoEventArgs(string ClassGrade, string ClassName)
        {
            this.ClassGrade = ClassGrade;
            this.ClassName = ClassName;
        }
    }
}

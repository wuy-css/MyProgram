using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerProgram
{
    public class StudentInfo
    {
        /// <summary>
        /// 声明委托对象
        /// </summary>
        public event EventHandler<ClassInfoEventArgs> showStudentInfo;
        public StudentInfo()
        {
            //绑定
            showStudentInfo += new EventHandler<ClassInfoEventArgs>(showStudentInfoMethod);
        }

        /// <summary>
        /// 声明一个方法绑定委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="classInfoEvent"></param>
        public void showStudentInfoMethod(object sender, ClassInfoEventArgs classInfoEvent)
        {
            Console.WriteLine("我是" + classInfoEvent.ClassGrade + classInfoEvent.ClassName + "的学生");
        }

        /// <summary>
        /// 调用方法，开启委托
        /// </summary>
        public void callShowStudentInfo(ClassInfoEventArgs classInfoEvent)
        {
            if (showStudentInfo != null)
            {
                showStudentInfo(this, classInfoEvent);
            }
        }
    }
}

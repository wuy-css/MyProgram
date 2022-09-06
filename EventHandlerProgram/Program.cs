using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassInfoEventArgs classInfoEvent = new ClassInfoEventArgs("三年级", "二班");
            StudentInfo studentInfo = new StudentInfo();
            studentInfo.callShowStudentInfo(classInfoEvent);
        }
    }
}

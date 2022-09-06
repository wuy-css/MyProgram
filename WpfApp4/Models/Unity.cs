using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Models
{
    public static class Unity
    {
        #region 第一种运行CMD的方式
        /// <summary>
        /// 调用CMD命令来杀死或重启进程
        /// </summary>
        /// <param name="a">杀死或重启进程</param>
        /// <returns>cmd命令返回</returns>
        public static void cmdkill(bool a)
        {
            string str;
            //string str = Console.ReadLine();
            if (a)
            {
                str = @"taskkill /f /im explorer.exe";
            }
            else
            {
                str = @"C:\Windows\explorer.exe";
                //str = @"start explorer.exe";
            }
            Process p = new Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.UseShellExecute = false;                 //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;            //接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;           //由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;            //重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;                   //不显示程序窗口
            p.Start();                                           //启动程序
            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");
            //p.StandardInput.WriteLine(str);
            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            //获取cmd窗口的输出信息
            //string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            //return output;
        }
        #endregion
    }
}

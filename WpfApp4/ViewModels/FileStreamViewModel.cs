using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.NotifyProperty;

namespace WpfApp4.ViewModels
{
    class FileStreamViewModel : CommonNotifyProperty
    {

        //写文件 FileStream --StreamWrite--BinaryWrite
        //这是因为FileStream类操作的是字节和字节数组
        //StreamReader类操作的是字符数据、读文本的读取器
        //BinaryReader是读二进制数据的读取器
        public FileStreamViewModel()
        {
            //一、Write
            FileStream fs = new FileStream(@"C:\Users\DELL\Desktop\Debug\abcc.txt", FileMode.Create, FileAccess.ReadWrite);
            byte[] data = new UTF8Encoding().GetBytes("nihao,wolaile");
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();

            //一、Read
            using (FileStream fs2 = new FileStream(@"C:\Users\DELL\Desktop\Debug\abcc.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] b = new byte[fs2.Length];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs2.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }

            //二、StreamWriter
            FileStream fs3 = new FileStream(@"C:\Users\DELL\Desktop\Debug\abcc.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs3);
            for (int i = 0; i < 1000; i++)
            {
                sw.Write("nihao,wolaile");

            }
            sw.Flush();
            sw.Close();
            //二、StreamReader
            using (StreamReader sr = new StreamReader(@"C:\Users\DELL\Desktop\Debug\abcc.txt"))
            {
                string line;
                // 从文件读取并显示行，直到文件的末尾 
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            sw.Close();   
            
            //三、BinaryWriter
            FileStream fs5 = new FileStream(@"C:\Users\DELL\Desktop\Debug\abcc.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs5);
            bw.Write("nihao,wolaile");
            bw.Flush();
            bw.Close();

            //三、BinaryReader
            FileStream fileStream1 = new FileStream(@"C:\Users\DELL\Desktop\Debug\abcc.txt", FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader1 = new BinaryReader(fileStream1);
            //获取文件长度
            long length = fileStream1.Length;
            byte[] bytes = new byte[length];
            //读取文件中的内容并保存到字节数组中
            binaryReader1.Read(bytes, 0, bytes.Length);
            //将字节数组转换为字符串
            string str = Encoding.Default.GetString(bytes);
            Console.WriteLine(str);

            //三、BinaryReader
            FileStream fileStream = new FileStream(@"C:\Users\DELL\Desktop\Debug\abcc.txt", FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            //读取文件的一个字符
            int a = binaryReader.Read();
            //判断文件中是否含有字符，若不含字符，a 的值为 -1
            while (a != -1)
            {
                //输出读取到的字符
                Console.Write((char)a);
                a = binaryReader.Read();
            }

            //OpenRead 读取流
            using (FileStream fs2 = File.OpenRead(@"C:\Users\DELL\Desktop\Debug\abcc.txt"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs2.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
        }

    }
    public interface abc : IDisposable
    {
    }
}

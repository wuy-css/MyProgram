using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MediaDemo
{
    public static class hashhelper
    {
        public static string WhiteList = "unins000.exe,ATGOUpdater.exe";
        /// <summary>
        ///  计算指定文件的MD5值
        /// </summary>
        /// <param name="fileName">指定文件的完全限定名称</param>
        /// <returns>返回值的字符串形式</returns>
        public static String FileMD5(String fileName)
        {
            String hashMD5 = String.Empty;
            //检查文件是否存在，如果文件存在则进行计算，否则返回空值
            if (System.IO.File.Exists(fileName))
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    //计算文件的MD5值
                    System.Security.Cryptography.MD5 calculator = System.Security.Cryptography.MD5.Create();
                    Byte[] buffer = calculator.ComputeHash(fs);
                    calculator.Clear();
                    //将字节数组转换成十六进制的字符串形式
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        stringBuilder.Append(buffer[i].ToString("x2"));
                    }
                    hashMD5 = stringBuilder.ToString().ToUpper();
                }
            }
            return hashMD5;
        }
        /// <summary>
        /// 获取文件列表hash值
        /// </summary>
        /// <returns></returns>
        public static string HashFiles(string path)
        {
            string WhiteStr = System.Configuration.ConfigurationManager.AppSettings["WhiteList"];

            //如果配置文件取字符串为空，则使用缺损值
            if (!string.IsNullOrWhiteSpace(WhiteStr))
            {
                WhiteList = WhiteStr;
            }
            string[] whiteList = WhiteList.Split(',');
            #region
            string hashmd5 = string.Empty;
            string directory = path;
            if (Directory.Exists(directory))
            {
                // 创建一个表示指定目录的DirectoryInfo对象。
                var dir = new DirectoryInfo(directory);
                // 获取目录中每个文件的FileInfo对象。
                FileInfo[] files = dir.GetFiles();
                using (MD5 myMD5 = MD5.Create())
                {
                    List<byte> bytes = new List<byte>();
                    foreach (FileInfo fInfo in files)
                    {
                        if ((fInfo.Extension == ".dll" || fInfo.Extension == ".exe") && !whiteList.Contains(fInfo.Name))
                        {
                            bytes.AddRange(myMD5.ComputeHash(new FileStream(fInfo.FullName, FileMode.Open, FileAccess.Read)));
                        }
                    }
                    //计算fileStream的hash。
                    byte[] buffer = bytes.ToArray();
                    hashmd5 = BitConverter.ToString(myMD5.ComputeHash(buffer)).Replace("-", "");
                }
            }
            return hashmd5;
            #endregion
        }
    }
}

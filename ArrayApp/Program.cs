using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 声明数组
            int[] a = new int[] { 1, 3, 4, 5, 656, -1 };
            // 声明多维数组
            int[,] aD = new int[,] { { 1, 2 }, { 3, 4 } };
            // 声明交错数组
            int[][] aJ = new int[][] { new int[] { 1, 2, 3 }, new int[] { 1 } };
            // 声明ArrayList
            ArrayList b = new ArrayList() { 1, 2, 344, "233", true };
            // 声明List<T>
            List<int> c = new List<int>();

            List<int> aToList = new List<int>(a);
            List<int> aToLista = a.ToList();

            Hashtable hashtable = new Hashtable();
            // hash.Add();

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (KeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}\tover");
            }
            // hashtable 转 Dict
            Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
            foreach (DictionaryEntry item in hashtable)
            {
                dictionary2.Add((int)item.Key, (int)item.Value);
            }
            // Dict转Hashtable
            Hashtable hashtable1 = new Hashtable(dictionary);
            //数组转List：
            string[] str1 = { "1", "2" };
            List<string> list = new List<string>(str1);
            //List转数组：
            string[] str = list.ToArray();

            list.ForEach((item) =>
            {
                Console.WriteLine(item);
            });

            List<object> listObject = aToList.ConvertAll(s => (object)s);

            HashSet<MyClass> hashSet = new HashSet<MyClass>();
        }

        class MyClass
        {

        }
    }
}

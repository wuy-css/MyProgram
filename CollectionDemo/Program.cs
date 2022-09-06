using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDemo
{
    //集合
    class Program
    {
        static void Main(string[] args)
        {
            //集合（Collection）类是专门用于数据存储和检索的类。这些类提供了对栈（stack）、队列（queue）、列表（list）和哈希表（hash table）的支持。大多数集合类实现了相同的接口。
            //集合（Collection）类服务于不同的目的，如为元素动态分配内存，基于索引访问列表项等等。这些类创建 Object 类的对象的集合。在 C# 中，Object 类是所有数据类型的基类。
            //最后，字典,堆栈，队列不能排序，如果想对字典排序就要用其它方法或集合，如SortedDictionary < TKey,TValue >。
            //有很多种的自动排序，它们的性能有细微差异，所以要仔细选择最好的适合项目的自动排序集合
            //动态数组--ArrayList
            //hash表--HashTable
            //排序列表--SortedList
            //堆栈--Stack
            //队列--Queue
            //点阵列-BitArray
            //大多数集合都在System.Collections，System.Collections.Generic两个命名空间。其中System.Collections.Generic专门用于泛型集合。
            //针对特定类型的集合类型位于System.Collections.Specialized; 命名空间；
            //线程安全的集合类位于System.Collections.Concurrent; 命名空间。
        }

        /// <summary>
        /// 动态数组（ArrayList）代表了可被单独索引的对象的有序集合。它基本上可以替代一个数组。
        /// 但是，与数组不同的是，您可以使用索引在指定的位置添加和移除项目，
        /// 动态数组会自动重新调整它的大小。它也允许在列表中进行动态内存分配、增加、搜索、排序各项。
        /// </summary>
        public void ArrayList()
        {
            ArrayList al = new ArrayList();
            Console.WriteLine("Adding some numbers:");
            al.Add(45);
            al.Add(78);
            al.Add(33);
            al.Add(56);
            al.Add(12);
            al.Add(23);
            al.Add(9);
            Console.WriteLine("Capacity: {0} ", al.Capacity);
            Console.WriteLine("Count: {0}", al.Count);

            Console.Write("Content: ");
            foreach (int i in al)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.Write("Sorted Content: ");
            al.Sort();
            foreach (int i in al)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        /// <summary>
        /// Hashtable 类代表了一系列基于键的哈希代码组织起来的键/值对。它使用键来访问集合中的元素。
        /// 当您使用键访问元素时，则使用哈希表，而且您可以识别一个有用的键值。哈希表中的每一项都有一个键/值对。键用于访问集合中的项目。
        /// </summary>
        public void HashTable()
        {
            Hashtable ht = new Hashtable();
            ht.Add("001", "Zara Ali");
            ht.Add("002", "Abida Rehman");
            ht.Add("003", "Joe Holzner");
            ht.Add("004", "Mausam Benazir Nur");
            ht.Add("005", "M. Amlan");
            ht.Add("006", "M. Arif");
            ht.Add("007", "Ritesh Saikia");

            if (ht.ContainsValue("Nuha Ali"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                ht.Add("008", "Nuha Ali");
            }
            // 获取键的集合
            ICollection key = ht.Keys;

            foreach (string k in key)
            {
                Console.WriteLine(k + ": " + ht[k]);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// SortedList 类代表了一系列按照键来排序的键/值对，这些键值对可以通过键和索引来访问。
        /// 排序列表是数组和哈希表的组合。它包含一个可使用键或索引访问各项的列表。
        /// 如果您使用索引访问各项，则它是一个动态数组（ArrayList），
        /// 如果您使用键访问各项，则它是一个哈希表（Hashtable）。集合中的各项总是按键值排序。
        /// </summary>
        public void SortedList()
        {
            SortedList sl = new SortedList();
            sl.Add("001", "Zara Ali");
            sl.Add("002", "Abida Rehman");
            sl.Add("003", "Joe Holzner");
            sl.Add("004", "Mausam Benazir Nur");
            sl.Add("005", "M. Amlan");
            sl.Add("006", "M. Arif");
            sl.Add("007", "Ritesh Saikia");

            if (sl.ContainsValue("Nuha Ali"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                sl.Add("008", "Nuha Ali");
            }

            // 获取键的集合
            ICollection key = sl.Keys;

            foreach (string k in key)
            {
                Console.WriteLine(k + ": " + sl[k]);
            }
        }
        /// <summary>
        /// 堆栈（Stack）代表了一个后进先出的对象集合。当您需要对各项进行后进先出的访问时，则使用堆栈。
        /// 当您在列表中添加一项，称为推入元素，当您从列表中移除一项时，称为弹出元素。
        /// </summary>
        public void Stack()
        {

            Stack st = new Stack();
            st.Push('A');
            st.Push('M');
            st.Push('G');
            st.Push('W');
            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            st.Push('V');
            st.Push('H');
            Console.WriteLine("The next poppable value in stack: {0}",
            st.Peek());
            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Removing values ");
            st.Pop();
            st.Pop();
            st.Pop();

            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
        }
        /// <summary>
        /// 队列（Queue）代表了一个先进先出的对象集合。当您需要对各项进行先进先出的访问时，则使用队列。
        /// 当您在列表中添加一项，称为入队，当您从列表中移除一项时，称为出队。
        /// </summary>
        public void Queue()
        {
            Queue q = new Queue();

            q.Enqueue('A');
            q.Enqueue('M');
            q.Enqueue('G');
            q.Enqueue('W');

            Console.WriteLine("Current queue: ");
            foreach (char c in q)
                Console.Write(c + " ");
            Console.WriteLine();
            q.Enqueue('V');
            q.Enqueue('H');
            Console.WriteLine("Current queue: ");
            foreach (char c in q)
                Console.Write(c + " ");
            Console.WriteLine();
            Console.WriteLine("Removing some values ");
            char ch = (char)q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
            ch = (char)q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
            Console.ReadKey();
        }
        /// <summary>
        /// BitArray 类管理一个紧凑型的位值数组，它使用布尔值来表示，其中 true 表示位是开启的（1），false 表示位是关闭的（0）。
        /// 当您需要存储位，但是事先不知道位数时，则使用点阵列。您可以使用整型索引从点阵列集合中访问各项，索引从零开始。
        /// </summary>
        public void BitArray()
        {
            // 创建两个大小为 8 的点阵列
            BitArray ba1 = new BitArray(8);
            BitArray ba2 = new BitArray(8);
            byte[] a = { 60 };
            byte[] b = { 13 };

            // 把值 60 和 13 存储到点阵列中
            ba1 = new BitArray(a);
            ba2 = new BitArray(b);

            // ba1 的内容
            Console.WriteLine("Bit array ba1: 60");
            for (int i = 0; i < ba1.Count; i++)
            {
                Console.Write("{0, -6} ", ba1[i]);
            }
            Console.WriteLine();

            // ba2 的内容
            Console.WriteLine("Bit array ba2: 13");
            for (int i = 0; i < ba2.Count; i++)
            {
                Console.Write("{0, -6} ", ba2[i]);
            }
            Console.WriteLine();


            BitArray ba3 = new BitArray(8);
            ba3 = ba1.And(ba2);

            // ba3 的内容
            Console.WriteLine("Bit array ba3 after AND operation: 12");
            for (int i = 0; i < ba3.Count; i++)
            {
                Console.Write("{0, -6} ", ba3[i]);
            }
            Console.WriteLine();

            ba3 = ba1.Or(ba2);
            // ba3 的内容
            Console.WriteLine("Bit array ba3 after OR operation: 61");
            for (int i = 0; i < ba3.Count; i++)
            {
                Console.Write("{0, -6} ", ba3[i]);
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        /// <summary>
        /// 首先，List 是个强类型，很安全。其次看那个尖括号，它是 C#2.0 时加入的泛型，所以并不存在像 ArrayList。那样要拆/装箱以此造成性能浪费。
        ///然后，List 通过索引分配，索引与数组一样，从 0 开始。它可以通过索引来读取值：
        /// </summary>
        public void List()
        {
            var a = new List<int>();
            a.Add(2);
            a.Add(6);
            a.Add(2);
            a.Add(10);
            Console.WriteLine($"第一个数为{a[0]}");
            a.Remove(2);//删去第一个匹配此条件的项
            a.Sort();
            foreach (var a2 in a)
            {
                Console.WriteLine(a2);
            }
            bool a3 = a.Contains(2);
            Console.WriteLine(a3);
            Console.ReadKey();
            //a.ForEach(Print); 每个元素执行指定操作
        }
        /// <summary>
        /// 看见尖括号就知道它是c#2.0的泛型了，所以它可以容纳任何类型。
        /// 首先，字典有一个键<TKey> 和一个值<TValue>, 其中键必须是唯一的，不能重复。
        /// 键不能是空引用
        /// 其次我们可以用键来索引，就不用索引值来索引了。
        /// </summary>
        public void Dictionary()
        {
            var a = new Dictionary<int, int>();
            a.Add(12, 14);
            a.Add(0, 1);
            Console.WriteLine("删去前的Count" + a.Count);
            a.Remove(0);
            Console.WriteLine(a[12]);
            Console.WriteLine(a.Count);
            Console.WriteLine(a.ContainsKey(12));
            Console.ReadKey();
        }

        /// <summary>
        /// 无论插入字典的数据是乱序还是有序，他都会根据ASCII码从小到大排序
        /// </summary>
        public void SortedDictionary()
        {
            Console.WriteLine("\n\n\n-----测试SortedDictionary分类字典的正序和反序-----");
            SortedDictionary<string, string> sd = new SortedDictionary<string, string>();
            sd.Add("a", "aaa");
            sd.Add("c", "bbb");
            sd.Add("b", "ccc");
            sd.Add("d", "ddd");

            Console.Write("\r\n正序排序数据：\r\n");
            foreach (KeyValuePair<string, string> item in sd)
            {
                Console.Write("键名：" + item.Key + " 键值：" + item.Value + "\r\n");
            }

            //重新封装到Dictionary里（PS：因为排序后我们将不在使用排序了，所以就使用Dictionary）
            Dictionary<string, string> dc = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in sd.Reverse())
            {
                dc.Add(item.Key, item.Value);
            }
            sd = null;
            //再看其输出结果：
            Console.Write("\r\n反序排序数据：\r\n");
            foreach (KeyValuePair<string, string> item in dc)
            {
                Console.Write("键名：" + item.Key + " 键值：" + item.Value + "\r\n");
            }
        }

        /// <summary>
        /// 经典的阻塞队列数据结构类似，能够适用于多个任务添加和删除数据，提供阻塞和限界能力
        /// 一个支持界限和阻塞的容器（线程安全集合）
        ///  Add ：向容器中插入元素
        ///TryTake：从容器中取出元素并删除
        ///TryPeek：从容器中取出元素，但不删除。
        ///CompleteAdding：告诉容器，添加元素完成。此时如果还想继续添加会发生异常。
        ///IsCompleted：告诉消费线程，生产者线程还在继续运行中，任务还未完成。
        /// </summary>
        public void BlockingCollection()
        {
            bool IsOpen = false;
            System.Collections.Concurrent.BlockingCollection<string> m_BlockData = new System.Collections.Concurrent.BlockingCollection<string>();
            //m_BlockData.GetConsumingEnumerable();//从集合中移除并返回项的 System.Collections.Generic.IEnumerable`1。
            //添加数据：
            string tempStr = "aaa";
            m_BlockData.Add(tempStr);
            //取出数据
            while (true)
            {
                if (m_BlockData != null)
                {
                    var temp = m_BlockData.Take();

                }

                if (!IsOpen)
                {
                    m_BlockData.Dispose();
                    m_BlockData = null;
                    break;
                }
            }
        }
        /// <summary>
        /// ConcurrentDictionary<TKey, TValue>的理解
        ///1、表示可由多个线程同时访问的键/值对的线程安全集合。
        ///2、ConcurrentDictionary是.net4.0推出的一套线程安全集合里的其中一个，和它一起被发行的还有
        ///ConcurrentStack, ConcurrentQueue等类型，它们的单线程版本（线程不安全的,Queue,Stack,Dictionary）。
        ///3、用法同Dictionary很多相同，但是多了一些方法。ConcurrentDictionary 属于System.Collections.Concurrent 命名空间
        /// </summary>
        public void ConcurrentDictionary()
        {
            ConcurrentDictionary<string, object> loggreDic = new ConcurrentDictionary<string, object>();
        }
    }
}

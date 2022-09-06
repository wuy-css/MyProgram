using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDemo
{
    class Program
    {
        public static readonly ConcurrentDictionary<SubOrderMsg, string> SubOrderMsgs = new ConcurrentDictionary<SubOrderMsg, string>();

        public static void GetStr()
        {
            SubOrderMsgs[new SubOrderMsg { clOrdId = "200001", index = 1 }] = "2";
            SubOrderMsgs[new SubOrderMsg { clOrdId = "200002", index = 2 }] = "2";
            SubOrderMsgs[new SubOrderMsg { clOrdId = "200001", index = 1 }] = "2";
            SubOrderMsgs[new SubOrderMsg { clOrdId = "200003", index = 3 }] = "3";
            SubOrderMsgs[new SubOrderMsg { clOrdId = "200004", index = 4 }] = "4";
        }
        static void Main(string[] args)
        {
            GetStr();
            var SubOrderList = SubOrderMsgs.Where(x => x.Value == "2").ToList();
            foreach (var model in SubOrderList)   
            {
                SubOrderMsgs.TryRemove(model.Key,out string value);
            }
        }
    }

    public class SubOrderMsg
    {
        public long index { get; set; }
        public string clOrdId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace LINQProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{
                    Country="中国",
                    Name="小俊",
                    CustomerID=1,
                    Orders=new List<Order>{
                        new Order{
                            CustomerID=1,
                            Details=new List<Detail>{
                            new Detail { DetailID=0, OrderID=0, ProductID=0, Quantity=0, UnitPrice=0 }
                        },
                            OrderDate=DateTime.Now,
                            OrderID=0,
                            Total=0
                        }
                }, }
            };
            List<Detail> details = new List<Detail>{
                            new Detail { DetailID=1, OrderID=01, ProductID=0, Quantity=100, UnitPrice=10.0 },
                            new Detail { DetailID=1, OrderID=01, ProductID=0, Quantity=100, UnitPrice=10.0 },
                            new Detail { DetailID=2, OrderID=02, ProductID=0, Quantity=1000, UnitPrice=10.0 },
                            new Detail { DetailID=3, OrderID=03, ProductID=1, Quantity=1000, UnitPrice=10.0 },
                            new Detail { DetailID=4, OrderID=04, ProductID=2, Quantity=1000, UnitPrice=10.0 }
            };
            //----每个from子句都是一个生成器，该生成器将引入一个包括序列(Sequence)的元素的范围变量(range variable)-------------------------------------------------------------
            //var query = from r in
            //                from c in customers
            //                select new
            //                {
            //                    Name = c.Name,
            //                    OrderCount = (from o in c.Orders
            //                                  from d in o.Details
            //                                  select d.Quantity).Sum()
            //                }
            //            orderby r.OrderCount
            //            select r;
            //---select或者group子句根据范围变量来指定结果的表现形式--------------------------------------------------------------
            //var groups = details.GroupBy(p => p.ProductID);
            //foreach (var group in groups)
            //{
            //    //Console.WriteLine("车牌号{0}:有{1}人<br/> ", group.Key.ProductID, group.Count());
            //    Console.WriteLine(group.Key);
            //    foreach (var person in group)
            //    {
            //        Console.WriteLine($"\t{person.ProductID},{person.Quantity}");
            //    }
            //}
            //Console.ReadKey();
            //-----使用into子句来连接查询，将某一查询结果的视为后续查询的生成器------------------------------------------------------------
            var query = from d in details
                        group d by d.ProductID into g
                        orderby g.Count(), g.Key
                        select new { Name1 = g.Key, Count = g.Count() };
            Console.WriteLine("ProductID" + "\t" + "Count");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name1 + "\t\t" + item.Count);
            }
            Console.ReadKey();
            //-----orderby子句都会根据指定的条件对各项进行重新排序------------------------------------------------------------
            //var query = from c in customers
            //            where c.City == "北京" && c.Name.StartsWith("小")
            //            select c;
            //foreach (Customer item in query)
            //{
            //    Console.WriteLine(item.Name + "\t\t" + item.City);
            //}
            //Console.ReadKey();
            //----------------------------------------------------------------------------------------------------------------
            //var query = from d in details
            //            group d by d.ProductID into g
            //            orderby g.Count(), g.Key
            //            select new
            //            {
            //                Name = g.Key,
            //                Count = g.Count(),
            //                Quantity = from d in g
            //                           orderby d.Quantity
            //                           select d.Quantity
            //            };

            //Console.WriteLine("ProductID" + "\t" + "Count" + "\t" + "Quantity");
            //foreach (var item in query)
            //{
            //    Console.Write(item.Name + "\t\t" + item.Count + "\t");
            //    foreach (var quantity in item.Quantity)
            //    {
            //        Console.Write("{0};", quantity);
            //    }
            //    Console.WriteLine();
            //}
            //Console.ReadKey();
            //---------------------------------------------------------------------------------------------
            var results = details.GroupBy(p => p, (p => new { p.DetailID, p.ProductID }),
            (p, ns) =>
            {
                string result = $"{p.ToString()}:\t";
                foreach (var n in ns)
                {
                    result += $"{n.DetailID},{p.ProductID}\t";
                }
                return result;
            }, new DetailEqualityComparer());
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            Console.ReadKey();
            //---------------------------------------------------------------------------------------------
        }
    }

    internal class Customer
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int CustomerID { get; set; }
        public string Country { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int Total { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Detail> Details { get; set; }
    }

    public class Detail
    {
        public int DetailID { get; set; }
        public int OrderID { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public int ProductID { get; set; }

    }
    class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
    class DetailEqualityComparer : IEqualityComparer<Detail>
    {
        public bool Equals(Detail x, Detail y) => x.ProductID == y.ProductID;
        public int GetHashCode(Detail obj) => obj.ProductID.GetHashCode();
    }
}

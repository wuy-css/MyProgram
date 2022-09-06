using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalDemo
{
    class Program
    {
        //在C#中，double比float的表示范围更大；
        //decimal的有效位数比double、float类型的都大，但表示范围却比它们两个都小；
        //decimal适用于银行这种更精确的货币，可以精确分数；
        //当声明小数的精度类型数值时，系统会自动默认为double类型；
        //声明float类型数值时，需要在小数前面加（float）或在小数后面加F
        static void Main(string[] args)
        {
            //decimal myMoney1 = 300.5m;
            //decimal myMoney2 = 300;

            //在浮点型和 decimal 类型之间不存在隐式转换；因此，必须使用强制转换在这两种类型之间进行转换
            //decimal myMoney3 = 99.9m;
            //double x = (double)myMoney3;
            //myMoney3 = (decimal)x;

            //decimal d = 9.1m;
            //int y = 3;
            //Console.WriteLine(d + y);   // Result converted to decimal

            decimal x = 0.999m;
            decimal y = 9999999999999999999999999999.026m;
            decimal z = 1.662m;
            double h = 1.6666;
            Console.WriteLine("My amount = {0:C}", x);
            Console.WriteLine("Your amount = {0:C}", y);
            Console.WriteLine("decimal:{0}", Decimal.Round(z, 2));
            Console.WriteLine("double:{0}", Decimal.Round((decimal)h, 2));
            double temp = 3.1485926;

            string str1 = temp.ToString("f1");//保留一位小数 四舍五入 结果：3.1 
            string str2 = temp.ToString("f2");//保留两位小数，四舍五入 下面一次类推 结果：3.14 
            //(N)Number:string 
            str2 = temp.ToString("N");//保留 结果：3.14 
            //(G)General (default):
            string str3 = temp.ToString("G");//保留 结果：3.1415926
            //(P)Percent:
            string str4 = temp.ToString("P");//保留 结果：314.16% 
            //(E)Scientific:
            string str5 = temp.ToString("E");//保留 结果E:3.141593E+000
            //(C)Currency:
            string str6 = temp.ToString("C");//保留 结果：￥3.14 
            //对于double temp=0.000000926的情况，上述方法都不管用，可以通过转成decimal格式再显示。
            //如下所示： 
            string str7 = ((decimal)temp).ToString();
            Console.WriteLine("str1：{0}", str1);
            Console.WriteLine("str2：{0}", str2);
            Console.WriteLine("str3：{0}", str3);
            Console.WriteLine("str4：{0}", str4);
            Console.WriteLine("str5：{0}", str5);
            Console.WriteLine("str6：{0}", str6);
            Console.WriteLine("str7：{0}", str7);

            //float double 是 基本类型（primitive type），decimal不是。
            //float 有效数字7位，范围 ±1.5 × 10E−45 to ±3.4 × 10E38
            //double 有效数字15/16 位，范围 ±5.0 × 10 E−324 to ±1.7 × 10E308
            //decimal 有效数字 28/29 位，范围 ±1.0 × 10E−28 to ±7.9 × 10E28

            decimal a = 3333333333333333333333333331.2222222222222222222222222222222222222222222m;
            Console.WriteLine("a：{0}", a);//a：1.2222222222222222222222222222  //a：3333333333333333333333333331.2
            double b = 333333333333333333331.222222222222222222222222222222222222222222222222222;
            Console.WriteLine("b：{0}", b);//b：1.22222222222222 //b：3.33333333333333E+20
            Console.ReadKey();
        }

        public void Str()
        {
            //1.   使用 Math.Round() 方法
            //说明：
            //1)   其实使用 Math.Round() 方法，是根据国际标准（五舍六入）的方式进行取舍的。
            //2)   进1的情况有两种：1）保留小数位后面第1位大于等于6；2）保留小数位后面第1位等于5，则第2位必须大于0。
            double double1_1 = Math.Round(1.545, 0);            //2.0
            double double1_2 = Math.Round(1.545, 1);            //1.5
            double double1_3 = Math.Round(1.545, 2);            //1.54
            double double1_4 = Math.Round(1.5451, 2);           //1.55
            double double1_5 = Math.Round(1.546, 2);            //1.55

            //2.   使用 Decimal.Round() 方法
            //说明：小数取舍与 Math.Round() 方法相同。
            decimal decimal2_1 = decimal.Round(1.545m, 0);      //2M
            decimal decimal2_2 = decimal.Round(1.545m, 1);      //1.5M
            decimal decimal2_3 = decimal.Round(1.545m, 2);      //1.54M
            decimal decimal2_4 = decimal.Round(1.5451m, 2);     //1.55M
            decimal decimal2_5 = decimal.Round(1.546m, 2);      //1.55M

            //3.   使用 ToString() + NumberFormatInfo
            //说明：标准的四舍五入法，更适合中国人的习惯哦。
            NumberFormatInfo nfi3_1 = new NumberFormatInfo();
            nfi3_1.NumberDecimalDigits = 0;
            string str3_1 = 1.545d.ToString("N", nfi3_1);       //"2"
            nfi3_1.NumberDecimalDigits = 1;
            string str3_2 = 1.545d.ToString("N", nfi3_1);       //"1.5"
            nfi3_1.NumberDecimalDigits = 2;
            string str3_3 = 1.545d.ToString("N", nfi3_1);       //"1.55"
            nfi3_1.NumberDecimalDigits = 2;
            string str3_4 = 1.5451d.ToString("N", nfi3_1);      //"1.55"
            nfi3_1.NumberDecimalDigits = 2;
            string str3_5 = 1.546d.ToString("N", nfi3_1);       //"1.55"



            //4.   使用 ToString() + 格式化字符
            //说明：标准的四舍五入法，更适合中国人的习惯哦。

            string str4_1_1 = 1.545d.ToString("N0");            //"2"
            string str4_1_2 = 1.545d.ToString("N1");            //"1.5"
            string str4_1_3 = 1.545d.ToString("N2");            //"1.55"
            string str4_1_4 = 1.5451d.ToString("N2");           //"1.55"
            string str4_1_5 = 1.546d.ToString("N2");            //"1.55"

            //ToString() 的简单方法
            string str4_2_6 = 1.545d.ToString("0");             //"2"
            string str4_2_7 = 1.545d.ToString("0.0");           //"1.5"
            string str4_2_8 = 1.545d.ToString("0.00");          //"1.55"
            string str4_2_9 = 1.5451d.ToString("0.00");         //"1.55"
            string str4_2_10 = 1.546d.ToString("0.00");         //"1.55"



            //5.   使用 String.Format() 方法
            //说明：标准的四舍五入法，更适合中国人的习惯哦。

            string str5_1 = string.Format("{0:N0}", 1.545d);    //"2"
            string str5_2 = string.Format("{0:N1}", 1.545d);    //"1.5"
            string str5_3 = string.Format("{0:N2}", 1.545d);    //"1.55"
            string str5_4 = string.Format("{0:N2}", 1.5451d);   //"1.55"
            string str5_5 = string.Format("{0:N2}", 1.546d);    //"1.55"



            //6.   将数字转为“%”百分号字符串
            string str6_1 = 0.545d.ToString("P", new NumberFormatInfo
            {
                PercentDecimalDigits = 2,       //转换后小数保留的位数，默认为2
                PercentPositivePattern = 1      //%号出现的位置：1 数字后面，2 数字前面，默认为0
            }); //"54.50%"
        }
    }
}

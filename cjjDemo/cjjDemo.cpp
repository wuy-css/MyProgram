
#include "HardDriveSerialNumer.h"
#include <iostream>
#include <string.h>
#include <stdio.h>
#pragma warning(disable:4996)
using namespace std;
const int MAX = 3;

void func(int* a) // a是一个指针变量
{
	*a = 20;
}

void func(int& ra) // ra是一个引用
{
	ra = 30;
}
int main()
{
	//-------------------------------指针---------------------------------
	//int  var[MAX] = { 10, 100, 200 };
	//int* ptr;

	//// 指针中的数组地址
	//ptr = var;
	//for (int i = 0; i < MAX; i++)
	//{
	//	cout << "var[" << i << "]的内存地址为 ";
	//	cout << ptr << endl;

	//	cout << "var[" << i << "] 的值为 ";
	//	cout << *ptr << endl;

	//	// 移动到下一个位置
	//	ptr++;
	//}
	//return 0;
	//-----------------------------引用-----------------------------------
	   // 声明简单的变量
	//int    i;
	////int    y;
	//double d;

	//// 声明引用变量
	//int& r = i;
	////int& r = y;
	//double& s = d;

	//i = 5;
	////y = 7;
	//cout << "Value of i : " << i << endl;
	//cout << "Value of i reference : " << r << endl;

	//d = 11.7;
	//cout << "Value of d : " << d << endl;
	//cout << "Value of d reference : " << s << endl;

	//return 0;
	//----------------------------引用的概念----------------------------------
	//引用就是变量的别名，对引用的操作与对变量直接操作完全一样。
	//int a;
	//int& ra = a;  // 定义引用ra，它是变量a的引用，即别名。
	//ra = 1;  等价于  a = 1;
	//----------------------------引用的应用----------------------------------
	//引用的主要作用就是作为函数的参数
	////void func(int* a) // a是一个指针变量
	////{
	////	*a = 20;
	////}

	////void func(int& ra) // ra是一个引用
	////{
	////	ra = 30;
	////}
	//int ii = 0;

	//func(&ii);  // 传递变量的地址
	//printf("1 ii=%d\n", ii);

	//func(ii);   // 引用
	//printf("2 ii=%d\n", ii);
	//------------------------------区分引用和取地址-----------------------------------
	//和类型在一起的是引用，和变量在一起的是取址;引用在赋值 = 的左边，而取地址在赋值的右边

	//int a = 3;
	//int& b = a; //引用
	//int* p = &a; //取地址
	//printf("b=%d\n", b);
	//printf("p地址=%d\n", p);
	//printf("p值=%d\n", *p);
	//----------------------------------打印磁盘序列号-----------------------------------------------
	//int out = 0, i = 10;
	//MasterHardDiskSerial a;
	//char SerialNumber[1024] = { "" };
	////std::cout << "i" << i-- << std::endl;
	//memset(&SerialNumber, 0, sizeof(SerialNumber));
	//out = a.GetSerialNo(SerialNumber);
	//std::cout << "SN " << SerialNumber << std::endl;
	//std::cin >> i;
	//-----------------------------sscanf(解析并转换字符串)---------------------------------------------
	//sscanf通常被用来解析并转换字符串，其格式定义灵活多变，可以实现很强大的字符串解析功能。
	//char str[] = "123456";
	//int num;
	//int a = sscanf(str, "%d", &num);//https://blog.csdn.net/faihung/article/details/119325390
	//cout << a << "," << num << endl;
	//-----------------------------------------sprintf(格式化的数据写入某个字符串)--------------------------------------------
	//格式化的数据写入某个字符串中，即发送格式化输出到 string 所指向的字符串
	//char str[10];
	//int num = 123456;
	//sprintf(str, "%d", num);
	//cout << str;
	//说明1：该函数包含在stdio.h的头文件中，使用时需要加入：#include <stdio.h>
	//说明 2：sprintf与printf函数的区别：二者 功能相似，但是 sprintf函数打印到字符串中，而printf函数打印输出到屏幕上
	//说明3：sprintf函数的格式： int sprintf( char *buffer, const char *format [, argument,…] );
	//除了前两个参数固定外，可选参数可以是任意个。buffer是字符数组名；format是格式化字符串（像："=%6.2f%#x%o", % 与#合用时，自动在十六进制数前面加上0x）。
	//只要在printf中可以使用的格式化字符串，在sprintf都可以使用。其中的格式化字符串是此函数的精华。
	//说明4:可以控制精度
	//char str[20];
	//double f = 14.309948;
	//sprintf(str, "%6.2f", f);
	//cout << str << endl;
	//说明5：可以将多个数值数据连接起来。
	//char str[20];
	//int a = 20984, b = 48090;
	//sprintf(str, "=", a, b);
	//cout << str << endl;
	//说明6：可以将多个字符串连接成字符串
	//char str[20];
	//char s1[] = { 'A','B','C' };
	//char s2[] = { 'T','Y','x' };

	//sprintf(str, "%.3s%.3s", s1, s2);
	//cout << str << endl;
	//%m.n在字符串的输出中，m表示宽度，字符串共占的列数；n表示实际的字符数。%m.n在浮点数中，m也表示宽度；n表示小数的位数。
	//说明7：可以动态指定，需要截取的字符数
	//sprintf(str, "%.*s%.s", 2, s1, 3, s2);
	//sprintf(str, "%.f", 10, 2, 3.1415926);
	//说明8：可以打印出i的地址： sprintf(s, “% p”, &i); 相当于 sprintf(s, "%0x", 2 * sizeof(void*), &i);
	//说明9：sprintf的返回值是字符数组中字符的个数，即字符串的长度，不用在调用strlen(s)求字符串的长度。
	//-------------------------------------------------------------------------------------
	//int arr1[5] = { 0, 1, 2, 3, 4 };
	////数组的指针
	//int(*arrPtr)[5] = &arr1;
	//cout << "arrPtr: " << arrPtr << endl;
	//cout << "*arrPtr:" << *arrPtr << endl;
	//int arr2[5] = { 0, 1, 2, 3, 6 };
	////数组的指针必须指向大小相同的数组
	//arrPtr = &arr2;
	//cout << "arrPtr: " << arrPtr << endl;
	//cout << "*arrPtr:" << *arrPtr << endl;
	////数组的指针指向数组，而数组是不可修改的
	////*arrPtr = arr1
	//-------------------------------------------------------------------------------------
	//	//reinterpret_cast 比较特殊。reinterpret 的意思是重新解读，而reinterpret_cast 
	//	//就是将一段数据按照二进制表示重新解读成另一种数据，
	//	//所以他并没有对数据做任何改变，只是改变了类型。
	//	 //在示例中，可以看到热interpret_cast将一个指向整数的指针转换成了指向字符的指针，也就是c风格的字符串，
	//	 //十六进制的62、63、64在ASCLL码中分别代表b、c、d，所以打印了“bcd”。
	//	 //reinterpret_cast 的作用就是将一个类型的指针转换成另一个类型的指针，
	//	 //而指针指向的内存将被原封不动地重新解读。当然这也是一种比较危险的举动。
	//	//int intNum = 0x00646362;
	//	//int* intPtr = &intNum;
	//	//cout << "*intPtr:" << *intPtr << endl;
	//	//char* str = reinterpret_cast<char*>(intPtr);
	//	//cout << "str的值为:" << str << endl;
	//----------------------------------指针和取址符---------------------------------------------------
	//int num = 4;
	//int* intPtr = &num;
	//cout << "num的地址是：" << &num << endl;
	//cout << "指针的值是:" << intPtr << endl;
	//if (intPtr)
	//{
	//	//检查指针是否为空
	//	cout << "指针所指的数字是：" << *intPtr << endl;
	//}
	//---------------------------------根据指针读取数组----------------------------------------------------
	//int arr[5] = { 0, 1, 2, 3, 4 };
	//int* ptr = arr;
	//for (int i = 0; i < 5; i++)
	//{
	//	cout << *ptr << "    ";
	//	ptr++;
	//	//也可以直接写成 cout << *(ptr++) << " ";
	//}
	//cout << endl;
	//-------------------------------字符取值、字符、取地------------------------------------------------------
	//char* str = (char*)"hello";
	//cout << *str << "\n";
	//cout << str << "\n";
	//cout << &str << "\n";
	//-------------------------------------------------------------------------------------
	//C++里cout太自作聪明了（<<运算符重载），为了省去我们循环输出字符的麻烦，cout<<p;被翻译为输出p指向的字符串值
	//这个时候要输出p的指针值就只能先将其转为void *再输出。因为void型， cout没法输出，只能乖乖输出指针
	//另外说一句int*和其他的是没有问题的
	//const char* pC = "Hello";
	//printf("%0x\n", pC);
	//cout << pC << endl;
	//const void* pV = pC;
	//cout << pV << endl;
	//-------------------------------------------------------------------------------------
	//char aa[] = "Hello";
	//char* p = &aa[0];
	//printf("%s\n", p);
	//printf("%0x \n", p);
	//--------------------------------------数字转字符-----------------------------------------------
	//基于拉丁字母的一套电脑编码系统
	//ASCII码为119的字符--ASCII (American Standard Code for Information Interchange)美国信息交换标准代码
	//char b = 1119;
	//char* a = &b;
	//cout << "指针所指的值是：" << *a << endl;
	//cout << "指针所指的地址是：" << a << endl;
	//-------------------------------------------------------------------------------------
	//	//int i = 1;
	//	//char i = 1;
	//	//char j = '1';
	//-------------------------------------------------------------------------------------
	//const char* p = "string";
	//int con = 123;
	//int* t = &con;
	//cout << p << endl; //输出为p指向的地址单元中的字符串string
	//cout << p << " at " << (int*)p  << endl;//输出为p指向的地址单元的地址
	//cout << t << endl; //输出为t指向的地址单元的地址
	//system("pause");
	//-------------------------------------------------------------------------------------
		// const char*转换为 string，直接赋值即可。
	const char* tmp = "tsinghua";
	string s = tmp;
	//-------------------------------------------------------------------------------------
	//	//string转换为const char* ，利用c_str()
	//	//string s = "tsinghua";
	//	//const char* tmp = s.c_str();
	//-------------------------------------------------------------------------------------
	//	// const char转化为char，利用const_cast<char*>
	//	//const char* tmp = "tsinghua";
	//	//char* p = const_cast<char*>(tmp);
	//-------------------------------------------------------------------------------------
	//	//char转化为const char，直接赋值即可。
	//	//char* p = "tsinghua";
	//	//const char* tmp = p;
	//-------------------------------------------------------------------------------------
	//	//char*转化为string，直接赋值即可。
	//	//char* p = (char*)"tsinghua";
	//	//string str2 = p;
	//-------------------------------------------------------------------------------------
	//	//string转化为char*，走两步，先是string->const char*，然后是const char*->char*
	//	//string str3 = "tsinghua";
	//	//char* p = const_cast<char*>(str3.c_str());
	//-------------------------------------------------------------------------------------
	//	//const char* str1 = "hello";
	//	//const char* str3 = "hello";
	//	//const char str2[] = "hello";
	//	//const char* s = "hello";
	//	//printf("str1:%s str3:%s str2:%s\n", str1, str3, str2);
	//	//str3 = "world";
	//	//printf("str1:%s str3:%s str2:%s\n", str1, str3, str2);
	//	//printf("hello,worldn");

	//-------------------------------------------------------------------------------------
	//	//string s = "hello";
	//	//const char* cp = s.c_str();
	//	//const char* p = "hello";
	//	//cout << cp << ",\n";    //hello
	//	//cout << p << ",\n";     //hello
	//	//cout << *p << endl;    //hello
}
//// cjjDemo.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//#include <iostream>
//#include "stdio.h"
//#include "stdlib.h"
//#include "string.h"
//using namespace std;
//// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
//// 调试程序: F5 或调试 >“开始调试”菜单
//// 入门使用技巧: 
////   1. 使用解决方案资源管理器窗口添加/管理文件
////   2. 使用团队资源管理器窗口连接到源代码管理
////   3. 使用输出窗口查看生成输出和其他消息
////   4. 使用错误列表窗口查看错误
////   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
////   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPSocketDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);//定义一网络端点
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//定义一个Socket
            newsock.Bind(ipep);//Socket与本地的一个终结点相关联
            Console.WriteLine("Waiting for a client.....");
                                                               
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);//定义要发送的计算机的地址
            EndPoint Remote = (EndPoint)(sender);//
            recv = newsock.ReceiveFrom(data, ref Remote);//接受数据          
            Console.WriteLine("Message received from{0}:", Remote.ToString());
            Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));

            string welcome = "Welcome to my test server!";
            data = Encoding.UTF8.GetBytes(welcome);
            newsock.SendTo(data, data.Length, SocketFlags.None, Remote);
            while (true)
            {
                data = new byte[1024];
                recv = newsock.ReceiveFrom(data, ref Remote);
                Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));
                newsock.SendTo(data, recv, SocketFlags.None, Remote);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace ConsoleApp
{
    class Program1
    {
        private static Socket newsock;
        private static EndPoint Remote;
        private static string localIp;

        //static void Main(string[] args)
        //{
        //    ArrayList AllIp = new ArrayList();
        //    string name = Dns.GetHostName();
        //    IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
        //    foreach (IPAddress ipa in ipadrlist)
        //    {
        //        if (ipa.AddressFamily == AddressFamily.InterNetwork)
        //            localIp = ipa.ToString();
        //        if (checkip(localIp))
        //        {
        //            AllIp.Add(localIp);
        //            Console.WriteLine("IPv4地址：" + localIp);
        //        }
        //    }
        //    localIp = AllIp[0].ToString();  //如有多个网卡可选任意一个            
        //    ReceviceData();
        //}

        private static bool checkip(string ipstr)   //判断IP是否合法
        {
            IPAddress ip;
            if (IPAddress.TryParse(ipstr, out ip))
            { return true; }
            else { return false; }
        }

        static void ReceviceData()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(localIp), 39169);
            newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newsock.Bind(ipep);
            Console.WriteLine("绑定地址：" + localIp + ":39169\n");
            //发送信息
            byte[] sendbuf = new byte[1];
            sendbuf[0] = 0xa6; //搜寻所有连线的读卡器命令

            IPEndPoint ipep1 = new IPEndPoint(IPAddress.Broadcast, 39169);
            Remote = (EndPoint)(ipep1);
            newsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);//设为广播式发送
            newsock.SendTo(sendbuf, 1, SocketFlags.None, Remote);
            Console.WriteLine("SendTo：" + (Convert.ToString(Remote) + "                      ").Substring(0, 21) + " Data：A6");

            Thread thread = new Thread(new ThreadStart(GetData));
            thread.Start();
        }

        static void GetData()
        {
            try
            {
                byte[] buf = new byte[1024];
                byte[] sendbuf = new byte[255];
                byte[] revbufheadbak = new byte[20];
                while (true)
                {
                    if (newsock == null || newsock.Available < 1)
                    {
                        Thread.Sleep(20);
                        continue;
                    }

                    //接受UDP数据包
                    int recv = newsock.ReceiveFrom(buf, ref Remote);
                    string RemoteIP = Convert.ToString(Remote).Split(':')[0];                 //sock来源IP
                    int RemotePort = Convert.ToInt32(Convert.ToString(Remote).Split(':')[1]); //Sock来源端口

                    string recestr = "FromIP：" + (Convert.ToString(Remote) + "                      ").Substring(0, 21) + " Data：";       //将接收到的数据显示
                    for (int i = 0; i < recv; i++)
                    {
                        recestr = recestr + buf[i].ToString("X2") + " ";
                    }
                    Console.WriteLine(recestr);

                    if (recv > 8)
                    {
                        if (buf[0] == revbufheadbak[0] && buf[1] == revbufheadbak[1] && buf[2] == revbufheadbak[2] && buf[3] == revbufheadbak[3] && buf[4] == revbufheadbak[4] && buf[5] == revbufheadbak[5] && buf[6] == revbufheadbak[6] && buf[7] == revbufheadbak[7] && buf[8] == revbufheadbak[8])
                        {
                            DisableSendAge(buf, RemoteIP, RemotePort);  //是重复接收的数据包，回应确认接收，不做处理
                            return;
                        }
                        else
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                revbufheadbak[i] = buf[i];  //将当前接收到的数据前9个字节保存，用于再次接收到数据时比对
                            }
                        }
                    }

                    switch (buf[0])
                    {
                        case 0xf2://读卡器响应服务器的搜索指令、上电开机时上传信息
                            Console.WriteLine("数据解析：读卡器上电开机、响应搜索指令的返回信息");
                            Console.WriteLine("功能码：" + buf[0].ToString("X2"));
                            Console.WriteLine("读卡器IP：" + buf[1].ToString("D") + "." + buf[2].ToString("D") + "." + buf[3].ToString("D") + "." + buf[4].ToString("D"));
                            Console.WriteLine("读卡器掩码：" + buf[5].ToString("D") + "." + buf[6].ToString("D") + "." + buf[7].ToString("D") + "." + buf[8].ToString("D"));
                            Console.WriteLine("通讯端口：" + (buf[9] + buf[10] * 256).ToString("D"));
                            Console.WriteLine("机号：" + (buf[11] + buf[12] * 256).ToString("D"));
                            Console.WriteLine("网关：" + buf[13].ToString("D") + "." + buf[14].ToString("D") + "." + buf[15].ToString("D") + "." + buf[16].ToString("D"));
                            Console.WriteLine("网关MAC：" + buf[17].ToString("X2") + "-" + buf[18].ToString("X2") + "-" + buf[19].ToString("X2") + "-" + buf[20].ToString("X2") + "-" + buf[21].ToString("X2") + "-" + buf[22].ToString("X2"));
                            Console.WriteLine("目标服务器IP：" + buf[23].ToString("D") + "." + buf[24].ToString("D") + "." + buf[25].ToString("D") + "." + buf[26].ToString("D"));
                            Console.WriteLine("服务器MAC：" + buf[27].ToString("X2") + "-" + buf[28].ToString("X2") + "-" + buf[29].ToString("X2") + "-" + buf[30].ToString("X2") + "-" + buf[31].ToString("X2") + "-" + buf[32].ToString("X2"));
                            Console.WriteLine("网络标识：" + buf[33].ToString("X2"));
                            Console.WriteLine("响声标识：" + buf[34].ToString("X2"));
                            Console.WriteLine("通讯模块号：" + buf[35].ToString("D") + "-" + buf[36].ToString("D") + "-" + buf[37].ToString("D") + "-" + buf[38].ToString("D"));
                            if (recv > 38)
                            {
                                string SerialNum = "";
                                for (int i = 38; i < recv; i++)
                                {
                                    SerialNum = SerialNum + buf[i].ToString("X2");
                                }
                                Console.WriteLine("唯一设备标识：" + SerialNum + "\n");
                            }
                            break;
                        case 0xf3://读卡器发送的心跳数据包

                            break;
                        case 0xf8://

                            break;
                        case 0xc1://IC只读卡号返回   
                            DisableSendAge(buf, RemoteIP, RemotePort); //确定接收到数据包，否则读卡器会发三次
                            Console.WriteLine("数据解析：接收到的信息是IC只读卡号数据包");
                            Console.WriteLine("功能码：" + buf[0].ToString("X2"));
                            Console.WriteLine("读卡器IP：" + buf[1].ToString("D") + "." + buf[2].ToString("D") + "." + buf[3].ToString("D") + "." + buf[4].ToString("D"));
                            Console.WriteLine("机号：" + (buf[5] + buf[6] * 256).ToString("D"));
                            Console.WriteLine("包序号：" + (buf[7] + buf[8] * 256).ToString("D"));
                            Console.WriteLine("16进制卡号：" + buf[10].ToString("X2") + buf[11].ToString("X2") + buf[12].ToString("X2") + buf[13].ToString("X2"));
                            uint cardhao = (uint)(buf[13] * 256 * 256 * 256 + buf[12] * 256 * 256 + buf[11] * 256 + buf[10]);
                            string cardnum = cardhao.ToString("D10");
                            Console.WriteLine("换算成10进制卡号：" + cardnum);
                            if (recv > 14)
                            {
                                string SerialNum = "";
                                for (int i = 14; i < recv; i++)
                                {
                                    SerialNum = SerialNum + buf[i].ToString("X2");
                                }
                                Console.WriteLine("唯一设备标识：" + SerialNum + "\n");
                            }

                            //此处可加入业务对数据库的查、增、删、改

                            SendDispBeep(cardnum, RemoteIP, RemotePort);
                            break;
                        case 0xc2://接收到IC读卡器的按键信息
                        case 0xd2://接收到ID读卡器的按键信息
                            break;
                        case 0xc3://IC全扇区读写器主动读取扇区信息返回
                            break;
                        case 0xc5://IC全扇区读写器指定区号、密码读扇区内容返回
                            break;
                        case 0xcd://IC全扇区读写器指定区号、密码写卡及更改密码返回
                            break;
                        case 0xcf://接收到IC卡离开读卡器的信息
                        case 0xdf://接收到ID卡离开读卡器的信息
                            break;
                        case 0xd1://ID读卡器读卡后返回
                            DisableSendAge(buf, RemoteIP, RemotePort); //确定接收到数据包，否则读卡器会发三次
                            Console.WriteLine("数据解析：接收到的信息是IC只读卡号数据包");
                            Console.WriteLine("功能码：" + buf[0].ToString("X2"));
                            Console.WriteLine("读卡器IP：" + buf[1].ToString("D") + "." + buf[2].ToString("D") + "." + buf[3].ToString("D") + "." + buf[4].ToString("D"));
                            Console.WriteLine("机号：" + (buf[5] + buf[6] * 256).ToString("D"));
                            Console.WriteLine("包序号：" + (buf[7] + buf[8] * 256).ToString("D"));
                            Console.WriteLine("16进制卡号：" + buf[9].ToString("X2") + buf[10].ToString("X2") + buf[11].ToString("X2") + buf[12].ToString("X2"));
                            cardhao = (uint)(buf[12] * 256 * 256 * 256 + buf[11] * 256 * 256 + buf[10] * 256 + buf[9]);
                            cardnum = cardhao.ToString("D10");
                            Console.WriteLine("换算成10进制卡号：" + cardnum);
                            if (recv > 14)
                            {
                                string SerialNum = "";
                                for (int i = 14; i < recv; i++)
                                {
                                    SerialNum = SerialNum + buf[i].ToString("X2");
                                }
                                Console.WriteLine("唯一设备标识：" + SerialNum + "\n");
                            }

                            //此处可加入业务对数据库的查、增、删、改

                            SendDispBeep(cardnum, RemoteIP, RemotePort);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DisableSendAge(byte[] buf, string RemortIpStr, int RemortPortInt)
        {   //回应已接收到数据包，否则读卡器会连发三次
            buf[0] = 0x69;
            IPEndPoint client = new IPEndPoint(IPAddress.Parse(RemortIpStr), RemortPortInt);
            newsock.SendTo(buf, 9, SocketFlags.None, client);
            string SendInf = "SendTo：" + (Convert.ToString(client) + "                      ").Substring(0, 21) + " Data：";
            for (int i = 0; i < 9; i++)
            {
                SendInf = SendInf + buf[i].ToString("X2") + " ";
            }
            Console.WriteLine(SendInf);
        }

        static void SendDispBeep(string cardnum, string RemortIpStr, int RemortPortInt)
        {   //向读卡器发送显示文字及蜂鸣响声
            string DispInf = "卡号:" + cardnum + "  " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "            ";//发送的显示文字
            byte[] strlsansi = System.Text.Encoding.GetEncoding(936).GetBytes(DispInf);//显示文字转换为Ansi
            byte[] Sendbyte = new byte[39];
            Sendbyte[0] = 0x5a;  //指令码
            Sendbyte[1] = 0x00;  //机号低位
            Sendbyte[2] = 0x00;  //机号高位，如果高低位都为0表示任意机号
            Sendbyte[3] = 0x02;  //蜂鸣响声代码，共12种不代响声代码
            Sendbyte[4] = 0x14;  //显示时长
            for (int i = 0; i < 34; i++)
            {
                Sendbyte[i + 5] = strlsansi[i];
            }

            IPEndPoint client = new IPEndPoint(IPAddress.Parse(RemortIpStr), RemortPortInt);
            newsock.SendTo(Sendbyte, 39, SocketFlags.None, client);
            string SendInf = "SendTo：" + (Convert.ToString(client) + "                      ").Substring(0, 21) + " Data：";
            for (int i = 0; i < 39; i++)
            {
                SendInf = SendInf + Sendbyte[i].ToString("X2") + " ";
            }
            Console.WriteLine(SendInf + "\n");
        }
    }
}
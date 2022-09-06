using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp4.Method
{
    public class UDPclient
    {

        static UDPclient instance;
        public static UDPclient Instance
        {
            get
            {
                if (instance == null)
                    instance = new UDPclient();
                return instance;
            }
        }

        Socket sock;
        //本机ip、端口
        IPEndPoint ip;
        //用来接收消息的any
        EndPoint ipany;

        //接收方的IP端口
        IPEndPoint ie;

        Thread ReceiveListern;
        //Dictionary<string, NetObject> netObjectDic = new Dictionary<string, NetObject>();//网络对象字典
        public void ConnectStart(int port)
        {
            //Debuger.EnableSave = true;
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);//开启群发功能
            //ie = new IPEndPoint(IPAddress.Broadcast,5555);//广播端口
            ip = new IPEndPoint(IPAddress.Parse(GetHostIpAddress()), port);
            sock.Bind(ip);
            Debug.WriteLine("服务器启动了");
            //
            IPEndPoint end = new IPEndPoint(IPAddress.Any, 0);
            ipany = (EndPoint)end;

            ReceiveListern = new Thread(Receive);
            ReceiveListern.Start();


        }
        public string str;
        public bool isaccept;
        //收消息
        public void Receive()
        {
            while (true)
            {
                byte[] byt = new byte[1024];
                int length = sock.ReceiveFrom(byt, ref ipany);
                if (length > 0)
                {
                    isaccept = true;
                    str = Encoding.UTF8.GetString(byt, 0, length);
                    Debug.WriteLine(string.Format("收到主机:{0}发来的消息|{1}", ipany, str));
                }
            }
        }
        //发消息 单发
        public void SendMessage(string msg)
        {
            byte[] byt = new byte[1024];//1K
            byt = Encoding.UTF8.GetBytes(msg);
            //sock.SendTo(byt, byt.Length, SocketFlags.None,ie);//ie为接收方的iP端口
        }

        //动态获取自身ip
        private string GetHostIpAddress()
        {
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    return ipa.ToString();
            }
            return "";
        }

        //释放线程、Sock资源
        public void Close1()
        {
            if (ReceiveListern != null)
            {
                ReceiveListern.Abort();
            }
            if (sock != null)
            {
                sock.Close();
            }
            //Debuger.Dispose();
        }
    }
}

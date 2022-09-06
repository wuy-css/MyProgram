using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketDemo
{
    public enum Commands
    {
        requestVideoCapital = 1,//请求获取视频
        requestSendPacket = 2,//请求发送数据包
        ResponseSendPacket = 3,//回应发送数据包
        ResponseEndPacket = 4//数据包传送结束

    }
}

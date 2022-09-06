using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketDemo
{
    /// <summary>
    /// 分包
    /// </summary>
    public class PacketSplitter
    {
        private byte[] imageBuffer;
        public PacketSplitter()
        {
            //CopyData(data);
            //https://www.cnblogs.com/MRRAOBX/articles/3402721.html
        }

        private void CopyData(byte[] data)
        {
            if (imageBuffer == null)
            {
                imageBuffer = data;
                return;
            }
            byte[] buffer = new byte[imageBuffer.Length + data.Length];
            Buffer.BlockCopy(imageBuffer, 0, buffer, 0, imageBuffer.Length);
            Buffer.BlockCopy(data, 0, buffer, imageBuffer.Length, data.Length);
            imageBuffer = buffer;
        }

        private static int defaultPartSize = 1024;
        /// <summary>
        /// 分包
        /// </summary>
        /// <param name="datagram">数据包</param>
        /// <param name="partSize">块大小（小于1024*64）</param>
        /// <returns>分包列表</returns>
        public static List<Packet> Split(byte[] datagram, int partSize)
        {
            defaultPartSize = partSize;
            return Split(datagram);

        }

        /// <summary>
        /// 分包
        /// </summary>
        /// <param name="datagram">数据包（使用默认块大小：1024 byte)</param>
        /// <returns>分包列表</returns>
        public static List<Packet> Split(byte[] datagram)
        {
            List<Packet> packets = new List<Packet>();
            if (datagram == null)
                return null;
            if (datagram.Length <= defaultPartSize)
            {
                packets.Add(new Packet(0, datagram, 1));
                return packets;
            }
            int _length = datagram.Length;
            int counts = _length / defaultPartSize;
            int remainder = _length % defaultPartSize;
            int tatal = counts;
            if (remainder > 0)
                counts++;
            for (int i = 0; i < counts; i++)
            {
                int _size = defaultPartSize;
                if (_length - defaultPartSize * i < defaultPartSize)
                    _size = _length - defaultPartSize * i;
                byte[] tmp = new byte[_size];
                Buffer.BlockCopy(datagram, defaultPartSize * i, tmp, 0, _size);
                int state = 2;
                if (i == 0)
                    state = 1;
                if (i == counts - 1)
                    state = 3;
                packets.Add(new Packet(i, tmp, state));
            }
            return packets;
        }
    }
}

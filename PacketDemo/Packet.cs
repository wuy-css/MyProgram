using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketDemo
{
    /// <summary>
    /// 包类
    /// </summary>
    public class Packet
    {
        private int _index;
        private byte[] _data;
        private int _state;
        public Packet(int index, byte[] buffer, int state)
        {
            this._index = index;
            this._data = buffer;
            this._state = state;
        }
        /// <summary>
        /// 索引序号
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        /// <summary>
        /// 数据
        /// </summary>
        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }
        /// <summary>
        /// 状态，用来记录包的开始和结束。1：开始，2：中间，3：包尾。
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}

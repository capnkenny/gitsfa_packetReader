using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pktReader
{
    class DataPacket
    {
        public bool clientPkt;
        public string _sourceIp, _destIp;
        public string _data;
        public int _pktSize;
        public int PacketNumber { get; set; }
        public string Timestamp { get; set; }
        public const string _PKTHEADER = "1357";
        public ushort _sz;

        public DataPacket()
        {
            _sourceIp = "";
            _destIp = "";
            _data = "";
            _pktSize = 0;
            clientPkt = false;
        }

        public DataPacket(string source, string dest, string data, int size, string timestamp, int num)
        {
            _sourceIp = source;
            _destIp = dest;
            _data = data;
            Timestamp = timestamp;
            _sz = determineSize(_data.Substring(6, 4));
            _pktSize = size;
            PacketNumber = num;
            clientPkt = false;
        }

        public ushort determineSize(string input)
        {
            var bitOne = input.Substring(0, 2);
            var bitTwo = input.Substring(2, 2);
            var littleEnd = bitTwo + bitOne;

            return UInt16.Parse(littleEnd, System.Globalization.NumberStyles.HexNumber);
        }

        public void setIfClient(int val)
        {
            clientPkt = (val == 1 ? true : false);
            var ts = Timestamp;
            if (clientPkt)
            {
                Timestamp = "Client: " + ts;
            }
            else
            {
                Timestamp = "Server: " + ts;
            }
        }
    }
}

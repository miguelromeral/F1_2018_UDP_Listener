using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_2018_Telemetry_Listener_CSharp.Packets
{
    class PacketHeader
    {
        /// /////////////////////////////////////////////////////////////
        //                                                             //
        //                            HEADER                           //
        //                                                             //
        /// /////////////////////////////////////////////////////////////
        
        public const int HEADER_SIZE = 21;
        public const int PACKET_FORMAT = 2018;

        UInt16 packetFormat;
        uint packetVersion;
        uint packetId;
        UInt64 sessionUID;
        float sessionTime;
        uint frameIdentifier;
        uint playerCarIndex;
        
        public PacketHeader(byte[] content)
        {
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(content);

            this.packetFormat = BitConverter.ToUInt16(content, 0);
            this.packetVersion = content[2];
            this.packetId = content[3];
            this.sessionUID = BitConverter.ToUInt64(content, 4);
            this.sessionTime = BitConverter.ToSingle(content, 12);
            this.frameIdentifier = content[19];
            this.playerCarIndex = content[20];
        }
        
        public String ToString()
        {
            return "Packet Format: " + packetFormat + "\n"
                + "Version: " + packetVersion + "\n"
                + "ID: " + packetId + "\n"
                + "Session UID: " + sessionUID + "\n"
                + "Session Time: " + TimeSpan.FromSeconds((double)(new decimal(sessionTime))) + "\n"
                + "Frame Identifier: " + frameIdentifier + "\n"
                + "Player Car Index: " + playerCarIndex+ "\n"
                ;
        }
    }
}

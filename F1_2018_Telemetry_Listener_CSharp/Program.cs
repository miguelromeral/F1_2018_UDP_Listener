using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using F1_2018_Telemetry_Listener_CSharp.Packets;

namespace F1_2018_Telemetry_Listener_CSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("It's ready!");

            int port = 18027;

            // This constructor arbitrarily assigns the local port number.
            UdpClient udpClient = new UdpClient(port);
            try
            {
                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                while (true)
                {
                    // Blocks until a message returns on this socket from a remote host.
                    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);

                    PacketHeader packet = new PacketHeader(receiveBytes);

                    Console.WriteLine("Received:\n" + packet.ToString());
                    
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                udpClient.Close();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace TeleDotNet.MTProto.TCP
{
    public class TcpTransport
    {
        public delegate void PacketReceivedCallback(TcpMessage incomingPacket);

        private readonly List<byte> _buffer = new List<byte>();
        private PacketReceivedCallback _callback;

        private readonly Socket _socket;
      
        private int _seqNo;

        public TcpTransport(string address, int port)
        {
            _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(address, port);

            new Thread(() =>
            {
                while (true)
                {
                    var buffer = new byte[1024];
                    var bytesReceived = 0;
                    try
                    {
                        while ((bytesReceived = _socket.Receive(buffer)) > 0)
                        {
                            _buffer.AddRange(buffer.ToList().GetRange(0, bytesReceived));
                            _socket.ReceiveTimeout = 100;
                        }
                    }
                    catch (SocketException ex)
                    {
                    }

                    DecodePacket();

                    _socket.ReceiveTimeout = 0;
                }
            }).Start();
        }

        private void DecodePacket()
        {
            var decodedMessage = TcpMessage.Decode(_buffer.ToArray());
            _buffer.Clear();

            // Console.WriteLine(
            //    $"Message #{decodedMessage.SequneceNumber} Received : \n {BitConverter.ToString(decodedMessage.Body).Replace("-", "")}");
            _callback?.Invoke(decodedMessage);
        }

        public void SetCallback(PacketReceivedCallback callback)
        {
            _callback = callback;
        }

        public void Send(byte[] data)
        {
            if (!IsConnected())
                throw new InvalidOperationException("Client not connected to server.");

            var tcpMessage = new TcpMessage(_seqNo, data);

            _socket.Send(tcpMessage.Encode());
            _seqNo++;
        }

        public bool IsConnected()
        {
            return _socket.Connected;
        }

       
    }
}
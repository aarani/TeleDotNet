using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TeleDotNet.MTProto.Crypto;
using TeleDotNet.MTProto.TCP;
using TeleDotNet.TL;
using static TeleDotNet.MTProto.Helpers.Helpers;

namespace TeleDotNet.MTProto
{
    public class MtProtoSender
    {
        public delegate void ObjectReceivedCallback(TLObject incomingObject);

        private readonly Session _session;
        private readonly TcpTransport _transport;
        private int sequence = 0;
        private int timeOffset;
        private long lastMessageId;
        private Random random;
        private Dictionary<int, ObjectReceivedCallback> _callbacks;

        public MtProtoSender(TcpTransport transport, Session session)
        {
            random = new Random();
            transport.SetCallback(InnerCallback);
            _callbacks = new Dictionary<int, ObjectReceivedCallback>();
            _transport = transport;
            _session = session;
        }

        private void InnerCallback(TcpMessage message)
        {
            object Object = null;
            using (var memStream = new MemoryStream(message.Body))
            using (var binaryReader = new BinaryReader(memStream))
            {
                if (binaryReader.BaseStream.Length < 8)
                    throw new InvalidOperationException($"Can't decode packet");
                
                ulong remoteAuthKeyId = binaryReader.ReadUInt64();
                
                if (remoteAuthKeyId == 0)
                {
                    long messageId = binaryReader.ReadInt64();
                    int messageLength = binaryReader.ReadInt32();
                    if (memStream.Length - memStream.Position == messageLength)
                    {
                        Object = ObjectUtils.DeserializeObject(binaryReader);    
                    }
                    else
                    {
                        throw new InvalidOperationException("Oops! Incomplete packet detected. Skip!");
                    }
                    if (_callbacks.ContainsKey((Object as TLObject).Constructor))
                    {
                        _callbacks[(Object as TLObject).Constructor](Object as TLObject);
                    }
                }
                
                
            }
        }

        private int GenerateSequence(bool confirmed)
        {
            return confirmed ? _session.Sequence++ * 2 + 1 : _session.Sequence * 2;
        }

        public void AddCallback(int constructor, ObjectReceivedCallback callback)
        {
            _callbacks.Add(constructor, callback);
        }

        public long Send(TLMethod request)
        {
            byte[] packet;
            using (var memory = new MemoryStream())
            using (var writer = new BinaryWriter(memory))
            {
                request.SerializeBody(writer);
                packet = memory.ToArray();
            }

            if (request.GetType().Name.StartsWith("TL"))
            {
                var messageId = _session.GetNewMessageId();

                byte[] alignedData;
                using (var plaintextPacket = MakeMemory(8 + 8 + 8 + 4 + 4 + packet.Length))
                {
                    using (var plaintextWriter = new BinaryWriter(plaintextPacket))
                    {
                        plaintextWriter.Write(_session.Salt);
                        plaintextWriter.Write(_session.Id);
                        plaintextWriter.Write(messageId);
                        plaintextWriter.Write(GenerateSequence(!request.GetType().Name.StartsWith("ML")));
                        plaintextWriter.Write(packet.Length);
                        plaintextWriter.Write(packet);

                        alignedData = CryptoUtils.Align(plaintextPacket.GetBuffer(), 16);
                    }
                }

                var last32 = new byte[32];
                Array.Copy(_session.AuthKey.Data, _session.AuthKey.Data.Length - 32, last32, 0, 32);

                var msgKey = CryptoUtils.CalculateMessageKey(last32.Concat(alignedData).ToArray());
                var ciphertext =
                    AES.EncryptAES(CryptoUtils.CalculateAesData(alignedData, _session.AuthKey.Data, msgKey, true),
                        alignedData);

                using (var ciphertextPacket = MakeMemory(8 + 16 + ciphertext.Length))
                {
                    using (var writer = new BinaryWriter(ciphertextPacket))
                    {
                        writer.Write(_session.AuthKey.Id);
                        writer.Write(msgKey);
                        writer.Write(ciphertext);

                        _transport.Send(ciphertextPacket.GetBuffer());
                    }
                }

                return messageId;
            }
            else
            {
                long messageId = GetNewMessageId();
                using (var memoryStream = new MemoryStream())
                {
                    using (var binaryWriter = new BinaryWriter(memoryStream))
                    {
                        binaryWriter.Write((long) 0);
                        binaryWriter.Write(messageId);
                        binaryWriter.Write(packet.Length);
                        binaryWriter.Write(packet);

                        byte[] packetData = memoryStream.ToArray();

                        _transport.Send(packetData);
                    }
                }

                return messageId;
            }
        }

        private long GetNewMessageId()
        {
            long time = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds);
            long newMessageId = ((time / 1000 + timeOffset) << 32) |
                                ((time % 1000) << 22) |
                                (random.Next(524288) << 2); // 2^19
            // [ unix timestamp : 32 bit] [ milliseconds : 10 bit ] [ buffer space : 1 bit ] [ random : 19 bit ] [ msg_id type : 2 bit ] = [ msg_id : 64 bit ]

            if (lastMessageId >= newMessageId)
            {
                newMessageId = lastMessageId + 4;
            }

            lastMessageId = newMessageId;
            return newMessageId;
        }
    }
}
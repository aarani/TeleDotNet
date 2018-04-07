using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-1631450872)]
    public class MLNewSessionCreated : TLObject
    {
        public override int Constructor => -1631450872;

        public long FirstMsgId { get; set; }
        public long UniqueId { get; set; }
        public long ServerSalt { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            FirstMsgId = br.ReadInt64();
            UniqueId = br.ReadInt64();
            ServerSalt = br.ReadInt64();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(FirstMsgId);
            bw.Write(UniqueId);
            bw.Write(ServerSalt);
        }
    }
}
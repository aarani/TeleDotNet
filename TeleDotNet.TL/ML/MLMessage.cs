using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(1538843921)]
    public class MLMessage : TLObject
    {
        public override int Constructor => 1538843921;

        public long MsgId { get; set; }
        public int Seqno { get; set; }
        public int Bytes { get; set; }
        public object Body { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            MsgId = br.ReadInt64();
            Seqno = br.ReadInt32();
            Bytes = br.ReadInt32();
            Body = ObjectUtils.DeserializeObject(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(MsgId);
            bw.Write(Seqno);
            bw.Write(Bytes);
            ObjectUtils.SerializeObject(Body, bw);
        }
    }
}
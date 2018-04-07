using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(661470918)]
    public class MLMsgDetailedInfo : MLAbsMsgDetailedInfo
    {
        public override int Constructor => 661470918;

        public long MsgId { get; set; }
        public long AnswerMsgId { get; set; }
        public int Bytes { get; set; }
        public int Status { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            MsgId = br.ReadInt64();
            AnswerMsgId = br.ReadInt64();
            Bytes = br.ReadInt32();
            Status = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(MsgId);
            bw.Write(AnswerMsgId);
            bw.Write(Bytes);
            bw.Write(Status);
        }
    }
}
using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-2137147681)]
    public class MLMsgNewDetailedInfo : MLAbsMsgDetailedInfo
    {
        public override int Constructor => -2137147681;

        public long AnswerMsgId { get; set; }
        public int Bytes { get; set; }
        public int Status { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            AnswerMsgId = br.ReadInt64();
            Bytes = br.ReadInt32();
            Status = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(AnswerMsgId);
            bw.Write(Bytes);
            bw.Write(Status);
        }
    }
}
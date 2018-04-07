using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-307542917)]
    public class MLBadServerSalt : MLAbsBadMsgNotification
    {
        public override int Constructor => -307542917;

        public long BadMsgId { get; set; }
        public int BadMsgSeqno { get; set; }
        public int ErrorCode { get; set; }
        public long NewServerSalt { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            BadMsgId = br.ReadInt64();
            BadMsgSeqno = br.ReadInt32();
            ErrorCode = br.ReadInt32();
            NewServerSalt = br.ReadInt64();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(BadMsgId);
            bw.Write(BadMsgSeqno);
            bw.Write(ErrorCode);
            bw.Write(NewServerSalt);
        }
    }
}
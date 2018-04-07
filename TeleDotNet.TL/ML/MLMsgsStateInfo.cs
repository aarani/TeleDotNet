using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(81704317)]
    public class MLMsgsStateInfo : TLObject
    {
        public override int Constructor => 81704317;

        public long ReqMsgId { get; set; }
        public byte[] Info { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            ReqMsgId = br.ReadInt64();
            Info = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ReqMsgId);
            BytesUtil.Serialize(Info, bw);
        }
    }
}
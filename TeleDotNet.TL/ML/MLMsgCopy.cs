using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-530561358)]
    public class MLMsgCopy : TLObject
    {
        public override int Constructor => -530561358;

        public MLMessage OrigMessage { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            OrigMessage = (MLMessage) ObjectUtils.DeserializeObject(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(OrigMessage, bw);
        }
    }
}
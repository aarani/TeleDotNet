using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(1945237724)]
    public class MLMsgContainer : TLObject
    {
        public override int Constructor => 1945237724;

        public TLVector<MLMessage> Messages {
            get;
            set;
        }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Messages = (TLVector<MLMessage>)ObjectUtils.DeserializeVector<MLMessage>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Messages, bw);
        }
    }
}
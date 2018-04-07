using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-630588590)]
    public class MLMsgsStateReq : TLObject
    {
        public override int Constructor => -630588590;

        public TLVector<long> MsgIds { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            MsgIds = ObjectUtils.DeserializeVector<long>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(MsgIds, bw);
        }
    }
}
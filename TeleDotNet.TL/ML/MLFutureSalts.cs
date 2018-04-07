using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-1370486635)]
    public class MLFutureSalts : TLObject
    {
        public override int Constructor => -1370486635;

        public long ReqMsgId { get; set; }
        public int Now { get; set; }
        public TLVector<MLFutureSalt> Salts { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            ReqMsgId = br.ReadInt64();
            Now = br.ReadInt32();
            Salts = (TLVector<MLFutureSalt>) ObjectUtils.DeserializeVector<MLFutureSalt>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ReqMsgId);
            bw.Write(Now);
            ObjectUtils.SerializeObject(Salts, bw);
        }
    }
}
using System.IO;
using System.Numerics;

namespace TeleDotNet.TL.ML
{
    [TLObject(85337187)]
    public class MLResPq : TLObject
    {
        public override int Constructor => 85337187;

        public BigInteger Nonce { get; set; }
        public BigInteger ServerNonce { get; set; }
        public byte[] Pq { get; set; }
        public TLVector<long> ServerPublicKeyFingerprints { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = ObjectUtils.DeserializeBigInteger(16, br);
            ServerNonce = ObjectUtils.DeserializeBigInteger(16, br);
            Pq = BytesUtil.Deserialize(br);
            ServerPublicKeyFingerprints = ObjectUtils.DeserializeVector<long>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Nonce.ToByteArray());
            bw.Write(ServerNonce.ToByteArray());
            BytesUtil.Serialize(Pq, bw);
            ObjectUtils.SerializeObject(ServerPublicKeyFingerprints, bw);
        }
    }
}
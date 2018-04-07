using System.IO;
using BigMath;

namespace TeleDotNet.TL.ML
{
    [TLObject(-2083955988)]
    public class MLPQInnerData : MLAbsPQInnerData
    {
        public override int Constructor => -2083955988;

        public byte[] PQ { get; set; }
        public byte[] P { get; set; }
        public byte[] Q { get; set; }
        public System.Numerics.BigInteger Nonce { get; set; }
        public System.Numerics.BigInteger ServerNonce { get; set; }
        public System.Numerics.BigInteger NewNonce { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PQ = BytesUtil.Deserialize(br);
            P = BytesUtil.Deserialize(br);
            Q = BytesUtil.Deserialize(br);
            Nonce = ObjectUtils.DeserializeBigInteger(16, br);
            ServerNonce = ObjectUtils.DeserializeBigInteger(16, br);
            NewNonce = ObjectUtils.DeserializeBigInteger(32, br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            BytesUtil.Serialize(PQ, bw);
            BytesUtil.Serialize(P, bw);
            BytesUtil.Serialize(Q, bw);
            bw.Write(Nonce.ToByteArray());
            bw.Write(ServerNonce.ToByteArray());
            bw.Write(NewNonce.ToByteArray());
        }
    }
}
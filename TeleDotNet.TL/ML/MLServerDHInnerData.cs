using System.IO;
using System.Numerics;

namespace TeleDotNet.TL.ML
{
    [TLObject(-1249309254)]
    public class MLServerDhInnerData : TLObject
    {
        public override int Constructor => -1249309254;

        public BigInteger Nonce { get; set; }
        public BigInteger ServerNonce { get; set; }
        public int G { get; set; }
        public byte[] DhPrime { get; set; }
        public byte[] Ga { get; set; }
        public int ServerTime { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = ObjectUtils.DeserializeBigInteger(16, br);
            ServerNonce = ObjectUtils.DeserializeBigInteger(16, br);
            G = br.ReadInt32();
            DhPrime = BytesUtil.Deserialize(br);
            Ga = BytesUtil.Deserialize(br);
            ServerTime = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Nonce.ToByteArray());
            bw.Write(ServerNonce.ToByteArray());
            bw.Write(G);
            BytesUtil.Serialize(DhPrime, bw);
            BytesUtil.Serialize(Ga, bw);
            bw.Write(ServerTime);
        }
    }
}
using System.IO;
using System.Numerics;

namespace TeleDotNet.TL.ML
{
    [TLObject(1715713620)]
    public class MLClientDHInnerData : TLObject
    {
        public override int Constructor => 1715713620;

        public BigInteger Nonce { get; set; }
        public BigInteger ServerNonce { get; set; }
        public long RetryId { get; set; }
        public byte[] Gb { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = ObjectUtils.DeserializeBigInteger(16, br);
            ServerNonce = ObjectUtils.DeserializeBigInteger(16, br);
            RetryId = br.ReadInt64();
            Gb = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Nonce.ToByteArray());
            bw.Write(ServerNonce.ToByteArray());
            bw.Write(RetryId);
            BytesUtil.Serialize(Gb, bw);
        }
    }
}
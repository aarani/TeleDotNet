using System.IO;
using System.Numerics;

namespace TeleDotNet.TL.ML
{
    [TLObject(-790100132)]
    public class MLServerDhParamsOk : MLAbsServerDHParams
    {
        public override int Constructor => -790100132;

        public BigInteger Nonce { get; set; }
        public BigInteger ServerNonce { get; set; }
        public byte[] EncryptedAnswer { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = ObjectUtils.DeserializeBigInteger(16, br);
            ServerNonce = ObjectUtils.DeserializeBigInteger(16, br);
            EncryptedAnswer = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Nonce.ToByteArray());
            bw.Write(ServerNonce.ToByteArray());
            BytesUtil.Serialize(EncryptedAnswer, bw);
        }
    }
}
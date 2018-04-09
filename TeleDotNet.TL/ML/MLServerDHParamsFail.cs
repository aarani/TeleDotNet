using System.IO;
using System.Numerics;

namespace TeleDotNet.TL.ML
{
    [TLObject(2043348061)]
    public class MLServerDhParamsFail : MLAbsServerDHParams
    {
        public override int Constructor => 2043348061;

        public BigInteger Nonce { get; set; }
        public BigInteger ServerNonce { get; set; }
        public BigInteger NewNonceHash { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = ObjectUtils.DeserializeBigInteger(16, br);
            ServerNonce = ObjectUtils.DeserializeBigInteger(16, br);
            NewNonceHash= ObjectUtils.DeserializeBigInteger(16, br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Nonce.ToByteArray());
            bw.Write(ServerNonce.ToByteArray());
            bw.Write(NewNonceHash.ToByteArray());
        }
    }
}
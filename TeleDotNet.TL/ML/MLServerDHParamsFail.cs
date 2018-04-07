using System.IO;
using BigMath;

namespace TeleDotNet.TL.ML
{
    [TLObject(2043348061)]
    public class MLServerDhParamsFail : MLAbsServerDHParams
    {
        public override int Constructor => 2043348061;

        public System.Numerics.BigInteger Nonce { get; set; }
        public System.Numerics.BigInteger ServerNonce { get; set; }
        public System.Numerics.BigInteger NewNonceHash { get; set; }


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
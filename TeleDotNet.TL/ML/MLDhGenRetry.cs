using System.IO;
using BigMath;

namespace TeleDotNet.TL.ML
{
    [TLObject(1188831161)]
    public class MLDHGenRetry : MLAbsSetClientDHParamsAnswer
    {
        public override int Constructor => 1188831161;

        public System.Numerics.BigInteger Nonce { get; set; }
        public System.Numerics.BigInteger ServerNonce { get; set; }
        public System.Numerics.BigInteger NewNonceHash2 { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = ObjectUtils.DeserializeBigInteger(16, br);
            ServerNonce = ObjectUtils.DeserializeBigInteger(16, br);
            NewNonceHash2 = ObjectUtils.DeserializeBigInteger(16, br);
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Nonce.ToByteArray());
            bw.Write(ServerNonce.ToByteArray());
            bw.Write(NewNonceHash2.ToByteArray());
            
        }
    }
}
using System.IO;
using System.Numerics;

namespace TeleDotNet.TL.ML
{
    [TLObject(1615239032)]
    public class MLRequestReqPQ : TLMethod
    {
        public override int Constructor => 1615239032;

        public BigInteger Nonce { get; set; }
        public MLResPq Response { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = ObjectUtils.DeserializeBigInteger(16, br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Nonce.ToByteArray());
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (MLResPq) ObjectUtils.DeserializeObject(br);
        }
    }
}
using System.IO;
using System.Numerics;

namespace TeleDotNet.TL.ML
{
    [TLObject(-184262881)]
    public class MLRequestSetClientDHParams : TLMethod
    {
        public override int Constructor => -184262881;

        public BigInteger Nonce { get; set; }
        public BigInteger ServerNonce { get; set; }
        public byte[] EncryptedData { get; set; }
        public MLAbsSetClientDHParamsAnswer Response { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = ObjectUtils.DeserializeBigInteger(16, br);
            ServerNonce = ObjectUtils.DeserializeBigInteger(16, br);
            EncryptedData = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Nonce.ToByteArray());
            bw.Write(ServerNonce.ToByteArray());
            BytesUtil.Serialize(EncryptedData, bw);
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (MLAbsSetClientDHParamsAnswer) ObjectUtils.DeserializeObject(br);
        }
    }
}
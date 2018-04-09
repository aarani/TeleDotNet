using System.IO;
using System.Numerics;

namespace TeleDotNet.TL.ML
{
    [TLObject(-686627650)]
    public class MLRequestReqDHParams : TLMethod
    {
        public override int Constructor => -686627650;

        public BigInteger Nonce { get; set; }
        public BigInteger ServerNonce { get; set; }
        public byte[] P { get; set; }
        public byte[] Q { get; set; }
        public long PublicKeyFingerprint { get; set; }
        public byte[] EncryptedData { get; set; }
        public MLAbsServerDHParams Response { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = ObjectUtils.DeserializeBigInteger(16, br);
            ServerNonce= ObjectUtils.DeserializeBigInteger(16, br);
            P = BytesUtil.Deserialize(br);
            Q = BytesUtil.Deserialize(br);
            PublicKeyFingerprint = br.ReadInt64();
            EncryptedData = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Nonce.ToByteArray());
            bw.Write(ServerNonce.ToByteArray());
            BytesUtil.Serialize(P, bw);
            BytesUtil.Serialize(Q, bw);
            bw.Write(PublicKeyFingerprint);
            BytesUtil.Serialize(EncryptedData, bw);
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (MLAbsServerDHParams) ObjectUtils.DeserializeObject(br);
        }
    }
}
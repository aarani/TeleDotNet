using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(1973679973)]
    public class MLBindAuthKeyInner : TLObject
    {
        public override int Constructor => 1973679973;

        public long Nonce { get; set; }
        public long TempAuthKeyId { get; set; }
        public long PermAuthKeyId { get; set; }
        public long TempSessionId { get; set; }
        public int ExpiresAt { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = br.ReadInt64();
            TempAuthKeyId = br.ReadInt64();
            PermAuthKeyId = br.ReadInt64();
            TempSessionId = br.ReadInt64();
            ExpiresAt = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Nonce);
            bw.Write(TempAuthKeyId);
            bw.Write(PermAuthKeyId);
            bw.Write(TempSessionId);
            bw.Write(ExpiresAt);
        }
    }
}
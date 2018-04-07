using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-501201412)]
    public class MLDestroySessionOk : MLAbsDestroySessionRes
    {
        public override int Constructor => -501201412;

        public long SessionId { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            SessionId = br.ReadInt64();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(SessionId);
        }
    }
}
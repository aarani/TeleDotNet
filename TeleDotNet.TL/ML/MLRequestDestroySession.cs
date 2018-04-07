using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-414113498)]
    public class MLRequestDestroySession : TLMethod
    {
        public override int Constructor => -414113498;

        public long SessionId { get; set; }
        public MLAbsDestroySessionRes Response { get; set; }


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

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (MLAbsDestroySessionRes) ObjectUtils.DeserializeObject(br);
        }
    }
}
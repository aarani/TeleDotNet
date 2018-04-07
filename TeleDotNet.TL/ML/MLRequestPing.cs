using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(2059302892)]
    public class MLRequestPing : TLMethod
    {
        public override int Constructor => 2059302892;

        public long PingId { get; set; }
        public MLPong Response { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PingId = br.ReadInt64();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(PingId);
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (MLPong) ObjectUtils.DeserializeObject(br);
        }
    }
}
using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-213746804)]
    public class MLRequestPingDelayDisconnect : TLMethod
    {
        public override int Constructor => -213746804;

        public long PingId { get; set; }
        public int DisconnectDelay { get; set; }
        public MLPong Response { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            PingId = br.ReadInt64();
            DisconnectDelay = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(PingId);
            bw.Write(DisconnectDelay);
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (MLPong) ObjectUtils.DeserializeObject(br);
        }
    }
}
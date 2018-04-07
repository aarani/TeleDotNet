using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(1491380032)]
    public class MLRequestRpcDropAnswer : TLMethod
    {
        public override int Constructor => 1491380032;

        public long ReqMsgId { get; set; }
        public MLAbsRpcDropAnswer Response { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            ReqMsgId = br.ReadInt64();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ReqMsgId);
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (MLAbsRpcDropAnswer) ObjectUtils.DeserializeObject(br);
        }
    }
}
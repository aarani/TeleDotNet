using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-212046591)]
    public class MLRpcResult : TLObject
    {
        public override int Constructor => -212046591;

        public long ReqMsgId { get; set; }
        public object Result { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            ReqMsgId = br.ReadInt64();
            Result = ObjectUtils.DeserializeObject(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ReqMsgId);
            ObjectUtils.SerializeObject(Result, bw);
        }
    }
}
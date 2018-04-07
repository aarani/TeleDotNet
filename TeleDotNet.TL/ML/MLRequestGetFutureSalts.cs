using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-1188971260)]
    public class MLRequestGetFutureSalts : TLMethod
    {
        public override int Constructor => -1188971260;

        public int Num { get; set; }
        public MLFutureSalts Response { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Num = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Num);
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (MLFutureSalts) ObjectUtils.DeserializeObject(br);
        }
    }
}
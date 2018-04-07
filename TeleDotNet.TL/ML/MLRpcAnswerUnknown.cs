using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(1579864942)]
    public class MLRpcAnswerUnknown : MLAbsRpcDropAnswer
    {
        public override int Constructor => 1579864942;


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
        }
    }
}
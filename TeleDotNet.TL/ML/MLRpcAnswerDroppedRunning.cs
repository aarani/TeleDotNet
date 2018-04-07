using System.IO;

namespace TeleDotNet.TL.ML
{
    [TLObject(-847714938)]
    public class MLRpcAnswerDroppedRunning : MLAbsRpcDropAnswer
    {
        public override int Constructor => -847714938;


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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleDotNet.TL;
namespace TeleDotNet.TL.Messages
{
    [TLObject(-244016606)]
    public class TLStickersNotModified : TLAbsStickers
    {
        public override int Constructor
        {
            get
            {
                return -244016606;
            }
        }



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

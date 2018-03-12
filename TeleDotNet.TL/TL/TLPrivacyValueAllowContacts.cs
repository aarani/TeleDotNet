using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleDotNet.TL;
namespace TeleDotNet.TL
{
    [TLObject(-123988)]
    public class TLPrivacyValueAllowContacts : TLAbsPrivacyRule
    {
        public override int Constructor
        {
            get
            {
                return -123988;
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

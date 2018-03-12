using System;
using System.Collections.Generic;
using System.IO;
using TeleDotNet.TL;
using TeleDotNet.Core.Utils;

namespace TeleDotNet.Core.Requests
{
    public class PingRequest : TeleDotNet.TL.TLMethod
    {
        public PingRequest()
        {
        }

        public override void SerializeBody(BinaryWriter writer)
        {
            writer.Write(Constructor);
            writer.Write(Helpers.GenerateRandomLong());
        }

        public override void DeserializeBody(BinaryReader reader)
        {
            throw new NotImplementedException();
        }

        public override void DeserializeResponse(BinaryReader stream)
        {
            throw new NotImplementedException();
        }

        public override int Constructor
        {
            get
            {
                return 0x7abe77ec;
            }
        }
    }
}

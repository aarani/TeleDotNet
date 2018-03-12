using System;
using System.IO;
using TeleDotNet.TL;
namespace TeleDotNet.Core.Requests
{
    public class DownloadFileRequest : MTProtoRequest
    {
        private GetFileArgs args = new GetFileArgs();
        public TeleDotNet.TL.File file;

        public DownloadFileRequest(InputFileLocation loc,int offset=0,int limit=0)
        {
            args.location = loc;
            args.offset = offset;
            args.limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            Serializer.Serialize(args, typeof(InputFileLocation), writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            file = (TeleDotNet.TL.File)Deserializer.Deserialize(typeof(TeleDotNet.TL.File), reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }
}

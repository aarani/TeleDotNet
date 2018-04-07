using System.IO;

namespace TeleDotNet.MTProto.Helpers
{
    public static class Helpers
    {
        public static MemoryStream MakeMemory(int len)
        {
            return new MemoryStream(new byte[len], 0, len, true, true);
        }
    }
}
using System;
using System.Linq;
using System.Security.Cryptography;

namespace TeleDotNet.MTProto.Crypto
{
    public static class CryptoUtils
    {
        public static byte[] CalculateMessageKey(byte[] data,byte[] sharedKey)
        {
            var x = 0;
            var sharedKeyList = sharedKey.ToList();

            var msgKeyLarge =
                SHA256(sharedKeyList.GetRange(88 + x, 32).Concat(data).ToArray())
                    .ToList(); //msg_key_large = SHA256 (substr (auth_key, 88+x, 32) + plaintext + random_padding);
            return msgKeyLarge.GetRange(8, 16).ToArray(); //msg_key = substr (msg_key_large, 8, 16);
            
        }

        public static AESKeyData CalculateAesData(byte[] sharedKey, byte[] msgKey, bool client)
        {
            //TODO : Need Optimization

            var x = client ? 0 : 8;

            var sharedKeyList = sharedKey.ToList();

            var sha256A = SHA256(msgKey.Concat(sharedKeyList.GetRange(x, 36)).ToArray()).ToList();
            var sha256B = SHA256(sharedKeyList.GetRange(40 + x, 36).Concat(msgKey).ToArray()).ToList();

            return new AESKeyData(
                sha256A.GetRange(0, 8).Concat(sha256B.GetRange(8, 16)).Concat(sha256A.GetRange(24, 8)).ToArray(),
                sha256B.GetRange(0, 8).Concat(sha256A.GetRange(8, 16)).Concat(sha256B.GetRange(24, 8)).ToArray());
        }

        public static byte[] Align(byte[] src, int factor)
        {
            var random = new Random();

            var padding = factor - src.Length % factor;

            padding += 16;
            var paddingBytes = new byte[padding];
            random.NextBytes(paddingBytes);

            return src.Concat(paddingBytes).ToArray();
        }

        public static byte[] AlignZeroToFifteen(byte[] src, int factor)
        {
            var random = new Random();
            
            if (src.Length % factor == 0)
            {
                return src;
            }
            
            var padding = factor - src.Length % factor;

            var paddingBytes = new byte[padding];
            random.NextBytes(paddingBytes);

            return src.Concat(paddingBytes).ToArray();
        }
        public static byte[] SHA256(byte[] data)
        {
            using (SHA256 sha256 = new SHA256Managed())
            {
                return sha256.ComputeHash(data);
            }
        }
        public static byte[] SHA1(byte[] data)
        {
            using (SHA1 sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(data);
            }
        }
    }
}
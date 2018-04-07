using System;
using System.Linq;
using System.Security.Cryptography;

namespace TeleDotNet.MTProto.Crypto
{
    public static class CryptoUtils
    {
        public static byte[] CalculateMessageKey(byte[] data)
        {
            return SHA256(data).Skip(64).Take(128).ToArray();
        }

        public static AESKeyData CalculateAesData(byte[] data, byte[] sharedKey, byte[] msgKey, bool client)
        {
            //TODO : Need Optimization

            var x = client ? 0 : 8;
            var buffer = new byte[48];

            var sharedKeyList = sharedKey.ToList();

            var msg_key_large =
                SHA256(sharedKeyList.GetRange(88 + x, 32).ToArray()).Concat(data)
                    .ToList(); //msg_key_large = SHA256 (substr (auth_key, 88+x, 32) + plaintext + random_padding);
            var msg_key = msg_key_large.GetRange(8, 16); //msg_key = substr (msg_key_large, 8, 16);

            var sha256_a = SHA256(msg_key.Concat(sharedKeyList.GetRange(x, 36)).ToArray()).ToList();
            var sha256_b = SHA256(sharedKeyList.GetRange(40 + x, 36).Concat(msg_key).ToArray()).ToList();

            return new AESKeyData(
                sha256_a.GetRange(0, 8).Concat(sha256_b.GetRange(8, 16)).Concat(sha256_a.GetRange(24, 8)).ToArray(),
                sha256_b.GetRange(0, 8).Concat(sha256_a.GetRange(8, 16)).Concat(sha256_b.GetRange(24, 8)).ToArray());
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
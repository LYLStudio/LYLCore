namespace LStudio.TestLibsApp.EncryptionTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    public static class Encryption
    {
        private static RNGCryptoServiceProvider _rngProvider = null;
        private static RNGCryptoServiceProvider RngProvider { get => _rngProvider ?? (_rngProvider = new RNGCryptoServiceProvider()); }

        private static SHA1Managed _sha1 = null;
        private static SHA1Managed Sha1 { get => _sha1 ?? (_sha1 = new SHA1Managed()); }

        private static SHA256Managed _sha256 = null;
        private static SHA256Managed Sha256 { get => _sha256 ?? (_sha256 = new SHA256Managed()); }

        public static byte[] GenSalt(int saltLength)
        {
            if (saltLength <= 0 || saltLength > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(saltLength));
            }

            var result = new byte[saltLength];
            RngProvider.GetBytes(result);
            return result;
        }

        public static string GenSaltBase64String(int saltLength)
        {
            var result = Convert.ToBase64String(GenSalt(saltLength));
            return result;
        }

        public static string SHA1(string data)
        {
            var result = Sha1.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(result);
        }

        public static string SHA256(string data, string salt)
        {
            var dataBytes = Convert.FromBase64String(data);
            var saltBytes = Convert.FromBase64String(salt);
            var rawBytes = new byte[dataBytes.Length + saltBytes.Length];
            dataBytes.CopyTo(rawBytes, 0);
            saltBytes.CopyTo(rawBytes, dataBytes.Length);

            var result = Sha256.ComputeHash(rawBytes);
            return Convert.ToBase64String(result);
        }
    }
}
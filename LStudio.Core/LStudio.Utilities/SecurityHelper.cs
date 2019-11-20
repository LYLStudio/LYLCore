namespace LStudio.Utilities
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class KeyAndIv
    {
        internal byte[] Key { get; }
        internal byte[] IV { get; }
        public KeyAndIv(byte[] key, byte[] iv)
        {
            Key = key;
            IV = iv;
        }
    }

    public static class SecurityHelper
    {
        //private static byte[] keyAndIvBytes;

        //static EncryptionHelper()
        //{
        //    // You'll need a more secure way of storing this, I hope this isn't
        //    // the real key
        //    //keyAndIvBytes = UTF8Encoding.UTF8.GetBytes("0123456789012345");
        //}

        public static string ByteArrayToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public static byte[] StringToByteArray(string hex)
        {
            if (string.IsNullOrEmpty(hex)) throw new ArgumentNullException(nameof(hex));

            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string DecodeAndDecrypt(string cipherText, KeyAndIv keyAndIv)
        {
            string DecodeAndDecrypt = AesDecrypt(StringToByteArray(cipherText), keyAndIv);
            return (DecodeAndDecrypt);
        }

        public static string EncryptAndEncode(string plaintext, KeyAndIv keyAndIv)
        {
            return ByteArrayToHexString(AesEncrypt(plaintext, keyAndIv));
        }

        public static string AesDecrypt(byte[] inputBytes, KeyAndIv keyAndIv)
        {
            if (inputBytes == null) throw new ArgumentNullException(nameof(inputBytes));
            if (keyAndIv == null) throw new ArgumentNullException(nameof(keyAndIv));


            byte[] outputBytes = inputBytes;

            string plaintext = string.Empty;

            var algorithm = GetCryptoAlgorithm();
            var crypto = algorithm.CreateDecryptor(keyAndIv.Key, keyAndIv.IV);
            MemoryStream memoryStream = new MemoryStream(outputBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, crypto, CryptoStreamMode.Read);
            try
            {
                using (StreamReader srDecrypt = new StreamReader(cryptoStream))
                {
                    plaintext = srDecrypt.ReadToEnd();
                }

                return plaintext;
            }
            finally
            {                
                crypto?.Dispose();
                algorithm?.Dispose();
            }
        }

        public static byte[] AesEncrypt(string inputText, KeyAndIv keyAndIv)
        {
            if (string.IsNullOrWhiteSpace(inputText)) throw new ArgumentNullException(nameof(inputText));
            if (keyAndIv == null) throw new ArgumentNullException(nameof(keyAndIv));

            byte[] inputBytes = UTF8Encoding.UTF8.GetBytes(inputText);

            byte[] result = null;

            MemoryStream memoryStream = new MemoryStream();
            var algorithm = GetCryptoAlgorithm();
            var crypto = algorithm.CreateEncryptor(keyAndIv.Key, keyAndIv.IV);

            try
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypto, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    result = memoryStream.ToArray();
                }

                return result;
            }
            finally
            {
                crypto?.Dispose();
                //memoryStream?.Dispose();
                algorithm?.Dispose();
            }
        }

        private static RijndaelManaged GetCryptoAlgorithm()
        {
            return new RijndaelManaged
            {
                //set the mode, padding and block size
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.ECB,
                KeySize = 256,
                BlockSize = 128
            };
        }
    }
}

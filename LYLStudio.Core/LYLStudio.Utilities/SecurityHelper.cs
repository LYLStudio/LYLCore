namespace LYLStudio.Utilities
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class SecurityHelper
    {
        //private static byte[] keyAndIvBytes;

        //static EncryptionHelper()
        //{
        //    // You'll need a more secure way of storing this, I hope this isn't
        //    // the real key
        //    //keyAndIvBytes = UTF8Encoding.UTF8.GetBytes("0123456789012345");
        //}

        public class KeyAndIv
        {
            public byte[] Key { get; set; }
            public byte[] IV { get; set; }
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public static byte[] StringToByteArray(string hex)
        {
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
            if (inputBytes == null) throw new NotImplementedException(nameof(inputBytes));
            if (keyAndIv == null) throw new NotImplementedException(nameof(keyAndIv));


            byte[] outputBytes = inputBytes;

            string plaintext = string.Empty;

            using (MemoryStream memoryStream = new MemoryStream(outputBytes))
            {
                var algorithm = GetCryptoAlgorithm();
                var crypto = algorithm.CreateDecryptor(keyAndIv.Key, keyAndIv.IV);

                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypto, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(cryptoStream))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }

                algorithm.Dispose();
            }

            return plaintext;
        }

        public static byte[] AesEncrypt(string inputText, KeyAndIv keyAndIv)
        {
            if (string.IsNullOrWhiteSpace(inputText)) throw new NotImplementedException(nameof(inputText));
            if (keyAndIv == null) throw new NotImplementedException(nameof(keyAndIv));

            byte[] inputBytes = UTF8Encoding.UTF8.GetBytes(inputText);

            byte[] result = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var algorithm = GetCryptoAlgorithm();
                var crypto = algorithm.CreateEncryptor(keyAndIv.Key, keyAndIv.IV);

                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypto, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    result = memoryStream.ToArray();
                }

                algorithm.Dispose();
            }

            return result;
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

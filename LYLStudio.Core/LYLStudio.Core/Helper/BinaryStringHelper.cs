namespace LYLStudio.Core
{
    using System;
    using System.Linq;
    using System.Text;

    public class BinaryStringHelper
    {
        /// <summary>
        /// Byte array to HEX string
        /// </summary>
        /// <param name="buffer">target byte array</param>
        /// <param name="bytesPerLine">how many bytes showed per line</param>
        /// <param name="separator">what kind separator showed between bytes</param>
        /// <returns>HEX string</returns>
        public static string ByteArrayToHexString(byte[] buffer, int bytesPerLine = 16, string separator = "")
        {
            var result = string.Empty;
            StringBuilder builder = new StringBuilder();

            if (buffer == null || buffer.Length == 0)
                return result;

            var temp = BitConverter.ToString(buffer).Split('-');
            var count = 0;
            foreach (var item in temp)
            {
                count++;
                builder.Append(item);
                if (count % bytesPerLine == 0)
                {
                    builder.AppendLine();
                }
                else
                {
                    if (count != temp.Length || !string.IsNullOrEmpty(separator))
                        builder.Append(separator);
                }
            }
            result = builder.ToString();
            return result;
        }

        /// <summary>
        /// HEX string convert to byte array
        /// </summary>
        /// <param name="hex">HEX string</param>
        /// <returns>byte array</returns>
        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}

namespace LYLStudio.Core.Helper
{
    public static class BinaryStringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string hex)
        {
            return BinaryStringHelper.HexStringToByteArray(hex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bytesPerLine"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToHexString(this byte[] buffer, int bytesPerLine = 16, string separator = "")
        {
            return BinaryStringHelper.ByteArrayToHexString(buffer, bytesPerLine, separator);
        }
    }
}
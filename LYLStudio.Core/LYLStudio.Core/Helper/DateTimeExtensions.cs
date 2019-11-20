namespace LYLStudio.Core
{
    using System;

    public static class DateTimeExtensions
    {
        public static string FormatT(this DateTime dateTime, string separator = "")
        {
            return dateTime.ToString($"HH{separator}mm{separator}ss");
        }

        public static string FormatD(this DateTime dateTime, string separator = "")
        {
            return dateTime.ToString($"yyyy{separator}MM{separator}dd");
        }

        public static string ToFormat(this DateTime dateTime, FastFormatType fastFormatType = FastFormatType.ISO8601)
        {
            string result;

            switch (fastFormatType)
            {
                case FastFormatType.T6:
                    result = dateTime.ToString("HHmmss");
                    break;
                case FastFormatType.D8:
                    result = dateTime.ToString("yyyyMMdd");
                    break;
                case FastFormatType.DT15:
                    result = dateTime.ToString("yyyyMMddTHHmmss");
                    break;
                case FastFormatType.ISO8601:
                default:
                    result = dateTime.ToString("O");
                    break;
            }

            return result;
        }

        public enum FastFormatType
        {
            ISO8601,
            T6,
            D8,
            DT15,
        }
    }
}
namespace LStudio.Core
{
    using System;
    using System.Globalization;

    public static class DateTimeExtensions
    {
        public static string FormatT(this DateTime dateTime)
        {
            return dateTime.ToString($"HHmmss", CultureInfo.InvariantCulture);
        }

        public static string FormatT(this DateTime dateTime, string separator)
        {
            return dateTime.ToString($"HH{separator}mm{separator}ss", CultureInfo.InvariantCulture);
        }

        public static string FormatD(this DateTime dateTime)
        {
            return dateTime.ToString($"yyyyMMdd", CultureInfo.InvariantCulture);
        }

        public static string FormatD(this DateTime dateTime, string separator)
        {
            return dateTime.ToString($"yyyy{separator}MM{separator}dd", CultureInfo.InvariantCulture);
        }

        public static string ToFormat(this DateTime dateTime, FastFormatType fastFormatType)
        {
            string result;

            switch (fastFormatType)
            {
                case FastFormatType.T6:
                    result = dateTime.ToString("HHmmss", CultureInfo.InvariantCulture);
                    break;
                case FastFormatType.D8:
                    result = dateTime.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
                    break;
                case FastFormatType.DT15:
                    result = dateTime.ToString("yyyyMMddTHHmmss", CultureInfo.InvariantCulture);
                    break;
                case FastFormatType.Iso8601:
                default:
                    result = dateTime.ToString("O", CultureInfo.InvariantCulture);
                    break;
            }

            return result;
        }

        public static string ToLogTime(this DateTime dateTime)
        {
            return dateTime.ToString("O",CultureInfo.InvariantCulture);
        }

        public enum FastFormatType
        {
            Iso8601,
            T6,
            D8,
            DT15,
        }
    }
}
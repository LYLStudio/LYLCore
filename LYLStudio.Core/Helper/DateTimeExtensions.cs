using System;

namespace LYLStudio.Core
{
    public static class DateTimeExtensions
    {
        public static string ToTimeFormated(this DateTime dateTime, string format = "HHmmss")
        {
            return dateTime.ToString(format);
        }

        public static string ToDateFormated(this DateTime dateTime, string format = "yyyyMMdd")
        {
            return dateTime.ToString(format);
        }

        public static string ToLogFormat(this DateTime dateTime, string format = "yyyyMMddHHmmss.fff")
        {
            return dateTime.ToString(format);
        }

        public static string ToFastFormat(this DateTime dateTime, FastFormatType fastFormatType)
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
                default:
                    result = dateTime.ToString();
                    break;
            }

            return result;
        }

        public static int ToAge(this DateTime dateTime, DateTime? referDateTime = null)
        {
            DateTime dt = referDateTime ?? DateTime.Now;

            int age = dt.Year - dateTime.Year;
            if (dt.Month < dateTime.Month
                || (dt.Month == dateTime.Month && dt.Day < dateTime.Day))
            {
                age--;
            }

            return age;
        }

        public enum FastFormatType
        {
            T6,
            D8,
            DT15,
        }
    }

}

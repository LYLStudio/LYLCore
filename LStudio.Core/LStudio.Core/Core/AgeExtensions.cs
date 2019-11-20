namespace LStudio.Core
{
    using System;

    public static class AgeExtensions
    {
        public static int ToAge(this DateTime dateTime, DateTime? referDateTime)
        {
            DateTime dt = referDateTime ?? DateTime.Now;

            int result = dt.Year - dateTime.Year;
            if (dt.Month < dateTime.Month
                || (dt.Month == dateTime.Month && dt.Day < dateTime.Day))
            {
                result--;
            }

            return result;
        }
    }
}
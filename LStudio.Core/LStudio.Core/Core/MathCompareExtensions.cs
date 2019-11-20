namespace LStudio.Core
{
    using System;

    public static class MathCompareExtensions
    {
        /// <summary>
        /// 驗證 <paramref name="value"/> 在包含邊界的範圍內
        /// </summary>
        /// <param name="value">驗證值</param>
        /// <param name="min">下界</param>
        /// <param name="max">上界</param>
        /// <returns></returns>
        public static bool IsInRange(this int value, int min, int max)
        {
            return (value >= min && value <= max);
        }

        /// <summary>
        /// 驗證 <paramref name="value"/> 在指定邊界類型的範圍內
        /// </summary>
        /// <param name="value">驗證值</param>
        /// <param name="min">下界</param>
        /// <param name="max">上界</param>
        /// <param name="boundaries">邊界類型</param>
        /// <returns></returns>
        public static bool IsInRange(this int value, int min, int max, Boundaries boundaries)
        {
            bool result;
            switch (boundaries)
            {
                case Boundaries.None:
                    result = (value > min && value < max);
                    break;
                case Boundaries.MinIncluded:
                    result = (value >= min && value < max);
                    break;
                case Boundaries.MaxIncluded:
                    result = (value > min && value <= max);
                    break;
                case Boundaries.All:
                default:
                    result = (value >= min && value <= max);
                    break;
            }

            return result;
        }

        /// <summary>
        /// 驗證 <paramref name="value"/> 在包含邊界的範圍內
        /// </summary>
        /// <param name="value">驗證值</param>
        /// <param name="min">下界</param>
        /// <param name="max">上界</param>
        public static bool IsInRange(this double inputValue, double min, double max)
        {
            return (inputValue >= min && inputValue <= max);
        }

        /// <summary>
        /// 驗證 <paramref name="value"/> 在指定邊界類型的範圍內
        /// </summary>
        /// <param name="value">驗證值</param>
        /// <param name="min">下界</param>
        /// <param name="max">上界</param>
        /// <param name="boundaries">邊界類型</param>
        public static bool IsInRange(this double inputValue, double min, double max, Boundaries boundaries)
        {
            bool result;

            switch (boundaries)
            {
                case Boundaries.None:
                    result = (inputValue > min && inputValue < max);
                    break;
                case Boundaries.MinIncluded:
                    result = (inputValue >= min && inputValue < max);
                    break;
                case Boundaries.MaxIncluded:
                    result = (inputValue > min && inputValue <= max);
                    break;
                case Boundaries.All:
                default:
                    result = (inputValue >= min && inputValue <= max);
                    break;
            }

            return result;
        }

        [Flags]
        public enum Boundaries
        {
            None = 0x0000,
            MinIncluded = 0x0010,
            MaxIncluded = 0x0100,
            All = MinIncluded | MaxIncluded
        }
    }
}

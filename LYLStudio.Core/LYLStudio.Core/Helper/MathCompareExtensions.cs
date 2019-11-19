namespace LYLStudio.Core
{
    using System;

    public static class MathCompareExtensions
    {
        public static bool IsInRange(this int inputValue, int min, int max, BoundaryTypeEnum includeBoundaryType = BoundaryTypeEnum.All)
        {
            var result = false;

            switch (includeBoundaryType)
            {
                case BoundaryTypeEnum.None:
                    result = (inputValue > min && inputValue < max);
                    break;
                case BoundaryTypeEnum.Min:
                    result = (inputValue >= min && inputValue < max);
                    break;
                case BoundaryTypeEnum.Max:
                    result = (inputValue > min && inputValue <= max);
                    break;
                case BoundaryTypeEnum.All:
                    result = (inputValue >= min && inputValue <= max);
                    break;
            }

            return result;
        }

        public static bool IsInRange(this double inputValue, double min, double max, BoundaryTypeEnum includeBoundaryType = BoundaryTypeEnum.All)
        {
            var result = false;
            switch (includeBoundaryType)
            {
                case BoundaryTypeEnum.None:
                    result = (inputValue > min && inputValue < max);
                    break;
                case BoundaryTypeEnum.Min:
                    result = (inputValue >= min && inputValue < max);
                    break;
                case BoundaryTypeEnum.Max:
                    result = (inputValue > min && inputValue <= max);
                    break;
                case BoundaryTypeEnum.All:
                    result = (inputValue >= min && inputValue <= max);
                    break;
            }

            return result;
        }

        [Flags]
        public enum BoundaryTypeEnum
        {
            None = 0x0000,
            Min = 0x0010,
            Max = 0x0100,
            All = Min | Max
        }
    }
}

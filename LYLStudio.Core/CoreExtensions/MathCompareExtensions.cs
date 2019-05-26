namespace LYLStudio.Core.CoreExtensions
{
    public static class MathCompareExtensions
    {
        public static bool IsInRange(this int inputValue, int min, int max, bool isIncludeBoundary = true)
        {
            if (isIncludeBoundary)
            {
                return (inputValue >= min && inputValue <= max);
            }
            else
            {
                return (inputValue > min && inputValue < max);
            }
        }

        public static bool IsInRange(this double inputValue, double min, double max, bool isIncludeBoundary = true)
        {
            if (isIncludeBoundary)
            {
                return (inputValue >= min && inputValue <= max);
            }
            else
            {
                return (inputValue > min && inputValue < max);
            }
        }
    }
}

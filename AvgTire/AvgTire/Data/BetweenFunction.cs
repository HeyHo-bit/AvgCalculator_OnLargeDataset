namespace AvgTire.Data
{
    internal static class BetweenFunction
    {
        public static bool Between(this int x, int a, int b)
        {
            return (a <= x) && (x <= b);
        }
        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                && Comparer<T>.Default.Compare(item, end) <= 0;
        }
    }
}
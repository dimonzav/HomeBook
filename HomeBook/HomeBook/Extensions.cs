namespace HomeBook
{
    using System;

    public static class Extensions
    {
        public static bool IsCleanText(this string str) => !String.IsNullOrEmpty(str) || !String.IsNullOrWhiteSpace(str);

        public static bool IsCleanNumber(this double? num) => num != null;

        public static bool IsCleanNumber(this int? num) => num != null;

        public static bool IsCleanNumber(this int num) => num > 0;
    }
}

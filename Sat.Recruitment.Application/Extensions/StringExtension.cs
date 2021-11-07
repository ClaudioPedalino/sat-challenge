using System;

namespace Sat.Recruitment.Application.Extensions
{
    public static class StringExtension
    {
        public static string ToDate(this DateTime date) =>
            date.ToString("F");

        public static string RemoveSpeacialCharacters(this string search)
            => search.Replace(",", string.Empty)
                     .Replace(".", string.Empty)
                     .Replace("-", string.Empty)
                     .Replace("_", string.Empty);
    }
}

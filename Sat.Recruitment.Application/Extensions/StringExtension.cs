using System;

namespace Sat.Recruitment.Application.Extensions
{
    public static class StringExtension
    {
        public static string ToDate(this DateTime date) =>
            date.ToString("F");
    }
}

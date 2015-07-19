using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TW.CTM.Common.Extends
{
    public static class StringExtend
    {
        public static bool IsContainNumber(this string str)
        {
            if (String.IsNullOrEmpty(str))
                return false;

            return str.Any(Char.IsDigit);
        }

        public static int ExtractFirstInt(this string str)
        {
            if (str.IsContainNumber())
            {
                var matchResult = Regex.Match(str, @"\d+");

                if (matchResult.Success)
                {
                    return int.Parse(matchResult.Value);
                }
            }
            throw new InvalidOperationException("The string is not contain any digit char!");
        }
    }
}
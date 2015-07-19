using System.Text.RegularExpressions;
using TW.CTM.Common;
using TW.CTM.Common.Extends;
using TW.CTM.Models;

namespace TW.CTM.Businesses
{
    public static class TalkHelper
    {
        public static Talk Parse(string talkDescribeStr)
        {
            Guard.ArgumentNotNullOrEmpty(talkDescribeStr, "talkDescribeStr");
            Talk result;

            var regex = new Regex(@"\d*min$"
                , RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            Match match = regex.Match(talkDescribeStr);
            if (match.Success)
            {
                result = new NormalTalk(talkDescribeStr.Replace(match.Value, string.Empty)
                    , talkDescribeStr.ExtractFirstInt());
            }
            else
            {
                result = new LightingTalk(talkDescribeStr.Replace("lightning", string.Empty));
            }

            return result;
        }
    }
}
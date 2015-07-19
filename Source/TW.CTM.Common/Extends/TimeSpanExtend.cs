using System;

namespace TW.CTM.Common.Extends
{
    public static class TimeSpanExtend
    {
        public static string ToStringHhMm(this TimeSpan ts)
        {
            return ts.ToString(@"hh\:mm");
        }

        public static TimeSpan AddMinutes(this TimeSpan ts, int minutes)
        {
            ts = ts.Add(TimeSpan.FromMinutes(minutes));
            return ts;
        }
    }
}
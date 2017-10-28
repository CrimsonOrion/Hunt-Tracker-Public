using System;

namespace CS_HuntTracker
{

    public static class ConvertTimeZone
    {
        public static DateTime ToLocalTime(DateTime utcTime)
        {
            DateTime localTime = DateTime.SpecifyKind(DateTime.Parse(utcTime.ToString()), DateTimeKind.Utc).ToLocalTime();
            return localTime;
        }

        public static DateTime ToUtcTime(string localTime)
        {
            DateTime utcTime = DateTime.SpecifyKind(DateTime.Parse(localTime), DateTimeKind.Local).ToUniversalTime();
            return utcTime;
        }
    }
}

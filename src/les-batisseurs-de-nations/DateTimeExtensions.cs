using System;

namespace LesBatisseursDeNations
{
    public static class DateTimeExtensions
    {
        //public static readonly TimeZoneInfo EasternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        public static readonly TimeZoneInfo EasternZone = TimeZoneInfo.FindSystemTimeZoneById("America/Toronto");

        public static DateTime ConvertUtcToEasternTime(this DateTime date)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(date, EasternZone);
        }
    }
}

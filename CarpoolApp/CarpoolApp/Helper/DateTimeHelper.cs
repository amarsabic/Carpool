using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Helper
{
    public class DateTimeHelper
    {
        private const int SECOND = 1;
        private const int MINUTE = 60 * SECOND;
        private const int HOUR = 60 * MINUTE;
        private const int DAY = 24 * HOUR;
        private const int MONTH = 30 * DAY;

        /// <summary>
        /// Returns a friendly version of the provided DateTime, relative to now. E.g.: "2 days ago", or "in 6 months".
        /// </summary>
        /// <param name="dateTime">The DateTime to compare to Now</param>
        /// <returns>A friendly string</returns>
        public static string GetFriendlyRelativeTime(DateTime dateTime)
        {
            var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 60)
            {
                return ts.Seconds == 1 ? "prije 1s" : "prije " + ts.Seconds + " s";
            }
            if (delta < 120)
            {
                return "prije 1min";
            }
            if (delta < 2700) // 45 * 60
            {
                return "prije " + ts.Minutes + "min";
            }
            if (delta < 5400) // 90 * 60
            {
                return "prije 1h";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return "prije " + ts.Hours + "h";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "jučer";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return "prije " + ts.Days + " dana";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "prije 1 mjesec" : months + "m";
            }
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "prije 1 godinu" : "prije " + years + " godina";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utils
{
    public class Util
    {
        
    }
    public static class DateTimeExtend {
        public static DateTime NowOrOwner(this DateTime date) {
            return date == DateTime.MinValue ? DateTime.Now : date;
        }
        public static DateTime BeginOfDate(this DateTime date) {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        public static DateTime EndOfDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }
    }
}

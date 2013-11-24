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
    }
}

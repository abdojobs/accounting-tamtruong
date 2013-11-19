using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Maths
{
    public class AccountMath
    {
        public static decimal MultiDouAndDecimal(decimal a, double b) {
            return a * Convert.ToDecimal(b);
        }
        public static decimal CalculateTax(decimal amount, double percent)
        {
            return MultiDouAndDecimal(amount,percent) / 100;
        }
        public static decimal ToDecimal(string s) {
            if (string.IsNullOrEmpty(s))
                return 0;
            decimal d = 0;
            decimal.TryParse(s, out d);
            return d;
        }
    }
}

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
    }
}

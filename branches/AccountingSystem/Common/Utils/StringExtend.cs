using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Utils
{
    public static class StringExtend
    {
        public static bool IsEmpty(this string s) {
            return string.IsNullOrEmpty(s) && string.IsNullOrWhiteSpace(s);
        }
        public static bool IsDegit(this string s) {
            Regex regex = new Regex(@"^\d$");
            return regex.IsMatch(s);
        }
        public static bool IsNumber(this string s) {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(s);
        }
        public static string Sub(this string s,int index, int length) {
            if (length < 0 || index < 0 || s.Length<=0)
                return s;
            if (s.Length <= index + length) {
                length = s.Length - index;
            }
            return s.Substring(index, length);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Maths
{
    public static class ExtensionClass {
        /// <summary>
        /// only use for type digit
        /// </summary>
        /// <typeparam name="T">type digit ex:int,double...</typeparam>
        /// <param name="value"></param>
        /// <returns>type</returns>
        public static T ToValue<T>(this object value)
        {
            if (value == null || value==DBNull.Value || value is string)
                return (T)Convert.ChangeType(0,typeof(T));
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static string DBValueToString(this object value) {
            if (value == DBNull.Value || value==null)
                return string.Empty;
            return string.Format("{0}",value);
        }
        
        public static int ToInt(this object value) {
            if (value is string && string.IsNullOrEmpty((string)value))
                return 0;
            if (value == DBNull.Value || value == null)
                return 0;
            return Convert.ToInt32(value);
        }
        public static double ToDouble(this object value) {
            if (value is string && string.IsNullOrEmpty((string)value))
                return 0;
            if (value == DBNull.Value || value==null)
                return 0;
            return Convert.ToDouble(value);
        }
        public static decimal ToDecimal(this object value) {
            if (value is string && string.IsNullOrEmpty((string)value))
                return 0;
            if (value == DBNull.Value || value == null)
                return 0;
            return Convert.ToDecimal(value);
        }
        public static bool IsDecimal(this string s) {
            Regex reg = new Regex(@"^\d+[,\.]?(\d+)?$");
            return reg.IsMatch(s);
        }
        public static bool IsAlphabe(this char c) {
            Regex reg = new Regex(@"^[a-zA-Z]+$");
            return reg.IsMatch(c.ToString());
        }
        public static bool IsDecimalChar(this char c) {
            Regex reg = new Regex(@"\d|\.");
            return reg.IsMatch(c.ToString());
        }
        
    }

    public static class StringExtension {
        public static string TrimOrEmpty(this string s) {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            return s.Trim();
        }
    }

    public class ValidateInput {
        public static bool OnlySpecialKey(char c) {
            int[] keys=new int[]{8,13,46};
            if (keys.Contains((int)c))
                return true;
            return false;
        }

        public static bool OnlyDecimal(string s,char c) {
            if (c.IsAlphabe())
            {
                return false;
            }
            if (!(ValidateInput.OnlySpecialKey(c) || c.IsDecimalChar()))
            {
                return false;
            }
            if (c.IsDecimalChar())
            {
                s += c;
                if (!s.IsDecimal())
                    return false;
            }
            return true;
        }
    }
}

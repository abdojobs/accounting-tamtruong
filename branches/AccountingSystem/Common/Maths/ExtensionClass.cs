using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Maths
{
    public static class ExtensionClass {
        ///// <summary>
        ///// only use for type digit
        ///// </summary>
        ///// <typeparam name="T">type digit ex:int,double...</typeparam>
        ///// <param name="value"></param>
        ///// <returns>type</returns>
        //public static T ToValue<T>(this object value) {
        //    if (value == null)
        //        return new Converter<Int32, T>(0);
        //    return new Converter<object, T>(x=>(T));
        //}

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
    }
}

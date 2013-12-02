using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingSystem.Utils
{
    class UtilGui
    {
        /// <summary>
        /// Hyphen is - mark, ex: s="foo" after use this method s="-foo"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ConcatHasHyphen(string s) {
            if (!string.IsNullOrEmpty(s))
                return  "-"+ s;
            return string.Empty;
        }
    }
}

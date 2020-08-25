using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace JolijoberProject.Shared.SharedKernal.ExtensionMethod
{
    public static class JolijoberExtensions
    {
        #region -   UtilTo   -
        public static string ParsToJolijoberEmail(this string s,string at= "@jolijober.com")
        {
            return s.Contains(at)?s:s+at;
        }

        #endregion

        #region -   Enumrable   -

        public static string ToLineString(this IEnumerable<string> list,char separator=',')
        {
            return String.Join(separator, list);
        }

        #endregion
    }
}

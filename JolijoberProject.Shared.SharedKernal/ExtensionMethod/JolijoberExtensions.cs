using JolijoberProject.Shared.SharedKernal.SharedDto;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public static string RemoveHostUri(this string uri)
        {
            return new Uri(uri).PathAndQuery;
        }


        #endregion

        #region -   Enumrable   -

        public static string ToLineString(this IEnumerable<string> list,string separator=",")
        {
            return String.Join(separator, list);
        }

        public static IEnumerable<T> ToPaginate<T>(this IEnumerable<T> queryable,Pagination pagination)
        {
            int skip = (pagination.Page - 1) * pagination.Quantity;
            return queryable
                .Skip(skip)
                .Take(pagination.Quantity);
        }


        public static List<T> ToPaginate<T>(this List<T> queryable,Pagination pagination)
        {
            int skip = (pagination.Page - 1) * pagination.Quantity;
            return queryable
                .Skip(skip)
                .Take(pagination.Quantity).ToList();
        }

        #endregion
    }
}

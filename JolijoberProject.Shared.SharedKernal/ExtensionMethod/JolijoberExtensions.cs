using JolijoberProject.Shared.SharedKernal.EnumClass;
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


        public static string RemoveHostUri(this string uri, bool skipDash=false)
        {
            return new Uri(uri).PathAndQuery.Substring(skipDash?1:0);
        }

        public static bool IsContainRole(this string uri, Roles role)
        {
            switch (role)
            {
                case Roles.User:
                    return !(uri.Contains("Company") || uri.Contains("Companies"));
                case Roles.Company:
                    return uri.Contains("Company") || uri.Contains("Companies");
                default:
                    return false;
            }
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

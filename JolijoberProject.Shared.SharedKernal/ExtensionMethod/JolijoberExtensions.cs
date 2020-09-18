using JolijoberProject.Shared.SharedKernal.EnumClass;
using JolijoberProject.Shared.SharedKernal.SharedDto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        #region -   Math   -

        public static double FixToHalf(this double d)
        {
          return Math.Round(d * 2, MidpointRounding.AwayFromZero) / 2;
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


        #region -   Compression   -

        public static bool TryQualityCompression(MemoryStream inputStream, long quality, out string newbase64)
        {
            try
            {
                Image image;
                image = Image.FromStream(inputStream);

                var jpegEncoder = ImageCodecInfo.GetImageDecoders()
                  .First(c => c.FormatID == ImageFormat.Jpeg.Guid);

                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality); // here % Quality
                                                                                                                    // Byte[] outputBytes;
                using (var outputStream = new MemoryStream())
                {
                    image.Save(outputStream, jpegEncoder, encoderParameters);
                    newbase64 = $"data:image/jpg;base64,{Convert.ToBase64String(outputStream.ToArray())}";

                }
                image.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                newbase64 = "";
                return false;
            }

        }

        #endregion

        #region -   Cookies   -
        


        #endregion
    }
}

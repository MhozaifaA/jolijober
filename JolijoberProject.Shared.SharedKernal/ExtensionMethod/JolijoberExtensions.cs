﻿using JolijoberProject.Shared.SharedKernal.EnumClass;
using JolijoberProject.Shared.SharedKernal.SharedDto;
using JolijoberProject.Shared.SharedKernal.SharedModel;
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

        public static string ToLine(this string[] s, string separator=",")
        {
            return String.Join(separator,s);
        }


        public static string Crop(this string s, int crop = 125)
        {
            return (s?.Substring(0, Math.Min(crop, s?.Length??0))??"") + " ... ";
        }

        //public static string LeftCrop(this string str, int length)
        //{
        //    return str.Substring(0, Math.Min(length, str.Length));
        //}

        //public static string RightCrop(this string str, int length)
        //{
        //    return str.Substring(str.Length - Math.Min(length, str.Length));
        //}


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

       
        public static long RecursiveLongCount(this Comment[] list)
        {
            long iterator = 0;

            foreach (var item in list)
            {
                iterator++;
                iterator += RecursiveLongCount(item.ChildComments);
            }
            return iterator;
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


        #region -   Seed   -
        
        public static List<TagsSelect> NewTagsSelect()
        {
            return (from item in Enum.GetNames(typeof(Tags))
                    select new TagsSelect(item)).ToList();
        }

        #endregion


        #region -   Fuzzy   -

        public static int LevenshteinDistance(string src, string dest)
        {
            int[,] d = new int[src.Length + 1, dest.Length + 1];
            int i, j, cost;
            char[] str1 = src.ToCharArray();
            char[] str2 = dest.ToCharArray();

            for (i = 0; i <= str1.Length; i++)
            {
                d[i, 0] = i;
            }
            for (j = 0; j <= str2.Length; j++)
            {
                d[0, j] = j;
            }
            for (i = 1; i <= str1.Length; i++)
            {
                for (j = 1; j <= str2.Length; j++)
                {

                    if (str1[i - 1] == str2[j - 1])
                        cost = 0;
                    else
                        cost = 1;

                    d[i, j] =
                        Math.Min(
                            d[i - 1, j] + 1,              // Deletion
                            Math.Min(
                                d[i, j - 1] + 1,          // Insertion
                                d[i - 1, j - 1] + cost)); // Substitution

                    if ((i > 1) && (j > 1) && (str1[i - 1] ==
                        str2[j - 2]) && (str1[i - 2] == str2[j - 1]))
                    {
                        d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
                    }
                }
            }

            return d[str1.Length, str2.Length];
        }


        public static List<string> FuzzySearch(
         string word,
         List<string> wordList,
         double fuzzyness)
        {
            List<string> foundWords = new List<string>();

            foreach (string s in wordList)
            {
                // Calculate the Levenshtein-distance:
                int levenshteinDistance =
                    LevenshteinDistance(word, s);

                // Length of the longer string:
                int length = Math.Max(word.Length, s.Length);

                // Calculate the score:
                double score = 1.0 - (double)levenshteinDistance / length;

                // Match?
                if (score > fuzzyness)
                    foundWords.Add(s);
            }
            return foundWords;
        }


        public static List<(string,string)> FuzzySearchLinq(
             string word,
             List<(string, string)> wordList,
             double fuzzyness)
        {
            // Tests have prove that the !LINQ-variant is about 3 times
            // faster!
            List<(string, string)> foundWords =
                (
                    from s in wordList
                    let levenshteinDistance = LevenshteinDistance(word??"", s.Item2??"")
                    let length = Math.Max(s.Item2?.Length??0, word?.Length??0)
                    let score = 1.0 - (double)levenshteinDistance / length
                    where score > fuzzyness
                    select s
                ).ToList();

            return foundWords;
        }

        #endregion


        #region -   Cookies   -



        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Main.Repository.Repositories
{
    public class UtilRepository
    {

        //public enum ImageFormats
        //{
        //    bmp,
        //    jpeg,
        //    gif,
        //    tiff,
        //    png,
        //    JPEG,
        //    pdf,
        //    doc,
        //    mp3,
        //    rar,
        //    swf,

        //    unknown
        //}

        //public static ImageFormats GetImageFormat(byte[] bytes)
        //{
        //    var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
        //    var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
        //    var png = new byte[] { 137, 80, 78, 71 };    // PNG
        //    var png1 = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 };
        //    var tiff = new byte[] { 73, 73, 42 };         // TIFF
        //    var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
        //    var jpeg = new byte[] { 255, 216, 255, 224 };  // jpeg
        //    var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon
        //    var JPEG = new byte[] { 255, 216, 255, 237 };  // JPEG 
        //    var pdf = new byte[] { 37, 80, 68, 70, 45, 49, 46 };   // PDF 

        //    var doc = new byte[] { 208, 207, 17, 224, 161, 177, 26, 225 };
        //    var mp3 = new byte[] { 255, 251, 48 };
        //    var rar = new byte[] { 82, 97, 114, 33, 26, 7, 0 };
        //    var swf = new byte[] { 70, 87, 83 };



        //    if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
        //        return ImageFormats.bmp;

        //    if (gif.SequenceEqual(bytes.Take(gif.Length)))
        //        return ImageFormats.gif;

        //    if (png1.SequenceEqual(bytes.Take(png1.Length)))
        //        return ImageFormats.png;

        //    if (png.SequenceEqual(bytes.Take(png.Length)))
        //        return ImageFormats.png;

        //    if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
        //        return ImageFormats.tiff;

        //    if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
        //        return ImageFormats.tiff;

        //    if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
        //        return ImageFormats.jpeg;

        //    if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
        //        return ImageFormats.jpeg;

        //    if (JPEG.SequenceEqual(bytes.Take(JPEG.Length)))
        //        return ImageFormats.JPEG;



        //    if (pdf.SequenceEqual(bytes.Take(pdf.Length)))
        //        return ImageFormats.pdf;

        //    if (doc.SequenceEqual(bytes.Take(doc.Length)))
        //        return ImageFormats.doc;

        //    if (mp3.SequenceEqual(bytes.Take(mp3.Length)))
        //        return ImageFormats.mp3;

        //    if (rar.SequenceEqual(bytes.Take(rar.Length)))
        //        return ImageFormats.rar;

        //    if (swf.SequenceEqual(bytes.Take(swf.Length)))
        //        return ImageFormats.swf;



        //    return ImageFormats.unknown;
        //}

        //public async Task<ApiResultObject<string>> UploadImage(byte[] fileBytes, string actionString, int documenttype, string myurl)
        //{
        //    try
        //    {
        //        //   string imageType = "Image";
        //        //    string getGuid = !String.IsNullOrEmpty(actionString)? actionString.Substring(actionString.IndexOf(imageType) + (imageType.Length + 1)) :"";
        //        string getGuid = !String.IsNullOrEmpty(actionString) ? actionString.Substring(actionString.LastIndexOf('/') + 1) : "";

        //        string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{PathFile[documenttype]}");
        //        if (fileBytes == null) // detete Action for Ad so remove image and no image bytes sended
        //        {

        //            string deletePath = Path.Combine(path, getGuid);
        //            // System.IO.File.Exists(deletePath)
        //            try
        //            {
        //                File.Delete(deletePath);
        //            }
        //            catch
        //            {
        //            }

        //            return new ApiResultObject<string>()
        //            {
        //                Result = OperationResultTypes.Success,
        //            };
        //        }
        //        else
        //        {
        //            if (String.IsNullOrEmpty(actionString)) // Save Action for Ad so no path sended 
        //            {
        //                return await WriteFile(fileBytes, documenttype, myurl);
        //            }
        //            else // Edit Action for Ad so search on old image path to remove 
        //            {
        //                string deletePath = Path.Combine(path, getGuid);
        //                try
        //                {
        //                    File.Delete(deletePath);
        //                }
        //                catch
        //                {
        //                }

        //                return await WriteFile(fileBytes, documenttype, myurl);// Edit Action for Ad so Save new image  
        //            }
        //        }
        //        return new ApiResultObject<string>()
        //        {
        //            Result = OperationResultTypes.Failed,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResultObject<string>()
        //        {
        //            Result = OperationResultTypes.Exeption,
        //            Data = ex.Message
        //        };
        //    }
        //}

        //public async Task<ApiResultObject<string>> WriteFile(byte[] file, int documenttype, string myurl)
        //{
        //    string PathDB;
        //    try
        //    {
        //        //  var extension = "." + file.Name.Split('.')[file.Name.Split('.').Length - 1];
        //        PathDB = Guid.NewGuid().ToString() + "." + ExtensionMethods.GetImageFormat(file);
        //        var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{PathFile[documenttype]}", PathDB);

        //        PathDB = $"{myurl}/{PathFile[documenttype]}/{PathDB}";
        //        // PathDB = $"{myurl}/{PathFile[documenttype]}\\{PathDB}";
        //        using (var bits = new FileStream(path, FileMode.Create))
        //        {
        //            await bits.WriteAsync(file, 0, file.Length);

        //            //await file.CopyToAsync(bits);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResultObject<string>()
        //        { Result = OperationResultTypes.Exeption, Data = ex.Message };
        //    }

        //    return new ApiResultObject<string>()
        //    { Result = OperationResultTypes.Success, Data = PathDB };
        //}
    }
}

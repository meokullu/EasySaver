using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;
using static EasySaver.EasySaver;

namespace EasySaver.BitmapFile
{
    /// <summary>
    /// 
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class EasySaverBitmapFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fileName"></param>
        /// <param name="namingFormat"></param>
        public static void Save(Bitmap bitmap, string fileName, NamingFormat namingFormat = NamingFormat.RandomName)
        {
            //
            if (namingFormat == NamingFormat.Custom)
            {
                //
            }
            else if (namingFormat == NamingFormat.RandomName)
            {
                // If file name is null bring random name from list.
                fileName ??= GetAvailableFileName();
            }
            else
            {
                // If file name is not given it gets fileName from pre-chosen formatted DateTimeStamp.
                fileName ??= GetFormattedDateTimeStamp(namingFormat: namingFormat);
            }

            // Writing a file into location.
            bitmap.Save($"./{fileName}", ImageFormat.Bmp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fileName"></param>
        /// <param name="folderName"></param>
        /// <param name="namingFormat"></param>
        [SupportedOSPlatform("windows")]
        public static void Save(Bitmap bitmap, string fileName, string folderName, NamingFormat namingFormat = NamingFormat.RandomName)
        {
            //
            if (namingFormat == NamingFormat.Custom)
            {
                //
            }
            else if (namingFormat == NamingFormat.RandomName)
            {
                // If file name is null bring random name from list.
                fileName ??= GetAvailableFileName();
            }
            else
            {
                //
                fileName ??= GetFormattedDateTimeStamp(namingFormat: namingFormat);
            }

            // Creating folder if it doesn't exist. If folder is already exists, CreateDirectory ignores it.
            System.IO.Directory.CreateDirectory($"{folderName}\\");

            //
            bitmap.Save($"./{folderName}/{fileName}", ImageFormat.Bmp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fileName"></param>
        /// <param name="namingFormat"></param>
        /// <returns></returns>
        [SupportedOSPlatform("windows")]
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName, NamingFormat namingFormat = NamingFormat.RandomName)
        {
            //
            if (namingFormat == NamingFormat.Custom)
            {
                //
            }
            else if (namingFormat == NamingFormat.RandomName)
            {
                // If file name is null bring random name from list.
                fileName ??= GetAvailableFileName();
            }
            else
            {
                //
                fileName ??= GetFormattedDateTimeStamp(namingFormat: namingFormat);
            }

            try
            {
                //
                bitmap.Save($"./{fileName}", ImageFormat.Bmp);

                //
                return (true, null);
            }
            catch (Exception ex)
            {
                //
                return (false, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fileName"></param>
        /// <param name="folderName"></param>
        /// <param name="namingFormat"></param>
        /// <returns></returns>
        [SupportedOSPlatform("windows")]
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName, string folderName, NamingFormat namingFormat = NamingFormat.RandomName)
        {
            //
            if (namingFormat == NamingFormat.Custom)
            {
                //
            }
            else if (namingFormat == NamingFormat.RandomName)
            {
                // If file name is null bring random name from list.
                fileName ??= GetAvailableFileName();
            }
            else
            {
                //
                fileName ??= GetFormattedDateTimeStamp(namingFormat: namingFormat);
            }

            try
            {
                // Creating folder if it doesn't exist. If folder is already exists, CreateDirectory ignores it.
                Directory.CreateDirectory($"{folderName}\\");

                //
                bitmap.Save($"./{folderName}/{fileName}", ImageFormat.Bmp);

                //
                return (true, null);
            }
            catch (Exception ex)
            {
                //
                return (false, ex);
            }
        }
    }
}
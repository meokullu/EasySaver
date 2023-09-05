using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;
using static EasySaver.Common.EasySaver;

namespace EasySaver.BitmapFile
{
    /// <summary>
    /// 
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class EasySaverBitmapFile
    {
        private static void Save(string path, Bitmap bitmap)
        {
            //
            bitmap.Save(path);
        }

        private static (bool, Exception?) SaveSafe(string path, Bitmap bitmap)
        {
            try
            {
                //
                Save(path: path, bitmap: bitmap);

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
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        [SupportedOSPlatform("windows")]
        public static bool Save(Bitmap bitmap, string fileName, NamingFormat namingFormat = NamingFormat.RandomName, bool overwrite = false, bool renameIfExists = true)
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

            //
            bool ifExist = CheckIfFileExist(path: $"./{fileName}");

            //
            if (ifExist == false)
            {
                //
                Save(path: fileName, bitmap: bitmap);

                //
                return true;
            }
            else if (overwrite == false)
            {
                //
                for (int i = 0; i < 255; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"./{fileName}({i})") == false)
                    {
                        //
                        Save(path: fileName, bitmap: bitmap);

                        //
                        return true;
                    }
                }

                //
                return false;
            }
            else
            {
                //
                Save(path: fileName, bitmap: bitmap);

                //
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fileName"></param>
        /// <param name="folderName"></param>
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        [SupportedOSPlatform("windows")]
        public static bool Save(Bitmap bitmap, string fileName, string folderName, NamingFormat namingFormat = NamingFormat.RandomName, bool overwrite = false, bool renameIfExists = false)
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

            //
            if (CheckIfFolderExist(folderName) == false)
            {
                // Creating folder if it doesn't exist. If folder is already exists, CreateDirectory ignores it.
                _ = System.IO.Directory.CreateDirectory($"{folderName}\\");
            }

            //
            bool ifExists = CheckIfFileExist(path: $"{folderName}/{fileName}");

            //
            if (ifExists == false)
            {
                //
                Save(path: $"{folderName}/{fileName}", bitmap: bitmap);

                //
                return true;
            }
            else if (overwrite == false)
            {
                //
                for (int i = 0; i < 255; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i})"))
                    {
                        //
                        Save(path: $"{folderName}/{fileName}({i})", bitmap: bitmap);

                        //
                        return true;
                    }
                }

                //
                return false;
            }
            else
            {
                //
                Save(path: fileName, bitmap: bitmap);

                //
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fileName"></param>
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        /// <returns></returns>
        [SupportedOSPlatform("windows")]
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName, NamingFormat namingFormat = NamingFormat.RandomName, bool overwrite = false, bool renameIfExists = true)
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

            //
            bool fileExists = CheckIfFileExist(path: $"./{fileName}");

            if (fileExists == false)
            {
                //
                (bool, Exception?) _result = SaveSafe(path: fileName, bitmap: bitmap);

                //
                return _result;
            }
            else if (overwrite == false)
            {
                //
                for (int i = 0; i < 255; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"./{fileName}({i})") == false)
                    {
                        //
                        (bool, Exception?) result = SaveSafe(path: $"{fileName}({i})", bitmap: bitmap);

                        //
                        return result;
                    }
                }

                //
                return (false, new ArgumentOutOfRangeException());

            }
            else
            {
                //
                (bool, Exception?) result = SaveSafe(path: fileName, bitmap: bitmap);

                //
                return result;
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
                _ = Directory.CreateDirectory($"{folderName}\\");

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

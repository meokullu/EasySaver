using System;
using System.Drawing;
using System.Reflection;
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
        #region Saving

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bitmap"></param>
        private static void Save(string path, Bitmap bitmap)
        {
            //
            bitmap.Save(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bitmap"></param>
        /// <returns></returns>
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

        #endregion Saving

        /// <summary>
        /// Save bitmap into default folder.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fileName"></param>
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        [SupportedOSPlatform("windows")]
        public static bool Save(Bitmap bitmap, string fileName, NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
        {
            //
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            //
            bool ifExist = CheckIfFileExist(path: $"{fileName}{_defaultImageExtension}");

            //
            if (ifExist == false)
            {
                //
                Save(path: $"./{fileName}{_defaultImageExtension}", bitmap: bitmap);

                //
                return true;
            }
            else if (overwrite == false && renameIfExists)
            {
                //
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{fileName}({i}){_defaultImageExtension}") == false)
                    {
                        //
                        Save(path: $"./{fileName}({i}){_defaultImageExtension}", bitmap: bitmap);

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
                Save(path: $"./{fileName}{_defaultImageExtension}", bitmap: bitmap);

                //
                return true;
            }
        }

        /// <summary>
        /// Save bitmap into given folder path.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fileName"></param>
        /// <param name="folderName"></param>
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        [SupportedOSPlatform("windows")]
        public static bool Save(Bitmap bitmap, string fileName, string folderName = "Data", NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
        {
            //
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            //
            if (CheckIfFolderExist(folderName) == false)
            {
                // Creating folder if it doesn't exist. If folder is already exists, CreateDirectory ignores it.
                _ = System.IO.Directory.CreateDirectory($"{folderName}\\");
            }

            //
            bool ifExists = CheckIfFileExist(path: $"{folderName}/{fileName}{_defaultImageExtension}");

            //
            if (ifExists == false)
            {
                //
                Save(path: $"./{folderName}/{fileName}{_defaultImageExtension}", bitmap: bitmap);

                //
                return true;
            }
            else if (overwrite == false && renameIfExists)
            {
                //
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i}){_defaultImageExtension}") == false)
                    {
                        //
                        Save(path: $"./{folderName}/{fileName}({i}){_defaultImageExtension}", bitmap: bitmap);

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
                Save(path: $"./{folderName}/{fileName}{_defaultImageExtension}", bitmap: bitmap);

                //
                return true;
            }
        }

        /// <summary>
        /// Save bitmap default folder with try-catch mechanism.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fileName"></param>
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        /// <returns></returns>
        [SupportedOSPlatform("windows")]
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName, NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
        {
            //
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            //
            bool fileExists = CheckIfFileExist(path: $"{fileName}{_defaultImageExtension}");

            //
            if (fileExists == false)
            {
                //
                (bool, Exception?) _result = SaveSafe(path: $"./{fileName}{_defaultImageExtension}", bitmap: bitmap);

                //
                return _result;
            }
            else if (overwrite == false && renameIfExists)
            {
                //
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{fileName}({i}){_defaultImageExtension}") == false)
                    {
                        //
                        (bool, Exception?) result = SaveSafe(path: $"{fileName}({i}){_defaultImageExtension}", bitmap: bitmap);

                        //
                        return result;
                    }
                }

                //
                return (false, new ArgumentOutOfRangeException(paramName: null, message: MaxAttemptMessage(MethodBase.GetCurrentMethod()!.Name)));

            }
            else
            {
                //
                (bool, Exception?) result = SaveSafe(path: $"./{fileName}{_defaultImageExtension}", bitmap: bitmap);

                //
                return result;
            }
        }

        /// <summary>
        /// Save bitmap into given folder path with try-catch mechanism.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fileName"></param>
        /// <param name="folderName"></param>
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        /// <returns></returns>
        [SupportedOSPlatform("windows")]
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName, string folderName = "Data", NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true) 
        {
            //
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            //
            if (CheckIfFolderExist($"./{folderName}") == false)
            {
                // Creating folder if it doesn't exist. If folder is already exists, CreateDirectory ignores it.
                _ = System.IO.Directory.CreateDirectory($"{folderName}\\");
            }

            //
            bool fileExists = CheckIfFileExist($"{folderName}/{fileName}");

            //
            if (fileExists == false)
            {
                //
                (bool, Exception?) result = SaveSafe(path: $"./{folderName}/{fileName}{_defaultImageExtension}", bitmap: bitmap);

                //
                return result;
            }
            else if(overwrite == false && renameIfExists)
            {
                //
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i}){_defaultImageExtension}") == false)
                    {
                        //
                        (bool, Exception?) result = SaveSafe(path: $"{folderName}{fileName}{_defaultImageExtension}", bitmap: bitmap);

                        //
                        return result;
                    }
                }

                //
                return (false, new ArgumentOutOfRangeException(paramName: null, message: MaxAttemptMessage(MethodBase.GetCurrentMethod()!.Name)));
            }
            else
            {
                //
                (bool, Exception?) result = SaveSafe(path: $"./{folderName}/{fileName}{_defaultImageExtension}", bitmap: bitmap);

                //
                return result;
            }
        }
    }
}

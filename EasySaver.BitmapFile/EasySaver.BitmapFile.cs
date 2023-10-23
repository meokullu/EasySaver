using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.Versioning;
using static EasySaver.Common.EasySaver;

namespace EasySaver.BitmapFile
{
    /// <summary>
    /// EasySaver BitmapFile
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class EasySaverBitmapFile
    {
        #region Saving

        // Saving file via Image.File().
        private static void Save(string path, Bitmap bitmap)
        {
            // Saving bitmap with specified path.
            bitmap.Save(path);
        }

        // Saving file via Image.File() with try-catch exception.
        private static (bool, Exception?) SaveSafe(string path, Bitmap bitmap)
        {
            try
            {
                // Try to save bitmap with specified path.
                Save(path: path, bitmap: bitmap);

                // Returning true with no exception.
                return (true, null);
            }
            catch (Exception ex)
            {
                // Returning false with exception.
                return (false, ex);
            }
        }

        #endregion Saving

        /// <summary>
        /// Save bitmap into path with naming.
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <param name="renameIfExists">Specify if file should renamed with number if exists already.</param>
        /// <returns>True or false.</returns>
        [SupportedOSPlatform("windows")]
        public static bool Save(Bitmap bitmap, string fileName, NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
        {
            // Calls GetFileName() to decide fileName with adding extension at the end.
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            // Checking if file exist via CheckIfFileExist().
            bool ifExist = CheckIfFileExist(path: $"{fileName}{_defaultImageExtension}");

            // Checking if file doesn't exist.
            if (ifExist == false)
            {
                // Saving file via Save().
                Save(path: $"./{fileName}{_defaultImageExtension}", bitmap: bitmap);

                // Returning true as successful process.
                return true;
            }
            // If file exists, overwrite is false but renameIfExist is true. File will be renamed and both of them will be kept.
            else if (overwrite == false && renameIfExists)
            {
                // Loop for attempt of creating new name via adding number.
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    // Checking if file exist.
                    if (CheckIfFileExist(path: $"{fileName}({i}){_defaultImageExtension}") == false)
                    {
                        // Saving file via Save().
                        Save(path: $"./{fileName}({i}){_defaultImageExtension}", bitmap: bitmap);

                        // Returning true as successful process.
                        return true;
                    }
                }

                // File isn't save because _maxAttemptForRename is reached.
                return false;
            }
            else
            {
                // Saving file via Save().
                Save(path: $"./{fileName}{_defaultImageExtension}", bitmap: bitmap);

                // Returning true as successful process.
                return true;
            }
        }

        /// <summary>
        /// Save bitmap into given folder path with naming.
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <param name="renameIfExists">Specify if file should renamed with number if exists already.</param>
        /// <returns>True or false.</returns>
        [SupportedOSPlatform("windows")]
        public static bool Save(Bitmap bitmap, string fileName, string folderName = "Data", NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
        {
            // Calls GetFileName() to decide fileName.
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            // Checking if folder exists.
            if (CheckIfFolderExist(folderName) == false)
            {
                // Creating folder if it doesn't exist. If folder is already exists, CreateDirectory ignores it.
                _ = System.IO.Directory.CreateDirectory($"{folderName}\\");
            }

            // Checking if file exist via CheckIfFileExist().
            bool ifExists = CheckIfFileExist(path: $"{folderName}/{fileName}{_defaultImageExtension}");

            // Checking if file doesn't exist.
            if (ifExists == false)
            {
                // Saving file via Save().
                Save(path: $"./{folderName}/{fileName}{_defaultImageExtension}", bitmap: bitmap);

                // Returning true as successful process.
                return true;
            }
            // If file exists, overwrite is false but renameIfExist is true. File will be renamed and both of them will be kept.
            else if (overwrite == false && renameIfExists)
            {
                // Loop for attempt of creating new name via adding number.
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    // Checking if file exist.
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i}){_defaultImageExtension}") == false)
                    {
                        // Saving file via Save().
                        Save(path: $"./{folderName}/{fileName}({i}){_defaultImageExtension}", bitmap: bitmap);

                        // Returning true as successful process.
                        return true;
                    }
                }

                // File isn't save because _maxAttemptForRename is reached.
                return false;
            }
            else
            {
                // Saving file via Save().
                Save(path: $"./{folderName}/{fileName}{_defaultImageExtension}", bitmap: bitmap);

                // Returning true as successful process.
                return true;
            }
        }

        /// <summary>
        /// Save bitmap default folder with try-catch mechanism.
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <param name="renameIfExists">Specify if file should renamed with number if exists already.</param>
        /// <returns>True or false with exception.</returns>
        [SupportedOSPlatform("windows")]
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName, NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
        {
            // Calls GetFileName() to decide fileName.
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            // Checking if file exist via CheckIfFileExist().
            bool fileExists = CheckIfFileExist(path: $"{fileName}{_defaultImageExtension}");

            // Checking if file doesn't exist.
            if (fileExists == false)
            {
                // Saving file via SaveSafe().
                (bool, Exception?) result = SaveSafe(path: $"./{fileName}{_defaultImageExtension}", bitmap: bitmap);

                // Returning result to indicate if process is successful or failed with exception.
                return result;
            }
            // If file exists, overwrite is false but renameIfExist is true. File will be renamed and both of them will be kept.
            else if (overwrite == false && renameIfExists)
            {
                // Loop for attempt of creating new name via adding number.
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    // Checking if file exist.
                    if (CheckIfFileExist(path: $"{fileName}({i}){_defaultImageExtension}") == false)
                    {
                        // Saving file via SaveSafe().
                        (bool, Exception?) result = SaveSafe(path: $"{fileName}({i}){_defaultImageExtension}", bitmap: bitmap);

                        // Returning result to indicate if process is successful or failed with exception.
                        return result;
                    }
                }

                // Returning false with an exception of maximum attempt is reached to rename file.
                return (false, new ArgumentOutOfRangeException(paramName: null, message: MaxAttemptMessage(MethodBase.GetCurrentMethod()!.Name)));
            }
            // If file exists, overwrite is false but renameIfExist is true. File will be renamed and both of them will be kept.
            else
            {
                // Saving file via SaveSafe().
                (bool, Exception?) result = SaveSafe(path: $"./{fileName}{_defaultImageExtension}", bitmap: bitmap);

                // Returning result to indicate if process is successful or failed with exception.
                return result;
            }
        }

        /// <summary>
        /// Save bitmap into given folder path with try-catch mechanism.
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <param name="renameIfExists">Specify if file should renamed with number if exists already.</param>
        /// <returns>True or false with exception.</returns>
        [SupportedOSPlatform("windows")]
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName, string folderName = "Data", NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true) 
        {
            // Calls GetFileName() to decide fileName.
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            // Checking if folder exists.
            if (CheckIfFolderExist($"./{folderName}") == false)
            {
                // Creating folder if it doesn't exist. If folder is already exists, CreateDirectory ignores it.
                _ = System.IO.Directory.CreateDirectory($"{folderName}\\");
            }

            // Checking if file exist via CheckIfFileExist().
            bool fileExists = CheckIfFileExist($"{folderName}/{fileName}");

            // Checking if file doesn't exist.
            if (fileExists == false)
            {
                // Saving file via SaveSafe().
                (bool, Exception?) result = SaveSafe(path: $"./{folderName}/{fileName}{_defaultImageExtension}", bitmap: bitmap);

                // Returning result to indicate if process is successful or failed with exception.
                return result;
            }
            // If file exists, overwrite is false but renameIfExist is true. File will be renamed and both of them will be kept.
            else if (overwrite == false && renameIfExists)
            {
                // Loop for attempt of creating new name via adding number.
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    // Checking if file exist.
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i}){_defaultImageExtension}") == false)
                    {
                        // Saving file via SaveSafe().
                        (bool, Exception?) result = SaveSafe(path: $"{folderName}{fileName}{_defaultImageExtension}", bitmap: bitmap);

                        // Returning result to indicate if process is successful or failed with exception.
                        return result;
                    }
                }

                // Returning false with an exception of maximum attempt is reached to rename file.
                return (false, new ArgumentOutOfRangeException(paramName: null, message: MaxAttemptMessage(MethodBase.GetCurrentMethod()!.Name)));
            }
            else
            {
                // Saving file via SaveSafe().
                (bool, Exception?) result = SaveSafe(path: $"./{folderName}/{fileName}{_defaultImageExtension}", bitmap: bitmap);

                // Returning result to indicate if process is successful or failed with exception.
                return result;
            }
        }
    }
}

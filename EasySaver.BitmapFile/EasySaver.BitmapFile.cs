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

        // Saving file via Image.File() with try-catch exception. Calls Save(string path, Bitmap bitmap)
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

        #region Default Choices

        // Default value if FileName is not provided.
        private readonly static string _defaultFileName = "";

        // Default value if NamingFormat is not provided.
        private readonly static NamingFormat _defaultNamingFormat = NamingFormat.DateTime;

        // Default value when using Save(Bitmap bitmap, string fileName) and SaveToFolder(Bitmap bitmap, string folderName, string fileName). Since there is only NamingFormat option available to use by design, this value is internally provided for shorter method usage.
        private readonly static NamingFormat _onlyBitmapProvidedNamingFormat = NamingFormat.Custom;

        private readonly static string _defaultFolderName = "Data";
        private readonly static bool _defaultOverwrite = false;
        private readonly static bool _defaultRenameIfExists = true;

        #endregion Default Choices

        #region Save to default path.

        /// <summary>
        /// Save bitmap into path with naming. Calls <see cref="Save(Bitmap, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <returns>True or false.</returns>
        public static bool Save(Bitmap bitmap)
        {
            return Save(bitmap: bitmap, fileName: _defaultFileName, namingFormat: _defaultNamingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into path with naming. Calls <see cref="Save(Bitmap, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <returns>True or false.</returns>
        public static bool Save(Bitmap bitmap, string fileName)
        {
            return Save(bitmap: bitmap, fileName: fileName, namingFormat: _onlyBitmapProvidedNamingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into path with naming. Calls <see cref="Save(Bitmap, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param> 
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <returns>True or false.</returns>
        public static bool Save(Bitmap bitmap, string fileName, NamingFormat namingFormat)
        {
            return Save(bitmap: bitmap, fileName: fileName, namingFormat: namingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into path with naming. Calls <see cref="Save(Bitmap, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <returns>True or false.</returns>
        public static bool Save(Bitmap bitmap, string fileName, NamingFormat namingFormat, bool overwrite)
        {
            return Save(bitmap: bitmap, fileName: fileName, namingFormat: namingFormat, overwrite: overwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into path with naming.
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <param name="renameIfExists">Specify if file should renamed with number if exists already.</param>
        /// <returns>True or false.</returns>
        public static bool Save(Bitmap bitmap, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)
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

        #endregion Save to default path.

        #region Save to folder path.

        /// <summary>
        /// Save bitmap into given folder path with naming. Calls <see cref="SaveToFolder(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <returns>True or false.</returns>
        public static bool SaveToFolder(Bitmap bitmap)
        {
            return SaveToFolder(bitmap: bitmap, folderName: _defaultFolderName, fileName: _defaultFileName, namingFormat: _defaultNamingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into given folder path with naming. Calls <see cref="SaveToFolder(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <returns>True or false.</returns>
        public static bool SaveToFolder(Bitmap bitmap, string folderName)
        {
            return SaveToFolder(bitmap: bitmap, folderName: folderName, fileName: _defaultFileName, namingFormat: _defaultNamingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into given folder path with naming. Calls <see cref="SaveToFolder(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <returns>True or false.</returns>
        public static bool SaveToFolder(Bitmap bitmap, string folderName, string fileName)
        {
            return SaveToFolder(bitmap: bitmap, folderName: folderName, fileName: fileName, namingFormat: _onlyBitmapProvidedNamingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into given folder path with naming. Calls <see cref="SaveToFolder(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <returns>True or false.</returns>
        public static bool SaveToFolder(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat)
        {
            return SaveToFolder(bitmap: bitmap, folderName: folderName, fileName: fileName, namingFormat: namingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into given folder path with naming. Calls <see cref="SaveToFolder(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <returns>True or false.</returns>
        public static bool SaveToFolder(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite)
        {
            return SaveToFolder(bitmap: bitmap, folderName: folderName, fileName: fileName, namingFormat: namingFormat, overwrite: overwrite, renameIfExists: _defaultRenameIfExists);
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
        public static bool SaveToFolder(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)
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

        #endregion Save to folder path.

        #region Save to default path (Safe)

        /// <summary>
        /// Save bitmap default folder with try-catch mechanism. Calls <see cref="SaveSafe(Bitmap, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveSafe(Bitmap bitmap)
        {
            return SaveSafe(bitmap: bitmap, fileName: _defaultFileName, namingFormat: _onlyBitmapProvidedNamingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap default folder with try-catch mechanism. Calls <see cref="SaveSafe(Bitmap, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName)
        {
            return SaveSafe(bitmap: bitmap, fileName: fileName, namingFormat: _onlyBitmapProvidedNamingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap default folder with try-catch mechanism. Calls <see cref="SaveSafe(Bitmap, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName, NamingFormat namingFormat)
        {
            return SaveSafe(bitmap: bitmap, fileName: fileName, namingFormat: namingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap default folder with try-catch mechanism. Calls <see cref="SaveSafe(Bitmap, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName, NamingFormat namingFormat, bool overwrite)
        {
            return SaveSafe(bitmap: bitmap, fileName: fileName, namingFormat: namingFormat, overwrite: overwrite, renameIfExists: _defaultRenameIfExists);
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
        public static (bool, Exception?) SaveSafe(Bitmap bitmap, string fileName, NamingFormat namingFormat, bool overwrite = false, bool renameIfExists = true)
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

        #endregion Save to default path (Safe)

        #region Save to folder path (Safe)

        /// <summary>
        /// Save bitmap into given folder path with try-catch mechanism. Calls <see cref="SaveToFolderSafe(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveToFolderSafe(Bitmap bitmap)
        {
            return SaveToFolderSafe(bitmap: bitmap, folderName: _defaultFolderName, fileName: _defaultFileName, namingFormat: _onlyBitmapProvidedNamingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into given folder path with try-catch mechanism. Calls <see cref="SaveToFolderSafe(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveToFolderSafe(Bitmap bitmap, string folderName)
        {
            return SaveToFolderSafe(bitmap: bitmap, folderName: folderName, fileName: _defaultFileName, namingFormat: _defaultNamingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into given folder path with try-catch mechanism. Calls <see cref="SaveToFolderSafe(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName)
        {
            return SaveToFolderSafe(bitmap: bitmap, folderName: folderName, fileName: fileName, namingFormat: _defaultNamingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into given folder path with try-catch mechanism. Calls <see cref="SaveToFolderSafe(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat)
        {
            return SaveToFolderSafe(bitmap: bitmap, folderName: folderName, fileName: fileName, namingFormat: namingFormat, overwrite: _defaultOverwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into given folder path with try-catch mechanism. Calls <see cref="SaveToFolderSafe(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite)
        {
            return SaveToFolderSafe(bitmap: bitmap, folderName: folderName, fileName: fileName, namingFormat: namingFormat, overwrite: overwrite, renameIfExists: _defaultRenameIfExists);
        }

        /// <summary>
        /// Save bitmap into given folder path with try-catch mechanism. Calls <see cref="SaveToFolderSafe(Bitmap, string, string, NamingFormat, bool, bool)"/>
        /// </summary>
        /// <param name="bitmap">Bitmap file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <param name="renameIfExists">Specify if file should renamed with number if exists already.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)
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

        #endregion Save to folder path (Safe)
    }
}

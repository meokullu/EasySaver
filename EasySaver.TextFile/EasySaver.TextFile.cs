using System;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
using static EasySaver.Common.EasySaver;

namespace EasySaver.TextFile
{
    /// <summary>
    /// EasySaver TextFile
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class EasySaverTextFile
    {
        #region Write

        // Saving file via StreamWriter.Write().
        private static void WriteViaStreamWriter(string path, string text)
        {
            // Using StreamWriter to use Write().
            using StreamWriter writer = new(path);

            // Saving text with specified path.
            writer.Write(text);
        }

        // Saving file via StreamWriter.Write() with try-catch exception.
        private static (bool, Exception?) WriteViaStreamWriterSafe(string path, string text)
        {
            try
            {
                // Try to save text with specified path.
                WriteViaStreamWriter(path: path, text: text);

                // Returning true with no exception.
                return (true, null);
            }
            catch (Exception ex)
            {
                // Returning false with exception.
                return (false, ex);
            }
        }

        #endregion Write

        /// <summary>
        /// Save file with into path with naming.
        /// </summary>
        /// <param name="text">Text file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <param name="renameIfExists">Specify if file should renamed with number if exists already.</param>
        /// <returns>True or false.</returns>
        public static bool Save(string text, string fileName, NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
        {
            // Calls GetFileName() to decide fileName with adding extension at the end.
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            // Checking if file exist via CheckIfFileExist().
            bool _fileExists = CheckIfFileExist(path: $"{fileName}{_defaultTextExtension}");

            // Checking if file doesn't exist.
            if (_fileExists == false)
            {
                // Saving file via WriteViaStreamWriter().
                WriteViaStreamWriter(path: $"./{fileName}{_defaultTextExtension}", text: text);

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
                    if (CheckIfFileExist(path: $"{fileName}({i}){_defaultTextExtension}") == false)
                    {
                        // Saving file via WriteViaStreamWriter().
                        WriteViaStreamWriter(path: $"./{fileName}({i}){_defaultTextExtension}", text: text);
                        
                        // Returning true as successful process.
                        return true;
                    }
                }

                // File isn't save because _maxAttemptForRename is reached.
                return false;
            }
            else
            {
                // Saving file via WriteViaStreamWriter().
                WriteViaStreamWriter(path: $"./{fileName}{_defaultTextExtension}", text: text);

                // Returning true as successful process.
                return true;
            }
        }

        /// <summary>
        /// Save text into given folder path with naming.
        /// </summary>
        /// <param name="text">Text file to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <param name="renameIfExists">Specify if file should renamed with number if exists already.</param>
        /// <returns>True or false.</returns>
        public static bool Save(string text, string fileName, string folderName = "Data", NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
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
            bool fileExists = CheckIfFileExist(path: $"{folderName}/{fileName}{_defaultTextExtension}");

            // Checking if file doesn't exist.
            if (fileExists == false)
            {
                // Saving file via WriteViaStreamWriter().
                WriteViaStreamWriter(path: $"./{folderName}/{fileName}{_defaultTextExtension}", text: text);

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
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i}){_defaultTextExtension}") == false)
                    {
                        // Saving file via WriteViaStreamWriter().
                        WriteViaStreamWriter(path: $"./{folderName}/{fileName}({i}){_defaultTextExtension}", text: text);

                        // Returning true as successful process.
                        return true;
                    }
                }

                // File isn't save because _maxAttemptForRename is reached.
                return false;
            }
            else
            {
                // Saving file via WriteViaStreamWriter().
                WriteViaStreamWriter(path: $"./{folderName}/{fileName}{_defaultTextExtension}", text: text);

                // Returning true as successful process.
                return true;
            }
        }

        /// <summary>
        /// Save text file default folder with try-catch mechanism.
        /// </summary>
        /// <param name="text">Text to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <param name="renameIfExists">Specify if file should renamed with number if exists already.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveSafe(string text, string fileName, NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
        {
            // Calls GetFileName() to decide fileName.
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            // Checking if file exist via CheckIfFileExist().
            bool fileExists = CheckIfFileExist(path: $"./{fileName}{_defaultTextExtension}");

            // Checking if file doesn't exist.
            if (fileExists == false)
            {
                // Saving file via SaveSafe().
                (bool, Exception?) result = WriteViaStreamWriterSafe(path: fileName + _defaultTextExtension, text: text);

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
                    if (CheckIfFileExist(path: $"{fileName}({i}){_defaultTextExtension}") == false)
                    {
                        // Saving file via WriteViaStreamWriterSafe().
                        (bool, Exception?) _result = WriteViaStreamWriterSafe(path: $"./{fileName}({i}{_defaultTextExtension}", text: text);

                        // Returning result to indicate if process is successful or failed with exception.
                        return _result;
                    }
                }

                // Returning false with an exception of maximum attempt is reached to rename file.
                return (false, new ArgumentOutOfRangeException(paramName: null, message: MaxAttemptMessage(MethodBase.GetCurrentMethod()!.Name)));
            }
            // If file exists, overwrite is false but renameIfExist is true. File will be renamed and both of them will be kept.
            else
            {
                // Saving file via WriteViaStreamWriterSafe().
                (bool, Exception?) _result = WriteViaStreamWriterSafe(path: $"./{fileName}{_defaultTextExtension}", text: text);

                // Returning result to indicate if process is successful or failed with exception.
                return _result;
            }
        }

        /// <summary>
        /// Save text into given folder path with try-catch mechanism.
        /// </summary>
        /// <param name="text">Text to save.</param>
        /// <param name="fileName">Name of file when NamingFormat is Custom.</param>
        /// <param name="folderName">Folder name to create if doesn't exist and use for saving file.</param>
        /// <param name="namingFormat">NamingFormat option to apply.</param>
        /// <param name="overwrite">Specify if file should overwritten if file exists already.</param>
        /// <param name="renameIfExists">Specify if file should renamed with number if exists already.</param>
        /// <returns>True or false with exception.</returns>
        public static (bool, Exception?) SaveSafe(string text, string fileName, string folderName = "Data", NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
        {
            //// Calls GetFileName() to decide fileName.
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            // Checking if folder exists.
            if (CheckIfFolderExist($"{folderName}") == false)
            {
                // Creating folder if it doesn't exist. If folder is already exists, CreateDirectory ignores it.
                _ = System.IO.Directory.CreateDirectory($"{folderName}\\");
            }

            // Checking if file exist via CheckIfFileExist().
            bool fileExist = CheckIfFileExist($"./{folderName}/{fileName}" + _defaultTextExtension);

            // Checking if file doesn't exist.
            if (fileExist == false)
            {
                // Saving file via WriteViaStreamWriterSafe().
                (bool, Exception?) result = WriteViaStreamWriterSafe(path: $"./{folderName}/{fileName}{_defaultTextExtension}", text: text);

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
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i}){_defaultTextExtension}") == false)
                    {
                        // Saving file via SaveSafe().
                        (bool, Exception?) result = WriteViaStreamWriterSafe(path: $"./{folderName}/{fileName}({i}){_defaultTextExtension}", text: text);

                        // Returning result to indicate if process is successful or failed with exception.
                        return result;
                    }
                }

                // Returning false with an exception of maximum attempt is reached to rename file.
                return (false, new ArgumentOutOfRangeException(paramName: null, message: MaxAttemptMessage(MethodBase.GetCurrentMethod()!.Name)));
            }
            else
            {
                // Saving file via WriteViaStreamWriterSafe().
                (bool, Exception?) result = WriteViaStreamWriterSafe(path: $"./{fileName}{_defaultTextExtension}", text: text);

                // Returning result to indicate if process is successful or failed with exception.
                return result;
            }
        }
    }
}
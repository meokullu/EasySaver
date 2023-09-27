using System.Reflection;
using System.Runtime.Versioning;
using static EasySaver.Common.EasySaver;

namespace EasySaver.TextFile
{
    /// <summary>
    /// 
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class EasySaverTextFile
    {
        #region Write

        private static void WriteViaStreamWriter(string path, string text)
        {
            //
            using StreamWriter writer = new(path);

            //
            writer.Write(text);
        }

        private static (bool, Exception?) WriteViaStreamWriterSafe(string path, string text)
        {
            try
            {
                //
                WriteViaStreamWriter(path: path, text: text);

                //
                return (true, null);
            }
            catch (Exception ex)
            {
                //
                return (false, ex);
            }
        }

        #endregion Write

        /// <summary>
        /// Save file with
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fileName"></param>
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        public static bool Save(string text, string fileName, NamingFormat namingFormat = NamingFormat.DateTime, bool overwrite = false, bool renameIfExists = true)
        {
            // file name with its extension.
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            //
            bool _fileExists = CheckIfFileExist(path: $"{fileName}{_defaultTextExtension}");

            //
            if (_fileExists == false)
            {
                //
                WriteViaStreamWriter(path: $"./{fileName}{_defaultTextExtension}", text: text);

                //
                return true;
            }
            else if (overwrite == false && renameIfExists)
            {
                //
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{fileName}({i}){_defaultTextExtension}") == false)
                    {
                        //
                        WriteViaStreamWriter(path: $"./{fileName}({i}){_defaultTextExtension}", text: text);

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
                WriteViaStreamWriter(path: $"./{fileName}{_defaultTextExtension}", text: text);

                //
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fileName"></param>
        /// <param name="folderName"></param>
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        public static bool Save(string text, string fileName, string folderName = "Data", NamingFormat namingFormat = NamingFormat.Custom, bool overwrite = false, bool renameIfExists = true)
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
            bool _fileExists = CheckIfFileExist(path: $"{folderName}/{fileName}{_defaultTextExtension}");

            //
            if (_fileExists == false)
            {
                //
                WriteViaStreamWriter(path: $"./{folderName}/{fileName}{_defaultTextExtension}", text: text);

                //
                return true;
            }
            else if (overwrite == false && renameIfExists)
            {
                //
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i}){_defaultTextExtension}") == false)
                    {
                        //
                        WriteViaStreamWriter(path: $"./{folderName}/{fileName}({i}){_defaultTextExtension}", text: text);

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
                WriteViaStreamWriter(path: $"./{folderName}/{fileName}{_defaultTextExtension}", text: text);

                //
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fileName"></param>
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        /// <returns></returns>
        public static (bool, Exception?) SaveSafe(string text, string fileName, NamingFormat namingFormat = NamingFormat.Custom, bool overwrite = false, bool renameIfExists = true)
        {
            //
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            //
            bool fileExists = CheckIfFileExist(path: $"./{fileName}{_defaultTextExtension}");

            //
            if (fileExists == false)
            {
                //
                (bool, Exception?) _result = WriteViaStreamWriterSafe(path: fileName + _defaultTextExtension, text: text);

                //
                return _result;
            }
            else if (overwrite == false && renameIfExists)
            {
                //
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{fileName}({i}){_defaultTextExtension}") == false)
                    {
                        //
                        (bool, Exception?) _result = WriteViaStreamWriterSafe(path: $"./{fileName}({i}{_defaultTextExtension}", text: text);

                        //
                        return _result;
                    }
                }

                //
                return (false, new ArgumentOutOfRangeException(paramName: null, message: MaxAttemptMessage(MethodBase.GetCurrentMethod()!.Name)));
            }
            else
            {
                //
                (bool, Exception?) _result = WriteViaStreamWriterSafe(path: $"./{fileName}{_defaultTextExtension}", text: text);

                //
                return _result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fileName"></param>
        /// <param name="folderName"></param>
        /// <param name="namingFormat"></param>
        /// <param name="overwrite"></param>
        /// <param name="renameIfExists"></param>
        /// <returns></returns>
        public static (bool, Exception?) SaveSafe(string text, string fileName, string folderName = "Data", NamingFormat namingFormat = NamingFormat.Custom, bool overwrite = false, bool renameIfExists = true)
        {
            //
            fileName = GetFileName(fileName: fileName, namingFormat: namingFormat);

            //
            if (CheckIfFolderExist($"{folderName}") == false)
            {
                // Creating folder if it doesn't exist. If folder is already exists, CreateDirectory ignores it.
                _ = System.IO.Directory.CreateDirectory($"{folderName}\\");
            }

            //
            bool fileExist = CheckIfFileExist($"./{folderName}/{fileName}" + _defaultTextExtension);

            //
            if (fileExist == false)
            {
                //
                (bool, Exception?) result = WriteViaStreamWriterSafe(path: $"./{folderName}/{fileName}{_defaultTextExtension}", text: text);

                //
                return result;
            }
            else if (overwrite == false && renameIfExists)
            {
                //
                for (int i = 0; i < _maxAttemptForRename; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i}){_defaultTextExtension}") == false)
                    {
                        (bool, Exception?) result = WriteViaStreamWriterSafe(path: $"./{folderName}/{fileName}({i}){_defaultTextExtension}", text: text);

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
                (bool, Exception?) result = WriteViaStreamWriterSafe(path: $"./{fileName}{_defaultTextExtension}", text: text);

                //
                return result;
            }
        }
    }
}
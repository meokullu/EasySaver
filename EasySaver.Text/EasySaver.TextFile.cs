using static EasySaver.Common.EasySaver;

namespace EasySaver.TextFile
{
    /// <summary>
    /// 
    /// </summary>
    public class EasySaverTextFile
    {
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
            bool _fileExists = CheckIfFileExist(path: $"./{fileName}");

            //
            if (_fileExists == false)
            {
                //
                WriteViaStreamWriter(path: fileName, text: text);

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
                        WriteViaStreamWriter(path: $"{fileName}({i})", text: text);

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
                WriteViaStreamWriter(path: fileName, text: text);

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
        public static bool Save(string text, string fileName, string folderName = "Data", NamingFormat namingFormat = NamingFormat.RandomName, bool overwrite = false, bool renameIfExists = true)
        {
            //
            if (namingFormat == NamingFormat.Custom)
            {
                //
            }
            else if (namingFormat == NamingFormat.RandomName)
            {
                // if file name is null bring random name from list.
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
            bool _fileExists = CheckIfFileExist(path: $"{folderName}/{fileName}");

            //
            if (_fileExists == false)
            {
                //
                WriteViaStreamWriter(path: $"{folderName}/{fileName}", text: text);

                //
                return true;
            }
            else if (overwrite == false)
            {
                //
                for (int i = 0; i < 255; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i})") == false)
                    {
                        //
                        WriteViaStreamWriter(path: $"{folderName}/{fileName}({i})", text: text);

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
                WriteViaStreamWriter(path: fileName, text: text);

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
        public static (bool, Exception?) SaveSafe(string text, string fileName, NamingFormat namingFormat = NamingFormat.RandomName, bool overwrite = false, bool renameIfExists = true)
        {
            //
            if (namingFormat == NamingFormat.Custom)
            {
                //
            }
            else if (namingFormat == NamingFormat.RandomName)
            {
                //
                fileName ??= GetAvailableFileName();
            }
            else
            {
                //
                fileName ??= GetFormattedDateTimeStamp(namingFormat: namingFormat);
            }

            //
            bool _fileExists = CheckIfFileExist(path: $"./{fileName}");

            //
            if (_fileExists == false)
            {
                //
                (bool, Exception?) _result = WriteViaStreamWriterSafe(path: fileName, text: text);

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
                        (bool, Exception?) _result = WriteViaStreamWriterSafe(path: $"{fileName}({i})", text: text);

                        //
                        return _result;
                    }
                }

                //
                return (false, new ArgumentOutOfRangeException());
            }
            else
            {
                //
                (bool, Exception?) _result = WriteViaStreamWriterSafe(path: fileName, text: text);

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
        public static (bool, Exception?) SaveSafe(string text, string fileName, string folderName = "Data", NamingFormat namingFormat = NamingFormat.RandomName, bool overwrite = false, bool renameIfExists = true)
        {
            //
            if (namingFormat == NamingFormat.Custom)
            {
                //
            }
            if (namingFormat == NamingFormat.RandomName)
            {
                //
                fileName ??= GetAvailableFileName();
            }
            else
            {
                //
                fileName ??= GetFormattedDateTimeStamp(namingFormat: namingFormat);
            }

            //
            if (CheckIfFolderExist($"./{folderName}"))
            {
                // Creating folder if it doesn't exist. If folder is already exists, CreateDirectory ignores it.
                _ = System.IO.Directory.CreateDirectory($"{folderName}\\");
            }

            //
            bool fileExist = CheckIfFolderExist(fileName);

            //
            if (fileExist == false)
            {
                //
                (bool, Exception?) result = WriteViaStreamWriterSafe(path: fileName, text: text);

                //
                return result;
            }
            else if (overwrite == false)
            {
                //
                for (int i = 0; i < 255; i++)
                {
                    //
                    if (CheckIfFileExist(path: $"{folderName}/{fileName}({i})") == false)
                    {
                        (bool, Exception?) result = WriteViaStreamWriterSafe(path: $"{folderName}/{fileName}({i})", text: text);

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
                (bool, Exception?) result = WriteViaStreamWriterSafe(path: fileName, text: text);

                //
                return result;
            }
        }
    }
}
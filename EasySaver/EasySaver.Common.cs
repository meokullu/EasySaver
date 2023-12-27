using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("EasySaver.TextFile")]
[assembly: InternalsVisibleTo("EasySaver.BitmapFile")]
#if DEBUG
[assembly: InternalsVisibleTo("EasySaverTest")]
#endif
namespace EasySaver.Common
{
    /// <summary>
    /// Easy Saver Common
    /// </summary>
    public partial class EasySaver
    {
        // Default text file extension.
        internal static string _defaultTextExtension = ".txt";

        // Default image file extension.
        internal static string _defaultImageExtension = ".bmp";

        /// <summary>
        /// Naming formats
        /// </summary>
        public enum NamingFormat
        {
            /// <summary>
            /// File name will consist only given text itself.
            /// </summary>
            Custom = 1,
            /// <summary>
            /// File name will consist time data.
            /// </summary>
            Time = 2,
            /// <summary>
            /// File name will consist date and time data.
            /// </summary>
            DateTime = 3,
            /// <summary>
            /// File name will consist date data.
            /// </summary>
            Date = 4,
            /// <summary>
            /// File name will consist random name that chosen from populated or prepopulated name list.
            /// </summary>
            RandomName = 5
        }

        /// <summary>
        /// Get a file name based on naming format.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="namingFormat"></param>
        /// <returns></returns>
        /// <exception cref="Exception">Throws if given namingFormat is not defined in NamingFormat enum llist.</exception>
        internal static string GetFileName(string fileName, NamingFormat namingFormat = NamingFormat.DateTime)
        {
            // The reason that extension is not added here, because of in case of repeatence filename might has a name like file(1).
            // If extension would be added here, it would look like as file.txt(1).

            // Checking if naming format is DateTime, Date or Time so GetFormattedDateTimeStamp() returns available file name.
            if (namingFormat == NamingFormat.DateTime || namingFormat == NamingFormat.Date || namingFormat == NamingFormat.Time)
            {
                // Calls GetFormattedDateTimeStamp().
                return GetFormattedDateTimeStamp(namingFormat: namingFormat);
            }
            // If Custom is 
            else if (namingFormat == NamingFormat.Custom)
            {
                // Check if fileName is null or white space. If it is, return "file" as default name it is not it returns fileName that is given by parameter.
                // The reason of this checking is because empty space is not allowed as file name.
                return string.IsNullOrWhiteSpace(fileName) ? "file" : fileName;
            }
            else if (namingFormat == NamingFormat.RandomName)
            {
                // If file name is null bring random name from list.
                return GetRandomFileName();
            }
            else
            {
                //
                throw new Exception("NamingFormat is not correct");
            }
        }

        #region Naming formats

       

        /// <summary>
        /// Variable that hold user choice to determine which option would be used for naming a file.
        /// </summary>
        public static NamingFormat SelectedNamingFormat { get; set; }

        #endregion Naming formats

        #region Get DateTime

        /// <summary>
        /// Get datetime data via DateTime.Now.
        /// </summary>
        /// <returns></returns>
        private static DateTime GetDateTimeStamp()
        {
            // Return now from System.DateTime.
            return DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string TodayString => GetFormattedDateTimeStamp(NamingFormat.Date);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string NowString => GetFormattedDateTimeStamp(NamingFormat.Time);

        /// <summary>
        /// Get formatted datetime span by pre-chosen option.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Throws if namingFormat is not implemented</exception>
        internal static string GetFormattedDateTimeStamp(NamingFormat namingFormat)
        {
            //
            DateTime dateTime = GetDateTimeStamp();

            // Date data.
            string year = dateTime.Date.ToString("yyyy");
            string month = dateTime.Date.ToString("MM");
            string day = dateTime.Date.ToString("dd");

            // Time data.
            string hour = dateTime.ToString("HH");
            string minute = dateTime.ToString("mm");
            string second = dateTime.ToString("ss");
            string millisecond = dateTime.ToString("fff");

            //
            if (namingFormat == NamingFormat.Time)
            {
                //
                return $"{hour}-{minute}-{second}-{millisecond}";
            }
            else if (namingFormat == NamingFormat.Date)
            {
                //
                return $"{year}-{month}-{day}";
            }
            else if (namingFormat == NamingFormat.DateTime)
            {
                //
                return $"{year}-{month}-{day}-{hour}-{minute}-{second}-{millisecond}";
            }
            else
            {
                //
                throw new NotImplementedException();
            }
        }

        #endregion Get DateTime

        #region Existing

        /// <summary>
        /// Check if file existing via System.IO.File.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Returns true if the file does exist, returns false if the file doesn't exist.</returns>
        internal static bool CheckIfFileExist(string path)
        {
            //
            if (File.Exists(path))
            {
                //
                return true;
            }
            else
            {
                //
                return false;
            }
        }

        /// <summary>
        /// Check if folder is existing via System.IO.Folder. 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Returns true if the folder does exist, returns false if the folder doesn't exist.</returns>
        internal static bool CheckIfFolderExist(string path)
        {
            //
            if (Directory.Exists(path))
            {
                //
                return true;
            }
            else
            {
                //
                return false;
            }
        }

        #endregion Existing
    }
}
using System;
using System.IO;
using System.Runtime.CompilerServices;
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
        internal static string s_defaultTextExtension = ".txt";

        // Default image file extension.
        internal static string s_defaultImageExtension = ".bmp";

        /// <summary>
        /// Variable indicates maximum attemt of renaming file name with new one if previous one does exist.
        /// </summary>
        internal static readonly byte s_maxAttemptForRename = byte.MaxValue;

        /// <summary>
        /// In case of reaching maximum attempt, this method create a message to indicate which method reached.
        /// </summary>
        internal static string MaxAttemptMessage(string methodName) => $"{methodName} reached maximum attempt ({s_maxAttemptForRename}) of renaming file that is about to save.";

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
            [Obsolete("Use LongTime")]
            Time = 2,
            /// <summary>
            /// File name will consist date and time data.
            /// </summary>
            [Obsolete("Use LongDateTime")]
            DateTime = 3,
            /// <summary>
            /// File name will consist date data.
            /// </summary>
            [Obsolete("Use LongDate")]
            Date = 4,
            ///// <summary>
            ///// File name will consist random name that chosen from populated or prepopulated name list.
            ///// </summary>
            //RandomName = 5

            /// <summary>
            /// File name will consist time data.
            /// </summary>
            LongTime = 20,

            /// <summary>
            /// File name will consist short time data.
            /// </summary>
            ShortTime = 21,

            /// <summary>
            /// File name will consist date and time data.
            /// </summary>
            LongDateTime = 40,

            /// <summary>
            /// File name will consist short date and time data.
            /// </summary>
            ShortDateTime = 41,

            /// <summary>
            /// File name will consist date data.
            /// </summary>
            LongDate = 60,

            /// <summary>
            /// File name will consist short date data.
            /// </summary>
            ShortDate = 61
        }

        /// <summary>
        /// Get a file name based on naming format.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="namingFormat"></param>
        /// <returns></returns>
        /// <exception cref="Exception">Throws if given namingFormat is not defined in NamingFormat enum list.</exception>
        internal static string GetFileName(string fileName, NamingFormat namingFormat = NamingFormat.LongDateTime)
        {
            // The reason that extension is not added here, because of in case of repeatence filename might has a name like file(1).
            // If extension would be added here, it would look like as file.txt(1).

            //TODO: Remove .DateTime, .Date and .Time when new version is introduced after making them obsolete.
            // Checking if naming format is LongDateTime, LongDate, LongTime so GetFormattedDateTimeStamp() returns available file name.
#pragma warning disable CS0618 // Type or member is obsolete
            if (
                namingFormat == NamingFormat.DateTime || 
                namingFormat == NamingFormat.Date || 
                namingFormat == NamingFormat.Time || 
                namingFormat == NamingFormat.LongDateTime || 
                namingFormat ==  NamingFormat.LongDate || 
                namingFormat == NamingFormat.LongTime || 
                namingFormat == NamingFormat.ShortDateTime || 
                namingFormat == NamingFormat.ShortDate || 
                namingFormat == NamingFormat.ShortTime)
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
            //else if (namingFormat == NamingFormat.RandomName)
            //{
            //    // If file name is null bring random name from list.
            //    return GetRandomFileName();
            //}
            else
            {
                //
                throw new Exception("NamingFormat is not correct.");
            }
#pragma warning restore CS0618 // Type or member is obsolete
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
        /// {year}-{month}-{day}
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use LongDayString")]
        public static string TodayString => GetFormattedDateTimeStamp(NamingFormat.Date);

        /// <summary>
        /// Returns {hour}-{minute}-{second}-{millisecond} as string.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use LongTimeString")]
        public static string NowString => GetFormattedDateTimeStamp(NamingFormat.Time);

        /// <summary>
        /// Return {year}-{month}-{day} as string.
        /// </summary>
        public static string LongDayString => GetFormattedDateTimeStamp(NamingFormat.LongDate);

        /// <summary>
        /// Returns {hour}-{minute}-{second}-{millisecond} as string.
        /// </summary>
        public static string LongTimeString => GetFormattedDateTimeStamp(NamingFormat.LongTime);

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

            //TODO: Remove .DateTime, .Date and .Time when new version is introduced after making them obsolete.
            //
#pragma warning disable CS0618 // Type or member is obsolete
            if (namingFormat == NamingFormat.Time || namingFormat == NamingFormat.LongTime)
            {
                //
                return $"{hour}-{minute}-{second}-{millisecond}";
            }
            else if (namingFormat == NamingFormat.ShortTime)
            {
                //
                return $"{hour}-{minute}-{second}";
            }
            else if (namingFormat == NamingFormat.Date || namingFormat == NamingFormat.LongDate)
            {
                //
                return $"{year}-{month}-{day}";
            }
            else if (namingFormat == NamingFormat.ShortDate)
            {
                //
                return $"{month}-{day}";
            }
            else if (namingFormat == NamingFormat.DateTime || namingFormat == NamingFormat.LongDateTime)
            {
                //
                return $"{year}-{month}-{day}-{hour}-{minute}-{second}-{millisecond}";
            }
            else if (namingFormat == NamingFormat.ShortDateTime)
            {
                //
                return $"{month}-{day}-{hour}-{minute}-{second}";
            }
            else
            {
                //
                throw new NotImplementedException();
            }
#pragma warning restore CS0618 // Type or member is obsolete
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
using System;

namespace EasySaver.Common
{
    public partial class EasySaver
    {
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

            // Checking if naming format is LongDateTime, LongDate, LongTime, ShortDateTime, ShortDate or ShortTime so GetFormattedDateTimeStamp() returns available file name.

            if (
                namingFormat == NamingFormat.LongDateTime ||
                namingFormat == NamingFormat.LongDate ||
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
        }
    }
}

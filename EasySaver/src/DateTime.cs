using System;

namespace EasySaver.Common
{
    public partial class EasySaver
    {
        /// <summary>
        /// Return {year}-{month}-{day} as string.
        /// </summary>
        public static string LongDateString => GetFormattedDateTimeStamp(NamingFormat.LongDate);

        /// <summary>
        /// Returns {hour}-{minute}-{second}-{millisecond} as string.
        /// </summary>
        public static string LongTimeString => GetFormattedDateTimeStamp(NamingFormat.LongTime);

        /// <summary>
        /// Return {month}-{day} as string.
        /// </summary>
        public static string ShortDateString => GetFormattedDateTimeStamp(NamingFormat.ShortDate);

        /// <summary>
        /// Return {hour}-{minute}-{second} as string.
        /// </summary>
        public static string ShortTimeString => GetFormattedDateTimeStamp(NamingFormat.ShortTime);

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
        /// Get formatted datetime span by pre-chosen option.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Throws if namingFormat is not implemented.</exception>
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
            if (namingFormat == NamingFormat.LongTime)
            {
                //
                return $"{hour}-{minute}-{second}-{millisecond}";
            }
            else if (namingFormat == NamingFormat.ShortTime)
            {
                //
                return $"{hour}-{minute}-{second}";
            }
            else if (namingFormat == NamingFormat.LongDate)
            {
                //
                return $"{year}-{month}-{day}";
            }
            else if (namingFormat == NamingFormat.ShortDate)
            {
                //
                return $"{month}-{day}";
            }
            else if (namingFormat == NamingFormat.LongDateTime)
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
        }

        #endregion Get DateTime
    }
}

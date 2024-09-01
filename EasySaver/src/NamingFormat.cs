namespace EasySaver.Common
{
    public partial class EasySaver
    {
        /// <summary>
        /// Naming formats
        /// </summary>
        public enum NamingFormat
        {
            /// <summary>
            /// File name will consist only given text itself.
            /// </summary>
            Custom = 1,

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

        #region Naming formats

        /// <summary>
        /// Variable that hold user choice to determine which option would be used for naming a file.
        /// </summary>
        public static NamingFormat SelectedNamingFormat { get; set; }

        #endregion Naming formats
    }
}

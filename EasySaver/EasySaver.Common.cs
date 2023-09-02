using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("EasySaver.TextFile")]
[assembly: InternalsVisibleTo("EasySaver.BitmapFile")]
namespace EasySaver.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class EasySaver
    {
        #region File paths

        // Path for pre-populated random file name list.
        private static readonly string _defaultFileNamePath = "DefaultRandomFileNameList.txt";

        // Path for random file list.
        private static readonly string _randomFileNamePath = "RandomFileNameList.txt";

        #endregion File paths

        #region Naming formats

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
        /// Variable that hold user choice to determine which option would be used for naming a file.
        /// </summary>
        public static NamingFormat SelectedNamingFormat { get; set; }

        #endregion Naming formats

        #region File Name

        /// <summary>
        /// List of random file names.
        /// </summary>
        internal static string[]? _randomFileNameList;

        /// <summary>
        /// Gets random name from list.
        /// </summary>
        /// <returns></returns>       
        internal static string GetAvailableFileName()
        {
            // Checking if list is null or empty.
            if (_randomFileNameList == null || _randomFileNameList.Length == 0)
            {
                // Fetching data into list.
                FetchRandomFileNameList();
            }

            //
            int availableNameOptions = _randomFileNameList.Length;

            // TODO: -1 for length?
            int indexOfAvailableName = new Random().Next(maxValue: availableNameOptions);

            //
            string availableFileName = _randomFileNameList[indexOfAvailableName];

            //
            return availableFileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="Exception"></exception>
        private static void FetchRandomFileNameList()
        {
            // Checking if randomfilename is null or empty.
            if (_randomFileNameList == null || _randomFileNameList.Length == 0)
            {
                // Read lines from file and populate _RandomFileNameList variable.
                _randomFileNameList = File.ReadAllLines(_randomFileNamePath, Encoding.UTF8);

                // Checking if _RandomFileNameList is null or empty again to determine if list is empty or corrupted.
                if (_randomFileNameList == null || _randomFileNameList.Length == 0)
                {
                    // Read lines from file and populate _RandomFileNameList variable.
                    _randomFileNameList = File.ReadAllLines(_defaultFileNamePath, Encoding.UTF8);

                    // Checking if _RandomFileNameList is still null or empty.
                    if (_randomFileNameList == null || _randomFileNameList.Length == 0)
                    {
                        // Throwing exception to indicate file is missing or corrupted.
                        throw new Exception($"File at {_defaultFileNamePath} is missing or corrupted", new NullReferenceException());
                    }
                    else
                    {
                        // Fetching default random names into random names list.
                        File.WriteAllLines(_randomFileNamePath, _randomFileNameList);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileNameList"></param>
        /// <returns></returns>
        public static bool PopulateRandomFileNameList(string[] fileNameList)
        {
            try
            {
                // Write fileNameList into _randomFileNamePath
                File.WriteAllLines(_randomFileNamePath, fileNameList);

                // Returning success to indicate writing was successful.
                return true;
            }
            catch (Exception)
            {
                // Throwing an exception to indicate writing was failed.
                throw;
            }
        }

        #endregion File Name

        #region Get DateTime

        /// <summary>
        /// Get datetime data via DateTime.Now.
        /// </summary>
        /// <returns></returns>
        private static DateTime GetDateTimeStamp()
        {
            //
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

            //
            string year = dateTime.Date.Year.ToString();
            string month = dateTime.Date.Month.ToString();
            string day = dateTime.Date.Day.ToString();

            //
            string hour = dateTime.Date.Hour.ToString();
            string minute = dateTime.Date.Minute.ToString();
            string second = dateTime.Date.Second.ToString();
            string millisecond = dateTime.Date.Millisecond.ToString();

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
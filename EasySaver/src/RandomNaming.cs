using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaver.Common
{
    public partial class EasySaver
    {
        #region File paths

        // Path for pre-populated random file name list.
        private static readonly string defaultFileNamePath = @".\Data\DefaultRandomFileNameList.txt";

        // Path for random file list.
        private static readonly string randomFileNamePath = @".\Data\RandomFileNameList.txt";

        #endregion File paths

        #region Random naming

        /// <summary>
        /// Variable indicates maximum attemt of renaming file name with new one if previous one does exist.
        /// </summary>
        internal static readonly byte _maxAttemptForRename = byte.MaxValue;

        /// <summary>
        /// In case of reaching maximum attempt, this method create a message to indicate which method reached.
        /// </summary>
        internal static string MaxAttemptMessage(string methodName) => $"{methodName} reached maximum attempt ({_maxAttemptForRename}) of renaming file that is about to save.";

        #region File Name

        /// <summary>
        /// List of random file names.
        /// </summary>
        internal static string[]? randomFileNameList;

        /// <summary>
        /// Gets random name from list.
        /// </summary>
        /// <returns></returns>       
        internal static string GetRandomFileName()
        {
            // Checking if list is null or empty.
            if (randomFileNameList == null || randomFileNameList.Length == 0)
            {
                // Fetching data into list.
                FetchRandomFileNameList();
            }

            //
            int availableNameOptions = randomFileNameList!.Length;

            //
#if DEBUG
            Console.WriteLine($"AvailableNameOptions: {availableNameOptions}");
#endif
            // TODO: -1 for length?
            int indexOfAvailableName = new Random().Next(maxValue: availableNameOptions);

#if DEBUG
            Console.WriteLine($"Random index: {indexOfAvailableName}");
#endif
            //
            string availableFileName = randomFileNameList[indexOfAvailableName];

            //
            return availableFileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="Exception"></exception>
        private static void FetchRandomFileNameList()
        {
            //
            if (CheckIfFileExist(defaultFileNamePath) == false)
            {
                throw new FileNotFoundException(defaultFileNamePath);
            }

            //
            if (CheckIfFileExist(randomFileNamePath) == false)
            {
                throw new FileNotFoundException(defaultFileNamePath);
            }

            // Checking if randomfilename is null or empty.
            if (randomFileNameList == null || randomFileNameList.Length == 0)
            {
                // Read lines from file and populate _RandomFileNameList variable.
                randomFileNameList = File.ReadAllLines(randomFileNamePath, Encoding.UTF8);

                // Checking if _RandomFileNameList is null or empty again to determine if list is empty or corrupted.
                if (randomFileNameList == null || randomFileNameList.Length == 0)
                {
                    // Read lines from file and populate _RandomFileNameList variable.
                    randomFileNameList = File.ReadAllLines(defaultFileNamePath, Encoding.UTF8);

                    // Checking if _RandomFileNameList is still null or empty.
                    if (randomFileNameList == null || randomFileNameList.Length == 0)
                    {
                        // Throwing exception to indicate file is missing or corrupted.
                        throw new Exception($"File at {defaultFileNamePath} is missing or corrupted", new NullReferenceException());
                    }
                    else
                    {
                        // Fetching default random names into random names list.
                        File.WriteAllLines(randomFileNamePath, randomFileNameList);
                    }
                }
            }
        }

        /// <summary>
        /// Deleted previous records, adds given data into the file.
        /// </summary>
        /// <param name="fileNameList"></param>
        /// <returns></returns>
        public static bool PopulateRandomFileNameList(string[] fileNameList)
        {
            //
            try
            {
                // Write fileNameList into _randomFileNamePath
                File.WriteAllLines(randomFileNamePath, fileNameList);

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

        #endregion Random naming
    }
}

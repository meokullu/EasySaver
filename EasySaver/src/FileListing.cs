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
        #region File

        /// <summary>
        /// Retrieves all file names in the specified path. The search pattern and search option can be customized.
        /// </summary>
        /// <param name="path">Exact string of given file.</param>
        /// <param name="searchPattern">During file search * and ? can be used.</param>                                                                                                                                                                         
        /// <param name="searchOption">TopDirectoryOnly or AllDirectories.</param>
        /// <returns>Array of file names.</returns>
        /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=net-7.0#system-io-directory-getfiles(system-string-system-string-system-io-searchoption)">Directory.GetFiles</see>                                                                                                       
        public static string[] GetAllFileNames(string path, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            // Get all file names with full path and then extract just the file names.                                      
            string[] fileNames = Directory.GetFiles(path, searchPattern: searchPattern, searchOption: searchOption);

            // Loop through the file names and extract just the file name from the full path.
            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = Path.GetFileName(fileNames[i]);
            }

            // Return the array of file names.
            return fileNames;
        }

        /// <summary>
        /// Retrieves all file names from multiple paths. The search pattern and search option can be customized.
        /// </summary>
        /// <param name="pathArray">Array of exact string of given files.</param>
        /// <param name="searchPattern">During file search * and ? can be used.</param>
        /// <param name="searchOption">TopDirectoryOnly or AllDirectories.</param>                         
        /// <returns>Array of file names.</returns>
        /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=net-7.0#system-io-directory-getfiles(system-string-system-string-system-io-searchoption)">Directory.GetFiles</see>
        public static string[] GetAllFileNames(string[] pathArray, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            // Create a list to store the file names from all paths.
            List<string> returnData = new List<string>();

            // Loop through each path in the array and get the file names, then add them to the returnData list.
            foreach (var item in pathArray)
            {
                // Get the file names from the current path and add them to the returnData list.
                returnData.AddRange(GetAllFileNames(item, searchPattern, searchOption).ToList());
            }

            // Convert the returnData list to an array and return it.
            return returnData.ToArray();
        }

        #endregion File

        #region Folder

        /// <summary>
        /// Retrieves the names of all folders within the specified directory that match the given search pattern and
        /// search option.
        /// </summary>
        /// <remarks>Folder names returned do not include their full paths; only the directory names are
        /// provided. The method does not return files. If the specified path does not exist, an exception will be
        /// thrown.</remarks>
        /// <param name="path">The path to the directory in which to search for folders. Cannot be null or empty.</param>
        /// <param name="searchPattern">The search string used to match folder names. Defaults to "*" to match all folders.</param>
        /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to
        /// SearchOption.TopDirectoryOnly.</param>
        /// <returns>An array of strings containing the names of all matching folders. The array will be empty if no folders are
        /// found.</returns>
        public static string[] GetAllFolderNames(string path, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            // Get all folder names with full path and then extract just the folder names.
            string[] folderNames = Directory.GetDirectories(path, searchPattern: searchPattern, searchOption: searchOption);

            // Loop through the folder names and extract just the folder name from the full path.
            for (int i = 0; i < folderNames.Length; i++)
            {
                // Use DirectoryInfo to get just the folder name from the full path.
                folderNames[i] = new DirectoryInfo(folderNames[i]).Name;
            }

            // Return the array of folder names.
            return folderNames;
        }

        /// <summary>
        /// Retrieves the names of all folders from multiple paths that match the given search pattern and search option.
        /// </summary>
        /// <remarks>Folder names returned do not include their full paths; only the directory names are provided. The method does not return files. If any of the specified paths do not exist, an exception will be thrown.</remarks>
        /// <param name="pathArray">Array of paths to directories in which to search for folders. Each path cannot be null or empty.</param>
        /// <param name="searchPattern">The search string used to match folder names. Defaults to "*" to match all folders.</param>
        /// <param name="searchOption">Specifies whether to search only the top directory or all subdirectories. Defaults to
        /// SearchOption.TopDirectoryOnly.</param>
        /// <returns>An array of strings containing the names of all matching folders from the specified paths. The array will be empty if no folders are found.</returns>
        public static string[] GetAllFolderNames(string[] pathArray, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            List<string> returnData = new List<string>();

            foreach (var item in pathArray)
            {
                returnData.AddRange(GetAllFolderNames(item, searchPattern: searchPattern, searchOption: searchOption).ToList());
            }

            return returnData.ToArray();
        }

        #endregion Folder
    }
}

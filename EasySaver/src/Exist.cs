using System.IO;

namespace EasySaver.Common
{
    public partial class EasySaver
    {
        #region Existing

        /// <summary>
        /// Check if file existing via <see cref="System.IO.File.Exists(string)"/>.
        /// </summary>
        /// <param name="path">Path to check if exists.</param>
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
        /// Check if folder is existing via <see cref="System.IO.Directory.Exists(string)"/>. 
        /// </summary>
        /// <param name="path">Path to check if exists.</param>
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

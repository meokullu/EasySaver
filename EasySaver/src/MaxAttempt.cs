namespace EasySaver.Common
{
    public partial class EasySaver
    {
        /// <summary>
        /// Variable indicates maximum attemt of renaming file name with new one if previous one does exist.
        /// </summary>
        internal static readonly byte s_maxAttemptForRename = byte.MaxValue;

        /// <summary>
        /// In case of reaching maximum attempt, this method create a message to indicate which method reached.
        /// </summary>
        internal static string MaxAttemptMessage(string methodName) => $"{methodName} reached maximum attempt ({s_maxAttemptForRename}) of renaming file that is about to save.";
    }
}

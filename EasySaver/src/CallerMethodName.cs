using System.Diagnostics;

namespace EasySaver.Common
{
    public partial class EasySaver
    {
        /// <summary>
        /// Caller method's name. First frame.
        /// </summary>
        public static readonly string CallerMethodName1 = new StackTrace().GetFrame(1)?.GetMethod().Name;

        /// <summary>
        /// Caller method's name. Second frame.
        /// </summary>
        public static readonly string CallerMethodName2 = new StackTrace().GetFrame(2)?.GetMethod().Name;

        /// <summary>
        /// Caller method's name. Third frame.
        /// </summary>
        public static readonly string CallerMethodName3 = new StackTrace().GetFrame(3)?.GetMethod().Name;

        /// <summary>
        /// Caller method's name. Fourth frame.
        /// </summary>
        public static readonly string CallerMethodName4 = new StackTrace().GetFrame(4)?.GetMethod().Name;

        /// <summary>
        /// Caller method's name. Fifth frame.
        /// </summary>
        public static readonly string CallerMethodName5 = new StackTrace().GetFrame(5)?.GetMethod().Name;

        /// <summary>
        /// Caller method's name. Sixth frame.
        /// </summary>
        public static readonly string CallerMethodName6 = new StackTrace().GetFrame(6)?.GetMethod().Name;

        /// <summary>
        /// Caller method's name. Seventh frame.
        /// </summary>
        public static readonly string CallerMethodName7 = new StackTrace().GetFrame(7)?.GetMethod().Name;

        /// <summary>
        /// Caller method's name. Eight frame.
        /// </summary>
        public static readonly string CallerMethodName8 = new StackTrace().GetFrame(8)?.GetMethod().Name;
    }
}

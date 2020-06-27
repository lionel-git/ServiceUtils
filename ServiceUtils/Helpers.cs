using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ServiceUtils
{
    /// <summary>
    /// Some helpers for service
    /// </summary>
    public class Helpers
    {
        /// <summary>
        /// Detect if program has a console attached
        /// </summary>
        /// <returns></returns>
        public static bool IsConsoleApp()
        {
            // Warning: Environment.UserInteractive always return true in .net core mode ?
            using (var stream = Console.OpenStandardInput(1))
            {
                return stream != Stream.Null;
            }
        }
    }
}

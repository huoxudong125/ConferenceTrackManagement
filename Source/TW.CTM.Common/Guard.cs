using System;

namespace TW.CTM.Common
{
    public static class Guard
    {
        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ArgumentNotNullOrEmpty(string argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            else if (argumentValue.Length == 0)
            {
                throw new ArgumentException("The provided string argument must not be empty.", argumentName);
            }
        }
    }
}
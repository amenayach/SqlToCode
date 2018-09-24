namespace SqlToCode.Services
{
    /// <summary>
    /// Handles strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Check if a string is not empty
        /// </summary>
        public static bool NotEmpty(this string keyName)
        {
            return !string.IsNullOrWhiteSpace(keyName);
        }

        /// <summary>
        /// Check if a string is empty
        /// </summary>
        public static bool IsEmpty(this string keyName)
        {
            return string.IsNullOrWhiteSpace(keyName);
        }
    }
}

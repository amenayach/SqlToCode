namespace SqlToCode.Services
{
    using System.Windows.Forms;
    using Microsoft.Win32;

    /// <summary>
    /// Handles registery get and set
    /// </summary>
    public class RegistryManager
    {
        /// <summary>
        /// The key used in as key for this app
        /// </summary>
        public const string ConstAppMainKey = "Software\\SqlToCode";

        /// <summary>
        /// Get registry value
        /// </summary>
        public static object GetRegistryValue(string keyName, object defaultValue = null)
        {
            return GetRegistryValue(ConstAppMainKey, keyName, defaultValue);
        }

        /// <summary>
        /// Set registry value
        /// </summary>
        public static void SetRegistryValue(string keyName, object value)
        {
            SetRegistryValue(ConstAppMainKey, keyName, value);
        }

        /// <summary>
        /// Get registry value
        /// </summary>
        public static object GetRegistryValue(string currentUserParentKey, string keyName, object defaultValue)
        {
            object res = null;

            try
            {
                var k = Registry.CurrentUser.OpenSubKey(currentUserParentKey, true);

                if (k != null)
                {
                    res = k.GetValue(keyName, defaultValue);
                }
                else
                {
                    k = Registry.CurrentUser.CreateSubKey(currentUserParentKey);
                }

                if (k != null)
                {
                    k.Close();
                }
                
            }
            catch
            {
                // Ignored
            }
            return res;
        }

        /// <summary>
        /// Set registry value
        /// </summary>
        public static void SetRegistryValue(string currentUserParentKey, string keyName, object value)
        {
            try
            {
                var k = Registry.CurrentUser.OpenSubKey(currentUserParentKey, true);

                if (k != null)
                {
                    k.SetValue(keyName, value);
                }
                else
                {
                    k = Registry.CurrentUser.CreateSubKey(currentUserParentKey);
                    if (k != null) k.SetValue(keyName, value);
                }

                if (k != null) k.Close();
            }
            catch
            {
                // Ignored
            }
        }

        /// <summary>
        /// Add a registry value to make the app startup
        /// </summary>
        public static void AddAppToWinStartup()
        {
            try
            {
                var openSubKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (openSubKey != null)
                {
                    openSubKey.SetValue(Application.ProductName, Application.ExecutablePath);
                }
            }
            catch
            {
                // Ignored
            }
        }

        /// <summary>
        /// Remove the registry flag to disable the app to start with window
        /// </summary>
        public static void RemoveAppFromWinStartup()
        {
            try
            {
                var openSubKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (openSubKey != null)
                {
                    openSubKey.SetValue(Application.ProductName, "");
                }
            }
            catch
            {
                // Ignored
            }
        }

    }
}

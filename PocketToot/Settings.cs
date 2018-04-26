using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace PocketToot
{
    public static class Settings
    {
        const string KEY = "HKEY_CURRENT_USER\\Software\\PocketToot";

        public static string GetSetting(string name, string fallback)
        {
            return (string)Registry.GetValue(KEY, name, fallback);
        }

        public static void SetSetting(string name, string value)
        {
            Registry.SetValue(KEY, name, value);
        }
    }
}

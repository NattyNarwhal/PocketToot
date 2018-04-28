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
        static Dictionary<string, string> _settings;

        static Settings()
        {
            _settings = new Dictionary<string, string>();
        }

        public static string GetSetting(string name, string fallback)
        {
            if (_settings.ContainsKey(name))
                return _settings[name];
            // fetch cache it otherwise
            var res = (string)Registry.GetValue(KEY, name, fallback);
            _settings[name] = res;
            return res;
        }

        public static void SetSetting(string name, string value)
        {
            _settings[name] = value;
            Registry.SetValue(KEY, name, value);
        }
    }
}

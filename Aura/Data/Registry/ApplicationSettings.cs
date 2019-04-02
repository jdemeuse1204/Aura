using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Data.Registry
{
    public class ApplicationSettings
    {
        public static string MainFileDirectory => string.Format(GetSetting<string>("MainFileDirectory"), Environment.UserName);
        public static string DataFileDirectory => string.Format(GetSetting<string>("DataFileDirectory"), DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public static string DataFileName => GetSetting<string>("DataFileName");
        public static string SessionFileName => GetSetting<string>("SessionFileName");
        public static string SessionFileDirectory => GetSetting<string>("SessionFileDirectory");

        private static T GetSetting<T>(string key)
        {
            var setting = ConfigurationManager.AppSettings[key];

            return (T)Convert.ChangeType(setting, typeof(T));
        }
    }
}

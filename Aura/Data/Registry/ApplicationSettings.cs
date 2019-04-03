using Aura.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Data.Registry
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string MainFileDirectory => string.Format(GetSetting<string>("MainFileDirectory"), Environment.UserName);
        public string DataFileDirectory => string.Format(GetSetting<string>("DataFileDirectory"), DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public string DataFileName => GetSetting<string>("DataFileName");
        public string SessionFileName => GetSetting<string>("SessionFileName");
        public string SessionFileDirectory => GetSetting<string>("SessionFileDirectory");
        public string AddOnsFileDirectory => GetSetting<string>("AddOnsFileDirectory");

        private static T GetSetting<T>(string key)
        {
            var setting = ConfigurationManager.AppSettings[key];

            return (T)Convert.ChangeType(setting, typeof(T));
        }
    }
}

using System;
using System.Configuration;
using System.IO;

namespace TFL.Automation.Helpers
{
    public class AppConfig
    {
        public static string GetAppUrl() => ConfigurationManager.AppSettings.Get("ApplicationUrl");
       
        public static string GetTestResultsPath()
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TestData"));
        }

    }
}

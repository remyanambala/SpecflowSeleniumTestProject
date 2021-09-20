using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressionTestSuite.Resources
{
    public class AppConfigReader
    {
        public BrowserTypes GetBrowser()
        {
            string browser =  ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            return (BrowserTypes)Enum.Parse(typeof(BrowserTypes), browser);
        }
        public string GetComputerDBURL()
        {
          return ConfigurationManager.AppSettings.Get(AppConfigKeys.ComputerDBURL);
            
        }
        public string GetJavaScriptAlertURL()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.JavaScriptAlertURL);
            
        }


    }
}

using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;

namespace AutomatedTestsBasicStable.Helper
{
    public static class ConfigurationHelper
    {
        public static IWebDriver Driver()
        {
            string browser = GetConfigParameterValue("Browser");

            IWebDriver driver;

            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            return driver;
        }

        public static string GetConfigParameterValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
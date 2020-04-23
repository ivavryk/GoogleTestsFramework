using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GoogleTestsFramework.Helper
{
    class TestDetailsHelper
    {
        /// <summary>
        /// Takes browser screen shot and saves to current directory
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="methodName"></param>
        internal static void TakeScreenshot(IWebDriver driver, string methodName)
        {
            string subfolderPath = $"{TestContext.CurrentContext.TestDirectory}\\Screenshots\\{DateTime.UtcNow:yyyy'-'MMM'-'dd'-'hh'-'mm}\\";
            string path = $"{subfolderPath}{methodName}_{DateTime.UtcNow.Ticks}.png";

            var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(subfolderPath));

            if (!destinationDirectory.Exists)
                destinationDirectory.Create();
            
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Png);
        }
    }
}

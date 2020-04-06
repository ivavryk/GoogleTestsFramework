using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestsBasic.Pages
{
    public class GoogleBasePage
    {
        private readonly IWebDriver _driver = Tests.TestsBasis.Driver;

        /// <summary>
        /// Gets current page's title.
        /// </summary>
        /// <returns></returns>
        public string GetPageTitle()
        {
            return _driver.Title;
        }

        /// <summary>
        /// Wait page to load.
        /// </summary>
        /// <param name="by"></param>
        public void WaitPageToLoad(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => _driver.FindElements(by).Count > 0);
        }

        /// <summary>
        /// Get browser title.
        /// </summary>
        /// <returns></returns>
        public string GetBrowserTitle()
        {
            return _driver.Title;
        }

        /// <summary>
        /// Get page source.
        /// </summary>
        /// <returns></returns>
        public string GetPageSource()
        {
            return _driver.PageSource;
        }

        /// <summary>
        /// Open full screen.
        /// </summary>
        public void OpenFullScreen()
        {
            _driver.Manage().Window.FullScreen();
        }

        /// <summary>
        /// Close browser.
        /// </summary>
        public void CloseBrowser()
        {
            _driver.Quit();
        }

        /// <summary>
        /// Navigate back in browser,
        /// </summary>
        public void NavigateBackInBrowser()
        {
            _driver.Navigate().Back();
        }

        /// <summary>
        /// Navigate forward in browser.
        /// </summary>
        public void NavigateForwardInBrowser()
        {
            _driver.Navigate().Forward();
        }

        /// <summary>
        /// Refresh page in browser.
        /// </summary>
        public void RefreshPageInBrowser()
        {
            _driver.Navigate().Refresh();
        }
    }
}

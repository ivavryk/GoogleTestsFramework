using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomatedTestsBasic.Pages
{
    public class GoogleSearchResultsPage : GoogleBasePage
    {
        //private readonly IWebDriver _driver = Tests.TestsBasis.Driver;

        public string SpecificSearchTitle = " - Пошук Google";
        public string RandomSearchTitle = "Google Doodles";

        public IWebElement SearchResults => _driver.FindElement(By.Id("res"));

        /// <summary>
        /// Wait page to load.
        /// </summary>
        public void WaitPageToLoad()
        {
            WaitPageToLoad(By.Id("content-wrap"));
        }
    }
}

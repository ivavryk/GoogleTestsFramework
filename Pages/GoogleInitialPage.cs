using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomatedTestsBasic.Pages
{
    public class GoogleInitialPage : GoogleBasePage
    {
        //private readonly IWebDriver _driver = Tests.TestsBasis.Driver;

        public string Url = "https://www.google.com";
        public string Title = "Google";
        public IWebElement TxtSearch => _driver.FindElement(By.Name("q"));
        public IWebElement BtnSearch => _driver.FindElement(By.CssSelector("center:nth-child(1) > input[name='btnK']:nth-child(1)"));
        public IWebElement BtnRandomSearch => _driver.FindElement(By.CssSelector("center:nth-child(1) > input[name='btnI']:nth-child(2)"));

        /// <summary>
        /// Opens initial Google search page.
        /// </summary>
        public GoogleInitialPage Open()
        {
            _driver.Navigate().GoToUrl(Url);

            return this;
        }

        /// <summary>
        /// Applies search of the word.
        /// </summary>
        /// <param name="searchWord"></param>
        public void ApplySearch(string searchWord)
        {
            TxtSearch.SendKeys(searchWord);
            TxtSearch.SendKeys(Keys.Escape);
            BtnSearch.Click();
        }

        /// <summary>
        /// Applies random search.
        /// </summary>
        public void ApplyRandomSearch()
        {
            BtnRandomSearch.Click();
        }
    }
}

using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestsBasic.Tests
{
    [Author("Igor"), TestFixture, Parallelizable(ParallelScope.All)]
    class GoogleTests : TestsBasis
    {
        [Test, Category("Smoke"), Category("Regression")]
        public void SearchWord()
        {
            const string searchWord = "Webdriver";

            Pages.GoogleInitialPage.Open();

            Pages.GoogleInitialPage.ApplySearch(searchWord);

            Assert.AreEqual(searchWord + Pages.GoogleSearchResultsPage.SpecificSearchTitle,
                Pages.GoogleInitialPage.GetPageTitle(),
                "Incorrect page title.");
            Assert.IsTrue(Pages.GoogleSearchResultsPage.SearchResults.Text.Contains(searchWord),
                "Search world is missing in the search results.");
        }

        [Test, Category("Smoke"), Category("Regression")]
        public void RandomSearch()
        {
            Pages.GoogleInitialPage
                .Open()
                .ApplyRandomSearch();

            Pages.GoogleSearchResultsPage.WaitPageToLoad();

            Assert.AreEqual(Pages.GoogleSearchResultsPage.RandomSearchTitle,
                Pages.GoogleSearchResultsPage.GetPageTitle(),
                "Incorrect page title.");
        }

        [Test, Category("Regression")]
        public void InitialTitle()
        {
            Pages.GoogleInitialPage.Open();

            Assert.AreEqual(Pages.GoogleInitialPage.Title, Pages.GoogleInitialPage.GetPageTitle());
        }

        [Test, Category("Regression")]
        public void BrowserNavigation()
        {
            Pages.GoogleInitialPage
                .Open()
                .ApplyRandomSearch();

            Pages.GoogleSearchResultsPage.NavigateBackInBrowser();
            Pages.GoogleInitialPage.NavigateForwardInBrowser();
            Pages.GoogleSearchResultsPage.NavigateBackInBrowser();
            Pages.GoogleInitialPage.RefreshPageInBrowser();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(Pages.GoogleInitialPage.Title,
                    Pages.GoogleInitialPage.GetBrowserTitle(),
                    $"Page title is incorrect.\nPage source: {Pages.GoogleInitialPage.GetPageSource()}");
                Assert.IsTrue(Pages.GoogleInitialPage.TxtSearch.Displayed,
                    "Search field is not displayed.");
                Assert.IsTrue(Pages.GoogleInitialPage.BtnSearch.Displayed,
                    "Search button is not displayed.");
                Assert.IsTrue(Pages.GoogleInitialPage.BtnRandomSearch.Displayed,
                    "Random search button is not displayed.");
            });
        }
    }

    [TestFixture, Parallelizable(ParallelScope.All)]
    class OtherTests
    {
        [Test]
        public void ComplexNumberTest()
        {
            Assert.Multiple(() =>
            {
                Console.WriteLine("Multiple asserts");
                Assert.AreEqual(5, 5, "First Assert");
                Assert.AreEqual("Testing 3", "Testing 2", "Second Assert");
                Assert.AreNotEqual("123", "123", "Asserts are not equal");
            });
        }

        // For testing only.
        [TestCase("https://meta.ua")]
        [TestCase("https://gmail.com")]
        public void OpenUrl1(string url)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = url;
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(d => d.Url.Contains(".")&&d.FindElement(By.Id("head")).Enabled);
            driver.Quit();
        }
        [Test]
        public void OpenUrl2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            driver.Quit();
        }

        // For testing only.
        [TestCase("https://meta.ua")]
        [TestCase("https://gmail.com")]

        public void OpenUrl3(string url)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Quit();
        }

        [Test]
        public void OpenUrl4()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.youtube.com/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Timeout = TimeSpan.FromSeconds(6000);
            wait.Message = $"Element not loaded in {wait.Timeout} milliseconds";
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("Nothing")));
            driver.Quit();
        }
    }
}
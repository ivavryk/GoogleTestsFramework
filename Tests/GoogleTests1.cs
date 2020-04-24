using System;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestsBasic.Tests
{
    [Author("Igor"), TestFixture]
    [AllureNUnit]
    [AllureSuite("Test Suite #1")]
    class GoogleTests1 : TestsBasis
    {
        [Test, Category("Smoke"), Category("Regression")]
        public void SearchWord()
        {
            const string searchWord = "Webdriver";

            TestContext.WriteLine("Open google initial page.");
            Pages.GoogleInitialPage.Open();

            TestContext.WriteLine("Search word.");
            Pages.GoogleInitialPage.ApplySearch(searchWord);

            TestContext.WriteLine("Verify test title.");
            Assert.AreEqual(searchWord + Pages.GoogleSearchResultsPage.SpecificSearchTitle,
                Pages.GoogleInitialPage.GetPageTitle(),
                "Incorrect page title.");

            TestContext.WriteLine("Verify search results.");
            Assert.IsTrue(Pages.GoogleSearchResultsPage.SearchResults.Text.Contains(searchWord),
                "Search world is missing in the search results.");
        }

        [Test, Category("Smoke"), Category("Regression")]
        public void RandomSearch()
        {
            TestContext.WriteLine("Open google initial page and apply random search.");
            Pages.GoogleInitialPage
                .Open()
                .ApplyRandomSearch();

            Pages.GoogleSearchResultsPage.WaitPageToLoad();

            TestContext.WriteLine("Check title.");
            Assert.AreEqual(Pages.GoogleSearchResultsPage.RandomSearchTitle,
                Pages.GoogleSearchResultsPage.GetPageTitle(),
                "Incorrect page title.");
        }

        [Test, Category("Regression")]
        public void InitialTitle()
        {
            TestContext.WriteLine("Open google initial page.");
            Pages.GoogleInitialPage.Open();

            TestContext.WriteLine("Check google title of initial page.");
            Assert.AreEqual(Pages.GoogleInitialPage.Title, Pages.GoogleInitialPage.GetPageTitle());
        }

        [Test, Category("Regression")]
        public void BrowserNavigation()
        {
            TestContext.WriteLine("Open google initial page and apply random search.");
            Pages.GoogleInitialPage
                .Open()
                .ApplyRandomSearch();

            TestContext.WriteLine("Check navigation.");
            Pages.GoogleSearchResultsPage.NavigateBackInBrowser();
            Pages.GoogleInitialPage.NavigateForwardInBrowser();
            Pages.GoogleSearchResultsPage.NavigateBackInBrowser();
            Pages.GoogleInitialPage.RefreshPageInBrowser();

            TestContext.WriteLine("Verify results.");
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
}
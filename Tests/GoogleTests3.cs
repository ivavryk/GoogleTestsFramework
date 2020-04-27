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
    [AllureSuite("Test Suite #3")]
    class GoogleTests3 : TestsBasis
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
            Pages.GoogleInitialPage.Open();

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
}
using System;
using AutomatedTestsBasicStable.Helper;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace AutomatedTestsBasic.Tests
{
    [TestFixture]
    class TestsBasis
    {
        //private IWebDriver _webDriver;
        //public IWebDriver WebDriver
        //{
        //    get { return _webDriver ??= ConfigurationHelper.Driver(); }
        //}

        public static IWebDriver Driver;

        public Pages.Pages Pages;

        [SetUp]
        public void SetUp()
        {
            Driver = ConfigurationHelper.Driver();
            //Driver = new ChromeDriver();
            //Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            Pages = new Pages.Pages();

            Pages.GoogleBasePage.OpenFullScreen();
        }

        [TearDown]
        public void TearDown()
        {
            Pages.GoogleBasePage.CloseBrowser();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
    }
}


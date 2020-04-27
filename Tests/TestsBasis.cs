using System;
using AutomatedTestsBasicStable.Helper;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using System.IO;
using Allure.Commons;
using GoogleTestsFramework.Helper;
using TestResult = NUnit.Framework.Internal.TestResult;
using NUnit.Allure.Attributes;

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
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                TestDetailsHelper.TakeScreenshot(Driver,
                    $"{TestContext.CurrentContext.Test.ClassName}_{TestContext.CurrentContext.Test.Name}");
            }

            Pages.GoogleBasePage.CloseBrowser();
        }

        //    [OneTimeSetUp]
        //    public void OneTimeSetUp()
        //    {

        //    }

        //    [OneTimeTearDown]
        //    public void OneTimeTearDown()
        //    {

        //    }
    }
}


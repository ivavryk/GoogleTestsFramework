using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomatedTestsBasic.Pages
{
    public class Pages
    {
        private GoogleInitialPage _googleInitialPage;
        private GoogleSearchResultsPage _googleSearchResultsPage;
        private GoogleBasePage _googleBasePage;

        public GoogleInitialPage GoogleInitialPage => 
            _googleInitialPage ??= new GoogleInitialPage();

        public GoogleSearchResultsPage GoogleSearchResultsPage =>
            _googleSearchResultsPage ??= new GoogleSearchResultsPage();

        public GoogleBasePage GoogleBasePage =>
            _googleBasePage ??= new GoogleBasePage();
    }
}

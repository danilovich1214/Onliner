using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OnlinerLibrary
{
    public class BasePage
    {
        protected readonly string Url;
        protected readonly By TitleLoactor;

        public BasePage(string url, By titleLocator)
        {
            this.Url = url;
            TitleLoactor = titleLocator;
            AssertIsOpen();
        }

        private void AssertIsOpen()
        {
           
        }

        public void Navigate()
        {
            Driver.Browser.Navigate().GoToUrl(this.Url);
        }

        public IWebElement GetElement(By locator)
        {
            return Driver.Browser.FindElement(locator);
        }
    }
}

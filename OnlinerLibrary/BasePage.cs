using System;
using OnlinerLibrary.BaseElement;
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
        }

        public void AssertIsOpen()
        {
           var baseLabel = new Label(TitleLoactor);
           baseLabel.WaitForElementIsPresent();
        }

        public void Navigate()
        {
            Driver.Browser.Navigate().GoToUrl(this.Url);
        }

        public void NavigateToUrl(string url)
        {
            Driver.Browser.Navigate().GoToUrl(url);
        }

        public IWebElement GetElement(By locator)
        {
            return Driver.Browser.FindElement(locator);
        }

        public bool IsDisplayed(By locator)
        {
            var element = Driver.Browser.FindElement(locator);
            var wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = TimeSpan.FromMinutes(2),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };

            var waiter = new Func<IWebElement, bool>((IWebElement ele) => element.Displayed);

            return wait.Until(waiter);
        }
    }
}

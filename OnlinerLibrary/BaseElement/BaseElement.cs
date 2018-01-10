using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace OnlinerLibrary.BaseElement
{
    public abstract class BaseElement
    {
        protected By Locator;
        protected IWebElement Element;
        private static readonly Logger Log = Logger.Instance;

        protected BaseElement(By locator)
        {
            Locator = locator;
        }

        public IWebElement GetElement()
        {
            try
            {
                Element = Driver.Browser.FindElement(Locator);
            }
            catch (NoSuchElementException)
            {
                Log.Fail("Element not found");
            }
            return Element;
        }

        protected abstract string GetElementType();

        public void WaitForElementIsPresent()
        {
            var wait = new WebDriverWait(Driver.Browser, Driver.GetElementTimeoutInSeconds());
            Element = wait.Until(d =>
            {
                try
                {
                    var elements = d.FindElements(Locator);
                    return elements.FirstOrDefault(webElement => webElement.Displayed);
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

        public void Focus()
        {
            WaitForElementIsPresent();
            new Actions(Driver.Browser).MoveToElement(Element).Build().Perform();
        }

        public void ActionsClick()
        {
            WaitForElementIsPresent();
            var action = new Actions(Driver.Browser);
            action.Click(Element);
            action.Perform();
        }
    }
}

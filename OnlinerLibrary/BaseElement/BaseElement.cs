using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

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

        public IWebElement GetElementByLocator(By locator)
        {
            try
            {
                Element = Driver.Browser.FindElement(locator);
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

        public void ActionsClick()
        {
            WaitForElementIsPresent();
            new Actions(Driver.Browser).MoveToElement(Element).Click(Element).Perform();
        }

        public string GetAttribute(string attr)
        {
            WaitForElementIsPresent();
            return Element.GetAttribute(attr);
        }

        public string GetText()
        {
            WaitForElementIsPresent();
            return Element.Text;
        }
    }
}

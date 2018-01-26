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
            try
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
            catch (TimeoutException ex)
            {
                Driver.Browser.Navigate().Refresh();
                if (!IsPresent())
                {
                    Logger.Instance.Fail(ex.Message + "\n" + "Element is not Present" + " by locator: " + Locator);
                }
            }
        }

        public bool IsPresent()
        {
            return IsPresent(5);
        }

        public bool IsPresent(int sec)
        {
            var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(Convert.ToDouble(sec)));
            try
            {
                wait.Until(waiting =>
                {
                    var elements = Driver.Browser.FindElements(Locator);
                    try
                    {
                        foreach (var webElement in elements.Where(webElement => webElement.Displayed))
                        {
                            Element = webElement;
                            return true;
                        }
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                    return false;
                });
            }
            catch (WebDriverTimeoutException e)
            {
                Logger.Instance.Debug("Element is not present: " + e.StackTrace);
                return false;
            }
            return true;
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

        public bool IsDisplayed()
        {
            var element = Driver.Browser.FindElement(Locator);
            var wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = TimeSpan.FromMinutes(2),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };

            var waiter = new Func<IWebElement, bool>((IWebElement ele) => ele.Displayed);

            return wait.Until(waiter);
        }
    }
}

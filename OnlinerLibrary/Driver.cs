using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace OnlinerLibrary
{
    public static class Driver
    {
        private static readonly double ElementTimeout = 30;

        private static WebDriverWait _browserWait;

        private static IWebDriver _browser;

        public static IWebDriver Browser
        {
            get
            {
                if (_browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return _browser;
            }

            private set => _browser = value;
        }

        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_browserWait == null || _browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return _browserWait;
            }

            private set => _browserWait = value;
        }

        public static void StartBrowser(BrowserTypes browserType = BrowserTypes.Chrome, int defaultTimeOut = 30)
        {
            switch (browserType)
            {
                case BrowserTypes.Firefox:
                    Driver.Browser = new FirefoxDriver(@"C:\Users\Evgenij\source\repos\Onliner\Drivers");
                    break;

                case BrowserTypes.InternetExplorer:
                    Driver.Browser = new InternetExplorerDriver(@"C:\Users\Evgenij\source\repos\Onliner\Drivers");
                    break;

                case BrowserTypes.Chrome:
                    System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\Users\Evgenij\source\repos\Onliner\Drivers");
                    Driver.Browser = new ChromeDriver(@"C:\Users\Evgenij\source\repos\Onliner\Drivers");
                    break;

                default:
                    break;
            }

            Driver.Browser.Manage().Window.Maximize();
            Driver.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            BrowserWait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(defaultTimeOut));
        }

        public static TimeSpan GetElementTimeoutInSeconds()
        {
            return TimeSpan.FromSeconds(Convert.ToDouble(ElementTimeout));
        }

        public static void StopBrowser()
        {
            Browser.Quit();
            Browser = null;
            BrowserWait = null;
        }
    }
}

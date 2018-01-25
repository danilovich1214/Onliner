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
        private static readonly double ElementTimeout = 120;

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

        public static void StartBrowser(BrowserTypes browserType = BrowserTypes.Chrome, int defaultTimeOut = 90)
        {
            switch (browserType)
            {
                case BrowserTypes.Firefox:
                    Driver.Browser = new FirefoxDriver(@"C:\Users\Evgenij\source\repos\Onliner\Drivers");
                    break;

                case BrowserTypes.InternetExplorer:
                    var ieOptions = new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        IgnoreZoomLevel = true,
                        EnableNativeEvents = true,
                        EnsureCleanSession = true
                    };
                    System.Environment.SetEnvironmentVariable("webdriver.ie.driver", Configuration.GetPathToDrivers() + @"\IEDriverServer.exe");
                    Driver.Browser = new InternetExplorerDriver(Configuration.GetPathToDrivers(), ieOptions);
                    break;

                case BrowserTypes.Chrome:
                    System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", Configuration.GetPathToDrivers() + @"\chromedriver.exe");
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("test-type");
                    Driver.Browser = new ChromeDriver(Configuration.GetPathToDrivers(), chromeOptions);
                    break;

                default:
                    break;
            }

            Driver.Browser.Manage().Window.Maximize();
            Driver.Browser.Manage().Timeouts().ImplicitWait = Driver.GetElementTimeoutInSeconds();

            BrowserWait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(defaultTimeOut));
        }

        public static TimeSpan GetElementTimeoutInSeconds()
        {
            return TimeSpan.FromSeconds(Convert.ToDouble(ElementTimeout));
        }

        public static void StopBrowser()
        {
            Browser.Close();
            Browser.Quit();
            Browser = null;
            BrowserWait = null;
        }
    }
}

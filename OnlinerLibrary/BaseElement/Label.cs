using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinerLibrary.BaseElement
{
    public class Label : BaseElement
    {
        public Label(By locator) : base(locator)
        { }

        protected override string GetElementType()
        {
            return "Label";
        }

        public static Label[] GetAllLabels(string locator, string lowerLevelElementLocator = "")
        {
            var count = Driver.Browser.FindElements(By.XPath(locator)).Count;
            var results = new Label[count];
            if (count > 0)
            {
                for (var i = 0; i < count; i++)
                {
                    var elementLocator = locator + "[" + i + 1 + "]";
                    if (lowerLevelElementLocator != "")
                    {
                        elementLocator += "/" + lowerLevelElementLocator;
                    }

                    results[i] = new Label(By.XPath(elementLocator));
                }
            }
            return results;
        }

        public string GetHref()
        {
            return GetAttribute("href");
        }
    }
}

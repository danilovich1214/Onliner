using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinerLibrary.BaseElement
{
    public class Label: BaseElement
    {
        public Label(By locator) : base(locator)
        { }

        protected override string GetElementType()
        {
            return "Label";
        }

        public static Label[] GetAllLabels(string locator)
        {

            int count = Driver.Browser.FindElements(By.XPath(locator)).Count;
            var results = new Label[count];
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    results[i] = new Label(By.XPath(locator + "[" + i + "]"));
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

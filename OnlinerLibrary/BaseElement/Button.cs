using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OnlinerLibrary.BaseElement
{
    public class Button: BaseElement
    {
        public Button(By locator) : base(locator)
        { }
        
        protected override string GetElementType()
        {
            return "Button";
        }

        public void Click()
        {
            WaitForElementIsPresent();
            Element.Click();
        }
    }
}

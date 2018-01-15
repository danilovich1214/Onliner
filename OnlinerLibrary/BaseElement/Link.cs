using OpenQA.Selenium;

namespace OnlinerLibrary.BaseElement
{
    public class Link: BaseElement
    {
        public Link(By locator) : base(locator)
        {}

        protected override string GetElementType()
        {
            return "Link";
        }

        public string GetHref()
        {
            return GetElement().GetAttribute("href");
        }

        public void Click()
        {
            WaitForElementIsPresent();
            Element?.Click();
        }
    }
}

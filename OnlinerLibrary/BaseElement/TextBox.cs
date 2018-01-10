using OpenQA.Selenium;

namespace OnlinerLibrary.BaseElement
{
    class TextBox: BaseElement
    {
        public TextBox(By locator) : base(locator)
        {
        }

        protected override string GetElementType()
        {
            return "TextBox";
        }

        public void SetText(string text)
        {
            WaitForElementIsPresent();
            Element.Clear();
            Element.SendKeys(text);
        }
    }
}

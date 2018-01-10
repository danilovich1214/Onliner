using OpenQA.Selenium;

namespace OnlinerLibrary.BaseElement
{
    public class MenuItem: BaseElement
    {
        public MenuItem(By locator) : base(locator)
        { }

        protected override string GetElementType()
        {
            return "MenuItem";
        }
    }
}

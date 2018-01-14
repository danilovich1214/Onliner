using OnlinerLibrary.BaseElement;
using OpenQA.Selenium;

namespace OnlinerLibrary.PageObject.MainPage
{
    public class MainPage : BasePage
    {
        public static By TitleLocator = By.XPath("");

        public static By LocatorDivGoToLoginPage = By.XPath("//div[@class='auth-bar__item auth-bar__item--text']");

        public static By LocatorDivProfileImage = By.CssSelector("div[class='b-top-profile__image']");

        public static By LocatorLinkMainNavigationCatalog =
            By.XPath("//ul[@class='b-main-navigation']/li/a[@class='b-main-navigation__link']");

        public MainPage()
            : base(@"http://onliner.by/", TitleLocator)
        {

        }

        public void GoToLoginPage()
        {
            var btnGoToLoginPage = new Button(LocatorDivGoToLoginPage);
            btnGoToLoginPage.Click();
        }

        public void GoToCategoryPage()
        {
            Link categoryLink = new Link(LocatorLinkMainNavigationCatalog);
            categoryLink.Click();
        }

        public bool IsProfileImageDisplayed()
        {
            return GetElement(LocatorDivProfileImage).Displayed;
        }
        
        public string GetCatalogHref()
        {
            Link catalogLink = new Link(LocatorLinkMainNavigationCatalog);
            return catalogLink.GetHref();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlinerLibrary.BaseElement;
using OpenQA.Selenium;

namespace OnlinerLibrary.PageObject
{
    public class MainPage : BasePage
    {
        public static By TitleLocator = By.CssSelector("div[class='b-tiles cfix ']");

        public static By LocatorDivGoToLoginPage = By.XPath("//div[@class='auth-bar__item auth-bar__item--text']");

        public static By LocatorDivProfileImage = By.CssSelector("div[class='b-top-profile__image']");

        public MainPage()
            : base(@"http://onliner.by/", TitleLocator)
        {

        }

        public void GoToLoginPage()
        {
            var btnGoToLoginPage = new Button(LocatorDivGoToLoginPage);
            btnGoToLoginPage.ActionsClick();
        }

        public void CkeckProfileImageIsDisplayed()
        {
            Assert.IsTrue(GetElement(LocatorDivProfileImage).Displayed,
                "The profile image is not displayed");
        }
    }
}

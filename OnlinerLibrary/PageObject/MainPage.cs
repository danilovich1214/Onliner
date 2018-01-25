using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlinerLibrary.BaseElement;
using OpenQA.Selenium;

namespace OnlinerLibrary.PageObject
{
    public class MainPage : BasePage
    {
        public static By TitleLocator = By.XPath("//div[@class='g-middle-i']/div[contains(@class, 'b-tiles')]");

        public static By LocatorDivGoToLoginPage = By.XPath("//div[contains(@class,'auth-bar')]/div[contains(@class,'auth-bar__item')]");

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
            Assert.IsTrue(IsDisplayed(LocatorDivProfileImage),
                "The profile image is not displayed");
        }
    }
}

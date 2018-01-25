using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlinerLibrary.BaseElement;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace OnlinerLibrary.PageObject
{
    public class CategoryPage : BasePage
    {
        public static readonly By TittleLocator = By.CssSelector("div[class='catalog-bar']");
    
        public static readonly string CategoryItemLocator = "//ul[@class='catalog-bar__list']/li[@class='catalog-bar__item']";

        public static readonly string CategoryLinkLocator = "a[contains(@class, 'catalog-bar__link')]";

        public static readonly By HeaderTitleLocator = By.CssSelector("h1[class='schema-header__title']");

        public static readonly By LogOutLocator = By.XPath("//div[@class='b-top-profile__logout']/a[contains(@class, 'b-top-profile__link')]");

        public static readonly By DivProfileImageLocator = By.XPath("//div[contains(@class, 'b-top-profile__item_arrow')]");

        public static By LocatorDivGoToLoginPage = By.XPath("//div[contains(@class, 'auth-bar')]/div[contains(@class, 'auth-bar__item')]");

        public CategoryPage()
            : base("https://catalog.onliner.by/", TittleLocator)
        {
        }

        public static Label GetRandomItemLabel()
        {
            var random = new Random();
            var categoryLabelArray = Label.GetAllLabels(CategoryItemLocator, CategoryLinkLocator);
            var randomIndex = random.Next(categoryLabelArray.Count());
            return categoryLabelArray[randomIndex];
        }

        public string GoToRandomCategory()
        {
            var categoryItemLabel = GetRandomItemLabel();
            var categoryText = categoryItemLabel.GetText();
            this.NavigateToUrl(categoryItemLabel.GetHref());
            return categoryText;
        }

        public void CheckGoToCategorySuccessfull(string expectedText)
        {
            var txtBoxNavigationTitle = new TextBox(HeaderTitleLocator);
            var navigationTitleText = txtBoxNavigationTitle.GetText();
            Assert.AreEqual(navigationTitleText, expectedText,
                $"There are incorrect title texts, NavigationTitleText={navigationTitleText} not equal {expectedText}");
        }

        public void LogOut()
        {
            var logOutLink = new Link(LogOutLocator);
            logOutLink.Click();
        }

        public void ClickToProfileImage()
        {
            var profileImageButton = new Button(DivProfileImageLocator);
            profileImageButton.ActionsClick();
        }

        public void CheckLogOutIsSuccessfull()
        {
            var btnGoToLoginPage = new Button(LocatorDivGoToLoginPage);
            Assert.IsTrue(btnGoToLoginPage.IsDisplayed(),
                "Log Out Is not successfull");
        }
    }
}

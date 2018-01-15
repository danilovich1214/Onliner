using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OnlinerLibrary.BaseElement;

namespace OnlinerLibrary.PageObject
{
    public class CategoryPage : BasePage
    {
        public static readonly By TittleLocator = By.XPath("");

        public static readonly string CategoryItemLocator = "//ul[@class='catalog-bar__list']/li[@class='catalog-bar__item']";

        public static readonly string CategoryLinkLocator = "a[contains(@class, 'catalog-bar__link')]";

        public static readonly By HeaderTitleLocator = By.CssSelector("h1[class='schema-header__title']");

        public static readonly By NavigationTitleLocator = By.XPath("//h1[@class='catalog-navigation__title']");

        public static readonly By LogOutLocator = By.XPath("//div[@class='b-top-profile__logout']/a");

        private Label _categoryItemLabel;

        public CategoryPage()
            : base("https://catalog.onliner.by/", TittleLocator)
        {
        }

        public void GetRandomItemLabel()
        {
            var random = new Random();
            Label[] categoryLabelArray = Label.GetAllLabels(CategoryItemLocator, CategoryLinkLocator);
            var randomIndex = random.Next(categoryLabelArray.Count());
            _categoryItemLabel = categoryLabelArray[randomIndex];
        }

        public string GetHrefCatalogItemLabel()
        {
            return _categoryItemLabel.GetHref();
        }

        public void CheckGoToCategorySuccessfull()
        {
            var txtNavigationTitle = new TextBox(NavigationTitleLocator);
            var txtNavigationTitleText = txtNavigationTitle.GetText();
            var txtCategoryItemLabel = _categoryItemLabel.GetText();
            Assert.AreEqual(txtNavigationTitleText, txtCategoryItemLabel,
                $"There are incorrect title texts, txtNavigationTitleText={txtNavigationTitleText} not equal txtCategoryItemLabel={txtCategoryItemLabel}");
        }

        public void LogOut()
        {
            Link logOutLink = new Link(LogOutLocator);
            logOutLink.Click();
        }
    }
}

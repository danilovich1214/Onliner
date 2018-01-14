using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OnlinerLibrary.BaseElement;

namespace OnlinerLibrary.PageObject.CategoryPage
{
    public class CategoryPage: BasePage
    {
        public static readonly By TittleLocator = By.XPath("");
        public static readonly string CatalogLinkLocator = "//ul[@class='catalog-bar__list']/li[@class='catalog-bar__item']";////a[contains(@class, 'catalog-bar__link')]
        public static readonly By HeaderTitleLocator = By.CssSelector("h1[class='schema-header__title']");
        private Label categoryItemLabel;

        public CategoryPage(string url)
            : base(url, TittleLocator)
        {
        }

        public void GetRandomItemLabel()
        {
            Random random = new Random();
            //List<IWebElement> listCategoryLink = BaseElement.BaseElement.GetDisplayedElements(CatalogLinkLocator);
            //catalogItemLink = listCategoryLink[randomIndex];
            //link = new Link(By.XPath(CatalogLinkLocator + "[2]"));      
            Label[] categoryLabelArray = Label.GetAllLabels(CatalogLinkLocator);
            int randomIndex = random.Next(categoryLabelArray.Count());
            categoryItemLabel = categoryLabelArray[randomIndex];
            Link categoryLink = categoryItemLabel.GetElement();
            //categoryItemLabel = new Label(By.XPath(CatalogLinkLocator));
        }

        public string GetHrefCatalogItemLabel()
        {            
            return categoryItemLabel.GetHref();
        }


    }
}

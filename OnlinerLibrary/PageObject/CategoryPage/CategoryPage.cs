using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OnlinerLibrary.PageObject.CategoryPage
{
    public class CategoryPage: BasePage
    {
        public static readonly By TittleLocator = By.XPath("");

        public CategoryPage()
            : base(@"https://catalog.onliner.by/", TittleLocator)
        {
        }
    }
}

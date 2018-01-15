using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlinerLibrary;
using OnlinerLibrary.PageObject;

namespace OnlinerTests
{
    [TestClass]
    public class LoginTest
    {
        string username = "bluerayend@gmail.com";
        string password = "1234567";

        [TestInitialize]
        public void SetupTest()
        {
            Driver.StartBrowser();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Driver.StopBrowser();
        }

        [TestMethod]
        public void LogInAndGoToCategory()
        {
            Logger.Instance.LogStep(1, "Open main Onliner page");
            var mainPage = new MainPage();
            mainPage.Navigate();

            Logger.Instance.LogStep(2, "Open login page and log in");
            mainPage.GoToLoginPage();
            var loginPage = new LoginPage();
            loginPage.LogIn(username, password);
            Assert.IsTrue(mainPage.IsProfileImageDisplayed());

            Logger.Instance.LogStep(3, "Go To Category Page");
            CategoryPage categoryPage = new CategoryPage();
            categoryPage.Navigate();

            Logger.Instance.LogStep(4, "");
            categoryPage.GetRandomItemLabel();
            categoryPage.NavigateToUrl(categoryPage.GetHrefCatalogItemLabel());
            categoryPage.CheckGoToCategorySuccessfull();
        }
    }
}

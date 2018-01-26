using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlinerLibrary;
using OnlinerLibrary.PageObject;

namespace OnlinerTests
{
    [TestClass]
    public class LoginTest
    {
        public readonly string Username = "bluerayend@gmail.com";
        public readonly string Password = "1234567";

        [DataRow(BrowserTypes.InternetExplorer)]
        [DataRow(BrowserTypes.Firefox)]
        [DataRow(BrowserTypes.Chrome)]
        [DataTestMethod]
        public void LogInAndGoToCategory(BrowserTypes typeBrowser)
        {
            Driver.StartBrowser(typeBrowser);

            Logger.Instance.Info("Hello logging world!");
            var mainPage = new MainPage();
            mainPage.Navigate();
            mainPage.AssertIsOpen();

            mainPage.GoToLoginPage();
            var loginPage = new LoginPage();
            loginPage.AssertIsOpen();

            loginPage.LogIn(Username, Password);
            mainPage.CkeckProfileImageIsDisplayed();

            var categoryPage = new CategoryPage();
            categoryPage.Navigate();
            categoryPage.AssertIsOpen();

            var categoryText = categoryPage.GoToRandomCategory();
            categoryPage.CheckGoToCategorySuccessfull(categoryText);

            categoryPage.ClickToProfileImage();
            categoryPage.LogOut();
            categoryPage.CheckLogOutIsSuccessfull();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Driver.StopBrowser();
        }
    }
}

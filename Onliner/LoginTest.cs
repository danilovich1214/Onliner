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

        [DataRow(BrowserTypes.Chrome)]
        [DataRow(BrowserTypes.InternetExplorer)]
        [DataRow(BrowserTypes.Firefox)]
        [DataTestMethod]
        public void LogInAndGoToCategory(BrowserTypes typeBrowser)
        {
            Driver.StartBrowser(typeBrowser);

            Logger.Instance.LogStep(1, "Go to main page");
            var mainPage = new MainPage();
            mainPage.Navigate();
            mainPage.AssertIsOpen();

            Logger.Instance.LogStep(2, "Go to login page");
            mainPage.GoToLoginPage();
            var loginPage = new LoginPage();
            loginPage.AssertIsOpen();

            Logger.Instance.LogStep(3, "Log in");
            loginPage.LogIn(Username, Password);
            mainPage.CkeckProfileImageIsDisplayed();

            Logger.Instance.LogStep(4, "Go to category page");
            var categoryPage = new CategoryPage();
            categoryPage.Navigate();
            categoryPage.AssertIsOpen();

            Logger.Instance.LogStep(5, "Go to random category");
            var categoryText = categoryPage.GoToRandomCategory();
            categoryPage.CheckGoToCategorySuccessfull(categoryText);

            Logger.Instance.LogStep(6, "Log out");
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

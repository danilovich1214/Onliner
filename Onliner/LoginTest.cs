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
            Logger.Instance.LogStep(1, "First Step1111111111111111111");
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
    }
}

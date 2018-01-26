using OnlinerLibrary.BaseElement;
using OpenQA.Selenium;

namespace OnlinerLibrary.PageObject
{
    public class LoginPage : BasePage
    {
        public static readonly By TitleLocator = By.CssSelector("div[class='auth-box__switcher']");

        public static readonly By TxtUsernameLocator = By.XPath("//input[@type='text'][@class='auth-box__input']");

        public static readonly By TxtPasswordLocator = By.XPath("//input[@type='password'][@class='auth-box__input']");

        public static readonly By BtnLoginLocator = By.XPath("//button[contains(@class, 'auth-box__auth-submit')]");
        
        public LoginPage()
            : base(@"http://onliner.by/", TitleLocator)
        {
        }

        public void LogIn(string username, string password)
        {
            var txtBoxUserName = new TextBox(TxtUsernameLocator);
            txtBoxUserName.SetText(username);
            var txtBoxPassword = new TextBox(TxtPasswordLocator);
            txtBoxPassword.SetText(password);
            var btnLogin = new Button(BtnLoginLocator);
            btnLogin.ActionsClick();
        }
    }
}

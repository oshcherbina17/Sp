using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace MobileTesting.Pages
{
    public class LoginPage : AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@content-desc='test-Username']")]
        private IWebElement UsernameField;
       
        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@content-desc='test-Password']")]
        private IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@content-desc='test-LOGIN']")]
        private IWebElement LoginButton;
        public LoginPage(IWebDriver driver) : base(driver) { }

        public bool IsPageOpened()
        {
            return UsernameField.Displayed;
        }

    
        public ProductListPage AutofillLogin(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
            return new ProductListPage(Driver);
        }
    }
}

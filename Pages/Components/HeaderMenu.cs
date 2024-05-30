using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using MobileTesting.Drivers;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace MobileTesting.Pages.Components
{
    public class HeaderMenu : AbstractPage
    {

        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@content-desc='test-Cart']")]
     
        private IWebElement CartButton;

        private By cartButtonBy = By.XPath("//android.view.ViewGroup[@content-desc='test-Cart']");

        public HeaderMenu(IWebDriver driver) : base(driver) { }

       public CartPage ClickOnCartBtn()
        {
            WaitForElementToBeClickable(cartButtonBy, 10);
            Driver.FindElement(cartButtonBy).Click();
            Thread.Sleep(3000); //////////
            return new CartPage(Driver);
        }
    }
}

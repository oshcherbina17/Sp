using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using MobileTesting.Drivers;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;

namespace MobileTesting.Pages
{
    public class CartPage : AbstractPage

    {
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@content-desc='test-CHECKOUT']")]
        private IWebElement CheckoutButton;

         private By checkoutButtonBy = By.XPath("//android.view.ViewGroup[@content-desc='test-CHECKOUT']"); 

        public CartPage(IWebDriver driver) : base(driver) { }

        private By CartItemTitle(string title)
        {
            return By.XPath($"//android.widget.TextView[@text='{title}']");
        }

        public bool CompareProductTitles(string productTitle)
        {
            WaitForElementToBeVisible(By.XPath("//android.view.ViewGroup[@content-desc='test-CHECKOUT']"), 10);
            return Driver.FindElement(CartItemTitle(productTitle)).Displayed;
        }
    }
}

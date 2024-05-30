using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using MobileTesting.Drivers;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using System.Threading;
using MobileTesting.Pages.Components;

namespace MobileTesting.Pages
{
    public class ProductListPage : AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@content-desc='test-Menu']")]
        private IWebElement BurgerMenu;

        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@content-desc='test-Cart']")]
        private IWebElement CartButton;

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text='{title}']/following-sibling::*[@content-desc='test-ADD TO CART']")]
        private IWebElement AddToCartBtn;

        public HeaderMenu HeaderMenu { get; private set; }

        public ProductListPage(IWebDriver driver) : base(driver)
        {
            HeaderMenu = new HeaderMenu(driver);
        }

        private By ProductTitle(string title)
        {
            return By.XPath($"//android.widget.TextView[@text='{title}']/following-sibling::*[@content-desc='test-ADD TO CART']");
        }


        public void AddProductToCart(string productTitle)
        {
            Driver.FindElement(ProductTitle(productTitle)).Click();
        }

        public bool IsBurgerMenuPresent()
        {
            WaitForElementToBeVisible(By.XPath("//android.view.ViewGroup[@content-desc='test-Cart']"), 10);
            return BurgerMenu.Displayed;
        }

        public bool IsCartButtonDisplayed()
        {
            WaitForElementToBeVisible(By.XPath("//android.view.ViewGroup[@content-desc='test-Cart']"), 10);
            return CartButton.Displayed;
        }
    }
}

using System;
using MobileTesting.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;




namespace MobileTesting.Pages
{
    public abstract class AbstractPage

    {
        protected IWebDriver Driver { get; set; }

        public AbstractPage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(Driver,this, new AppiumPageObjectMemberDecorator(new TimeOutDuration(TimeSpan.FromSeconds(5))));

        }

        public void WaitForElementToBeVisible(By by, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitForElementToBeClickable(By by, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        public T GetComponent<T>(IWebDriver driver) where T : new()
        {
            var component = new T();
            PageFactory.InitElements(driver, component);
            return component;
        }
    }

}

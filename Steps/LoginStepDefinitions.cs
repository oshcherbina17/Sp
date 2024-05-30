using MobileTesting.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;
using MobileTesting.Drivers;

namespace MobileTesting.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage _loginPage;
        private ProductListPage _productListPage;
        private IWebDriver _driver;

        public LoginSteps()
        {
            _driver = DriverManager.Driver;
            _loginPage = new LoginPage(_driver);
            _productListPage = new ProductListPage(_driver);

        }
        [Given(@"the app is launched")]
        public void GivenTheAppIsLaunched()
        {
            Assert.IsNotNull(_driver);
        }

        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
             _loginPage.AutofillLogin("standard_user", "secret_sauce");
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            Assert.IsTrue(_productListPage.IsCartButtonDisplayed());

        }
    }
}

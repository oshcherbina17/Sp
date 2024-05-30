using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MobileTesting.Drivers;
using MobileTesting.Pages;
using MobileTesting.Pages.Components;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MobileTesting.Steps
{
   [Binding]
   public class CartSteps
    {
        private LoginPage _loginPage;
        private ProductListPage _productListPage;
        private CartPage _cartPage;
        private IWebDriver _driver;
        private HeaderMenu _headerMenu;

        public CartSteps()
        {
            _driver = DriverManager.Driver;
            _loginPage = new LoginPage(_driver);
            _productListPage = new ProductListPage(_driver);
            _cartPage = new CartPage(_driver);
            _headerMenu = new HeaderMenu(_driver);
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
           Assert.IsTrue(_loginPage.IsPageOpened(), "Login page isn't opened");
        }

        [When(@"I log in with valid credentials")]
        public void WhenILogInWithValidCredentials()
        {
            _loginPage.AutofillLogin("standard_user", "secret_sauce");

        }

        [Then(@"I should see the product list page")]
        public void ThenIShouldSeeTheProductListPage()
        {
            Assert.IsTrue(_productListPage.IsBurgerMenuPresent(), "Burger menu isn't presented");

        }

        [When(@"I add products to the cart ""(.*)""")]
        public void WhenIAddProductsToTheCart(string productTitle)
        {
            _productListPage.AddProductToCart(productTitle);
        }

        [Then(@"the products should be added to the cart")]
        public void ThenTheProductsShouldBeAddedToTheCart()
        {

            _cartPage = _headerMenu.ClickOnCartBtn();
        }

        [Then(@"I should see the correct product titles in the cart ""(.*)""")]
        public void ThenIShouldSeeTheCorrectProductTitlesInTheCart(string productTitle)
        {
            Assert.IsTrue(_cartPage.CompareProductTitles(productTitle), "Product titles aren't presented");
        }
    }
}
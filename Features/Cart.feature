Feature: Add product to cart
  As a user
  I want to log in and add products to my cart
  So that I can review them before checkout

  Scenario Outline: Add product to cart
    Given I am on the login page
    When I log in with valid credentials
    Then I should see the product list page
    When I add products to the cart "<item>"
    Then the products should be added to the cart
    And I should see the correct product titles in the cart "<item>"
Examples:
    | item                  |
    | Sauce Labs Backpack   |
    | Sauce Labs Bike Light |

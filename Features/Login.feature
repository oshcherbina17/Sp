Feature: Login
  Scenario: Successful Login
    Given the app is launched
    When I enter valid credentials
    Then I should be logged in successfully
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MobileTesting.Drivers;

namespace MobileTesting.Hooks
{
    [Binding]
    public class Hooks
    {
     [BeforeScenario]
    public void BeforeScenario()
    {
        var driver = DriverManager.Driver;
       // Assert.IsNotNull(driver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        DriverManager.QuitDriver();
    }   
    }
}

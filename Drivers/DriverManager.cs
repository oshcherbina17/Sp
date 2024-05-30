using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;


namespace MobileTesting.Drivers
{
    public class DriverManager
    {
       private static IWebDriver _driver;
        

       public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    var appiumOptions = new AppiumOptions();
                    appiumOptions.AddAdditionalCapability("appium:platformName", "Android");
                    appiumOptions.AddAdditionalCapability("appium:deviceName", "emulator-5554");
                    appiumOptions.AddAdditionalCapability("appium:app", "/Users/olhashcherbina/Downloads/Android.SauceLabs.Mobile.Sample.app.2.7.1.apk");
                    appiumOptions.AddAdditionalCapability("appium:automationName", "UiAutomator2");
                    appiumOptions.AddAdditionalCapability("appium:appActivity", "com.swaglabsmobileapp.MainActivity");
                    appiumOptions.AddAdditionalCapability("appium:appPackage", "com.swaglabsmobileapp");

                    _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);
                }

                return _driver;
            }
        }

        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}

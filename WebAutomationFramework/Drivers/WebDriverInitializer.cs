using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace WebAutomationFramework.Drivers
{
    public static class WebDriverInitializer
    {
        public static IWebDriver LaunchWebDriver()
        {
            IWebDriver driver;
                // LambdaTest-specific capabilities
                ChromeOptions capabilities = new ChromeOptions();

                // Specify Chrome browser version.
                capabilities.BrowserVersion = "139";

                // LambdaTest options
                Dictionary<string, object> ltOptions = new Dictionary<string, object>
                {
                    { "username", "nanidinnu3" },
                    { "accessKey", "v45oO8wkcaq8sLei5me0yO6qxNDoqqC5LKsFPqw2EYq4avVG1m" },
                    { "geoLocation", "IN" },
                    { "visual", true },
                    { "video", true },
                    { "platformName", "Windows 10" },
                    { "timezone", "Kolkata" },
                    { "build", "Selenium 101 Assessment Test" },
                    { "project", "Assessment" },
                    { "name", "PlayGroundTest" },
                    { "console", "error" },
                    { "networkThrottling", "Regular 4G" },
                    { "w3c", true },
                    { "plugin", "c#-nunit" }
                };

                // Set the LambdaTest options in capabilities
                capabilities.AddAdditionalOption("LT:Options", ltOptions);

                // LambdaTest hub URL
                string lambdaTestHubUrl = "https://hub.lambdatest.com/wd/hub";

                // Initialize RemoteWebDriver with LambdaTest hub URL and configured capabilities
                driver = new RemoteWebDriver(new Uri(lambdaTestHubUrl), capabilities);


            // Optional: Set common driver settings
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
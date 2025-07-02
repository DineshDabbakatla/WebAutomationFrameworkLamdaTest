// WebAutomationFramework.Drivers/WebDriverInitializer.cs
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace WebAutomationFramework.Drivers
{
    public static class WebDriverInitializer
    {
        public static IWebDriver LaunchWebDriver(
            string browser,
            string browserVersion,
            string platform)
        {
            // fetch your LT creds
            string userName = GetSystemVariable("LT_USERNAME");
            string accessKey = GetSystemVariable("LT_ACCESS_KEY");
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(accessKey))
                throw new InvalidOperationException("Set LT_USERNAME & LT_ACCESS_KEY first.");

            DriverOptions options = browser.ToLower() switch
            {
                "chrome" => new ChromeOptions(),
                "firefox" => new FirefoxOptions(),
                "edge" => new EdgeOptions(),
                "safari" => new SafariOptions(),
                _ => throw new ArgumentException($"Unsupported browser: {browser}")
            };

            options.BrowserVersion = browserVersion;
            var ltOpt = new Dictionary<string, object>
            {
                ["username"] = userName,
                ["accessKey"] = accessKey,
                ["platformName"] = platform,
                ["project"] = "Web",
                ["build"] = "Parallel Build",
                ["name"] = $"{browser} on {platform}",
                ["w3c"] = true
            };
            if (browser.Equals("safari", StringComparison.OrdinalIgnoreCase))
            {
                ltOpt["automaticInspection"] = true;
            }
            options.AddAdditionalOption("LT:Options", ltOpt);

            var hub = new Uri("https://hub.lambdatest.com/wd/hub");
            var driver = new RemoteWebDriver(hub, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
            return driver;
        }

        private static string GetSystemVariable(string key)
        {
            // Use process-level environment variable (works in Gitpod and containers)
            return Environment.GetEnvironmentVariable(key);
        }


        public static void MarkTestStatus(IWebDriver driver, bool passed, string reason = "")
        {
            // This JS snippet tells LambdaTest whether this session passed or failed
            string status = passed ? "passed" : "failed";
            ((IJavaScriptExecutor)driver)
                .ExecuteScript($"lambda-status={status}");

            if (!string.IsNullOrEmpty(reason))
            {
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript($"lambda-comment={reason}");
            }
        }

    }
}
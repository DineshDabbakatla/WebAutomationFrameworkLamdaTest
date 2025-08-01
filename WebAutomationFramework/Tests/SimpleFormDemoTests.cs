﻿using NUnit.Framework;
using OpenQA.Selenium;
using WebAutomationFramework.Config;
using WebAutomationFramework.Drivers;
using WebAutomationFramework.Pages;

namespace WebAutomationFramework.Tests
{
    [TestFixture]
    public class SimpleFormDemoTests
    {
        private IWebDriver driver;
        private string browser;
        private string version;
        private string platform;

        [SetUp]
        public void SetUp()
        {
            // WebDriver will be initialized in the test method using parameters
            driver = null;
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();  // Ends the browser session
                driver.Dispose(); // Releases WebDriver resources
            }
        }

        [Test, TestCaseSource(typeof(BrowserConfigs), nameof(BrowserConfigs.Chrome))]
        public void ValidateSimpleFormDemo(string browser, string version, string platform)
        {
            this.browser = browser;
            this.version = version;
            this.platform = platform;
            var urlKey = "SeleniumPlayground";
            var testName = $"ValidateSimpleFormDemo - {browser} - {platform}";

            try
            {
                driver = WebDriverInitializer.LaunchWebDriver(browser, version, platform, testName);

                var page = new SeleniumPlaygroundPage(driver);
                page.NavigateTo(ConfigReader.GetUrl(urlKey));

                var simpleForm = page.ClickSimpleFormDemo();
                var url = simpleForm.Url;
                string msg = "Welcome to LambdaTest";
                simpleForm.EnterMessage(msg).ClickGetCheckedValue();
                var yourMessage = simpleForm.GetYourMessage();

                bool passed = url.Contains("simple-form-demo") && yourMessage.Equals(msg);
                WebDriverInitializer.MarkTestStatus(driver, passed);

                Assert.That(url, Does.Contain("simple-form-demo"), "The URL did not contain 'simple-form-demo'.");
                Assert.That(yourMessage, Is.EqualTo(msg), "The message did not match the expected text.");
            }
            catch (Exception ex)
            {
                WebDriverInitializer.MarkTestStatus(driver, false);
                throw;
            }
        }
    }
}

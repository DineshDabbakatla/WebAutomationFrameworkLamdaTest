using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutomationFramework.Drivers;
using WebAutomationFramework.Pages;

namespace WebAutomationFramework.Tests
{
    [TestFixture]
    public class SimpleFormDemoTests
    {
        private IWebDriver? driver;
        [SetUp]
        public void Setup()
        {
            driver = WebDriverInitializer.LaunchWebDriver();
        }
        [Test]
        public void ValidateSimpleFormDemo()
        {
            var message = "Welcome to LambdaTest";
            var expectedKeywordinUrl = "simple - form - demo";

            var seleniumPlaygroundPage = new SeleniumPlaygroundPage(driver);
            seleniumPlaygroundPage.NavigateTo("https://www.lambdatest.com/selenium-playground");
            var simpleFormDemo = seleniumPlaygroundPage.ClickSimpleFormDemo();
            var currentUrl = simpleFormDemo.Url;
            simpleFormDemo.EnterMessage(message).ClickGetCheckedValue();
            var yourMessage = simpleFormDemo.GetYourMessage();

            Assert.Multiple(() =>
            {
                Assert.That(currentUrl.Contains(expectedKeywordinUrl), $"The Url doesn't comtain {expectedKeywordinUrl}");
                Assert.That(yourMessage.Equals(message), $"Your message result is not same as {message}");
            });
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver?.Dispose();
            }
        }
    }
}

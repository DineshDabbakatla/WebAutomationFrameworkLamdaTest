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
    [Parallelizable(ParallelScope.All)]
    public class InputFormSubmitTests
    {
        [Test, TestCaseSource(typeof(BrowserConfigs), nameof(BrowserConfigs.All))]
        public void ValidateInputFormSubmit(
            string browser,
            string version,
            string platform)
        {
            IWebDriver driver = null;
            try
            {
                driver = WebDriverInitializer.LaunchWebDriver(browser, version, platform);

                var playgroundPage = new SeleniumPlaygroundPage(driver);
                playgroundPage.NavigateTo("https://www.lambdatest.com/selenium-playground");
                string name = "John Doe";
                string email = "Example@email.com";
                string password = "Password123";
                string company = "LambdaTest";
                string address1 = "123 Main St";
                string address2 = "Suite 100";
                string websiteName = "www.example.com";
                string country = "United States";
                string state = "California";
                string city = "Los Angeles";
                string zip = "90001";
                string expectedValidatedMessage = string.Empty;
                string expectedSucessMessage = "Thanks for contacting us, we will get back to you shortly.";

                if (browser.StartsWith("safari", StringComparison.OrdinalIgnoreCase))
                {
                    expectedValidatedMessage = "Fill out this field";
                }
                else
                {
                    expectedValidatedMessage = "Please fill out this field.";
                }

                var inputFormSubmitPage = playgroundPage.ClickInputFormSubmit();
                var validationMessage = inputFormSubmitPage.DoesValidationMessageDisplayed();
                inputFormSubmitPage.FillForm(name, email, password, company, country, address1, address2, websiteName, state, city, zip);
                inputFormSubmitPage.ClickSubmitButton();
                var successMessage = inputFormSubmitPage.GetSuccessMessage;
                var isSucessMessageDisplayed = successMessage.Equals(expectedSucessMessage);
                var isValidationMessageDisplayed = validationMessage.Equals(expectedValidatedMessage);


                if (isSucessMessageDisplayed && isValidationMessageDisplayed)
                {
                    WebDriverInitializer.MarkTestStatus(driver, true);
                }
                else
                {
                    WebDriverInitializer.MarkTestStatus(driver, false);
                }

                Assert.That(successMessage, Is.EqualTo(expectedSucessMessage), "The success message did not match the expected text.");
                Assert.IsTrue(validationMessage.Equals(expectedValidatedMessage), $"The validation message did not match the expected text. Expected : {expectedValidatedMessage}  but actual : {validationMessage}");
            }
            catch (Exception ex)
            {
                WebDriverInitializer.MarkTestStatus(driver, false);
            }
            finally
            {
                driver?.Quit();
                driver?.Dispose();
            }
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationFramework.Pages
{
    public class SimpleFormDemoPage : BasePage
    {
        public SimpleFormDemoPage(IWebDriver driver) : base(driver)
        {
        }

        private const string EnterMessageTextboxId = "user-message";
        private const string GetCheckedvalueBtnXpath = "//button[@id = 'showInput']";
        private const string YourMessageId = "message";

        private IWebElement EnterMessageTextbox => Driver.FindElement(By.Id(EnterMessageTextboxId));
        private IWebElement GetCheckedValueButton => Driver.FindElement(By.XPath(GetCheckedvalueBtnXpath));
        private IWebElement YourMessage => Driver.FindElement(By.Id(YourMessageId));

        public SimpleFormDemoPage EnterMessage(string message)
        {
            int retries = 3; // Maximum retry attempts
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    var textbox = Driver.FindElement(By.Id(EnterMessageTextboxId)); // Re-locate the element
                    textbox.Clear(); // Ensure any existing text is cleared
                    textbox.SendKeys(message); // Enter the message
                    return this; // Return current page object upon success
                }
                catch (StaleElementReferenceException)
                {
                    Console.WriteLine($"Attempt {i + 1}: Element became stale. Retrying...");
                    if (i == retries - 1)
                        throw; // Re-throw the exception on the final attempt
                }
            }
            return this; // Fail-safe return to avoid compilation errors
        }

        public void ClickGetCheckedValue()
        {
            GetCheckedValueButton.Click();
        }

        public string GetYourMessage()
        {
            return YourMessage.Text;
        }
    }
}

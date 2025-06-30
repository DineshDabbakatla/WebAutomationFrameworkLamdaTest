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
    class DragAndDropSlidersTest
    {
        [Test, TestCaseSource(typeof(BrowserConfigs), nameof(BrowserConfigs.All))]
        public void ValidateSimpleFormDemo(
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

                var dragAndDropPage = playgroundPage.ClickDragAndDropSliders();
                dragAndDropPage.DragDefaultValue15SliderTo(95);
                var rangeValue = dragAndDropPage.RangeSuccessValue;
                if (rangeValue == 95)
                {
                    WebDriverInitializer.MarkTestStatus(driver, true);
                }
                else
                {
                    WebDriverInitializer.MarkTestStatus(driver, false);
                }

                Assert.That(rangeValue, Is.EqualTo(95), "The slider did not reach the expected value of 95.");
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

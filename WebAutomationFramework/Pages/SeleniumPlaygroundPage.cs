using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationFramework.Pages
{
    public class SeleniumPlaygroundPage : BasePage
    {
        public SeleniumPlaygroundPage(IWebDriver driver) : base(driver)
        { 
        }

        private const string SimpleFormDemoBtnText = "Simple Form Demo";
        
        private IWebElement SimpleFormDemo => Driver.FindElement(By.PartialLinkText(SimpleFormDemoBtnText));
        

        public SimpleFormDemoPage ClickSimpleFormDemo()
        {
            SimpleFormDemo.Click();
            return new SimpleFormDemoPage(Driver);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TFL.Automation.Extensions
{
    public static class WebElementExtensions
    {
        public static void ClickOnTextBox(this IWebElement webElement)
        {
            Actions actions = new Actions(DriverContext.Instance);
            actions.MoveToElement(webElement).Click().Build().Perform();
        }
        public static void ClickOnButton(this IWebElement webElement)
        {
            try
            {
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)DriverContext.Instance;
                javaScriptExecutor.ExecuteScript("arguments[0].click()", webElement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EnterTextBoxValue(this IWebElement webElement, string value)
        {
            webElement.SendKeys(value);
            webElement.SendKeys(Keys.Tab);
        }

    }
}

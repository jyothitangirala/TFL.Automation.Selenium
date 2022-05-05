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
    public class ControlExtensions
    {
        public static void ClickOnTextBox(IWebElement webElement)
        {
            Actions actions = new Actions(DriverContext.Instance);
            actions.MoveToElement(webElement).Click().Build().Perform();
        }
        public static void ClickOnButton(IWebElement webElement)
        {
            try
            {
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)DriverContext.Instance;
                javaScriptExecutor.ExecuteScript("arguments[0].click()", webElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EnterTextBoxValue(IWebElement webElement, string value)
        {
            webElement.SendKeys(value);
            webElement.SendKeys(Keys.Tab);
        }

        public static void SelectListBoxValue(IWebElement webElement, string valueTobeSelected, bool fireChangeEvent = false)
        {
            try
            {
                List<IWebElement> dbInstanceList = new List<IWebElement>(webElement.FindElements(By.TagName("li")));
                foreach (IWebElement element in dbInstanceList)
                {
                    if (element.Text.Equals(valueTobeSelected))
                    {
                        if (fireChangeEvent)
                        {
                            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)DriverContext.Instance;
                            javaScriptExecutor.ExecuteScript("$(arguments[0]).change();return true;", element);
                        }
                        element.Click();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace TFL.Automation.PageObjects
{
    public class PageBase
    {
                
        public static IWebElement FindControlById(string value)
        {
            try
            {
                DriverContext.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(value)));
                IWebElement element = DriverContext.Instance.FindElement(By.Id(value));
                return element;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IWebElement FindControlByXPath(string value)
        {
            try
            {
                DriverContext.Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(value)));
                IWebElement element = DriverContext.Instance.FindElement(By.XPath(value));
                return element;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IWebElement FindControlByClassName(string value)
        {
            try
            {
                DriverContext.Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(value)));
                IWebElement element = DriverContext.Instance.FindElement(By.ClassName(value));
                return element;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static IWebElement FindControlByLinkText(string value)
        {
            try
            {
                DriverContext.Wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(value)));
                IWebElement element = DriverContext.Instance.FindElement(By.LinkText(value));
                return element;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

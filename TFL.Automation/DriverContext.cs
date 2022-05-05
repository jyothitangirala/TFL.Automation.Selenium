using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TFL.Automation
{
    public class DriverContext
    {
        public static IWebDriver Instance { get; set; }
        public static WebDriverWait Wait;

        public static void Initialize(string browser = null)
        {
            Instance = new ChromeDriver();
            Wait = new WebDriverWait(Instance, new TimeSpan(0, 1, 0));
            try
            {
                Instance.Manage().Window.Maximize();
            }
            catch { }
        }

        public static void Navigate(string appUrl)
        {
            Instance.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey/");
            AcceptCookies();
            Thread.Sleep(1000);
        }

        public static void Close()
        {
            Instance.Close();
            Instance.Quit();
        }

        private static void AcceptCookies()
        {
            Instance.FindElement(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll']")).Click();
            Instance.FindElement(By.XPath("/html/body/div[1]/div[4]/div[2]/button")).Click();
        }
    }
}

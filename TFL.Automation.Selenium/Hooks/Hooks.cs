using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Configuration;
using OpenQA.Selenium;
using System.IO;
using NUnit.Framework;
using TFL.Automation.Helpers;

namespace TFL.Automation.Specs.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Console.WriteLine("Cleaning last execution screenshots and logs.");
            //string folderPath = AppConfig.GetTestResultsPath();
            //List<bool> result = new List<bool>
            //{
            //    FileUtils.DeleteAllFiles(folderPath, "*.*"),
            //};

            //Assert.IsFalse(result.Contains(false));
        }


        [BeforeScenario]
        [Scope(Tag = "JourneyPlan")]
        public static void BeforeScenario()
        {
            try
            {
                DriverContext.Initialize();
                DriverContext.Navigate(AppConfig.GetAppUrl());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured in loading to the TFL Website.\n" + ex.Message);
            }
        }

        [AfterScenario]
        [Scope(Tag = "JourneyPlan")]
        public static void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                Console.WriteLine("screenshots path:" + AppConfig.GetTestResultsPath());
                Screenshot screenshot = ((ITakesScreenshot)DriverContext.Instance).GetScreenshot();
                screenshot.SaveAsFile(AppConfig.GetTestResultsPath() + "\\" + ScenarioContext.Current.ScenarioInfo.Title, ScreenshotImageFormat.Jpeg);
            }
            DriverContext.Close();

            Console.WriteLine("Browser is closed successfully after scenario execution.");
        }
    }
}

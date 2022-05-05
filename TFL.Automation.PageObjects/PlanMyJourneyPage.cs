using TFL.Automation.Extensions;
using OpenQA.Selenium;
using System;
using SeleniumExtras.WaitHelpers;
using Shouldly;

namespace TFL.Automation.PageObjects
{
    public class PlanMyJourneyPage
    {
        private static string inputFromId = "InputFrom";
        private static string inputFromErrorId = "InputFrom-error";
        private const string inputFromValidation="The From field is required.";

        private static string inputToId = "InputTo";
        private static string inputToErrorId = "InputTo-error";
        private const string inputToValidation = "The To field is required.";

        private static string planJourneyBtn = "plan-journey-button";

        public static void EnterFromJourneyLocation(string frmLocation)
        {
            try
            {
                DriverContext.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(inputFromId)));
                var inputFromTxtbx = DriverContext.Instance.FindElement(By.Id(inputFromId));
                ControlExtensions.EnterTextBoxValue(inputFromTxtbx, frmLocation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in entering database Name." + ex.Message);
            }
        }
        public static void EnterToJourneyLocation(string toLocation)
        {
            try
            {
                DriverContext.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(inputToId)));
                var inputToTxtbx = DriverContext.Instance.FindElement(By.Id(inputToId));
                ControlExtensions.EnterTextBoxValue(inputToTxtbx, toLocation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in entering database Name." + ex.Message);
            }
        }

        public static void ClickonPlanMyJourney()
        {
            try
            {
                DriverContext.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(planJourneyBtn)));
                var planmyJourney = DriverContext.Instance.FindElement(By.Id(planJourneyBtn));
                planmyJourney.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in finding plan my journey button." + ex.Message);
            }
        }

        public static void ClickonRecents()
        {
            try
            {
                DriverContext.Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Recents")));
                var recentsBtn = DriverContext.Instance.FindElement(By.LinkText("Recents"));
                recentsBtn.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in finding plan my journey button." + ex.Message);
            }
        }

        public static void VerifyRequiredFieldErrors(bool fromError,bool  toError)
        {
            if (fromError)
            {
                DriverContext.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(inputFromErrorId)));
                var inputError = DriverContext.Instance.FindElement(By.Id(inputFromErrorId));
                inputError.Displayed.ShouldBe(fromError);
                inputError.Text.ShouldBe(inputFromValidation, "From Location validation is not s expected.");
            }
            if (toError)
            {
                DriverContext.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(inputToErrorId)));
                var inputError = DriverContext.Instance.FindElement(By.Id(inputToErrorId));
                inputError.Displayed.ShouldBe(toError);
                inputError.Text.ShouldBe(inputToValidation, "To Location validation is not s expected.");
            }
        }

       public static void VerifyRecentJourneys()
       {
            IWebElement recentResults = DriverContext.Instance.FindElement(By.XPath("//*[@id='jp-recent-content-home-']/a"));
            recentResults?.Displayed.ShouldBeTrue();
        }

    }
}

using TFL.Automation.Extensions;
using OpenQA.Selenium;
using System;
using SeleniumExtras.WaitHelpers;
using Shouldly;

namespace TFL.Automation.PageObjects
{
    public class PlanMyJourneyPage : PageBase
    {

        #region Constants 

        private static string inputFromId = "InputFrom";
        private static string inputFromErrorId = "InputFrom-error";
        private const string inputFromValidation="The From field is required.";

        private static string inputToId = "InputTo";
        private static string inputToErrorId = "InputTo-error";
        private const string inputToValidation = "The To field is required.";

        private static string recentsXPath = "//*[@id='jp-recent-content-home-']/a";
        private static string planJourneyBtnId = "plan-journey-button";

        #endregion Constants

        #region Controls
        private static IWebElement inputFromTxtbx => FindControlById(inputFromId);
        private static IWebElement inputFromError => FindControlById(inputFromErrorId);

        private static IWebElement inputToTxtbx => FindControlById(inputToId);
        private static IWebElement inputToError => FindControlById(inputToErrorId);

        private static IWebElement planJourneyBtn => FindControlById(planJourneyBtnId);
        private static IWebElement recentsBtn => FindControlByLinkText("Recents");
        private static IWebElement recentJourneys => FindControlByXPath(recentsXPath);


        #endregion Controls

        #region Actions
        public static void EnterFromJourneyLocation(string frmLocation)
        {
            inputFromTxtbx.EnterTextBoxValue(frmLocation);
        }
        public static void EnterToJourneyLocation(string toLocation)
        {
            inputToTxtbx.EnterTextBoxValue(toLocation);
        }

        public static void ClickonPlanMyJourney()
        {
            planJourneyBtn.Click();
        }

        public static void ClickonRecents()
        {
           recentsBtn.Click();
        }

        #endregion Actions

        #region Verifications
        public static void VerifyRequiredFieldErrors(bool fromError,bool  toError)
        {
            if (fromError)
            {
                inputFromError.Displayed.ShouldBe(fromError);
                inputFromError.Text.ShouldBe(inputFromValidation, "From Location validation is not s expected.");
            }
            if (toError)
            {
                inputToError.Displayed.ShouldBe(toError);
                inputToError.Text.ShouldBe(inputToValidation, "To Location validation is not s expected.");
            }
        }

       public static void VerifyRecentJourneys()
       {
            recentJourneys?.Displayed.ShouldBeTrue();
        }

        #endregion Verifications
    }
}

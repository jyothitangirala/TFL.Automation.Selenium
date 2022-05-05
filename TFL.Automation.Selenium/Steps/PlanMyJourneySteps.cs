using System;
using TechTalk.SpecFlow;
using TFL.Automation.PageObjects;

namespace TFL.Automation.Selenium
{
    [Binding]
    public class PlanMyJourneySteps
    {
        [Given(@"I have Launched TFL website")]
        public void GivenIHaveLaunchedTFLWebsite()
        {
        }

        [Given(@"I have provided valid from ""(.*)"" and to ""(.*)"" locations")]
        public void GivenIHaveProvidedValidFromAndToLocations(string fromLocation, string toLocation)
        {
            PlanMyJourneyPage.EnterFromJourneyLocation(fromLocation);
            PlanMyJourneyPage.EnterToJourneyLocation(toLocation);
        }

        [When(@"I click on plan my Journey")]
        public void WhenIClickOnPlanMyJourney()
        {
            PlanMyJourneyPage.ClickonPlanMyJourney();
        }

        [Then(@"results with journey options should be displayed ""(.*)""/""(.*)""")]
        public void ThenResultsWithJourneyOptionsShouldBeDisplayed(string fromLocation, string toLocation)
        {
            JourneyResultsPage.VerifyResultsdisplayed(fromLocation, toLocation);
            ScenarioContext.Current.Add("FromLocation", fromLocation);
            ScenarioContext.Current.Add("ToLocation", toLocation);
        }

        [Then(@"results are not displayed")]
        public void ThenResultsAreNotDisplayed()
        {
            JourneyResultsPage.VerifyNoResultsValidation();
        }


        [Then(@"""(.*)""/""(.*)"" message should be displayed for the respective fields")]
        public void ThenMessageShouldBeDisplayedForTheRespectiveFields(bool from,bool to)
        {
            PlanMyJourneyPage.VerifyRequiredFieldErrors(from,to);
        }                             

        [Then(@"I can edit the journey and get updated results")]
        public void ThenICanEditTheJourneyAndGetUpdatedResults()
        {
            var from = ScenarioContext.Current.Get<string>("FromLocation");
            var to = ScenarioContext.Current.Get<string>("ToLocation");
            JourneyResultsPage.EditJourney();
            JourneyResultsPage.VerifyResultsdisplayed(from,to);
        }

        [When(@"I click on Recents")]
        public void WhenIClickOnRecents()
        {
            PlanMyJourneyPage.ClickonRecents();
        }

        [Then(@"I can view my recent journey details")]
        public void ThenICanViewMyRecentJourneyDetails()
        {
            PlanMyJourneyPage.VerifyRecentJourneys();
        }


    }
}

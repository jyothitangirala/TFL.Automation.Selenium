using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Shouldly;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFL.Automation.PageObjects
{
    public class JourneyResultsPage : PageBase
    {
        #region Constants
        private static string fromLocationTxt = "//*[@id='plan-a-journey']/div[1]/div[1]/div[1]/span[2]/strong";
        private static string toLocationTxt = "//*[@id='plan-a-journey']/div[1]/div[1]/div[2]/span[2]/strong";

        #endregion Constants

        #region Controls
        private static IWebElement FromLocation => FindControlByXPath(fromLocationTxt);
        private static IWebElement ToLocation => FindControlByXPath(toLocationTxt);
        #endregion Controls

        #region Verifications
        public static void VerifyResultsdisplayed(string from, string to)
        {
            DriverContext.Wait.Until(ExpectedConditions.TextToBePresentInElement(FromLocation, from));
            FromLocation.Text.ShouldBe(from, "From location in the Journey results is not matching.");

            DriverContext.Wait.Until(ExpectedConditions.TextToBePresentInElement(ToLocation, to));
            ToLocation.Text.ShouldBe(to, "To location in the Journey results is not matching.");

            DriverContext.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("carousel-wrap")));
            IWebElement resultsGroup = DriverContext.Instance.FindElement(By.ClassName("carousel-wrap"));

            IList<IWebElement> journeyOptions = resultsGroup.FindElements(By.XPath("//div[contains(@class, 'always-visible journey-option')]"));
            var options = journeyOptions?.Select(x => x.Text).Where(Text => Text.Contains(to)).ToList();
            options.Count.ShouldBeGreaterThanOrEqualTo(1, "No mtching results displayed");

            IWebElement noResultsdiv = DriverContext.Instance.FindElement(By.XPath("//div[contains(@class, 'r ajax-response')]"));
            IList<IWebElement> vlidationErrors = noResultsdiv.FindElements(By.ClassName("field-validation-errors"));
            vlidationErrors?.Any(element => element.Text.Contains("Sorry, we can't find a journey matching your criteria")).ShouldBeTrue();

        }

        public static void VerifyNoResultsValidation()
        {
            IWebElement noResultsdiv = DriverContext.Instance.FindElement(By.XPath("//div[contains(@class, 'r ajax-response')]"));
            IList<IWebElement> vlidationErrors = noResultsdiv.FindElements(By.ClassName("field-validation-errors"));
            vlidationErrors?.Any(element => element.Text.Contains("Sorry, we can't find a journey matching your criteria")).ShouldBeTrue();

        }

        #endregion Verifications

        #region Actions
        public static void EditJourney()
        {
            IWebElement editJourney = DriverContext.Instance.FindElement(By.LinkText("Edit journey"));
            DriverContext.Wait.Until(ExpectedConditions.ElementToBeClickable(editJourney)).Click();

            IWebElement selectDate = DriverContext.Instance.FindElement(By.Id("Date"));
            SelectElement dateSelector = new SelectElement(selectDate);
            dateSelector.SelectByText("Tomorrow");

            DriverContext.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("plan-journey-button")));
            var updateJourney = DriverContext.Instance.FindElement(By.Id("plan-journey-button"));
            updateJourney.Click();
        }

        #endregion Actions
    }

}

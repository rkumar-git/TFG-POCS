using System;
using System.Configuration;
using CT_Solution.TestExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using sample.TestExtension;
using TechTalk.SpecFlow;

namespace sample.StepDefinition.MaturityAssessment
{
    [Binding]
    public class NavigateToMAPageSteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);

        public NavigateToMAPageSteps(IWebDriver driver)
        {
            _webDriver = driver;
        }

        [When(@"User Clicks on Maturity Assess Link from Navigation Panel")]
        public void WhenUserClicksOnMaturityAssessLinkFromNavigationPanel()
        {
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.MaturityAssessmentLink(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
        }

        [Then(@"Maturity Assess page should be displayed")]
        public void ThenMaturityAssessPageShouldBeDisplayed()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.DesiredState_Button(_webDriver)));
        }

        [Then(@"New Assessment tab should be displayed in the MaturityAssessment Page")]
        public void ThenNewAssessmentTabShouldBeDisplayedInTheMaturityAssessmentPage()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.NewAssessmentTab(_webDriver)));
        }

        [Then(@"View History Details tab should be displayed in the Maturity Assessment Page")]
        public void ThenViewHistoryDetailsTabShouldBeDisplayedInTheMaturityAssessmentPage()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.ViewHistoryTab(_webDriver)));
        }
    }
}

using System;
using System.Configuration;
using CT_Solution.TestExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using sample.TestExtension;
using TechTalk.SpecFlow;

namespace sample
{
    [Binding]
    public class ViewRecentSummarySteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();
        ManageAppMethods mAppMet = new ManageAppMethods();
        string username = ConfigurationManager.AppSettings["Rapid_AdminUserName"];
        string password = ConfigurationManager.AppSettings["Rapid_AdminPassword"];
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);

        public ViewRecentSummarySteps(IWebDriver driver)
        {
            _webDriver = driver;
        }


        [Given(@"MaturityAssessment View History tab is Active")]
        public void GivenMaturityAssessmentViewHistoryTabIsActive()
        {
            //Launch Application
            mApp.LaunchRapidApplication(_webDriver);
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.UserName_EditBox(_webDriver)));

            //Login to the Application
            Assert.IsTrue(mApp.LoginRapidApplication(_webDriver, username, password), "Authenticate Rapid Application.");

            //Navigate to Maturity Assessment.
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.MaturityAssessmentLink(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
            Assert.IsTrue(ManageObjects.MaturityAssessmentPage.DesiredState_Button(_webDriver).Displayed, "Navigated to Maturity assessment page.");

            mAppMet.NavigateToMaturityAssessment_ViewHistoryTab(_webDriver);
            mApp.WaitForAWhile(default_wait_time);
        }

        [When(@"I Click RecentSummary Button")]
        public void WhenIClickRecentSummaryButton()
        {
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.RecentSummary_Button(_webDriver));
        }

        [Then(@"Recent Maturity Level Summary should be displayed")]
        public void ThenRecentMaturityLevelSummaryShouldBeDisplayed()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.MaturityLevelSummary_Image(_webDriver)));
            mApp.WaitForAWhile(default_wait_time);
        }
    }
}

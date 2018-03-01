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
    public class VarifyMaturityAssessment_DesiredStateFieldsSteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);
        string username = ConfigurationManager.AppSettings["Rapid_AdminUserName"];
        string password = ConfigurationManager.AppSettings["Rapid_AdminPassword"];

        public VarifyMaturityAssessment_DesiredStateFieldsSteps(IWebDriver driver)
        {
            _webDriver = driver;
        }

        [Given(@"RapidApplicationLaunched\tand LoggedIn with valid credential")]
        public void GivenRapidApplicationLaunchedAndLoggedInWithValidCredential()
        {
            //Launch Application
            mApp.LaunchRapidApplication(_webDriver);
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.UserName_EditBox(_webDriver)));

            //Login to the Application
            Assert.IsTrue(mApp.LoginRapidApplication(_webDriver, username, password), "Authenticate Rapid Application.");

        }
        
        [When(@"User Click MaturityAssessment Link")]
        public void WhenUserClickMaturityAssessmentLink()
        {
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.MaturityAssessmentLink(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
        }
        
        [Then(@"Maturity Assessment Page is Active")]
        public void ThenMaturityAssessmentPageIsActive()
        {
            Assert.IsTrue(ManageObjects.MaturityAssessmentPage.DesiredState_Button(_webDriver).Displayed, "Navigated to Maturity assessment page.");
        }

        [Then(@"Desired State Button should be displayed")]
        public void ThenDesiredStateButtonShouldBeDisplayed()
        {
            Assert.IsTrue(ManageObjects.MaturityAssessmentPage.DesiredState_Button(_webDriver).Displayed, "Navigated to Maturity assessment page.");
        }
        
        [Then(@"Current State Button Should be displayed")]
        public void ThenCurrentStateButtonShouldBeDisplayed()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.CurrentState_Button(_webDriver)));
        }

        [Then(@"Organization and Process dropdown should be displayed and enabled")]
        public void ThenOrganizationAndProcessDropdownShouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.OrganizationAndProcess_DropdownBox(_webDriver)),
                "Organization And Process dropdownBox.");
        }

        [Then(@"Continuous Integration dropdown should be displayed and enabled")]
        public void ThenContinuousIntegrationDropdownShouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.ContinuousIntegration_DropdownBox(_webDriver)),
                "Continuous Integration dropdownBox.");
        }

        [Then(@"Continuous Inspection dropdown should be displayed and enabled")]
        public void ThenContinuousInspectionDropdownShouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.ContinuousInspection_DropdownBox(_webDriver)), 
                "Continuous Inspection dropdownBox.");
        }

        [Then(@"Continuous Feedback dropdown should be displayed and enabled")]
        public void ThenContinuousFeedbackDropdownShouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.ContinuousFeedback_DropdownBox(_webDriver)), 
                "Continuous Feedback dropdownBox.");
        }

        [Then(@"Continuous Delivery Deployment dropdown should be displayed and enabled")]
        public void ThenContinuousDeliveryDeploymentDropdownShouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.ContinuousDeliveryAndDeployment_DropdownBox(_webDriver)),
                "Continuous Delivery and Deployment.");
        }

        [Then(@"Continuous Testing dropdown should be displayed and enabled")]
        public void ThenContinuousTestingDropdownShouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.ContinuousTesting_DropdownBox(_webDriver)), 
                "Continuous Testing dropdownBox.");
        }

        [Then(@"Continuous Infrastructure dropdown should be displayed and enabled")]
        public void ThenContinuousInfrastructureDropdownShouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.Continuous_Infrastructure_DropdownBox(_webDriver)), 
                "Continuous Infrastucture dropdownBox.");
        }

        [Then(@"Continuous Monitoring dropdown should be displayed and enabled")]
        public void ThenContinuousMonitoringDropdownShouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.Continuous_Monitoring_DropdownBox(_webDriver)), 
                "Continuous Monitoring dropdownBox.");
        }
    }
}

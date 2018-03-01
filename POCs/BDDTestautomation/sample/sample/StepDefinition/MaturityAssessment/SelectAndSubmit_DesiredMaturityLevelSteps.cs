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
    public class SelectAndSubmit_DesiredMaturityLevelSteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);
        string username = ConfigurationManager.AppSettings["Rapid_AdminUserName"];
        string password = ConfigurationManager.AppSettings["Rapid_AdminPassword"];

        string AssessmentValue_To_Select = "Enabling";

        public SelectAndSubmit_DesiredMaturityLevelSteps(IWebDriver driver)
        {
            _webDriver = driver;
        }

        [Given(@"The MaturityAssessment Page New Assessment Tab is Active")]
        public void GivenTheMaturityAssessmentPageNewAssessmentTabIsActive()
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
        }

        [When(@"User Select all values from  Desired Functional State area from dropdown")]
        public void WhenUserSelectAllValuesFromDesiredFunctionalStateAreaFromDropdown()
        {
            //"Select OrganizationAndProcess Desired State Level".
            mApp.SelectOptionsFromDropDown(ManageObjects.MaturityAssessmentPage.OrganizationAndProcess_DropdownBox(_webDriver), "Enabling");
            Assert.IsTrue(mApp.GetSelectedListBoxValue(ManageObjects.MaturityAssessmentPage.OrganizationAndProcess_DropdownBox(_webDriver)).ToUpper() == AssessmentValue_To_Select.ToUpper(), 
                          "Select Organization And Process as Enabling");

            mApp.SelectOptionsFromDropDown(ManageObjects.MaturityAssessmentPage.ContinuousIntegration_DropdownBox(_webDriver), "Enabling");
            Assert.IsTrue(mApp.GetSelectedListBoxValue(ManageObjects.MaturityAssessmentPage.ContinuousIntegration_DropdownBox(_webDriver)).ToUpper() == AssessmentValue_To_Select.ToUpper(), 
                "Select Continuous Integration as Enabling");

            //Verify Continuous Inspection Dropdown box is listed.
            mApp.SelectOptionsFromDropDown(ManageObjects.MaturityAssessmentPage.ContinuousInspection_DropdownBox(_webDriver), "Enabling");
            Assert.IsTrue(mApp.GetSelectedListBoxValue(ManageObjects.MaturityAssessmentPage.ContinuousInspection_DropdownBox(_webDriver)).ToUpper() == AssessmentValue_To_Select.ToUpper(), 
                "Select Continuous Inspection as Enabling");

            mApp.SelectOptionsFromDropDown(ManageObjects.MaturityAssessmentPage.ContinuousFeedback_DropdownBox(_webDriver), "Enabling");
            Assert.IsTrue(mApp.GetSelectedListBoxValue(ManageObjects.MaturityAssessmentPage.ContinuousFeedback_DropdownBox(_webDriver)).ToUpper() == AssessmentValue_To_Select.ToUpper(), 
                "Select Continuous Feedback dropdownBox as Enabled.");

            mApp.SelectOptionsFromDropDown(ManageObjects.MaturityAssessmentPage.ContinuousDeliveryAndDeployment_DropdownBox(_webDriver), "Enabling");
            Assert.IsTrue(mApp.GetSelectedListBoxValue(ManageObjects.MaturityAssessmentPage.ContinuousDeliveryAndDeployment_DropdownBox(_webDriver)).ToUpper() == AssessmentValue_To_Select.ToUpper(),
                "Select Continuous Delivery and Deployment as Enabling.");

            mApp.SelectOptionsFromDropDown(ManageObjects.MaturityAssessmentPage.ContinuousTesting_DropdownBox(_webDriver), "Enabling");
            Assert.IsTrue(mApp.GetSelectedListBoxValue(ManageObjects.MaturityAssessmentPage.ContinuousTesting_DropdownBox(_webDriver)).ToUpper() == AssessmentValue_To_Select.ToUpper(), 
                "Select Continuous Testing as Enabling.");

            //Verify Continuous Infrastructure Dropdown box is listed.
            mApp.SelectOptionsFromDropDown(ManageObjects.MaturityAssessmentPage.Continuous_Infrastructure_DropdownBox(_webDriver), "Enabling");
            Assert.IsTrue(mApp.GetSelectedListBoxValue(ManageObjects.MaturityAssessmentPage.Continuous_Infrastructure_DropdownBox(_webDriver)).ToUpper() == AssessmentValue_To_Select.ToUpper(), 
                "Select Continuous Infrastucture dropdownBox as Enabling.");

            //Verify Continuous Monitoring Dropdown box is listed.
            mApp.SelectOptionsFromDropDown(ManageObjects.MaturityAssessmentPage.Continuous_Monitoring_DropdownBox(_webDriver), "Enabling");
            Assert.IsTrue(mApp.GetSelectedListBoxValue(ManageObjects.MaturityAssessmentPage.Continuous_Monitoring_DropdownBox(_webDriver)).ToUpper() == AssessmentValue_To_Select.ToUpper(), 
                "Select Continuous Monitoring dropdownBox as Enabling");
        }
        
        [When(@"Click Next Button")]
        public void WhenClickNextButton()
        {
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.Next_Button(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
        }

        [Then(@"Current State Maturity level questions should be displayed")]
        public void ThenCurrentStateMaturityLevelQuestionsShouldBeDisplayed()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.SubmitButton(_webDriver)));
        }
    }
}

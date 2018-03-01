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
    public class ViewAll_SubmittedAssessmentHistorySteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();
        ManageAppMethods mAppMet = new ManageAppMethods();
        string username = ConfigurationManager.AppSettings["Rapid_AdminUserName"];
        string password = ConfigurationManager.AppSettings["Rapid_AdminPassword"];
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);

        public ViewAll_SubmittedAssessmentHistorySteps(IWebDriver driver)
        {
            _webDriver = driver;
        }

        [When(@"I Click ViewAll Button")]
        public void WhenIClickViewAllButton()
        {
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.ViewAll_Button(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.ViewAll_Button(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
        }

        [Then(@"Submitted Assessment should be listed")]
        public void ThenSubmittedAssessmentShouldBeListed()
        {
            Assert.IsTrue(ManageObjects.MaturityAssessmentPage.AssessmentHistory_Table(_webDriver).Displayed);
        }
    }
}

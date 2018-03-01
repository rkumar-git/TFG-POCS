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
    public class EditSubmittedAssessmentSteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();
        ManageAppMethods mAppMet = new ManageAppMethods();
        string username = ConfigurationManager.AppSettings["Rapid_AdminUserName"];
        string password = ConfigurationManager.AppSettings["Rapid_AdminPassword"];
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);

        public EditSubmittedAssessmentSteps(IWebDriver driver)
        {
            _webDriver = driver;
        }

        [Given(@"Listed all the Submitted Maturity Level Assessment")]
        public void GivenListedAllTheSubmittedMaturityLevelAssessment()
        {
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.ViewAll_Button(_webDriver));
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.ViewAll_Button(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
        }
        
        [When(@"User select an Assessment from listed History")]
        public void WhenUserSelectAnAssessmentFromListedHistory()
        {
            IWebElement vh_checkBox = _webDriver.FindElement(By.CssSelector("input.checkthis"));
            mApp.ClickElement(vh_checkBox);
            mApp.WaitForAWhile(default_wait_time);
        }
        
        [When(@"Click the Edit option of the Selected Assessment")]
        public void WhenClickTheEditOptionOfTheSelectedAssessment()
        {
            IWebElement vh_EditButton = _webDriver.FindElement(By.XPath("//*[@id='mytable']/tbody/tr[1]/td[6]/p/button/span"));
            mApp.ClickElement(vh_EditButton);
            mApp.WaitForAWhile(default_wait_time);
        }
        
        [Then(@"Selected Assessment details should be displayed to Edit\.")]
        public void ThenSelectedAssessmentDetailsShouldBeDisplayedToEdit_()
        {
            IWebElement edit_assessment_header = _webDriver.FindElement(By.LinkText("Edit Assessment"));
            Assert.IsTrue(edit_assessment_header.Displayed, "Edit Assessment page should display");
            mApp.WaitForAWhile(default_wait_time);
        }
    }
}

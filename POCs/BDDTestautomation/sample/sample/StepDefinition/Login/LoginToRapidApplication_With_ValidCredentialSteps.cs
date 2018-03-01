using System;
using System.Configuration;
using CT_Solution.TestExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using sample.TestExtension;
using sample.TestExtension.Drivers;
using TechTalk.SpecFlow;

namespace sample.StepDefinition
{
    [Binding]
    public class Login_With_ValidCredentialSteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageWebDriver mDriver = new ManageWebDriver();
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);

        public Login_With_ValidCredentialSteps(IWebDriver driver)
        {
            _webDriver = driver;
        }

        [Given(@"RapidApplicationLaunched")]
        public void GivenRapidApplicationLaunched()
        {
            mApp.LaunchRapidApplication(_webDriver);
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.UserName_EditBox(_webDriver)));
        }
        
        [When(@"User Enter valid Username and Password")]
        public void WhenUserEnterValidUsernameAndPassword()
        {
            string username = ConfigurationManager.AppSettings["Rapid_AdminUserName"];
            string password = ConfigurationManager.AppSettings["Rapid_AdminPassword"];
            mApp.EnterTextBoxValue(ManageObjects.LoginPage.UserName_EditBox(_webDriver), username);
            mApp.WaitForAWhile(default_wait_time);
            mApp.EnterTextBoxValue(ManageObjects.LoginPage.Password_EditBox(_webDriver), password);
            mApp.WaitForAWhile(default_wait_time);
        }
        
        [When(@"Click Login Button")]
        public void WhenClickLoginButton()
        {
            mApp.ClickElement(ManageObjects.LoginPage.Login_Button(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
        }

        [Then(@"RapidApplication Home should be displayed")]
        public void ThenRapidApplicationHomeShouldBeDisplayed()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.MaturityAssessmentLink(_webDriver)), "Rapid Application should launch.");
        }        
    }
}

using System;
using System.Configuration;
using CT_Solution.TestExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using sample.TestExtension;
using TechTalk.SpecFlow;

namespace sample.StepDefinition
{
    [Binding]
    public class Login_With_InvalidCredentialsSteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);

        public Login_With_InvalidCredentialsSteps(IWebDriver driver)
        {
            _webDriver = driver;
        }

        [When(@"User Enter Invalid Username and Password")]
        public void WhenUserEnterInvalidUsernameAndPassword()
        {
            string username = ConfigurationManager.AppSettings["Rapid_InvalidUserName"];
            string password = ConfigurationManager.AppSettings["Rapid_InvalidPassword"];
            mApp.EnterTextBoxValue(ManageObjects.LoginPage.UserName_EditBox(_webDriver), username);
            mApp.WaitForAWhile(default_wait_time);
            mApp.EnterTextBoxValue(ManageObjects.LoginPage.Password_EditBox(_webDriver), password);
            mApp.WaitForAWhile(default_wait_time);
        }

        [Then(@"Alert Message should be displayed")]
        public void ThenAlertMessageShouldBeDisplayed()
        {
            Assert.IsTrue(mApp.isTextPresentInPage(_webDriver, "Invalid username or password"));
        }
    }
}

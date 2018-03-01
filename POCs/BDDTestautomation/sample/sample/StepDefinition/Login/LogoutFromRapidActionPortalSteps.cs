using System;
using System.Configuration;
using CT_Solution.TestExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using sample.TestExtension;
using sample.TestExtension.Drivers;
using TechTalk.SpecFlow;

namespace sample
{
    [Binding]
    public class LogoutFromRapidActionPortalSteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);

        public LogoutFromRapidActionPortalSteps(IWebDriver driver)
        {
            _webDriver = driver;
        }

        [Given(@"Logged in with valid credential")]
        public void GivenLoggedInWithValidCredential()
        {
            string username = ConfigurationManager.AppSettings["Rapid_AdminUserName"];
            string password = ConfigurationManager.AppSettings["Rapid_AdminPassword"];
            mApp.EnterTextBoxValue(ManageObjects.LoginPage.UserName_EditBox(_webDriver), username);
            mApp.WaitForAWhile(default_wait_time);
            mApp.EnterTextBoxValue(ManageObjects.LoginPage.Password_EditBox(_webDriver), password);
            mApp.WaitForAWhile(default_wait_time);
            mApp.ClickElement(ManageObjects.LoginPage.Login_Button(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
        }
        
        [When(@"I click the Logout button")]
        public void WhenIClickTheLogoutButton()
        {
            mApp.ClickElement(ManageObjects.LoginPage.LogOut_Button(_webDriver));
        }
        
        [Then(@"RapidApplication should logout")]
        public void ThenRapidApplicationShouldLogout()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.UserName_EditBox(_webDriver)));
        }
    }
}

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
    public class LaunchRapidApplicationSteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();

        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);
        string application_url = ConfigurationManager.AppSettings["RapidApplicationUrl"];

        public LaunchRapidApplicationSteps(IWebDriver driver)
        {
            _webDriver = driver;
        }
        
        [Given(@"Browser Opened and Active")]
        public void GivenBrowserOpenedAndActive()
        {
            Assert.IsTrue(_webDriver.CurrentWindowHandle !="","Web Browser Launched..");
        }
        
        [When(@"I enter the Rapid Application url")]
        public void WhenIEnterTheRapidApplicationUrl()
        {   
            _webDriver.Navigate().GoToUrl(application_url);
            mApp.WaitForAWhile(default_wait_time);
        }
        
        [Then(@"DevOps Portal should be launched")]
        public void ThenDevOpsPortalShouldBeLaunched()
        {
            //ScenarioContext.Current.Pending();
            Console.WriteLine("..." + _webDriver.CurrentWindowHandle);
        }
        
        [Then(@"UserName EditBox should be displayed and enabled")]
        public void ThenUserNameEditBoxShouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.UserName_EditBox(_webDriver)),"User Name edit box displayed.");
        }
        
        [Then(@"Password EditBox should be displayed and enabled")]
        public void ThenPasswordEditBoxShouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.Password_EditBox(_webDriver)),"Password Editbox is diaplyed.");
        }
        
        [Then(@"Login Button shhould be displayed and enabled")]
        public void ThenLoginButtonShhouldBeDisplayedAndEnabled()
        {
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.Login_Button(_webDriver)),"Login Button displayed...");
        }
        
        [Then(@"Forget Password Link should be displayed and enabled")]
        public void ThenForgetPasswordLinkShouldBeDisplayedAndEnabled()
        {
            IWebElement element = _webDriver.FindElement(By.LinkText("Forgot Password ?"));
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(element), "Rapid Application Launched and Login page displayed.");
            mApp.WaitForAWhile(default_wait_time);
        }
    }
}

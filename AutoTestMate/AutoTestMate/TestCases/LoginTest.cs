using AutoTestMate.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestMate.TestCases
{
    public class LoginTest
    {
        public IWebDriver _driver;
        ManageWebDriver mDriver = new ManageWebDriver();
        
        [SetUp]
        public void Initialize()
        {
            //Get TestRunDriver value from App config.
            string TestRunDriver = System.Configuration.ConfigurationSettings.AppSettings["RunWith_Browser"];
            
            //Create WebDriver by calling the CreateWebDriver method from ManageWebDriver class.
            _driver = mDriver.CreateWebDriver(TestRunDriver);
            //Make Browser maximized and set implicit wait to 10 seconds.
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Launch the application
            _driver.Navigate().GoToUrl(System.Configuration.ConfigurationSettings.AppSettings["ApplicationURL"]);
        }

        [Test]
        //Test valid login Scenario
        public void testValidLogin_To_SkinnyTies()
        {
            string skinnyTies_email = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
            string skinnyTies_password = System.Configuration.ConfigurationSettings.AppSettings["Password"];
            
            //Test the valid login scenario of Skinny Test
            LoginPage loginpage = new LoginPage(_driver);
            AccountOverviewPage aoviewPage = loginpage.ValidLogin_To_SkinnyTies(skinnyTies_email, skinnyTies_password);
            if (!aoviewPage.isAt_AccountOverViewPage())
            {
                Assert.Fail("Failed to Login with SkinnyTies the User Name and Password" + skinnyTies_email + ".");
                //Best Practice: Take snapshot of the screen for failure analysis.
            }
            else
            {
                Assert.Pass("Logged in to Skinny Test with the User Name and Password " + skinnyTies_email + ".");
            }
        }

        [Test]
        public void testInvalidLogin_To_SkinnyTies()
        {
            //Get email, password and expected message from App.Config
            string invalid_email = System.Configuration.ConfigurationSettings.AppSettings["Invalid_UserName"];
            string invalid_password = System.Configuration.ConfigurationSettings.AppSettings["Invalid_Password"];
            string errormsg_expected = System.Configuration.ConfigurationSettings.AppSettings["InvalidLogin_ErrorMessage"];
            
            //Test Invalid login scenario of Skinny Test
            LoginPage loginpage = new LoginPage(_driver);
            if (!loginpage.InvalidLogin_To_SkinnyTies(invalid_email, invalid_password, errormsg_expected))
            {
                Assert.Fail("Invalid Login test scenario failed, not displayed the expected error message " + '"' + errormsg_expected + '"' +". Please check manually.");
                //Best Practice: Take snapshot of the screen for failure analysis.
            }
            else
            {
                Assert.Pass("Invalid Login test scenario Passed, displayed the expected error message "+ '"' + errormsg_expected + '"');
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
               _driver.Quit();
            } 
        }
    }
}

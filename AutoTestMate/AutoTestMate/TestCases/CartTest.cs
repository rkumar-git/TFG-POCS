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
    public class CartTest
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

            //Launch application. Get application url from App.config.
            _driver.Navigate().GoToUrl(System.Configuration.ConfigurationSettings.AppSettings["ApplicationURL"]);
        }

        [Test]
        public void testBuyWeeklyPick()
        {
            //Cart page constructor
            CartPage cartPage = new CartPage(_driver);
            if (!cartPage.BuyWeeklyPick())
            {
                 Assert.Fail("Failed to update newly added prodcut count in the basklet.");
                 //Best Practice: Take snapshot of the screen for failure analysis.
            }
            else
            {
                Assert.Pass("Updated the newly added product count in the basket.");
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
using AutoTestMate.Libraries;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestMate.PageObjects
{//Begin
    // Login page class to track the associated objects and methods.
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        SelenseSync selense = new SelenseSync();
       
        //Objects reference of LoginIn/SignIn Page.
        [FindsBy(How = How.Id, Using = "email")] private IWebElement edt_EmailAddress;
        [FindsBy(How = How.Id, Using = "pass")] private IWebElement edt_Password;
        [FindsBy(How = How.XPath, Using = "//*[@id='login-form']/div/button")] private IWebElement btnSignIn;
        [FindsBy(How = How.XPath, Using = "//*[@id='matter']/div[2]/div/ul/li/ul/li")] private IWebElement pnlErrorMessage;

        //Initiate the Page Factory in the Page Object class
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        //Methods which support the Login page
        /*
          Objective: Login to Skinny Ties Account with valid User Name and Password.
          Method name: ValidLogin_To_SkinnyTies
          Params: string userName and password.
          return: Page Object
        */
        public AccountOverviewPage ValidLogin_To_SkinnyTies(string userName, string password)
        {
            try
            {
                //Calling reusable methods from SelenseSync 
                //Enter User name
                selense.EnterEditBoxValue(edt_EmailAddress, userName);
                //Enter Password
                selense.EnterEditBoxValue(edt_Password, password);                
                //Click SignIn Button
                selense.clickElement(btnSignIn);                
                //Wait till the expected element is visible in Account Overview page, after authentication.
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("dashboard - account - info")));
            }
            catch (Exception ex)
            {
                //Best Practice: We can include log4Net to track the logs and exception traces. Not in present scope.
                Console.WriteLine("Exception on ValidLogin_To_SkinnyTies: " + ex.Message);
            }
            return new AccountOverviewPage(driver);
        }

        /*
          Objective: Login to Skinny Test with Invalid username or password.
          Method name: InvalidLogin_To_SkinnyTies
          Params: string userName and password.
          return: bool (true, if condition satisfies, else false)
        */
        public bool InvalidLogin_To_SkinnyTies(string username, string password, string expected_errormsg)
        {
            bool isErrorMessageDisplayed = false;
            try
            {
                //Calling reusable methods from SelenseSync class
                selense.EnterEditBoxValue(edt_EmailAddress, username);
                selense.EnterEditBoxValue(edt_Password, password);
                selense.clickElement(btnSignIn);
                //Verify the actual error message and expected error message.
                if (pnlErrorMessage.Displayed && pnlErrorMessage.Enabled)
                {
                    string actual_errorMessage = pnlErrorMessage.Text;
                    if (expected_errormsg.ToUpper().Trim() == actual_errorMessage.ToUpper().Trim())
                    {
                        Console.WriteLine("Invalid Login displyed the error message " + actual_errorMessage + ", Expected " + expected_errormsg);
                        isErrorMessageDisplayed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on InvalidLogin_To_SkinnyTies: " +ex.Message);
            }
            return isErrorMessageDisplayed;
        }
    }
}//End

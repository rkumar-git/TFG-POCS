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
{
    public class AccountOverviewPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        //Constructure for the SelenseSync
        SelenseSync selense = new SelenseSync();

        //Object Reference of Account info page
        [FindsBy(How = How.Id, Using = "dashboard-account-info")] private IWebElement btn_EditAccountInfo;
        [FindsBy(How = How.Id, Using = "header - cart")] private IWebElement btn_CartHeader;

        //Initiate the Page Factory in the Page Object class
        public AccountOverviewPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /*
         Objective: Click the Cart Header and Go to Cart Page.
         Method name: GoToCartPage()
         Params: NA
         return: CartPage object
       */
        public CartPage GoToCartPage()
        {
            try
            {
                selense.clickElement(btn_CartHeader);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='matter']/div[1]/div/h1")));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on GoToCartPage: " + ex.Message);       
            }           
            return new CartPage(driver);
        }
        
        //Method to verify the Account Overview page.
        public bool isAt_AccountOverViewPage()
        {
            bool isAtOverviewPage = false;
            try
            {
                isAtOverviewPage = btn_EditAccountInfo.Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in isAt_AccountOverViewPage" + ex.Message);
            }
            return isAtOverviewPage;
        }
    }
}
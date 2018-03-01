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
    public class CartPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        SelenseSync selenseSync = new SelenseSync();

        //Objects reference of Cart Page Page.
        [FindsBy(How = How.XPath, Using = "//*[@id='footer']/section[1]/div/section[1]/div/div/a[1]")] private IWebElement lnk_WeeklyPick;
        [FindsBy(How = How.Id, Using = "product-addtocart-button")] private IWebElement btn_AddToCart;
        [FindsBy(How = How.XPath, Using = "//*[@id='header-cart']/ul/li/a/span")] private IWebElement lbl_CartQty;

        //Initiate the Page Factory in the Page Object class
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /*
         Objective: Add to Cart
         Method name: BuyWeeklyPick
         Params: NA.
         return: bool (true, if condition satisfies, else false)
        */
        public bool BuyWeeklyPick()
        {
            int cartvalue_Beforeadd = 0;
            int cartvalue_Afteradd = 0;
            bool isAdded = false;

            //Get the Username and password from App.Config
            string skinnyTies_email = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
            string skinnyTies_password = System.Configuration.ConfigurationSettings.AppSettings["Password"];
            try
            {
                //Reuse the valid login method for Skinny Ties authentication.
                LoginPage loginpage = new LoginPage(driver);
                AccountOverviewPage aoviewPage = loginpage.ValidLogin_To_SkinnyTies(skinnyTies_email, skinnyTies_password);
                if (aoviewPage.isAt_AccountOverViewPage())
                {
                    //Get the present cart value before adding new items to cart.
                    cartvalue_Beforeadd = Int32.Parse(GetCartValue());
                    //Click the Weekly Pick
                    selenseSync.clickElement(lnk_WeeklyPick);
                    //Click Add to cart to add the default quantity of the product to cart.
                    selenseSync.clickElement(btn_AddToCart);
                    //Get the Cart value after adding new item.
                    cartvalue_Afteradd = Int32.Parse(GetCartValue());
                    //Compare the Cart values to decide true or false
                    if (cartvalue_Afteradd > cartvalue_Beforeadd)
                    {
                        Console.WriteLine("Cart value " + cartvalue_Beforeadd + ". After addition " + cartvalue_Afteradd);
                        isAdded = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on AddWeeklyPickToCart: " + ex.Message);
            }
            return isAdded;
        }

        /*
         Objective: Get the Cart value.
         Method name: GetCartValue
         Params: NA.
         return: string (return the span text)
        */
        public string GetCartValue()
        {
            string cvalue = null;
            try
            {
                cvalue = lbl_CartQty.Text;
                Console.WriteLine("Cart Value: " + cvalue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on GetCartValue: " + ex.Message);
            }
            return cvalue;
        }
    }
}
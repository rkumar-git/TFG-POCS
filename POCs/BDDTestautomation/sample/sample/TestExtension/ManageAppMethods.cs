using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using sample.TestExtension;

namespace CT_Solution.TestExtension
{
    public class ManageAppMethods
    {
        ManageApplication mApp = new ManageApplication();
        int default_wait_time = Convert.ToInt32(ConfigurationSettings.AppSettings["Default_Wait_Time"]);

        //Select and Submit Desired capabilities
        public void Select_Then_Submit_DesiredStateLevel(IWebDriver driver, string desiredstatelevel)
        {
            desiredstatelevel = desiredstatelevel.Trim();
            IWebElement OrganizationAndProcess_DropdownBox = driver.FindElement(By.Name("DevOpsFacets[0].selectedDesiredState"));
            mApp.SelectOptionsFromDropDown(OrganizationAndProcess_DropdownBox, desiredstatelevel);

            IWebElement ContinuousIntegration_DropdownBox = driver.FindElement(By.Name("DevOpsFacets[1].selectedDesiredState"));
            mApp.SelectOptionsFromDropDown(ContinuousIntegration_DropdownBox, desiredstatelevel);

            IWebElement ContinuousInspection_DropdownBox = driver.FindElement(By.Name("DevOpsFacets[2].selectedDesiredState"));
            mApp.SelectOptionsFromDropDown(ContinuousInspection_DropdownBox, desiredstatelevel);

            IWebElement ContinuousFeedback_DropdownBox = driver.FindElement(By.Name("DevOpsFacets[3].selectedDesiredState"));
            mApp.SelectOptionsFromDropDown(ContinuousFeedback_DropdownBox, desiredstatelevel);

            IWebElement ContinuousDeliveryAndDeployment_DropdownBox = driver.FindElement(By.Name("DevOpsFacets[4].selectedDesiredState"));
            mApp.SelectOptionsFromDropDown(ContinuousDeliveryAndDeployment_DropdownBox, desiredstatelevel);

            IWebElement ContinuousTesting_DropdownBox = driver.FindElement(By.Name("DevOpsFacets[5].selectedDesiredState"));
            mApp.SelectOptionsFromDropDown(ContinuousTesting_DropdownBox, desiredstatelevel);

            IWebElement Continuous_Infrastructure_DropdownBox = driver.FindElement(By.Name("DevOpsFacets[6].selectedDesiredState"));
            mApp.SelectOptionsFromDropDown(Continuous_Infrastructure_DropdownBox, desiredstatelevel);

            IWebElement Continuous_Monitoring_DropdownBox = driver.FindElement(By.Name("DevOpsFacets[7].selectedDesiredState"));
            mApp.SelectOptionsFromDropDown(Continuous_Monitoring_DropdownBox, desiredstatelevel);

            IWebElement Next_Button = driver.FindElement(By.Id("Next"));
            mApp.ClickElement(Next_Button);
            System.Threading.Thread.Sleep(default_wait_time);
        }

        public bool NavigateToMaturityAssessment_ViewHistoryTab(IWebDriver driver)
        {
            bool isNavigated = false;
            try
            {
                IWebElement MASS_Link = driver.FindElement(By.Id("AssessLink"));
                mApp.ClickElement(MASS_Link);
                System.Threading.Thread.Sleep(default_wait_time);
                IWebElement element_ViewHistory = driver.FindElement(By.Id("ViewHistory"));
                mApp.ClickElement(element_ViewHistory);
                isNavigated = mApp.IsWebElementDisplayed_And_Enabled(element_ViewHistory);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isNavigated;
        }

        public bool LoginRapidApplication_New(IWebDriver driver, string username, string password)
        {
            bool isLoggedIn = false;
            try
            {
                driver.Navigate().GoToUrl(ConfigurationSettings.AppSettings["RapidApplicationUrl"]);
                System.Threading.Thread.Sleep(default_wait_time);
                mApp.ClickElement(ManageObjects.LoginPage.UserName_EditBox(driver));
                mApp.EnterTextBoxValue(ManageObjects.LoginPage.UserName_EditBox(driver), username.Trim());
                System.Threading.Thread.Sleep(default_wait_time);
                mApp.ClickElement(ManageObjects.LoginPage.Password_EditBox(driver));
                mApp.EnterTextBoxValue(ManageObjects.LoginPage.Password_EditBox(driver), password.Trim());
                System.Threading.Thread.Sleep(default_wait_time);
                mApp.ClickElement(ManageObjects.LoginPage.Login_Button(driver));
                System.Threading.Thread.Sleep(default_wait_time);
                isLoggedIn = mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.RapidApplication_HomePage(driver));
            }
            catch (Exception ex)
            {
                Console.WriteLine("LoginRapidApplication:" + ex.Message);
            }
            return isLoggedIn;
        }

        public bool NavigateToMaturityAssessmentPage(IWebDriver driver)
        {
            bool isNavigated = false;
            try
            {
                if (ManageObjects.MaturityAssessmentPage.MaturityAssessmentLink(driver).Displayed)
                {
                    mApp.ClickElement(ManageObjects.MaturityAssessmentPage.MaturityAssessmentLink(driver));
                    System.Threading.Thread.Sleep(default_wait_time);
                    if (ManageObjects.MaturityAssessmentPage.DesiredState_Button(driver).Displayed)
                    {
                        isNavigated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("NavigateToMaturityAssessmentPage:" + ex.Message);
            }
            return isNavigated;
        }

        public bool NavigateToMaturityAssessmentPage_HistoryTab(IWebDriver driver)
        {
            bool isActivated = false;
            try
            {
                bool isNavigatedToMA = NavigateToMaturityAssessmentPage(driver);
                if (isNavigatedToMA)
                {
                    mApp.ClickElement(ManageObjects.MaturityAssessmentPage.ViewHistoryTab(driver));
                    if (mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.MaturityAssessmentPage.RecentSummary_Button(driver)))
                    {
                        isActivated = true;
                        Console.WriteLine("View History tab is active....");
                    }
                    else
                    {
                        isActivated = false;
                        Console.WriteLine("View History tab is not active....");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception NavigateToMaturityAssessmentPage_HistoryTab:" + ex.Message);
            }
            return isActivated;
        }
    }
}

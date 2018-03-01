using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace sample.TestExtension
{
    public class ManageObjects
    {
        public static class LoginPage
        {
            public static IWebElement element = null;
            // Manage web Objects.
            public static IWebElement UserName_EditBox(IWebDriver driver)
            {
                try
                {
                    element = null;
                    element = driver.FindElement(By.Id("UserName"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                return element;
            }

            public static IWebElement Password_EditBox(IWebDriver driver)
            {
                try
                {
                    element = null;
                    element = driver.FindElement(By.Id("Password"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                return element;
            }

            public static IWebElement ForgetPassword_Link(IWebDriver driver)
            {
                try
                {
                    element = null;
                    element = driver.FindElement(By.LinkText("Forgot Password ?"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                return element;
            }

            public static IWebElement Login_Button(IWebDriver driver)
            {
                try
                {
                    element = null;
                    element = driver.FindElement(By.Id("btnLogin"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                return element;
            }

            public static IWebElement LogOut_Button(IWebDriver driver)
            {
                try
                {
                    element = null;
                    element = driver.FindElement(By.XPath("//*[@id='logoutForm']/li/input"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                return element;
            }

            public static IWebElement RapidApplication_HomePage(IWebDriver driver)
            {
                try
                {
                    element = null;
                    element = driver.FindElement(By.CssSelector("#carousel-example-generic"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("RapidApplication_HomePage:" + ex.Message);
                }
                return element;
            }
        }


        //Maturity Assessment Page ###################################################
        public static class MaturityAssessmentPage
        {
            public static IWebElement element = null;
            public static IWebElement DesiredState_Button(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.LinkText("Desired State"));
                return element;
            }

            public static IWebElement CurrentState_Button(IWebDriver driver)
            {
                IWebElement element = null;
                element = driver.FindElement(By.Id("currentstatepill"));
                return element;
            }

            public static IWebElement MaturityAssessmentLink(IWebDriver driver)
            {
                IWebElement element = null;
                element = driver.FindElement(By.Id("AssessLink"));
                return element;
            }

            public static IWebElement NewAssessmentTab(IWebDriver driver)
            {
                IWebElement element = null;
                try
                {
                    element = driver.FindElement(By.LinkText("New Assessment"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception:" + ex.Message);
                }
                return element;
            }
            public static IWebElement ViewHistoryTab(IWebDriver driver)
            {
                IWebElement element = null;
                element = driver.FindElement(By.Id("ViewHistory"));
                return element;
            }
            public static IWebElement RecentSummary_Button(IWebDriver driver)
            {
                IWebElement element = null;
                try
                {
                    element = driver.FindElement(By.XPath("//*[@id='ResultsSummary']"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                return element;
            }
            public static IWebElement Next_Button(IWebDriver driver)
            {
                IWebElement element = null;
                try
                {
                    element = driver.FindElement(By.Id("Next"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception:" + ex.Message);
                }
                return element;
            }

            public static IWebElement ViewAll_Button(IWebDriver driver)
            {
                element = null;
                try
                {
                    element = driver.FindElement(By.Id("ViewAll"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                return element;
            }

            public static IWebElement MaturityLevelSummary_Image(IWebDriver driver)
            {
                IWebElement element = null;
                try
                {
                    element = driver.FindElement(By.Id("maturitySummary"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                return element;
            }

            public static IWebElement AssessmentHistory_Table(IWebDriver driver)
            {
                IWebElement element = null;
                try
                {
                    element = driver.FindElement(By.XPath("//*[@id='mytable']"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                return element;
            }

            public static IWebElement SubmitButton(IWebDriver driver)
            {
                IWebElement element = null;
                try
                {
                    element = driver.FindElement(By.Id("submitbtn"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception:" + ex.Message);
                }
                return element;
            }

            public static IWebElement AlertLabel(IWebDriver driver)
            {
                IWebElement element = null;
                try
                {
                    element = driver.FindElement(By.Id("alertlabel"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message + ex.StackTrace);
                }
                return element;
            }
            ///MAHistory_Edit_Button = driver.FindElement(By.XPath("//*[@id="mytable"]/tbody/tr[2]/td[5]/p/button"));
            ///MAHistory_Delete_Button = driver.FindElement(By.XPath("//*[@id="deletebtn"]"));
            public static IWebElement MAHistory_Edit_Button(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.XPath("//*[@id='mytable']/tbody/tr[2]/td[5]/p/button"));
                return element;
            }

            public static IWebElement MAHistory_Delete_Button(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.XPath("//*[@id='deletebtn']"));
                return element;
            }

            public static IWebElement OrganizationAndProcess_DropdownBox(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.Name("DevOpsFacets[0].selectedDesiredState"));
                return element;
            }
           
            public static IWebElement ContinuousFeedback_DropdownBox(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.Name("DevOpsFacets[3].selectedDesiredState"));
                return element;
            }
            public static IWebElement ContinuousDeliveryAndDeployment_DropdownBox(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.Name("DevOpsFacets[4].selectedDesiredState"));
                return element;
            }
            public static IWebElement ContinuousTesting_DropdownBox(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.Name("DevOpsFacets[5].selectedDesiredState"));
                return element;
            }
            public static IWebElement Continuous_Infrastructure_DropdownBox(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.Name("DevOpsFacets[6].selectedDesiredState"));
                return element;
            }
            public static IWebElement Continuous_Monitoring_DropdownBox(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.Name("DevOpsFacets[7].selectedDesiredState"));
                return element;
            }
            
            public static IWebElement ContinuousIntegration_DropdownBox(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.Name("DevOpsFacets[1].selectedDesiredState"));
                return element;
            }

            public static IWebElement ContinuousInspection_DropdownBox(IWebDriver driver)
            {
                element = null;
                element = driver.FindElement(By.Name("DevOpsFacets[2].selectedDesiredState"));
                return element;

            }
        }



        public static class SetUpToolChainPage
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using sample.TestExtension;
using sample.TestExtension.Drivers;

namespace CT_Solution.TestExtension
{
    public class ManageApplication
    {
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);
        
        //Get key value from app settings.
        public string getKeyvalueFromAppSettings(string keyname)
        {
            string keyvalue = null;
            try
            {
                keyvalue = ConfigurationManager.AppSettings[keyname];
            }
            catch (Exception ex)
            {
                Console.WriteLine("getKeyvalueFromAppSetting - Exception :" + ex.Message);
            }
            return keyvalue;
        }

        public bool LaunchRapidApplication(IWebDriver wDriver)
        {
            bool isDisplayed = false;
            string base_Application_url = null;
            try
            {
                //base_Application_url = ConfigurationManager.AppSettings["RapidApplicationUrl"];
                base_Application_url = getKeyvalueFromAppSettings("RapidApplicationUrl");
                wDriver.Url = base_Application_url;
                wDriver.Manage().Window.Maximize();
                wDriver.Navigate().GoToUrl(base_Application_url);
                IWebElement loginLink = wDriver.FindElement(By.XPath("//*[@id='btnLogin']"));
                isDisplayed = loginLink.Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Method:Launch Rapid Application:" + ex.Message);
            }
            return isDisplayed;
        }

        public string GetProjectSolutionPath()
        {
            string solution_path = null;
            try
            {
                solution_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            return solution_path;
        }

        public void TaksScreenshotOnFailures(IWebDriver driver)
        {
            var screenshot = driver.TakeScreenshot();
            string filepath = ConfigurationManager.AppSettings["SnapshotPath"];
            Console.WriteLine("Snapshot Path: " + filepath);
            //screenshot.SaveAsFile(filepath + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png", ImageFormat.Png);
        }

        public void CloseAllBrowsers(string browser_name)
        {
            try
            {
                Process[] browserInstances = Process.GetProcessesByName(browser_name);
                foreach (Process p in browserInstances)
                {
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        public bool LaunchWebPortal(IWebDriver wDriver)
        {
            bool isDisplayed = false;
            string base_Application_url = null;
            try
            {
                base_Application_url = ConfigurationManager.AppSettings["ApplicationUrl"];
                wDriver.Url = base_Application_url;
                wDriver.Manage().Window.Maximize();
                wDriver.Navigate().GoToUrl(base_Application_url);
                IWebElement loginLink = wDriver.FindElement(By.Id("loginLink"));
                isDisplayed = loginLink.Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isDisplayed;
        }

        public string ReadResourceValue(string key)
        {
            string file = "D:\\DevOps - Portal - TestProject\\DevopsPortal - CIProject\\DevopsPortal - CIProject\\Test\\ObjectRepository.resx";
            //value for our return value
            string resourceValue = string.Empty;
            try
            {
                // specify your resource file name
                string resourceFile = file;
                // get the path of your file
                string filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                // create a resource manager for reading from the resx file
                ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager(resourceFile, filePath, null);
                // retrieve the value of the specified key
                resourceValue = resourceManager.GetString(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resourceValue = string.Empty;
            }
            return resourceValue;
        }

        public bool ClickAndVerify(IWebElement element_to_click, IWebElement element_to_verify)
        {
            bool isDisplayed = false;
            try
            {
                element_to_click.Click();
                System.Threading.Thread.Sleep(2000);
                isDisplayed = element_to_verify.Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isDisplayed;
        }

        public void ClickElement(IWebElement element_to_click)
        {
            try
            {
                element_to_click.Click();
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool IsWebElementDisplayed_And_Enabled(IWebElement element_to_verify)
        {
            bool isDisplayedAndEnabled = false;
            try
            {
                isDisplayedAndEnabled = element_to_verify.Displayed && element_to_verify.Enabled;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isDisplayedAndEnabled;
        }

        public bool SelectOptionsFromDropDown(IWebElement element_dropdown_box, string option_to_select)
        {
            bool isSelected = false;
            try
            {
                var selectElement = new SelectElement(element_dropdown_box);
                selectElement.SelectByText(option_to_select);
                System.Threading.Thread.Sleep(1000);
                string selected_value = element_dropdown_box.Selected.ToString();
                if (selected_value.ToUpper() == option_to_select.ToUpper())
                {
                    isSelected = true;
                }
                else
                {
                    isSelected = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isSelected;
        }

        public string GetSelectedListBoxValue(IWebElement element_listbox)
        {
            string selected_value = string.Empty;
            try
            {
                //selected_value = element_listbox.GetAttribute(selected_value);
                SelectElement selectedValue = new SelectElement(element_listbox);
                selected_value = selectedValue.SelectedOption.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return selected_value;
        }

        public IWebElement GetElement(IWebDriver driver, string element_ref)
        {
            IWebElement element_to_find = null;
            string ref_name = string.Empty;
            string ref_value = string.Empty;
            try
            {
                //Get the relement ref and value
                string[] element_ref_toparse = element_ref.Split(':');
                ref_name = element_ref_toparse[0];
                ref_value = element_ref_toparse[1];

                //Find Element based on Ref
                switch (ref_name.ToUpper())
                {
                    case "ID":
                        element_to_find = driver.FindElement(By.Id(ref_value));
                        break;
                    case "NAME":
                        element_to_find = driver.FindElement(By.Name(ref_value));
                        break;
                    case "XPATH":
                        element_to_find = driver.FindElement(By.XPath(ref_value));
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            return element_to_find;
        }

        public bool EnterTextBoxValue(IWebElement textbox_element, string value_to_enter)
        {
            bool isEntered = false;
            try
            {
                textbox_element.Clear();
                System.Threading.Thread.Sleep(1000);
                textbox_element.SendKeys(value_to_enter);
                if (textbox_element.Text.ToUpper() == value_to_enter.ToUpper())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("EnterTextBoxValue:" + ex.Message);
            }
            return isEntered;
        }

        public bool isTextPresentInPage(IWebDriver driver, string text_to_find)
        {
            bool isPresent = false;
            try
            {
                string bodyText = driver.FindElement(By.TagName("body")).Text;
                if (bodyText.Contains(text_to_find))
                {
                    isPresent = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("isTextPresentInPage:" + ex.Message);
            }
            return isPresent;
        }

        public bool LoginRapidApplication_old(IWebDriver driver, string username, string password)
        {
            bool isLoggedIn = false;
            try
            {
                ManageWebDriver mDriver = new ManageWebDriver();
                driver = mDriver.SetWebDriver(ConfigurationManager.AppSettings["default_browser"]);
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["RapidApplicationUrl"]);
                System.Threading.Thread.Sleep(5000);
                ClickElement(ManageObjects.LoginPage.UserName_EditBox(driver));
                EnterTextBoxValue(ManageObjects.LoginPage.UserName_EditBox(driver), username.Trim());
                System.Threading.Thread.Sleep(5000);
                ClickElement(ManageObjects.LoginPage.Password_EditBox(driver));
                EnterTextBoxValue(ManageObjects.LoginPage.Password_EditBox(driver), password.Trim());
                System.Threading.Thread.Sleep(5000);
                ClickElement(ManageObjects.LoginPage.Login_Button(driver));
                System.Threading.Thread.Sleep(5000);
                isLoggedIn = IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.RapidApplication_HomePage(driver));
            }
            catch (Exception ex)
            {
                Console.WriteLine("LoginRapidApplication:" + ex.Message);
            }
            return isLoggedIn;
        }

        public bool LoginRapidApplication(IWebDriver driver, string username, string password)
        {
            bool isLoggedIn = false;
            try
            {
                //ManageWebDriver mDriver = new ManageWebDriver();
                //driver = mDriver.SetWebDriver(ConfigurationManager.AppSettings["default_browser"]);
               // driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["RapidApplicationUrl"]);
                //System.Threading.Thread.Sleep(5000);
                ClickElement(ManageObjects.LoginPage.UserName_EditBox(driver));
                EnterTextBoxValue(ManageObjects.LoginPage.UserName_EditBox(driver), username.Trim());
                System.Threading.Thread.Sleep(5000);
                ClickElement(ManageObjects.LoginPage.Password_EditBox(driver));
                EnterTextBoxValue(ManageObjects.LoginPage.Password_EditBox(driver), password.Trim());
                System.Threading.Thread.Sleep(5000);
                ClickElement(ManageObjects.LoginPage.Login_Button(driver));
                System.Threading.Thread.Sleep(5000);
                isLoggedIn = IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.RapidApplication_HomePage(driver));
            }
            catch (Exception ex)
            {
                Console.WriteLine("LoginRapidApplication:" + ex.Message);
            }
            return isLoggedIn;
        }

        public void WaitForAWhile(int time_to_wait)
        {
            try
            {
                System.Threading.Thread.Sleep(time_to_wait);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption - WaitForAWhilr" + ex.Message);
            }
        }
    }
}

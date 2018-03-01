using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestMate
{
    /*
        Objective: Setting Up Webdriver as a common class
        MethosName: CreateWebDrover()
        Param: BrowserName
        Return: WebDriver as per the Param
        Default Return: Chrome Driver         
    */

    public class ManageWebDriver
    {
        public IWebDriver CreateWebDriver(string BrowserName)
        {
            string driver_path = null;
           
            //Getting the Driver path from App Settings
            driver_path = System.Configuration.ConfigurationSettings.AppSettings["DriverPath"];
            switch (BrowserName.Trim().ToUpper())
            {
                //Browser Name is Chrome, Chrome WebDriver will be returnd.
                case "CHROME":
                default:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("start-maximized");
                    return new ChromeDriver(@driver_path, chromeOptions);
            }       
        }     
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using sample.TestExtension.Drivers;
using TechTalk.SpecFlow;

namespace CT_Solution.TestExtension
{
    [Binding]
    public class WebDriverShared
    {   
        //Shared WebDriver for Context injection.
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _webDriver;
        ManageWebDriver mDriver = new ManageWebDriver();
        ManageAppMethods mApp = new ManageAppMethods();
        string defalut_Browser = null;
        string solution_path = null;

        public WebDriverShared(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {            
            Console.WriteLine("Called Before Scenario...");
            defalut_Browser = ConfigurationManager.AppSettings["default_browser"];
            Console.WriteLine("Selected Browser: " + defalut_Browser);
            solution_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            _webDriver = mDriver.SetWebDriver(defalut_Browser);
            if (_webDriver.WindowHandles != null)
            {
                _objectContainer.RegisterInstanceAs<IWebDriver>(_webDriver);
            }            
        }

        [AfterScenario]
        public void CleanUp()
        {
            Console.WriteLine("Called After Scenario...");
            _webDriver.Close();
            _webDriver.Dispose();
        }       
    }
}

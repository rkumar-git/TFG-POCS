using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace sample.TestExtension.Drivers
{
    public class ManageWebDriver
    {
        string driver_path = null;
        string solution_path = null;

        //Manage WebDriver
        public IWebDriver SetWebDriver(string driverName)
        {
            IWebDriver selectedWebDriver = null;       
            solution_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            switch (driverName.ToUpper())
            {
                case "FIREFOX":
                    string ghekoDriverPath = solution_path + "\\TestExtension\\Drivers";
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@ghekoDriverPath, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox";
                    selectedWebDriver = new FirefoxDriver(service);
                    break;

                case "CHROME":
                    driver_path = solution_path + "\\TestExtension\\Drivers\\";
                    Console.WriteLine("Driver Path:" + driver_path);
                    ChromeOptions chrome_ops = new ChromeOptions();
                    //ChromeDriverService cdservice = ChromeDriverService.CreateDefaultService();
                    //cdservice.SuppressInitialDiagnosticInformation = true;
                    chrome_ops.AddArgument("start-maximized");
                    selectedWebDriver = new ChromeDriver(@driver_path, chrome_ops);
                    break;

                case "IE":
                    driver_path = solution_path + "TestExtension\\Drivers";
                    selectedWebDriver = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                    break;
            }
            return selectedWebDriver;
        }                 
    }
}

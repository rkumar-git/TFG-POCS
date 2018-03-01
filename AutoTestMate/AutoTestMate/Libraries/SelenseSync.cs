using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestMate.Libraries
{
    /*
        Objective is to track all the Selenium related common methods which are
        reusable for the Test script development.
    */
    public class SelenseSync
    {
        //Webdrive declatation
        private IWebDriver driver;                

        /*
            Objective: Click a WebElement which is passing as param. 
        */
        public void clickElement(IWebElement element_to_click)
        {
            try
            {
                // Click the element only of the element is visible and enabled.
                if (element_to_click.Displayed && element_to_click.Enabled)
                {
                    element_to_click.Click();                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on clickElement: " + ex.Message);
            }
        }

        /*
            Objective: Enter value in a Text box.
            Method name: EnterEditBoxValue
            Params: InputBox as IWebElement, Value to enter in the edit box.
            return: bool, true if the param value entered else false.
        */
        public bool EnterEditBoxValue(IWebElement element, string value_to_enter)
        {
            bool isValueEntered = false;
            string entered_value = string.Empty;
            if (!element.Enabled && element.Displayed)
            {
                Console.WriteLine("Input box is not displayed or editable. Please check.");
            }
            else
            {
                element.Click();
                element.SendKeys("");
                element.SendKeys(value_to_enter.Trim());
                entered_value = element.GetAttribute("value");
                if (value_to_enter.Trim().ToUpper() == entered_value.Trim().ToUpper())
                {
                    isValueEntered = true;
                    Console.WriteLine("Edit box text entered as " + entered_value);
                    //Best practice: Need to configure Log4Net and add the traces in log.
                }
                else
                {
                    Console.WriteLine("Edit box text entered as " + entered_value);
                }
            }
            return isValueEntered;
        }

        /*
          Objective: Get the param elements text value
          Method name: GetElementTextValue
          Params: IWebElement, to read the value.
          return: string, the attribute value.
        */
        public string GetElementTextValue(IWebElement element_to_getText)
        {
            string element_text = null;
            try
            {
                element_text = element_to_getText.GetAttribute("Value");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            return element_text;
        }
        
        /*
          Objective: Take snapshot in failure or exception.
          Method name: TaksScreenshotOnFailures
          Params: IWebElement, save_to_filepath.
          return: void
          Result: Take snapshot on call and save to the specified file path.
        */
        public void TaksScreenshotOnFailures(IWebDriver driver, string saveTo_Filepath)
        {
            var screenshot = driver.TakeScreenshot();
            Console.WriteLine("Snapshot Path: " + saveTo_Filepath);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            //screenshot.SaveAsFile("Error-"+ timestamp + ".jpeg", ImageFormat.Jpeg);
        }
    }
}
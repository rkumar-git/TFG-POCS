using System;
using System.Configuration;
using CT_Solution.TestExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using sample.TestExtension;
using TechTalk.SpecFlow;

namespace sample.StepDefinition.MaturityAssessment
{
    [Binding]
    public class DeleteSubmittedAssessmentSteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();
        ManageAppMethods mAppMet = new ManageAppMethods();
        string username = ConfigurationManager.AppSettings["Rapid_AdminUserName"];
        string password = ConfigurationManager.AppSettings["Rapid_AdminPassword"];
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);
        int ahtable_rowcount_beforeDelete = 0;
        int ahtable_rowcount_afterDelete = 0;

        public DeleteSubmittedAssessmentSteps(IWebDriver driver)
        {
            _webDriver = driver;
        }

        [When(@"Click the Delete Button of the Selected Assessment")]
        public void WhenClickTheDeleteButtonOfTheSelectedAssessment()
        {
            ahtable_rowcount_beforeDelete = _webDriver.FindElements(By.XPath("//table[@id='mytable']//tr")).Count;
            IWebElement vh_DeleteButton = _webDriver.FindElement(By.Id("deletebtn"));
            mApp.ClickElement(vh_DeleteButton);
            mApp.WaitForAWhile(default_wait_time);
        }
        
        [Then(@"Selected Assessment details should be deleted")]
        public void ThenSelectedAssessmentDetailsShouldBeDeleted()
        {
            IWebElement delete_dailog = _webDriver.FindElement(By.XPath("//*[@id='delete']"));
            if (delete_dailog.Displayed)
            {
                _webDriver.SwitchTo().ActiveElement();
                IWebElement delete_Yes_Button = _webDriver.FindElement(By.XPath("//*[@id='DeleteYesBtn']"));
                IWebElement delete_No_Button = _webDriver.FindElement(By.XPath("//*[@id='delete']/div/div/div[3]/button[2]"));
                mApp.ClickElement(delete_No_Button);
            }
        }
        
        [Then(@"Should not listed in the View History details\.")]
        public void ThenShouldNotListedInTheViewHistoryDetails_()
        {
            //Get table_rowcount_before Delete
            ahtable_rowcount_afterDelete = _webDriver.FindElements(By.XPath("//table[@id='mytable']//tr")).Count;
            if (ahtable_rowcount_afterDelete == ahtable_rowcount_beforeDelete)
            {
                Console.WriteLine(" Not Deleted the Assessment from History. ");
            }
            else
            {
                Assert.Fail("Deleted Assessment History");
            }
        }
    }
}

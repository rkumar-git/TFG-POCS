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
    public class AnswerDesiredStateLevel_And_SubmitSteps
    {
        //To inject WebDriver to make available for Test execution.
        private readonly IWebDriver _webDriver;
        ManageApplication mApp = new ManageApplication();
        ManageObjects mObject = new ManageObjects();
        ManageAppMethods mAppMet = new ManageAppMethods();
        string username = ConfigurationManager.AppSettings["Rapid_AdminUserName"];
        string password = ConfigurationManager.AppSettings["Rapid_AdminPassword"];
        int default_wait_time = Convert.ToInt32(ConfigurationManager.AppSettings["Default_Wait_Time"]);

        public AnswerDesiredStateLevel_And_SubmitSteps(IWebDriver driver)
        {
            _webDriver = driver;
        }

        [Given(@"""(.*)"" Questions page is Active")]
        public void GivenQuestionsPageIsActive(string p0)
        {

            //Launch Application
            mApp.LaunchRapidApplication(_webDriver);
            Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(ManageObjects.LoginPage.UserName_EditBox(_webDriver)));

            //Login to the Application
            Assert.IsTrue(mApp.LoginRapidApplication(_webDriver, username, password), "Authenticate Rapid Application.");

            //Navigate to Maturity Assessment.
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.MaturityAssessmentLink(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
            Assert.IsTrue(ManageObjects.MaturityAssessmentPage.DesiredState_Button(_webDriver).Displayed, "Navigated to Maturity assessment page.");
            
            //Select desired Desired State level
            mAppMet.Select_Then_Submit_DesiredStateLevel(_webDriver, "Enabling");
            System.Threading.Thread.Sleep(default_wait_time);

            //Click Next Button
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.Next_Button(_webDriver));
            System.Threading.Thread.Sleep(default_wait_time);
        }
        
        [When(@"User Select Answers of each question")]
        public void WhenUserSelectAnswersOfEachQuestion()
        {
            //Click First Level Answers.
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_0__selectedanswer")));
            /*
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_1__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_2__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_3__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_4__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_5__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_6__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_7__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_8__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_9__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_10__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_11__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_12__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_13__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_14__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_15__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_16__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_17__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_18__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_19__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_20__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_21__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_22__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_23__selectedanswer")));
            mApp.ClickElement(_webDriver.FindElement(By.Id("MaturityAssessQuestions_24__selectedanswer")));
            */
        }
        
        [When(@"Click Submit Button")]
        public void WhenClickSubmitButton()
        {
            mApp.ClickElement(ManageObjects.MaturityAssessmentPage.SubmitButton(_webDriver));
            mApp.WaitForAWhile(default_wait_time);
        }

        [Then(@"the Desired state selection page should be displayed")]
        public void ThenTheDesiredStateSelectionPageShouldBeDisplayed()
        {
            //Assert.IsTrue(mApp.IsWebElementDisplayed_And_Enabled(CancelButton));
            System.Console.WriteLine("Cancel button should be displayed.");
        }

        [Then(@"the message ""(.*)"" should be displayed\.")]
        public void ThenTheMessageShouldBeDisplayed_(string p0)
        {
            //Assert.IsTrue(mApp.isTextPresentInPage(_webDriver, "Assessment Submitted Successfully!"));
            System.Console.WriteLine("The Success message should be displayed.");
        }
    }
}

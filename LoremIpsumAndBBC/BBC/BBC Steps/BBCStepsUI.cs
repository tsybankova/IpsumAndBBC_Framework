using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Assert = NUnit.Framework.Assert;
using static LoremIpsumAndBBC.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoremIpsumAndBBC
{
    [Binding]
    public class BBCStepsUI
    {
        ContactBBCLogic contactBBCLogic = new ContactBBCLogic();
        private static IWebDriver driver = WebDriverSingleton.getInstance();

        [Given(@"I am on Contact BBC page")]
        public void GoToContactBBCPage()
        {
            contactBBCLogic.GoTOSendCommentsToBBCPage();
        }

        [When(@"I select Comment on BBC Website Category")]
        public void SelectCommentOnBBCWebsiteCategory()
        {
            contactBBCLogic.SelectCommentOnBBCWebsiteFeedbackType();
        }

        [When(@"I Populate Comment with (Too Long|Properly Sized) Feedback \$")]
        public void PopulateFeedbackFields(string textSize, Table table)
        {
            string url = GetValuesFromTableRow(table, "Url");
            string subject = GetValuesFromTableRow(table, "Subject");
            bool confirmation = Convert.ToBoolean(GetValuesFromTableRow(table, "Is Confirmation Letter Needed"));
            string feedback;
            if (textSize == "Too Long")           
                feedback = ScenarioContext.Current["Too Long Text"].ToString();            
            else           
                feedback = ScenarioContext.Current["Properly Sized Text"].ToString();
            
            contactBBCLogic.PopulateSubmitCommentPage(url, subject, feedback, confirmation);
        }

        [Then(@"Generated and Submitted Text Lengths are equal: (true|false) \$")]
        public void CompareTextLeghth(string condition)
        {
            int generatedTextLength = ScenarioContext.Current[ScenarioContext.Current["Text Size"].ToString()].ToString().Length;
            int submittedTextLength = contactBBCLogic.GetFeedbackTextLength();
            
            if (condition == "true")            
                Assert.IsTrue(generatedTextLength.Equals(submittedTextLength));            
            else           
                Assert.IsFalse(generatedTextLength.Equals(submittedTextLength));            
        }

        [Then(@"I Take a Screenshot")]
        public void TakeScreenshot()
        {
            contactBBCLogic.TakeScreenShot();
        }

        [When(@"I Submit Comment with Some Empty Fields")]
        public void SubmitCommentWithTooLongFeedback(Table table)
        {
            string url = GetValuesFromTableRow(table, "Url");
            string subject = GetValuesFromTableRow(table, "Subject");
            bool confirmation = Convert.ToBoolean(GetValuesFromTableRow(table, "Is Confirmation Letter Needed"));
            string feedback = ScenarioContext.Current["Properly Sized Text"].ToString();

            contactBBCLogic.SubmitComment(url, subject, feedback, confirmation);
        }

        [Then(@"Error Banner is Displayed")]
        public void IsErrorBannerDisplayed()
        {
            Assert.IsTrue(contactBBCLogic.IsGeneralErrorBannerDisplayed(), "Error banner is not displayed, congrats!");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}

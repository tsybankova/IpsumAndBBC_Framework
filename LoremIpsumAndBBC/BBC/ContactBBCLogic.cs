using LoremIpsumAndBBC.BBC;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsumAndBBC
{
    public class ContactBBCLogic
    {
        private IWebDriver driver = WebDriverSingleton.getInstance();
        private const string contactBBCPageUrl = "https://www.bbc.co.uk/contact/comments";
        ContactBBCPage contactBBCPage = new ContactBBCPage();

        public void GoTOSendCommentsToBBCPage()
        {
            driver.Navigate().GoToUrl(contactBBCPageUrl);
        }
        public void SelectCommentOnBBCWebsiteFeedbackType()
        {
            contactBBCPage.ClickSubmitCommentBtn();
            contactBBCPage.ChooseSendCommentType();
            contactBBCPage.ChooseWebsiteOrAppFeedbackCategory();
            contactBBCPage.ClickContinueBtn();
        }

        public void PopulateSubmitCommentPage(string url, string subject, string feedback, bool needsConfirmationLetter)
        {
            contactBBCPage.SendUrlToFeedbackForm(url);
            contactBBCPage.SendSubjectToFeedbackForm(subject);
            contactBBCPage.SendFeedback(feedback);
            contactBBCPage.ChooseWhetherReceiveConfirmationEmail(needsConfirmationLetter);
        }

        public int GetFeedbackTextLength() =>
            contactBBCPage.GetFeedbackTextLength();

        public void SubmitComment(string url, string subject, string feedback, bool needsConfirmationLetter)
        {
            contactBBCPage.SendUrlToFeedbackForm(url);
            contactBBCPage.SendSubjectToFeedbackForm(subject);
            contactBBCPage.SendFeedback(feedback);
            contactBBCPage.ChooseWhetherReceiveConfirmationEmail(needsConfirmationLetter);
            contactBBCPage.ClickContinueBtn(); 
        }

        public bool IsGeneralErrorBannerDisplayed() =>
            contactBBCPage.IsGeneralErrorBannerDisplayed();

        public void TakeScreenShot()
        {
            contactBBCPage.TakeScreenShot();
        }
    }
}

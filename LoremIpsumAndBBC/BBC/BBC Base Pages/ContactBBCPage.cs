using LoremIpsumAndBBC.BBC_Base_Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LoremIpsumAndBBC.Utils;

namespace LoremIpsumAndBBC.BBC
{
    public class ContactBBCPage
    {
        public ContactBBCPage()
        {
            PageFactory.InitElements(driver, this);
        }

        private static IWebDriver driver = WebDriverSingleton.getInstance();

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Submit a comment')]")]
        private IWebElement SubmitComentBtn;

        //I want to... section
        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Send positive feedback')]")]
        private readonly IWebElement SendPositiveFeedbackBtn;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Send a comment or observation')]")]
        private IWebElement SendComentOrObservationBtn;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Report a fault')]")]
        private IWebElement ReportAFaultBtn;
        //end of section

        //I want to provide feedback on... section
        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'A TV')]")]
        private IWebElement TVProgrammeFeedbackBtn;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'A radio')]")]
        private IWebElement RadioProgrammeFeedbackBtn;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'A BBC website or a BBC app')]")]
        private IWebElement BBCWebsiteOrAppFeedbackBtn;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Something else')]")]
        private IWebElement SomethingElseFeedbackBtn;
        //end of section

        [FindsBy(How = How.XPath, Using = "//*[@id = 'bbccookies-continue-button']")]
        private IWebElement AgreeToCookiesBtn;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Continue')]")]
        private IWebElement ContinueBtn;

        [FindsBy(How = How.XPath, Using = "//*[contains(label, 'URL of the page or App')]/input")]
        private IWebElement UrlInputField;

        [FindsBy(How = How.XPath, Using = "//*[contains(label, 'Feedback subject')]/input")]
        private IWebElement FeedbackSubjectInputField;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'form-group group')]//textarea")]
        private IWebElement FeedbackInputField;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'true')]/..")]
        private IWebElement ReceiveConfirmationLetterOnFeedback;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'false')]/..")]
        private IWebElement DoNotReceiveConfirmationLetterOnFeedback;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'general error')]/h4")]
        private IWebElement GeneralErrorBanner;

        public void ClickSubmitCommentBtn()
        {
            SubmitComentBtn.Click();
            if (AgreeToCookiesBtn.Displayed)
                AgreeToCookiesBtn.Click();
        } 

        public void ChooseSendCommentType()
        {
            ElementClickable(2000, SendComentOrObservationBtn);
            SendComentOrObservationBtn.Click();
        }

        public void ChooseWebsiteOrAppFeedbackCategory()
        {
            BBCWebsiteOrAppFeedbackBtn.Click();
        }
        
        public void SendUrlToFeedbackForm(string url)
        {
            UrlInputField.SendKeys(url);
        }

        public void SendSubjectToFeedbackForm(string subject)
        {
            FeedbackSubjectInputField.SendKeys(subject);
        }

        public void SendFeedback(string feedback)
        {
            FeedbackInputField.SendKeys(feedback);
        }

        public int GetFeedbackTextLength() =>
            FeedbackInputField.Text.Length;

        public void ChooseWhetherReceiveConfirmationEmail(bool condition)
        {
            var button = condition ? ReceiveConfirmationLetterOnFeedback : DoNotReceiveConfirmationLetterOnFeedback;
            ElementClickable(2000, button);
            button.Click();                                       
        }

        public void ClickContinueBtn()
        {
            ContinueBtn.Click();
        }

        public bool IsGeneralErrorBannerDisplayed() => 
            GeneralErrorBanner.Displayed;

        public void TakeScreenShot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(String.Format(ConfigurationManager.AppSettings["ScreenshotLocation"], 
                new Random().Next(99)), ScreenshotImageFormat.Png);
        }
    }
}

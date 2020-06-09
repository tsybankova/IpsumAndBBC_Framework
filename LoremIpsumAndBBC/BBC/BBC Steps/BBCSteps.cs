using HtmlAgilityPack;
using LoremIpsumAndBBC.BBC;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Assert = NUnit.Framework.Assert;

namespace LoremIpsumAndBBC
{
    [Binding]
    public class BBCSteps
    {
        BBCNewsPage bbcNewsPage = new BBCNewsPage(ConfigurationManager.AppSettings["BBCNewsPageUrl"]);

        [When(@"I Get the Html Document from (BBC News Page|BBC Search Page) \$")]
        public HtmlDocument GetHtmlDocument(string page)
        {
            BBCSearchPage bbcSearchPage = new BBCSearchPage(ConfigurationManager.AppSettings["BBCSearchPageUrl"], 
                bbcNewsPage.HeadlineArticleCategory);
            switch (page)
            {
                case "BBC News Page":
                    return bbcNewsPage.HtmlDocument;
                case "BBC Search Page":
                    return bbcSearchPage.HtmlDocument;
                default:
                    throw new System.NullReferenceException("The html document was not received");
            }
        }

        [Then(@"The Headline Article title is (.*)")]
        public void CheckHeadlineArticleTitle(string expectedHeadlineArticleTitle)
        {
            string actualHeadlineArticle = bbcNewsPage.HedlineArticleTitle;
            Assert.AreEqual(expectedHeadlineArticleTitle, actualHeadlineArticle);
        }

        [Then(@"Secondary Articles titles are")]
        public void TheHeadlineArticleTitleIs(Table table)
        {
            List<string> actualSecondaryArticlesTitles = bbcNewsPage.GetSecondaryArticlesTitles(5);
            List<string> expectedSecondaryArticlesTitles = table.Rows.Select(row => row["Article Title"]).ToList();
            CollectionAssert.AreEqual(expectedSecondaryArticlesTitles, actualSecondaryArticlesTitles);
        }

        [When(@"I Get the Headline Article Category")]
        public void GetTheHeadlineArticleCategory()
        {
            string headlineArticleCategory = bbcNewsPage.HeadlineArticleCategory;
        }

        [Then(@"The First Article Title in Category Search Results List is (.*)")]
        public void CheckFirstArticleTitle(string expectedFirstArticleTitle)
        {
            BBCSearchPage bbcSearchPage = new BBCSearchPage(ConfigurationManager.AppSettings["BBCSearchPageUrl"], 
                bbcNewsPage.HeadlineArticleCategory);
            string actualFirstArticleTitle = bbcSearchPage.FirstArticleTitle;
            Assert.AreEqual(expectedFirstArticleTitle, actualFirstArticleTitle);
        }
    }
}

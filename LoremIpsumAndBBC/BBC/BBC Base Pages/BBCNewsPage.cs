using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.XPath;
using HtmlAgilityPack;
using LoremIpsumAndBBC.BBC_Base_Pages;

namespace LoremIpsumAndBBC.BBC
{
    public class BBCNewsPage : BasePage
    { 
        private const string headlineArticleLocator = "//*[contains(@data-entityid, 'container-top-stories#1')]//h3";
        private const string secondaryArticlesLocator = "//*[contains(@data-entityid, 'container-top-stories#{0}')]//h3";
        private const string secondaryLiveArticleLocator = "//*[contains(@data-mode, 'secondary')]//h3";
        private const string headlineArticleCategoryLoctor = "//*[contains(@data-entityid, 'container-top-stories#1')]//li//span"; 

        public BBCNewsPage(string url) : base(url)
        {
        }

        public string HedlineArticleTitle =>
            HttpUtility.HtmlDecode(Navigator.SelectSingleNode(headlineArticleLocator).Value);

        public string HeadlineArticleCategory =>
            HttpUtility.HtmlDecode(Navigator.SelectSingleNode(headlineArticleCategoryLoctor).Value);

        public List<string> GetSecondaryArticlesTitles(int numberOfArticles)
        {
            List<string> secondaryArticlesTitles = new List<string>();

            //1st secondary article has #2 in locator
            for (int i = 2; i <= numberOfArticles + 1; i++)
            {
                string secondaryArticleLocator = String.Format(secondaryArticlesLocator, i);
                XPathNavigator node = Navigator.SelectSingleNode(secondaryArticleLocator);
                
                //in case of a special "live" article
                if (node == null)                
                    secondaryArticleLocator = secondaryLiveArticleLocator;
                
                secondaryArticlesTitles.Add(HttpUtility.HtmlDecode(Navigator.SelectSingleNode(secondaryArticleLocator).Value));
            }
            return secondaryArticlesTitles;
        }   
    }
}

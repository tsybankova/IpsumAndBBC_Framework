using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LoremIpsumAndBBC.BBC_Base_Pages;

namespace LoremIpsumAndBBC.BBC
{
    public class BBCSearchPage : BasePage
    {
        private const string firstArticleLocator = "//*[contains(@class, 'css-118lm29-PromoLink ett16tt7')]";
        
        public BBCSearchPage(string url, string category): base(url)
        {
            Url = String.Format(url, category);
        }

        public string FirstArticleTitle =>
            HttpUtility.HtmlDecode(Navigator.SelectSingleNode(firstArticleLocator).Value);
    }
}

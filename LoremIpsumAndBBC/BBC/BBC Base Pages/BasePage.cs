using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LoremIpsumAndBBC.BBC_Base_Pages
{
    public abstract class BasePage
    {
        public string Url { get; set; }
        public HtmlDocument HtmlDocument => GetHtmlDoc();
        public XPathNavigator Navigator => HtmlDocument.CreateNavigator();

        public BasePage(string url)
        {
            Url = url;
        }
        public HtmlDocument GetHtmlDoc() =>
            new HtmlWeb().Load(Url);

        //is not usedб but I wanted to keep it
        public WebRequest GetRequest(string uri, string method)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpRequest.Method = method;
            httpRequest.ContentType = "text/html";
            return httpRequest;
        }

        public string GetHtmlDocInString(WebRequest httpRequest) => 
            new StreamReader(httpRequest.GetResponse().GetResponseStream()).ReadToEnd();
    }
}

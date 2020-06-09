using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LoremIpsumAndBBC.LoremIpsum_Page
{
    public class BaseballIpsum
    {
        public string GetRequestUri(string baseUrl, int numOFParagraphs) => 
            $"{baseUrl}api/?paras={numOFParagraphs}";

        public WebRequest GetRequest(string baseUrl, int numOFParagraphs, string method, string contentType = "application/json")
        {
            string uri = GetRequestUri(baseUrl, numOFParagraphs);
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpRequest.Method = method;
            httpRequest.ContentType = contentType;
            return httpRequest;
        }

        public string GetResponse(WebRequest httpRequest)
        {
            using (var s = httpRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var jsonString = sr.ReadToEnd();
                    return jsonString;
                }
            }
        }

        public string GetText(string baseUrl, int numOFParagraphs, string method = "Get")
        {
            string text = GetResponse(GetRequest(baseUrl, numOFParagraphs, method));
            // because it is not a JSON object actually and string needs to be filtered
            text = text.Remove(text.Length - 2).Remove(0, 2).Replace("\",\"", " ").Replace("\\u0027", "'");
            return text;
        }
    }
}

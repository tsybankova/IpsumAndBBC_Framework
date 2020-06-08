using LoremIpsumAndBBC.LoremIpsum_Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Assert = NUnit.Framework.Assert;

namespace LoremIpsumAndBBC
{
    [Binding]
    public class BaseballIpsumSteps
    {
        public readonly string baseballIpsumBaseUrl = "http://baseballipsum.apphb.com/";
        BaseballIpsum baseballIpsum = new BaseballIpsum();

        [Given(@"I Generate (Too Long|Properly Sized) Text at BaseballIpsum site \$")]
        [When(@"I Generate (Too Long|Properly Sized) Text at BaseballIpsum site \$")]
        public void GenerateText(string textSize)
        {
            string text;
            if (textSize == "Too Long")
            {
                text = baseballIpsum.GetText(baseballIpsumBaseUrl, 5);
                ScenarioContext.Current.Add("Too Long Text", text);
            }
            else
            {
                text = baseballIpsum.GetText(baseballIpsumBaseUrl, 2);
                ScenarioContext.Current.Add("Properly Sized Text", text);
            }
            ScenarioContext.Current.Add("Text Size", $"{textSize} Text");
        }
    }
}

using LoremIpsumAndBBC.LoremIpsum_Page;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public readonly string baseballIpsumBaseUrl = ConfigurationManager.AppSettings["BaseballIpsumBaseUrl"];
        BaseballIpsum baseballIpsum = new BaseballIpsum();

        [Given(@"I Generate (Too Long|Properly Sized) Text at BaseballIpsum site \$")]
        [When(@"I Generate (Too Long|Properly Sized) Text at BaseballIpsum site \$")]
        public void GenerateText(string textSize)
        {
            string text = textSize == "Too Long" ? baseballIpsum.GetText(baseballIpsumBaseUrl, 5) : 
                baseballIpsum.GetText(baseballIpsumBaseUrl, 2);

            ScenarioContext.Current.Add($"{textSize} Text", text);
            ScenarioContext.Current.Add("Text Size", $"{textSize} Text");
        }
    }
}

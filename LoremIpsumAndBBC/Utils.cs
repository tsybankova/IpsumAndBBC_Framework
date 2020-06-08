using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LoremIpsumAndBBC
{
    public static class Utils
    {
        public static string GetValuesFromTableRow(Table table, string value) =>
            table.Rows.Select(r => r[value]).First();

        public static void ElementClickable(int timeout, IWebElement element)
        {
            new WebDriverWait(WebDriverSingleton.getInstance(), TimeSpan.FromSeconds(timeout))
                    .Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}

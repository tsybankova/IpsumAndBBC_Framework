using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoremIpsumAndBBC
{
    public static class WebDriverSingleton
    {
        public static IWebDriver driver;

        public static IWebDriver getInstance()
        {
            if (driver == null)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                driver = new ChromeDriver(options);
            }
            return driver;
        }
    }
}

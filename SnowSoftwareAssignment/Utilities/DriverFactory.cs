using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;

namespace SnowSoftwareAssignment.Utilities
{
    public class DriverFactory
    {
        private static IWebDriver driver=null!;

        public static IWebDriver GetDriver(BrowserType browserType)
        {
            if (driver == null)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        driver = new ChromeDriver();
                        break;
                    case BrowserType.Firefox:
                        driver = new FirefoxDriver();
                        break;
                    case BrowserType.Edge:
                        driver = new EdgeDriver();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
                }
            }
            return driver;
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null!;
            }
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge
    }
}

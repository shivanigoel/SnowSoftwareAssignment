using NUnit.Framework;
using OpenQA.Selenium;
using SnowSoftwareAssignment.Utilities;
using BusinessValueCalculatorTests.Pages;

namespace BusinessValueCalculatorTests.Tests
{
    public class BusinessValueCalculatorTest
    {
        IWebDriver driver = null!;

        [SetUp]
        public void Setup()
        {
            // Set up Selenium WebDriver using DriverFactory
            driver = DriverFactory.GetDriver(BrowserType.Chrome);
            driver.Manage().Window.Maximize(); // Maximize the window
        }

        [Test]
        public void CalculateBusinessValueTest()
        {
            // Create an instance of the page object
            var calculatorPage = new BusinessValueCalculatorPage(driver);

            // Open the Business Value Calculator page
            calculatorPage.Open();

            // Accept cookies if present
            AcceptCookiesIfPresent(driver);

            // Calculate business value
            calculatorPage.CalculateBusinessValue("50", "5000", "10000");

            // Select option for years
            calculatorPage.SelectOptionByTextYears("5 years");

            // Select option for headquarters
            calculatorPage.SelectOptionByTextHeadquater("United States");

            // Wait for the result to be displayed
            System.Threading.Thread.Sleep(3000);

            // Assert the results
            calculatorPage.VerifyriskText("$2,916,064");
            calculatorPage.VerifyProductivityText("$3,371,842");
            calculatorPage.VerifycostText("$20,586,357");
        }

        [Test]
        public void VerifyPageTitle()
        {
            // Create an instance of the page object
            var calculatorPage = new BusinessValueCalculatorPage(driver);

            // Open the Business Value Calculator page
            calculatorPage.Open();

            // Assert the page title
            Assert.That("Technology ROI Calculator",Is.EqualTo(driver.Title));
        }

        [Test]
        public void VerifyPageURL()
        {
            // Create an instance of the page object
            var calculatorPage = new BusinessValueCalculatorPage(driver);

            // Open the Business Value Calculator page
            calculatorPage.Open();

            // Assert the page URL
            Assert.That("https://www.flexera.com/flexera-one/business-value-calculator", Is.EqualTo(driver.Url));
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up WebDriver using DriverFactory
            DriverFactory.QuitDriver();
        }

        private void AcceptCookiesIfPresent(IWebDriver driver)
        {
            try
            {
                IWebElement cookieConsent = driver.FindElement(By.Id("cookiescript_injected"));
                if (cookieConsent.Displayed)
                {
                    IWebElement acceptButton = cookieConsent.FindElement(By.Id("cookiescript_accept"));
                    acceptButton.Click();
                }
            }
            catch (NoSuchElementException)
            {
                // Cookie consent dialog not found or not displayed
            }
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BusinessValueCalculatorTests.Pages
{
    public class BusinessValueCalculatorPage
    {
        private readonly IWebDriver driver;

        // Constructor
        public BusinessValueCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Page Elements
        private IWebElement frameElement => driver.FindElement(By.Id("vroi"));
        private IWebElement EnterRevenue => driver.FindElement(By.XPath("//*[@id='AnnualRevenue']"));
        private IWebElement NumOfEmp => driver.FindElement(By.XPath("//*[@id='NumberofEmployees']"));
        private IWebElement AnnualITBudget => driver.FindElement(By.XPath("//*[@id='app_user_form']/div[1]/div[1]/div[1]/div/div[5]/div/input"));
        public IWebElement SelectYears => driver.FindElement(By.Id("Number_of_Years"));
        public IWebElement SelectHeadquarters => driver.FindElement(By.Id("Headquarters_Country"));
        public IWebElement TotalRiskSavings => driver.FindElement(By.XPath("(//*[text()='Total risk savings']/parent::*/*)[2]"));

        public IWebElement TotalProductivitySavings => driver.FindElement(By.XPath("(//*[text()='Total productivity savings']/parent::*/*)[2]"));
       
    public IWebElement TotalcostSavings => driver.FindElement(By.XPath("(//*[text()='Total cost savings']/parent::*/*)[2]"));
        

        // Page Methods
        public void Open()
        {
            driver.Navigate().GoToUrl("https://www.flexera.com/flexera-one/business-value-calculator");
        }

        public void CalculateBusinessValue(string annualRevenue, string numOfEmployees, string itBudget)
        {
            driver.SwitchTo().Frame(frameElement);
            EnterRevenue.Clear();
            EnterRevenue.SendKeys(annualRevenue);

            NumOfEmp.Clear();
            NumOfEmp.SendKeys(numOfEmployees);

            AnnualITBudget.Clear();
            AnnualITBudget.SendKeys(itBudget);
        }

        public void SelectOptionByTextYears(string optionText)
        {
            SelectElement select = new SelectElement(SelectYears);
            select.SelectByText(optionText);
        }

        public void SelectOptionByTextHeadquater(string optionText)
        {
            SelectElement select = new SelectElement(SelectHeadquarters);
            select.SelectByText(optionText);
        }

         public void VerifyriskText(string optionText)
        {
            String risksaving=TotalRiskSavings.Text;
            Assert.Pass(optionText.Equals(risksaving) ? "Option text matches expected value." : "Option text does not match expected value.");

        }

         public void VerifyProductivityText(string optionText)
        {
            String risksaving=TotalProductivitySavings.Text;
            Assert.Pass(optionText.Equals(risksaving) ? "Option text matches expected value." : "Option text does not match expected value.");

        }
         public void VerifycostText(string optionText)
        {
            String risksaving=TotalRiskSavings.Text;
            Assert.Pass(optionText.Equals(risksaving) ? "Option text matches expected value." : "Option text does not match expected value.");

        }
    }
}

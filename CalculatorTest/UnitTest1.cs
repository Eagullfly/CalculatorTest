namespace CalculatorTest
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using Xunit;
    
    public class UnitTest1 : IDisposable
    {
        private readonly ChromeDriver _driver;

        public UnitTest1()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.calculator.net/");
        }

        [Fact]
        public void PressFiveButton()
        {
            //_driver.Navigate().GoToUrl("https://www.calculator.net/");
            var fiveButton = _driver.FindElement(By.XPath("//span[text()='5']"));
            Thread.Sleep(1000);
            fiveButton.Click();
            Thread.Sleep(1000);

            var inputField = _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[1]/td/div/div[2]"));
            var inputValue = inputField.Text;

            Assert.Equal(" 5", inputValue);
        }

        [Fact]
        public void AddNumbersTest()
        {
            //_driver.Navigate().GoToUrl("https://www.calculator.net/");

            // Click on the calculator buttons for the addition operation
            _driver.FindElement(By.XPath("//span[text()='1']")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//span[text()='+']")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//span[text()='2']")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//span[text()='=']")).Click();
            Thread.Sleep(1000);

            // Get the result
            var result = _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[1]/td/div/div[2]")).Text;

            // Assert the result
            Assert.Contains(" 3", result);
        }

        [Fact]
        public void SubNumbersTest()
        {

            // Click on the calculator buttons for the subtraction operation
            _driver.FindElement(By.XPath("//span[text()='4']")).Click();
            _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[2]/td[2]/div/div[2]/span[4]")).Click();
            _driver.FindElement(By.XPath("//span[text()='2']")).Click();
            _driver.FindElement(By.XPath("//span[text()='=']")).Click();

            // Get the result
            var subResult = _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[1]/td/div/div[2]")).Text;

            // Assert the result
            Assert.Contains(" 2", subResult);
        }

        [Fact]
        public void NumberTests()
        {
            // Click on the calculator buttons for the addition operation
            _driver.FindElement(By.XPath("//span[text()='1']")).Click();
            _driver.FindElement(By.XPath("//span[text()='+']")).Click();
            _driver.FindElement(By.XPath("//span[text()='2']")).Click();
            _driver.FindElement(By.XPath("//span[text()='=']")).Click();

            // Get the result
            var addResult = _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[1]/td/div/div[2]")).Text;

            // Check the result
            Assert.Contains(" 3", addResult);

            // Click on the calculator buttons for the subtraction operation
            _driver.FindElement(By.XPath("//span[text()='4']")).Click();
            _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[2]/td[2]/div/div[2]/span[4]")).Click();
            _driver.FindElement(By.XPath("//span[text()='2']")).Click();
            _driver.FindElement(By.XPath("//span[text()='=']")).Click();

            // Get the result
            var subResult = _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[1]/td/div/div[2]")).Text;

            // Assert the result
            Assert.Contains(" 2", subResult);

            // Click on the calculator buttons for the multiplacation operation
            _driver.FindElement(By.XPath("//span[text()='4']")).Click();
            _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[2]/td[2]/div/div[3]/span[4]")).Click();
            _driver.FindElement(By.XPath("//span[text()='2']")).Click();
            _driver.FindElement(By.XPath("//span[text()='=']")).Click();

            // Get the result
            var multResult = _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[1]/td/div/div[2]")).Text;

            // Assert the result
            Assert.Contains(" 8", multResult);

            // Click on the calculator buttons for the division operation
            _driver.FindElement(By.XPath("//span[text()='8']")).Click();
            _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[2]/td[2]/div/div[4]/span[4]")).Click();
            _driver.FindElement(By.XPath("//span[text()='2']")).Click();
            _driver.FindElement(By.XPath("//span[text()='=']")).Click();

            // Get the result
            var divResult = _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[1]/td/div/div[2]")).Text;

            // Assert the result
            Assert.Contains(" 4", divResult);
        }

        [Fact]
        public void MortgageCalcTest()
        {
            _driver.Navigate().GoToUrl("https://www.calculator.net/mortgage-calculator.html");
            Thread.Sleep(1000);

            // Input 25 in DownPayment box
            var downPayment = _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[4]/div/form/table/tbody/tr[2]/td[2]/input"));
            downPayment.Clear();
            Thread.Sleep(1000);
            downPayment.SendKeys("25");
            Thread.Sleep(1000);

            // Change % to $ in dropdown box
            var dropdown = new SelectElement(_driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[4]/div/form/table/tbody/tr[2]/td[3]/select")));
            dropdown.SelectByText("$");
            Thread.Sleep(1000);

            // Check down payment amount
            var downPaymentValue = downPayment.GetAttribute("value");
            Assert.Contains("100,000", downPaymentValue);
            Thread.Sleep(1000);

            // Change down payment amount
            downPayment.Clear();
            Thread.Sleep(1000);
            downPayment.SendKeys("200000");
            Thread.Sleep(1000);

            // Input property taxes percentage
            var propertyTaxes = _driver.FindElement(By.XPath("//*[@id=\"cpropertytaxes\"]"));
            propertyTaxes.Clear();
            Thread.Sleep(1000);
            propertyTaxes.SendKeys("2");
            Thread.Sleep(1000);

            // Click '+ More Options' button
            _driver.FindElement(By.XPath("//a[contains(text(), '+ More Options')]")).Click();
            Thread.Sleep(1000);

            // Change property taxes increase to 1
            var propertytaxesIncreases = _driver.FindElement(By.XPath("//*[@id=\"cmoreoptioninputs\"]/tbody/tr[2]/td[2]/input"));
            propertytaxesIncreases.Clear();
            Thread.Sleep(1000);
            propertytaxesIncreases.SendKeys("1");
            Thread.Sleep(1000);

            // Change extra monthly pay to $25
            var extraMonthlyPay = _driver.FindElement(By.XPath("//*[@id=\"cexma\"]"));
            extraMonthlyPay.Clear();
            Thread.Sleep(1000);
            extraMonthlyPay.SendKeys("25");
            Thread.Sleep(1000);

            // Press calculate button 
            _driver.FindElement(By.XPath("//input[@value='Calculate']")).Click();
            Thread.Sleep(1000);

            //Assert the results
            var monthlyPay = _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[4]/table/tbody/tr/td/h2")).Text;
            Assert.Contains("Monthly Pay:   $1,302.92", monthlyPay);
        }

        [Fact]
        public void BMICalcTest()
        {
            _driver.Navigate().GoToUrl("https://www.calculator.net/bmi-calculator.html");
            Thread.Sleep(1000);

            // Click female button
            _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[4]/div[2]/table/tbody/tr/td/form/table[1]/tbody/tr[2]/td[2]/label[2]/span")).Click();
            Thread.Sleep(1000);

            var age = _driver.FindElement(By.XPath("//*[@id=\"cage\"]"));
            age.Clear();
            Thread.Sleep(1000);
            age.SendKeys("31");
            Thread.Sleep(1000);

            var feet = _driver.FindElement(By.XPath("//*[@id=\"cheightfeet\"]"));
            feet.Clear();
            Thread.Sleep(1000);
            feet.SendKeys("5");
            Thread.Sleep(1000);

            var inches = _driver.FindElement(By.XPath("//*[@id=\"cheightinch\"]"));
            inches.Clear();
            Thread.Sleep(1000);
            inches.SendKeys("11");
            Thread.Sleep(1000);

            var weight = _driver.FindElement(By.XPath("//*[@id=\"cpound\"]"));
            weight.Clear();
            Thread.Sleep(1000);
            weight.SendKeys("178");
            Thread.Sleep(1000);

            _driver.FindElement(By.XPath("//input[@value='Calculate']")).Click();
            Thread.Sleep(1000);

            var results = _driver.FindElement(By.ClassName("bigtext")).Text;
            Assert.Contains("24.8", results);
        }

        [Fact]
        public void LoanCalcTest()
        {
            _driver.Navigate().GoToUrl("https://www.calculator.net/loan-calculator.html");
            Thread.Sleep(1000);

            var amortizedLoanAmount = _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[3]/table/tbody/tr[1]/td[2]/input"));
            amortizedLoanAmount.Clear();
            Thread.Sleep(1000);
            amortizedLoanAmount.SendKeys("200000");
            Thread.Sleep(1000);

            var amortizedLoanTermYears = _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[3]/table/tbody/tr[2]/td[2]/input[1]"));
            amortizedLoanTermYears.Clear();
            Thread.Sleep(1000);
            amortizedLoanTermYears.SendKeys("12");
            Thread.Sleep(1000);

            var amortizedLoanTermMonths = _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[3]/table/tbody/tr[2]/td[2]/input[2]"));
            amortizedLoanTermMonths.Clear();
            Thread.Sleep(1000);
            amortizedLoanTermMonths.SendKeys("6");
            Thread.Sleep(1000);

            var amortizedInterestRate = _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[3]/table/tbody/tr[3]/td[2]/input"));
            amortizedInterestRate.Clear();
            Thread.Sleep(1000);
            amortizedInterestRate.SendKeys("8");
            Thread.Sleep(1000);

            var amortizedCompound = new SelectElement(_driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[3]/table/tbody/tr[4]/td[2]/select")));
            amortizedCompound.SelectByText("Annually (APY)");
            Thread.Sleep(1000);

            var amortizedPayBack = new SelectElement(_driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[3]/table/tbody/tr[5]/td[2]/select")));
            amortizedPayBack.SelectByText("Every Quarter");
            Thread.Sleep(1000);

            _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[3]/table/tbody/tr[6]/td/input[1]")).Click();
            Thread.Sleep(1000);

            var amortizedQuarterlyPayment = _driver.FindElement(By.XPath("//*[@id=\"content\"]/div[3]/table/tbody/tr[1]/td[2]/b")).Text;
            Assert.Contains("$6,288.16", amortizedQuarterlyPayment);

            var amortizedTotalPayments = _driver.FindElement(By.XPath("//*[@id=\"content\"]/div[3]/table/tbody/tr[2]/td[2]/b")).Text;
            Assert.Contains("$314,407.94", amortizedTotalPayments);

            var amortizedTotalInterest = _driver.FindElement(By.XPath("//*[@id=\"content\"]/div[3]/table/tbody/tr[3]/td[2]/b")).Text;
            Assert.Contains("$114,407.94", amortizedTotalInterest);

            var deferredLoanAmount = _driver.FindElement(By.XPath("//*[@id=\"c2loanamount\"]"));
            deferredLoanAmount.Clear();
            Thread.Sleep(1000);
            deferredLoanAmount.SendKeys("180000");
            Thread.Sleep(1000);

            var deferredLoanTermYears = _driver.FindElement(By.Name("c2loanterm"));
            deferredLoanTermYears.Clear();
            Thread.Sleep(1000);
            deferredLoanTermYears.SendKeys("8");
            Thread.Sleep(1000);

            var deferredLoanTermMonths = _driver.FindElement(By.Name("c2loantermmonth"));
            deferredLoanTermMonths.Clear();
            Thread.Sleep(1000);
            deferredLoanTermMonths.SendKeys("6");
            Thread.Sleep(1000);

            var deferredInterestRate = _driver.FindElement(By.Name("c2interestrate"));
            deferredInterestRate.Clear();
            Thread.Sleep(1000);
            deferredInterestRate.SendKeys("5");
            Thread.Sleep(1000);

            var deferredCompound = new SelectElement(_driver.FindElement(By.Name("c2compound")));
            deferredCompound.SelectByText("Semi-annually");
            Thread.Sleep(1000);

            _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[7]/table/tbody/tr[5]/td/input[1]")).Click();
            Thread.Sleep(1000);

            var deferredAmountDue = _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[7]/table/tbody/tr[1]/td[2]/b")).Text;
            Assert.Contains("$273,891.29", deferredAmountDue);

            var deferredTotalInterest = _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[7]/table/tbody/tr[2]/td[2]/b")).Text;
            Assert.Contains("$93,891.29", deferredTotalInterest);

            var bondPredeterminedDueAmount = _driver.FindElement(By.XPath("//*[@id=\"c3loanamount\"]"));
            bondPredeterminedDueAmount.Clear();
            Thread.Sleep(1000);
            bondPredeterminedDueAmount.SendKeys("250000");
            Thread.Sleep(1000);

            var bondLoanTermYears = _driver.FindElement(By.XPath("//*[@name=\"c3loanterm\"]"));
            bondLoanTermYears.Clear();
            Thread.Sleep(1000);
            bondLoanTermYears.SendKeys("5");
            Thread.Sleep(1000);

            var bondLoanTermMonths = _driver.FindElement(By.XPath("//*[@id=\"c3loantermmonth\"]"));
            bondLoanTermMonths.Clear();
            Thread.Sleep(1000);
            bondLoanTermMonths.SendKeys("4");
            Thread.Sleep(1000);

            var bondInterestRate = _driver.FindElement(By.XPath("//*[@name=\"c3interestrate\"]"));
            bondInterestRate.Clear();
            Thread.Sleep(1000);
            bondInterestRate.SendKeys("6");
            Thread.Sleep(1000);

            var bondCompound = new SelectElement(_driver.FindElement(By.XPath("//*[@id=\"c3compound\"]")));
            bondCompound.SelectByText("Monthly (APR)");
            Thread.Sleep(1000);

            _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[11]/table/tbody/tr[5]/td/input[1]")).Click();
            Thread.Sleep(1000);

            var bondAmountDue = _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[11]/table/tbody/tr[1]/td[2]/b")).Text;
            Assert.Contains("$181,682.06", bondAmountDue);

            var bondTotalInterest = _driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div[11]/table/tbody/tr[2]/td[2]/b")).Text;
            Assert.Contains("$68,317.94", bondTotalInterest);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
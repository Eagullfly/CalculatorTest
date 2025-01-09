namespace CalculatorTest
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
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
            fiveButton.Click();

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
            _driver.FindElement(By.XPath("//span[text()='+']")).Click();
            _driver.FindElement(By.XPath("//span[text()='2']")).Click();
            _driver.FindElement(By.XPath("//span[text()='=']")).Click();

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

            // Assert the result
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

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
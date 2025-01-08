namespace CalculatorTest
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Xunit;
    public class UnitTest1
    {
        private readonly ChromeDriver _driver;

        public UnitTest1()
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void PressFiveButton()
        {
            _driver.Navigate().GoToUrl("https://www.calculator.net/");
            var fiveButton = _driver.FindElement(By.XPath("//span[text()='5']"));
            fiveButton.Click();

            var inputField = _driver.FindElement(By.XPath("/html/body/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr[1]/td/div/div[2]"));
            var inputValue = inputField.Text;

            Assert.Equal(" 5", inputValue);
        }

        [Fact]
        public void AddNumbersTest()
        {
            _driver.Navigate().GoToUrl("https://www.calculator.net/");

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
    }
}
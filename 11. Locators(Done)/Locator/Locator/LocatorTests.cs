using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locator
{
    [TestClass]
    public class LocatorTests
    {
        IWebDriver driver;
        
        [TestMethod]
        public void TestMethodSearchFieldXPath()
        {
            SetUpWebDriverChrome();

            driver.Navigate().GoToUrl("https://www.bbc.com/sport");
            IWebElement searchButton = driver.FindElement(By.XPath("//div[@role='search']"));

            Assert.IsTrue(searchButton.Displayed);
        }

        [TestMethod]
        public void TestMethodSearchFieldCssSelector()
        {
            SetUpWebDriverChrome();

            driver.Navigate().GoToUrl("https://www.bbc.com/sport");
            IWebElement searchButton = driver.FindElement(By.CssSelector("div[role='search']"));

            Assert.IsTrue(searchButton.Displayed);
        }

        [TestMethod]
        public void TestMethodBbcIconXPath()
        {
            SetUpWebDriverChrome();

            driver.Navigate().GoToUrl("https://www.bbc.com/sport");
        }

        [TestMethod]
        public void TestMethodBbcIconCssSelector()
        {
            SetUpWebDriverChrome();

            driver.Navigate().GoToUrl("https://www.bbc.com/sport");
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        public void SetUpWebDriverChrome()
        {
            driver = new ChromeDriver();
        }
    }
}
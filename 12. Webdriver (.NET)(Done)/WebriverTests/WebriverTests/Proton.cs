using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverTests;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebdriverTests
{
    internal class Proton
    {
        private WebDriverWait wait;
        private readonly IWebDriver browser;
        private readonly string url = "https://account.proton.me/ru/mail";
        internal string login = "ivan.navi222test@proton.me";
        internal string password = "H,#:T:F5@j-qeNQ";

        public Proton(IWebDriver browser)
        {
            this.browser = browser;
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(5.0));
        }
        public ProtonElementMap Map
        {
            get
            {
                return new ProtonElementMap(browser);
            }
        }


        public void Navigate()
        {
            browser.Navigate().GoToUrl(url);
        }
        public void LogIn(string login, string password)
        {
            isAlertPresent(browser);
            Map.LoginField.SendKeys(login);
            Map.PasswordField.SendKeys(password);
            Map.SubmitButton.Click();
        }
        public void OpenLatestLetter()
        {
            Map.LatestLetter.Click();
        }
        public void SendReply(string reply)
        {
            var openReplyWin = new Actions(browser).SendKeys("r");
            var sendAlias = new Actions(browser).SendKeys(reply);
            var sendReply = new Actions(browser).KeyDown(Keys.Control).SendKeys(Keys.Enter);

            openReplyWin.Perform();
            Thread.Sleep(100);                  // SendKeys missing a letter workaround
            sendAlias.Perform();
            sendReply.Perform();
        }

        private void isAlertPresent(IWebDriver driver)
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException ex)
            {
                return;
            }
        }
    }
}

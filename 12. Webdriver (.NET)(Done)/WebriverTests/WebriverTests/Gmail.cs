using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V120.DOM;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebdriverTests;

namespace WebdriverTests
{
    internal class Gmail
    {
        private WebDriverWait wait;
        private readonly IWebDriver browser;
        private readonly string url = "https://accounts.google.com/v3/signin/identifier?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ifkv=ASKXGp2LmcgNxQG73DvrrLxxn-gnPesAAgiXfXsWLH6sBqH1ew9CdVPO4_5tK6J-8_NaIzHHSKHr&rip=1&sacu=1&service=mail&flowName=GlifWebSignIn&flowEntry=ServiceLogin&dsh=S503820059%3A1703767017023636&theme=glif";
        internal string login = "atickinnick.test@gmail.com";
        internal string password = "Atickin111";

        public Gmail(IWebDriver browser)
        {
            this.browser = browser;
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(5.0));
        }
        public GmailElementMap Map
        {
            get
            {
                return new GmailElementMap(browser);
            }
        }


        public void Navigate()
        {
            browser.Navigate().GoToUrl(url);
        }
        public void SubmitLogin(string login)
        {
            Map.LoginField.SendKeys($"{login}");
            Map.LoginSubmitButton.Click();
        }
        public void SubmitPassword(string password)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='password']")));
            Map.PasswordField.SendKeys($"{password}");
            Map.PasswordSubmitButton.Click();
        }
        public void LogIn(string login, string password)
        {
            Map.LoginField.SendKeys($"{login}");
            Map.LoginSubmitButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='password']")));
            Map.PasswordField.SendKeys($"{password}");
            Map.PasswordSubmitButton.Click();
        }
        public void SendLetter(string recipient, string content)
        {      
            Map.WriteLetterButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='aGb'] input")));
            Map.RecipientField.SendKeys(recipient);
            Map.SubjectField.SendKeys("Test");
            Map.LetterTextbox.SendKeys(content);
            Map.SendLetterButton.Click();
        }
        public void ChangeAlias(string newAlias)
        {
            browser.Navigate().GoToUrl("https://myaccount.google.com/profile/nickname/edit?add=true&continue=https%3A%2F%2Fmyaccount.google.com%2Fpersonal-info%3Fpli%3D1");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)browser;
            jse.ExecuteScript("arguments[0].value=arguments[1];", 
                Map.NewAliasTextbox, newAlias);
            jse.ExecuteScript("arguments[0].removeAttribute('disabled')",
                Map.SaveNewAlliasButton);
            Map.SaveNewAlliasButton.Click();
        }
        public void OpenLatestLetter()
        {
            Map.LatestLetter.Click();
        }
    }
}

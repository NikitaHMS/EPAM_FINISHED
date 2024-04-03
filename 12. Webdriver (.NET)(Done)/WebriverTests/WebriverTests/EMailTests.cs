using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebdriverTests;
using NuGet.Frameworks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V118.Debugger;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.DevTools.V85.IndexedDB;

[assembly: Parallelize(Workers = 3, Scope = ExecutionScope.ClassLevel)]

/// <remarks>
/// ProtonLogInTests may require completing 1 captcha
/// </remarks>

namespace WebdriverTests
{
    [TestClass]
    public class ProtonLogInTests
    {
        static private IWebDriver browser;
        static private WebDriverWait wait;

        [ClassInitialize]
        public static void OneTimeSetUp(TestContext context)
        {
            browser = new ChromeDriver();
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60.0));
            browser.Manage().Window.Maximize();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        [ClassCleanup]
        public static void CleanUp()
        {
            browser.Quit();
        }


        [TestMethod]
        public void Input_ValidData_LoginSuccessful()
        {
            Proton proton = new(browser);
            string expected = proton.login;
            proton.Navigate();

            proton.LogIn(proton.login, proton.password);
            IWebElement logInConfirm = browser.FindElement(By.XPath("//span[contains(@class, 'user-dropdown-email')]"));

            Assert.AreEqual(expected, logInConfirm.Text);
        }

        [TestMethod]
        public void Input_InvalidLogin_GetError()                                   
        {
            Proton proton = new(browser);
            string expected = "Неверные учетные данные для входа. Попробуйте снова.";
            proton.Navigate();

            proton.LogIn("InvalidLogin", proton.password);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='notification__content']")));
            IWebElement loginError = browser.FindElement(By.XPath("//span[@class='notification__content']"));

            Assert.AreEqual(expected, loginError.Text);
        }

        [TestMethod]
        public void Input_InvalidPassword_GetError()
        {
            Proton proton = new(browser);
            string expected = "Пароль неверен. Пожалуйста, попробуйте другой пароль.";
            proton.Navigate();

            proton.LogIn(proton.login, "InvalidPassword123");
            IWebElement passwordError = browser.FindElement(By.XPath("//span[@class='notification__content']"));

            Assert.AreEqual(expected, passwordError.Text);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        public void Input_BlankOrEmptyLogin_GetError(string login)
        {
            Proton proton = new(browser);
            string expected = "Это обязательное поле";
            proton.Navigate();

            proton.LogIn(login, "1");
            IWebElement loginError = browser.FindElement(By.XPath("//div[@id='id-4']/span"));

            Assert.AreEqual(expected, loginError.Text);
        }

        [TestMethod]
        [DataRow("`")]
        public void Input_InappropriateLogin_GetError(string login)
        {
            Proton proton = new(browser);
            string expected = "Недопустимое имя пользователя";
            proton.Navigate();

            proton.LogIn(login, "1");
            IWebElement loginError = browser.FindElement(By.XPath("//span[@class='notification__content']"));

            Assert.AreEqual(expected, loginError.Text);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        public void Input_BlankOrEmptyPassword_GetError(string password)
        {
            Proton proton = new(browser);
            string expected = "Это обязательное поле";
            proton.Navigate();

            proton.LogIn("a", password);
            IWebElement passwordError = browser.FindElement(By.XPath("//div[@id='id-5']/span"));

            Assert.AreEqual(expected, passwordError.Text);
        }
    }

    [TestClass]
    public class GmailLogInTests
    {
        static private IWebDriver browser;
        static private WebDriverWait wait;

        [ClassInitialize]
        public static void OneTimeSetUp(TestContext context)
        {
            browser = new ChromeDriver();
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60.0));
            browser.Manage().Window.Maximize();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            browser.Quit();
        }


        [TestMethod]
        public void Input_ValidData_LoginSuccessful()
        {
            Gmail gmail = new(browser);
            Actions hover = new(browser);
            string expected = gmail.login;
            gmail.Navigate();

            gmail.SubmitLogin(gmail.login);
            gmail.SubmitPassword(gmail.password);
            IWebElement account = browser.FindElement(By.XPath("//a[@class='gb_d gb_Ea gb_I']"));
            hover.MoveToElement(account).Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='gb_Dc']/div[3]")));
            string loginSuccess = browser.FindElement(By.XPath("//div[@class='gb_Dc']/div[3]")).GetAttribute("innerText");

            Assert.AreEqual(expected, loginSuccess);
        }

        [TestMethod]
        public void Input_InvalidLoginMail_GetError()
        {
            Gmail gmail = new(browser);
            string expected = "Не удалось найти аккаунт Google.";
            gmail.Navigate();

            gmail.SubmitLogin("InvalidLogin1");
            string loginError = browser.FindElement(By.XPath("//div[@class='o6cuMc Jj6Lae']")).Text;

            Assert.AreEqual(expected, loginError);

        }

        [TestMethod]
        public void Input_InvalidPassword_GetError()
        {
            Gmail gmail = new(browser);
            string expected = "Неверный пароль. Повторите попытку или нажмите на ссылку \"Забыли пароль?\", чтобы сбросить его.";
            gmail.Navigate();

            gmail.SubmitLogin(gmail.login);
            gmail.SubmitPassword("1");
            IWebElement loginError = browser.FindElement(By.CssSelector("div[jsname='B34EJ'] > span[jsslot]"));

            Assert.AreEqual(expected, loginError.Text);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        public void Input_BlankOrEmptyLogin_GetError(string login)
        {
            Gmail gmail = new(browser);
            string expected = "Введите адрес электронной почты или номер телефона.";
            gmail.Navigate();

            gmail.SubmitLogin(login);
            string loginError = browser.FindElement(By.XPath("//div[@class='o6cuMc Jj6Lae']")).Text;

            Assert.AreEqual(expected, loginError);
        }

        [TestMethod]
        [DataRow("`")]
        public void Input_InappropriateLogin_GetError(string login)
        {
            Gmail gmail = new(browser);
            string expected = "Не удалось найти аккаунт Google.";
            gmail.Navigate();

            gmail.SubmitLogin(login);
            string loginError = browser.FindElement(By.XPath("//div[@class='o6cuMc Jj6Lae']")).Text;

            Assert.AreEqual(expected, loginError);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        public void Input_BlankOrEmptyPassword_GetError(string password)
        {
            Gmail gmail = new(browser);
            string expected = "Введите пароль";
            gmail.Navigate();

            gmail.SubmitLogin(gmail.login);
            gmail.SubmitPassword(password);
            IWebElement loginError = browser.FindElement(By.CssSelector("div[jsname='B34EJ'] > span[jsslot]"));
            string error = loginError.Text.Replace(".", "");

            Assert.AreEqual(expected, error);
        }
    }                   

    [TestClass]
    public class AccountActivitiesTests
    {
        static private IWebDriver browser;
        static internal string context;
        static private WebDriverWait wait;
        static private Gmail gmail;
        static private Proton proton;

        [ClassInitialize]
        public static void OneTimeSetUp(TestContext context)
        {
            browser = new ChromeDriver();
            gmail = new Gmail(browser);
            proton = new Proton(browser);
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60.0));
            browser.Manage().Window.Maximize();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            browser.Quit();
        }


        [TestMethod]
        public void A_GMail_SendRandomLetterToProton_LetterIsSent()
        {
            string recipient = proton.login;
            string letterContent = GetRandomContent();
            string expected = "Сообщение отправлено.";
            gmail.Navigate();

            gmail.LogIn(gmail.login, gmail.password);
            gmail.SendLetter(recipient, letterContent);
            bool sendConfirm = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span[class='bAq']"), expected));

            Assert.IsTrue(sendConfirm);
        }

        [TestMethod]
        public void B_Proton_ValidateLetterArrival_HasArrived()
        {
            string expected = gmail.login;
            proton.Navigate();
            
            proton.LogIn(proton.login, proton.password);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-shortcut-target='item-container-wrapper']/div/div/div/div[2]/span[2]/span")));
            IWebElement latestSender = browser.FindElement(By.XPath("//div[@data-shortcut-target='item-container-wrapper']/div/div/div/div[2]/span[2]/span"));
            string sender = latestSender.GetAttribute("title");

            Assert.AreEqual(expected, sender);
        }          

        [TestMethod]
        public void C_Proton_ValidateLetterUnread_IsUnread()
        {
            string expected = "Непрочитанная почта";

            IWebElement readStatus = browser.FindElement(By.XPath("//div[@data-shortcut-target='item-container-wrapper']/div/div/div/div[2]/span[1]/span"));
            string status = readStatus.GetAttribute("innerText");

            Assert.AreEqual(expected, status);
        }

        [TestMethod]
        public void D_Proton_ValidateCorrectSender_IsCorrect()
        {
            string expected = gmail.login;

            IWebElement senderEMail = browser.FindElement(By.XPath("//div[@data-shortcut-target='item-container-wrapper']/div/div/div/div[2]/span[2]/span"));
            string sender = senderEMail.GetAttribute("title");

            Assert.AreEqual(expected, sender);
        }

        [TestMethod]
        public void E_Proton_VerifyLetterContentMatching_IsMatching()
        {
            string expected = context;

            proton.OpenLatestLetter();
            IWebDriver frame = browser.SwitchTo().Frame(browser.FindElement(By.XPath("//iframe[@title='Содержимое письма']")));
            IWebElement letterContent = frame.FindElement(By.XPath("//body/div/div/div/div[1]"));
            string content = letterContent.Text;

            Assert.AreEqual(expected, content);
        }

        [TestMethod]
        public void F_Proton_SendReplyWithNewUserAlias_IsSent()
        {
            string alias = GetRandomAlias();
            string expected = alias;

            proton.SendReply(alias);
            Thread.Sleep(3000);                                                     // Waiting for a letter to be sent 
            browser.Navigate().GoToUrl("https://mail.proton.me/u/0/all-sent");
            proton.OpenLatestLetter();
            IWebDriver frame = browser.SwitchTo().Frame(browser.FindElement(By.XPath("//iframe[@title='Содержимое письма']")));
            IWebElement sentText = frame.FindElement(By.XPath("//body/div/div/div/div[1]"));
            string sentAlias = sentText.Text; 

            Assert.AreEqual(expected, sentAlias);
        }

        [TestMethod]
        public void G_GMail_LogInChangeAliasVerifyAlias_SentAliasIsSet()
        {
            string expected;
            string newAlias;
            gmail.Navigate();

            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div[class='aRI']"), "Новое"));
            gmail.OpenLatestLetter();
            browser.SwitchTo().Window(browser.WindowHandles[1]);
            newAlias = browser.FindElement(By.XPath("//div[@class='a3s aiL ']/div[1]")).Text;
            browser.Close();
            browser.SwitchTo().Window(browser.WindowHandles[0]);
            gmail.ChangeAlias(newAlias);
            expected = browser.FindElement(By.XPath("//div[@data-index='1']//div[@class='gWjfMb']")).Text;

            Assert.AreEqual(expected, newAlias);
        }

        private string GetRandomContent()
        {
            char[] content = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            new Random().Shuffle(content);
            string randomContent = new(content);
            context = randomContent;
            return randomContent;
        }
        private string GetRandomAlias()
        {
            string[] aliases = ["Alias_One", "Alias_Two", "Alias_Three", "Alias_Four", "Alias_Five"];
            string alias = aliases[new Random().Next(4)];
            return alias;
        }
    }                           
}
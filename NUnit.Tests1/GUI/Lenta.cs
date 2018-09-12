using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Protractor;
using OpenQA.Selenium.Support;

namespace INTRY.GUI
{
    [TestFixture]
    public class Lenta
    {
        IWebDriver driver;
        NgWebDriver ngdriver;
        String LentaURL = "http://lesnikov:qoO5QOE9@test-squadspace.squadsoft.ru/default.aspx/";
        String cssNotify = "#DeltaPlaceHolderMain > app-intry > app-header > div > div > div.pull-right > app-notifications > div > span";
                            
        [OneTimeSetUp]
        public void setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            ngdriver = new NgWebDriver(driver);
            driver.Navigate().GoToUrl(LentaURL);
            
        }

        [OneTimeTearDown]
        public void close()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void PageTitleLenta()
        {
            ngdriver.WaitForAngular();
            String titleLenta = driver.Title.ToString();
            Console.WriteLine("Заголовок страницы: " + titleLenta);
            Assert.AreEqual(titleLenta, "Главная страница");
            
        }

        [Test]
        public void checkname()
        {
            ngdriver.WaitForAngular();
            NgWebElement profilename = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > app-header > div > div > div.pull-right > div > span"));
            String name = profilename.GetAttribute("innerText");
            Console.WriteLine(name);
            Assert.AreEqual(name, "Ivan Lesnikov");
        }

        [Test]
        public void notificationCount()
        {
            ngdriver.WaitForAngular();
            NgWebElement notifyCount = ngdriver.FindElement(By.CssSelector(cssNotify));
            String notCount = notifyCount.GetAttribute("innerText");
            Console.WriteLine(notCount);
            notifyCount.Click();
            //Assert.AreEqual(true, ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > app-header > div > div > div.pull-right > app-notifications > div > div")).Displayed);

            //NgWebElement markREAD = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > app-header > div > div > div.pull-right > app-notifications > div > div > div.notification__header > a"));
            //markREAD.Click();

            //Assert.AreEqual(false, notifyCount.Displayed);
            
        }
    }
}

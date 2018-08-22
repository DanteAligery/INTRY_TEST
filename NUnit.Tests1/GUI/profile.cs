using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protractor;


namespace INTRY.GUI
{
    [TestFixture]
    public class Profile
    {
        IWebDriver driver;
        NgWebDriver ngdriver;
        //NgWebElement lastPOSTcellphone;
        String tel_xpath = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-user-card/div/div/input[2]";
        String empty = "/html/body/form/div[5]/app-intry";
        String last_post = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div";
        String last_post_cellphone = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div/div/div[2]";
        String cellphoneL = "cellphone";
        String cellphoneN = "1234567890";
        String cellphoneS = "!@#$%^&*()_+-=~[]{}'";
        String cellphoneREAL = "+7(903)128-45-76";
        String profileSTR = "http://lesnikov:qoO5QOE9@test-squadspace.squadsoft.ru/default.aspx/profile/8";
        String message_number = "Новый номер: ";

        private static TestCaseData cellnum
        {
            get
            {
                yield return new TestCaseData("cellphone");
            }
        }

        [OneTimeSetUp]
        public void setup()
        {
            
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            ngdriver = new NgWebDriver(driver);
            driver.Navigate().GoToUrl(profileSTR);
            ngdriver.WaitForAngular();
            //lastPOSTcellphone = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__text.ng-star-inserted"));
        }
        
        [OneTimeTearDown]
        public void close()
        {
            driver.Close();
            driver.Quit();
        }

        [Test, TestCaseSource(nameof(cellnum))]
        public void param(String cell, int expectedResult)
        {
            IWebElement tel_field = driver.FindElement(By.XPath(tel_xpath));
            IWebElement empty_field = driver.FindElement(By.XPath(empty));
            tel_field.Click();
        }

        [Test]
        public void NEGATIVE_Cellphone_letter()
        {
            IWebElement tel_field = driver.FindElement(By.XPath(tel_xpath));
            IWebElement empty_field = driver.FindElement(By.XPath(empty));
            tel_field.Click();
            tel_field.SendKeys(cellphoneL);
            empty_field.Click();
            driver.Navigate().Refresh();
            NgWebElement lastpostTime = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__author.ng-star-inserted > div > span.link-profile__subtext"));
            NgWebElement lastPOSTcellphone =  ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__text.ng-star-inserted"));
            String innertext = lastPOSTcellphone.GetAttribute("innerHTML");
            String outertext = lastpostTime.GetAttribute("outerText");
            Console.WriteLine(innertext);
            Console.WriteLine(outertext);
            Assert.That(outertext, Is.EqualTo("Только что"));
            Assert.That(innertext, Is.Not.EqualTo(message_number));
        }

        [Test]
        public void NEGATIVE_Cellphone_symbol()
        {
            IWebElement tel_field = driver.FindElement(By.XPath(tel_xpath));
            IWebElement empty_field = driver.FindElement(By.XPath(empty));
            tel_field.Click();
            tel_field.SendKeys(cellphoneS);
            empty_field.Click();
            driver.Navigate().Refresh();
            NgWebElement lastpostTime = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__author.ng-star-inserted > div > span.link-profile__subtext"));
            NgWebElement lastPOSTcellphone = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__text.ng-star-inserted"));
            String innertext = lastPOSTcellphone.GetAttribute("innerHTML");
            String outertext = lastpostTime.GetAttribute("outerText");
            Console.WriteLine(innertext);
            Console.WriteLine(outertext);
            Assert.That(outertext, Is.EqualTo("Только что"));
            Assert.That(innertext, Is.Not.EqualTo(message_number));
        }


        [Test]
        public void POSITIVE_Cellphone_number()
        {
            IWebElement tel_field = driver.FindElement(By.XPath(tel_xpath));
            IWebElement empty_field = driver.FindElement(By.XPath(empty));
            tel_field.Click();
            tel_field.SendKeys(cellphoneN);
            empty_field.Click();
            driver.Navigate().Refresh();
            NgWebElement lastPOSTcellphone = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__text.ng-star-inserted"));
            NgWebElement lastpostTime = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__author.ng-star-inserted > div > span.link-profile__subtext"));
            String innertext = lastPOSTcellphone.GetAttribute("innerHTML").ToString();
            String outertext = lastpostTime.GetAttribute("outerText");
            Console.WriteLine(innertext);
            Console.WriteLine(outertext);
            Assert.That(outertext, Is.EqualTo("Только что"));
            Assert.That(innertext, Is.EqualTo(message_number + cellphoneN));
        }

        [Test]
        public void POSITIVE_Cellphone_REAL()
        {
            IWebElement tel_field = driver.FindElement(By.XPath(tel_xpath));
            IWebElement empty_field = driver.FindElement(By.XPath(empty));
            tel_field.Click();
            tel_field.SendKeys(cellphoneREAL);
            empty_field.Click();
            driver.Navigate().Refresh();
            NgWebElement lastPOSTcellphone = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__text.ng-star-inserted"));
            NgWebElement lastpostTime = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__author.ng-star-inserted > div > span.link-profile__subtext"));
            String innertext = lastPOSTcellphone.GetAttribute("innerHTML").ToString();
            String outertext = lastpostTime.GetAttribute("outerText");
            Console.WriteLine(innertext);
            Console.WriteLine(outertext);
            Assert.That(outertext, Is.EqualTo("Только что"));
            Assert.That(innertext, Is.EqualTo(message_number + cellphoneREAL));
        }
        
        /*
        [TestCase("Мобильный телефон")]
        public void cellphone()
        {
            IWebElement tel_field = driver.FindElement(By.XPath(tel_xpath));
        }
        */

    }
}

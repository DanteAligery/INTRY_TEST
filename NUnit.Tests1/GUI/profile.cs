using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using Protractor;


namespace INTRY.GUI
{
    [TestFixture]
    public class Profile
    {
        IWebDriver driver;
        NgWebDriver ngdriver;
        String tel_xpath = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-user-card/div/div/input[2]";
        String empty = "/html/body/form/div[5]/app-intry";
        String last_post = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div";
        String last_post_cellphone = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div/div/div[2]";
        static String cellphoneL = "cellphone";
        static String cellphoneN = "1234567890";
        static String cellphoneS = "!@#$%^&*()_+-=~[]{}'";
        static String cellphoneREAL = "+7(903)128-45-76";
        String profileSTR = "http://lesnikov:qoO5QOE9@test-squadspace.squadsoft.ru/default.aspx/profile/8";
        static String message_number = "Новый номер: ";

        public static IEnumerable<TestCaseData> cellnum
        {
            get
            {
                yield return new TestCaseData(cellphoneL, (message_number + cellphoneL));
                yield return new TestCaseData(cellphoneN, (message_number + cellphoneN));
                yield return new TestCaseData(cellphoneS, message_number + cellphoneS);
                yield return new TestCaseData(cellphoneREAL, (message_number + cellphoneREAL));
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
        }

        [OneTimeTearDown]
        public void close()
        {
            driver.Close();
            driver.Quit();
        }

        [Test, TestCaseSource(nameof(cellnum))]
        public void mobilephone(String a, String expectedresult)
        {
            IWebElement tel_field = driver.FindElement(By.XPath(tel_xpath));
            IWebElement empty_field = driver.FindElement(By.XPath(empty));
            tel_field.Click();
            tel_field.SendKeys(a);
            empty_field.Click();
            driver.Navigate().Refresh();
            ngdriver.WaitForAngular();
            NgWebElement lastpostTime = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__author.ng-star-inserted > div > span.link-profile__subtext"));
            NgWebElement lastPOSTcellphone = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__text.ng-star-inserted"));
            String innertext = lastPOSTcellphone.GetAttribute("innerHTML");
            String outertext = lastpostTime.GetAttribute("outerText");
            Console.WriteLine(innertext);
            Console.WriteLine(outertext);
            Assert.AreEqual(expectedresult, innertext);
        }
    }
}

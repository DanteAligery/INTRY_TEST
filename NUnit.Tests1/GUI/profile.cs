﻿using NUnit.Framework;
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
        String tel_xpath = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-user-card/div/div/input[2]";
        String empty = "/html/body/form/div[5]/app-intry";
        String last_post = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div";
        String last_post_cellphone = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div/div/div[2]";
        String cellphoneS = "cellphone";
        String cellphoneN = "1234567890";
        String profileSTR = "http://lesnikov:qoO5QOE9@test-squadspace.squadsoft.ru/default.aspx/profile/8";
        String message_number = "Новый номер: ";

        [SetUp]
        public void setup()
        {
            

            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            ngdriver = new NgWebDriver(driver);

            driver.Navigate().GoToUrl(profileSTR);
            ngdriver.WaitForAngular();
            //ngdriver.Navigate().GoToUrl(profileSTR);
            //ngdriver.Url = driver.Url;
        }

        [Test]
        public void Cellphone_symbol()
        {
   
            
            //driver.Manage().Window.Maximize();
            //driver.Url = "http://lesnikov:qoO5QOE9@test-squadspace.squadsoft.ru/default.aspx/profile/8";
            
            IWebElement tel_field = driver.FindElement(By.XPath(tel_xpath));
            IWebElement empty_field = driver.FindElement(By.XPath(empty));
            tel_field.Click();
            tel_field.SendKeys(cellphoneS);
            empty_field.Click();
            driver.Navigate().Refresh();
            //ngdriver.FindElement (By.ClassName("post"));
            NgWebElement lastPOSTcellphone =  ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__text.ng-star-inserted"));
            String innertext = lastPOSTcellphone.GetAttribute("innerHTML");
            Console.WriteLine(innertext);
            Assert.That(innertext, Is.Not.EqualTo(message_number));
            //IWebElement lastPOSTcellphone = driver.FindElement(By.ClassName("post__text ng-star-inserted"));
            //NgWebElement lastPOSTcellphone = ngdriver.FindElement();
            /*
            IWebElement empty_field = driver.FindElement(By.XPath(empty));
            empty_field.Click();
            driver.Navigate().Refresh();

            IWebElement lastPOSTcellphone =  driver.FindElement(By.XPath(last_post_cellphone));
            ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(last_post));

            IWebElement lastPOSTcellphone = driver.FindElement(By.XPath(last_post_cellphone));
            String classn = lastPOSTcellphone.GetAttribute("post__text ng-star-inserted");
            Console.WriteLine("post__text ng-star-inserted = " + classn);
            */

        }
        [Test]
        public void Cellphone_number()
        {
            IWebElement tel_field = driver.FindElement(By.XPath(tel_xpath));
            IWebElement empty_field = driver.FindElement(By.XPath(empty));
            tel_field.Click();
            tel_field.SendKeys(cellphoneN);
            empty_field.Click();
            driver.Navigate().Refresh();
            NgWebElement lastPOSTcellphone = ngdriver.FindElement(By.CssSelector("#DeltaPlaceHolderMain > app-intry > div > app-profile-view > div.content > app-profile-feed-view > app-profile-feed > app-post:nth-child(2) > div > div > div.post__text.ng-star-inserted"));
            String innertext = lastPOSTcellphone.GetAttribute("innerHTML");
            Console.WriteLine(innertext);
            Assert.That(innertext, Is.EqualTo(message_number + cellphoneN));
        }

        [TearDown]
        public void close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

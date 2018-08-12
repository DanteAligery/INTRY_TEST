using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using RemoteBrowserMobProxy;
using System;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1.GUI
{
    [TestFixture]
    public class TestClass1
    {
        IWebDriver driver;
        String tel_xpath = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-user-card/div/div/input[2]";
        String empty = "/html/body/form/div[5]/app-intry";
        String last_post_cellphone = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div/div/div[2]";

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();


        }

        [Test]
        public void GUIAutorization()
        {
            driver.Manage().Window.Maximize();
            //driver.Url = "http://lesnikov:qoO5QOE9@test-squadspace.squadsoft.ru/default.aspx/";
            driver.Url = "http://lesnikov:qoO5QOE9@test-squadspace.squadsoft.ru/default.aspx/profile/8";
            IWebElement tel_field = driver.FindElement(By.XPath(tel_xpath));
            tel_field.Click();
            tel_field.SendKeys("cellphone");
            IWebElement empty_field = driver.FindElement(By.XPath(empty));
            empty_field.Click();
            driver.Navigate().Refresh();

            IWebElement lastPOSTcellphone = driver.FindElement(By.XPath(last_post_cellphone));
         
        }


        [TearDown]
        public void close()
        {
            //driver.Close();
        }
    }
}

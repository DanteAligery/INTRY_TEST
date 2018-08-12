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

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();


        }

        [Test]
        public void GUIAutorization()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "http://lesnikov:qoO5QOE9@test-squadspace.squadsoft.ru/default.aspx/";
            //driver.SwitchTo().Alert().SetAuthenticationCredentials("lesnikov", "qoO5QOE9");
            //driver.SwitchTo().Alert().Accept();
            //Actions builder = new Actions(driver);
            //builder.SendKeys(Keys.Tab);
            //SendKeys.Send("{TAB}"); 
            // TODO: Add your test code here
            //Assert.Pass("Your first passing test");
        }

        [TearDown]
        public void close()
        {
            //driver.Close();
        }
    }
}

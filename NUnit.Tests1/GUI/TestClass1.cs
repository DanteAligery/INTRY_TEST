using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
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
        public void TestMethod()
        {
            driver.Url = "http://test-squadspace.squadsoft.ru/default.aspx/";
            // TODO: Add your test code here
            //Assert.Pass("Your first passing test");
        }
        [TearDown]
        public void close()
        {
            driver.Close();
        }
    }
}

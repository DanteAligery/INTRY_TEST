using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        private IWebDriver Cdriver;
        private String URL = "https://yandex.ru/";

        [Test]
        public void TestMethod()
        {
            Cdriver = new ChromeDriver();
            Cdriver.Navigate().GoToUrl(URL);
        }
        public void cleanup()
        {
            Cdriver.Quit();
        }
    }
}

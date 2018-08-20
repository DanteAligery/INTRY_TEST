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
    public class system
    {
        IWebDriver driver;
        String tel_xpath = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-user-card/div/div/input[2]";
        String empty = "/html/body/form/div[5]/app-intry";
        String last_post = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div";
        String last_post_cellphone = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div/div/div[2]";
        String cellphone = "cellphone";

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
            
            
        }


        [TearDown]
        public void close()
        {
            driver.Close();
        }
    }
}

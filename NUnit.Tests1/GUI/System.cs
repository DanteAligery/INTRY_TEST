using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Net.Http;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protractor;
using System.Net;
using System.Security.Policy;

namespace INTRY.GUI
{
    [TestFixture]
    public class system
    {
        static IWebDriver driver;
        //RemoteWebDriver driver;
        NgWebDriver ngdriver;
        static String realm = "test-squadspace.squadsoft.ru";
        static String userName = "lesnikov";
        static String password = "qoO5QOE9";
        static String URL;
        static Uri mainUri;
        String tel_xpath = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-user-card/div/div/input[2]";
        String empty = "/html/body/form/div[5]/app-intry";
        String last_post = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div";
        String last_post_cellphone = "/html/body/form/div[5]/app-intry/div/app-profile-view/div[2]/app-profile-feed-view/app-profile-feed/app-post[1]/div/div/div[2]";
        String cellphone = "cellphone";

        [OneTimeSetUp]
        public void setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-extensions");
            //options.AddArgument("-headless");

            Console.WriteLine("Chromeoptions:    " + options.ToString());

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(ChromeOptions.Capability, options);
            //capabilities.SetCapabili();
            driver = new ChromeDriver(options);
            ngdriver = new NgWebDriver(driver);

            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
        }


        [Test]
        public static async Task GUIAutorization()
        {
            UriBuilder Builder = new UriBuilder();
            Builder.Scheme = "http";
            Builder.Host = realm;
            Uri mainUri = Builder.Uri;
            URL = mainUri.ToString();
            Console.WriteLine(URL);

            driver.Manage().Window.Maximize();
            String basicAUTH = userName + ":" + password;
            Console.WriteLine("basicAUTH:   " + basicAUTH);

            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(basicAUTH);
            String basicAUTHencoded = System.Convert.ToBase64String(data);
            Console.WriteLine("basicAUTHencoded:    " + basicAUTHencoded);
            CredentialCache cache = new CredentialCache();
            cache.Add(mainUri, "NTLM", new NetworkCredential(userName, password, ""));
            HttpClientHandler handler = new HttpClientHandler();
            handler.AllowAutoRedirect = true;
            handler.Credentials = cache;
            //OpenQA.Selenium.Cookie cookie = new OpenQA.Selenium.Cookie(handler);
            
            HttpClient client = new HttpClient(handler);
            HttpResponseMessage rs = await client.GetAsync(mainUri);
            //driver.Manage().Cookies.AddCookie(handler);
            driver.Navigate().GoToUrl("http://test-squadspace.squadsoft.ru/default.aspx/");
            //driver.Url = "http://test-squadspace.squadsoft.ru/default.aspx/";
            
            //WebRequest rq = WebRequest.Create(URL);
            //driver.FindElement(By.Id("usr")).SendKeys("123");
            //driver.Url = "http://lesnikov:qoO5QOE9@test-squadspace.squadsoft.ru/default.aspx/";

            /*
                         UriBuilder Builder = new UriBuilder();
            Builder.Scheme = "http";
            Builder.Host = realm;
            Uri mainUri = Builder.Uri;
            URL = mainUri.ToString();
            Console.WriteLine(URL);


            String basicAUTH = userName + ":" + password;
            Console.WriteLine(basicAUTH);

            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(basicAUTH);
            String basicAUTHencoded = System.Convert.ToBase64String(data);
            
            CredentialCache cache = new CredentialCache();
            cache.Add(mainUri, "NTLM", new NetworkCredential(userName, password,""));
            HttpClientHandler handler = new HttpClientHandler();
            handler.AllowAutoRedirect = true;
            handler.Credentials = cache;
            HttpClient client = new HttpClient(handler);
            HttpResponseMessage rs = await client.GetAsync(mainUri);
            
            if (rs.IsSuccessStatusCode)
            {
                Console.WriteLine("StatusCode: " + rs.StatusCode.ToString());
            }
            else
            {
                Console.WriteLine("Status code: ", rs.StatusCode.ToString());
            }
             */

        }



    }
}

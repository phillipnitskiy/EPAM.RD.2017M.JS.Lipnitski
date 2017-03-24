using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ImageBaseTests
{
    [TestFixture]
    public class JsTests
    {
        [Test]
        public void JsTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:13509/Angular/gallery");
            driver.Manage().Window.Maximize();
            var albumsSelect = driver.FindElement(By.TagName("select"));
            albumsSelect.Click();
            albumsSelect.FindElement(By.TagName("option"));
            albumsSelect.Click();

            driver.Close();
            driver.Quit();
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class HomeNaoLogadaPO
    {
        private IWebDriver driver;
        public MenuNaoLogadoPO Menu { get; set; }

        public HomeNaoLogadaPO(IWebDriver driver)
        {
            this.driver = driver;
            this.Menu = new MenuNaoLogadoPO(driver);
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }
    }
}

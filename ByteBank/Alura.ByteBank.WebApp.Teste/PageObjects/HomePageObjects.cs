using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Teste.PageObjects
{
    public class HomePageObjects
    {
        private IWebDriver driver;
        private By linkHome;
        private By linkContaCorrentes;
        private By linkClientes;
        private By linkAgencias;

        public HomePageObjects(IWebDriver driver)
        {
            this.driver = driver;
            this.linkHome = By.Id("home");
            this.linkContaCorrentes = By.Id("contacorrente");
            this.linkClientes = By.Id("clientes");
            this.linkAgencias = By.Id("agencia");
        }

        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void LinkHomeClick()
        {
            driver.FindElement(linkHome).Click();
        }

        public void LinkContaCorrenteClick()
        {
            driver.FindElement(linkContaCorrentes).Click();
        }

        public void LinkClientesClick() 
        {
            driver.FindElement(linkClientes).Click();
        }

        public void LinkAgenciasClick() 
        { 
            driver.FindElement(linkAgencias).Click();
        }
    }
}

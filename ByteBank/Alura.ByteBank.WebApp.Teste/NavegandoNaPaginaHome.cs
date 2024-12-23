using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.ByteBank.WebApp.Teste
{
    public class NavegandoNaPaginaHome
    {
        [Fact]
        public void CarregandoPaginaHomeEVerificaTituloDaPagina()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            //act
            driver.Navigate().GoToUrl("https://localhost:5001");

            //assert
            Assert.Contains("WebApp", driver.Title);
        }

        [Fact]
        public void CarregandoPaginaHomeVerificaExistenciaLinkLoginEHome()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            //act
            driver.Navigate().GoToUrl("https://localhost:5001");

            //assert
            Assert.Contains("Login", driver.PageSource);
            Assert.Contains("Home", driver.PageSource);
        }

        [Fact]
        public void ExecutandoLoginWebApp()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("https://localhost:5001/");
            driver.Manage().Window.Size = new System.Drawing.Size(968, 775);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");
            driver.FindElement(By.Id("Senha")).Click();
            driver.FindElement(By.Id("Senha")).SendKeys("senha01");
            driver.FindElement(By.Id("btn-logar")).Click();
            driver.FindElement(By.Id("agencia")).Click();
            driver.FindElement(By.Id("home")).Click();
            driver.FindElement(By.CssSelector("html")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
        }
    }
}

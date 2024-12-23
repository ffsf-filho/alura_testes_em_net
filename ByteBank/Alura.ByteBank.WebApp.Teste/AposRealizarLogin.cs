using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.ByteBank.WebApp.Teste
{
    public class AposRealizarLogin
    {
        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:5001/UsuarioApps/Login");

            var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
            var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
            var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

            login.SendKeys("andre@email.com");
            senha.SendKeys("senha01");

            //act
            btnLogar.Click();

            //assert
            Assert.Contains("Agência", driver.PageSource);
        }

        [Fact]
        public void TentarRealizarLoginSemPreencherCampos()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:5001/UsuarioApps/Login");

            var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
            var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
            var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

            //login.SendKeys("andre@email.com");
            //senha.SendKeys("senha01");

            //act
            btnLogar.Click();

            //assert
            Assert.Contains("The Email field is required.", driver.PageSource);
            Assert.Contains("The Senha field is required.", driver.PageSource);
        }

        [Fact]
        public void TentarRealizarLoginComSenhaInvalida()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:5001/UsuarioApps/Login");

            var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
            var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
            var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

            login.SendKeys("andre@email.com");
            senha.SendKeys("senha11");//Senha Inválida

            //act
            btnLogar.Click();

            //assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}

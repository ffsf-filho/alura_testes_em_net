using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.WebApp.Teste
{
    public class NavegandoNaPaginaHome
    {
        public ITestOutputHelper SaidaConsoleTeste;

        public NavegandoNaPaginaHome(ITestOutputHelper saidaConsoleTeste)
        {
            SaidaConsoleTeste = saidaConsoleTeste;
        }

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

        [Fact]
        public void ValidaLinkDeLoginNaHome()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            
            driver.Navigate().GoToUrl("https://localhost:5001/");
            var linkLogin = driver.FindElement(By.LinkText("Login"));

            //act
            linkLogin.Click();

            //assert
            Assert.Contains("img", driver.PageSource);
        }

        [Fact]
        public void TentarAcessarPaginaSemEstarLogado()
        {
            //arrange
            //act
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:5001/Agencia/Index");

            //assert
            Assert.Contains("401", driver.PageSource);
        }

        [Fact]
        public void AcessarPaginaSemEstarLogadoVerificaURL()
        {
            //arrange
            //act
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:5001/Agencia/Index");

            //assert
            Assert.Contains("https://localhost:5001/Agencia/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
        }

        [Fact]
        public void RealizarLoguinAcessaMenuECadastraCliente()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:5001/UsuarioApps/Login");

            var login = driver.FindElement(By.Name("Email"));
            var senha = driver.FindElement(By.Name("Senha"));

            login.SendKeys("andre@email.com");
            senha.SendKeys("senha01");

            driver.FindElement(By.Id("btn-logar")).Click();
            driver.FindElement(By.LinkText("Cliente")).Click();
            driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

            driver.FindElement(By.Name("Identificador")).Click();
            driver.FindElement(By.Name("Identificador")).SendKeys("2df71922-ca7d-4dd3-b142-0767b32f822a");
            driver.FindElement(By.Name("CPF")).Click();
            driver.FindElement(By.Name("CPF")).SendKeys("69981034096");
            driver.FindElement(By.Name("Nome")).Click();
            driver.FindElement(By.Name("Nome")).SendKeys("Tobey Garfield");
            driver.FindElement(By.Name("Profissao")).Click();
            driver.FindElement(By.Name("Profissao")).SendKeys("Clientista");

            //act
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.LinkText("Home")).Click();

            //Assett
            Assert.Contains("Logout", driver.PageSource);
        }

        [Fact]
        public void RealizarLoguinAcessaListagemDeContas()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:5001/UsuarioApps/Login");

            var login = driver.FindElement(By.Name("Email"));
            var senha = driver.FindElement(By.Name("Senha"));

            login.SendKeys("andre@email.com");
            senha.SendKeys("senha01");

            driver.FindElement(By.Id("btn-logar")).Click();

            //Conta corrente
            driver.FindElement(By.Id("contacorrente")).Click();
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.TagName("a"));
            var elemento = (from webElemento in elements
                            where webElemento.Text.Contains("Detalhes")
                            select webElemento).First();

            //foreach (IWebElement e in elements)
            //{
            //    SaidaConsoleTeste.WriteLine(e.Text);
            //}

            //act
            elemento.Click();

            //Assett
            //Assert.True(elements.Count == 12);
            Assert.Contains("Voltar", driver.PageSource);
        }
    }
}

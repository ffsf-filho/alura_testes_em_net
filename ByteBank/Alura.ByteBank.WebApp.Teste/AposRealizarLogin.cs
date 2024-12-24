using Alura.ByteBank.WebApp.Teste.PageObjects;
using Alura.ByteBank.WebApp.Teste.Utilitarios;
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
    public class AposRealizarLogin : IClassFixture<Gerenciador>
    {
        private readonly IWebDriver _driver;
        public ITestOutputHelper SaidaConsoleTeste;

        public AposRealizarLogin(Gerenciador gerenciador, ITestOutputHelper saidaConsoleTeste)
        {
            _driver = gerenciador.Driver;

            this.SaidaConsoleTeste = saidaConsoleTeste;
        }

        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
        {
            //arrange
            var loginPO = new LoginPageObjects(_driver);
            loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");
            loginPO.PreencherCampos("andre@email.com", "senha01");

            //act
            loginPO.BtnClick();

            //assert
            Assert.Contains("Agência", _driver.PageSource);
        }

        [Fact]
        public void TentarRealizarLoginSemPreencherCampos()
        {
            //arrange
            var loginPO = new LoginPageObjects(_driver);
            loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");
            loginPO.PreencherCampos("", "");

            //act
            loginPO.BtnClick();

            //assert
            Assert.Contains("The Email field is required.", _driver.PageSource);
            Assert.Contains("The Senha field is required.", _driver.PageSource);
        }

        [Fact]
        public void TentarRealizarLoginComSenhaInvalida()
        {
            //arrange
            var loginPO = new LoginPageObjects(_driver);
            loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");
            loginPO.PreencherCampos("andre@email.com", "senha11");

            //act
            loginPO.BtnClick();

            //assert
            Assert.Contains("Login", _driver.PageSource);
        }

        [Fact]
        public void RealizarLoguinAcessaMenuECadastraCliente()
        {
            //arrange
            var loginPO = new LoginPageObjects(_driver);
            loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.BtnClick();

            _driver.FindElement(By.LinkText("Cliente")).Click();
            _driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

            _driver.FindElement(By.Name("Identificador")).Click();
            _driver.FindElement(By.Name("Identificador")).SendKeys("2df71922-ca7d-4dd3-b142-0767b32f822a");
            _driver.FindElement(By.Name("CPF")).Click();
            _driver.FindElement(By.Name("CPF")).SendKeys("69981034096");
            _driver.FindElement(By.Name("Nome")).Click();
            _driver.FindElement(By.Name("Nome")).SendKeys("Tobey Garfield");
            _driver.FindElement(By.Name("Profissao")).Click();
            _driver.FindElement(By.Name("Profissao")).SendKeys("Clientista");

            //act
            _driver.FindElement(By.CssSelector(".btn-primary")).Click();
            _driver.FindElement(By.LinkText("Home")).Click();

            //Assett
            Assert.Contains("Logout", _driver.PageSource);
        }

        [Fact]
        public void RealizarLoguinAcessaListagemDeContas()
        {
            //arrange
            var loginPO = new LoginPageObjects(_driver);
            loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.BtnClick();

            //Conta corrente
            _driver.FindElement(By.Id("contacorrente")).Click();
            IReadOnlyCollection<IWebElement> elements = _driver.FindElements(By.TagName("a"));
            var elemento = (from webElemento in elements
                            where webElemento.Text.Contains("Detalhes")
                            select webElemento).First();

            //act
            elemento.Click();

            //Assett
            Assert.Contains("Voltar", _driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaListagemDeContasUsandoHomePageObjects()
        {
            //arrange
            var homePO = new HomePageObjects(_driver);
            var loginPO = new LoginPageObjects(_driver);
            loginPO.Navegar("https://localhost:5001/UsuarioApps/Login");
            loginPO.PreencherCampos("andre@email.com", "senha01");

            //act
            loginPO.BtnClick();
            homePO.LinkContaCorrenteClick();

            //assert
            Assert.Contains("Adicionar Conta-Corrente", _driver.PageSource);
        }
    }
}

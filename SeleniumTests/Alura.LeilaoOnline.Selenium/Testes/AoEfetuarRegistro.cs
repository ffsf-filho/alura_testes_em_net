using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture testFixture)
        {
            this.driver = testFixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange
            //dado chrome aberto, página inicial do sist. de leilões, dados de registro válidos informados
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //Nome
            var inputNome = driver.FindElement(By.Id("Nome"));
            inputNome.SendKeys("Daniel Portugal");

            //Email
            var inputEmail = driver.FindElement(By.Id("Email"));
            inputEmail.SendKeys("daniel.portugal@caelum.com.br");

            //Password
            var inputSenha = driver.FindElement(By.Id("Password"));
            inputSenha.SendKeys("123");

            //ConfirmPassword
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
            inputConfirmSenha.SendKeys("123");
            
            //Botão de Registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            //efetuo o registro
            botaoRegistro.Click();

            //assert
            //devo ser direcionado para uma página de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "daniel.portugal@caelum.com.br", "123", "123")]
        [InlineData("Daniel Portugal", "daniel", "123", "123")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "456")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "")]
        public void DadoInfoInvalidasDeveContinuarNaHome(string nome, string email, string senha, string confirmSenha)
        {
            //arrange
            //dado Chrome aberto, página inicial do sistema de leilões
            //dados de registro válidos informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            //Nome
            var inputNome = driver.FindElement(By.Id("Nome"));
            inputNome.SendKeys(nome);

            //Email
            var inputEmail = driver.FindElement(By.Id("Email"));
            inputEmail.SendKeys(email);

            //Password
            var inputSenha = driver.FindElement(By.Id("Password"));
            inputSenha.SendKeys(senha);

            //ConfirmPassword
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
            inputConfirmSenha.SendKeys(confirmSenha);

            //Botão de Registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            //efetuamos o registro
            botaoRegistro.Click();

            //assert
            //devemos nos direcionar para uma página de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            //Botão de Registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            botaoRegistro.Click();

            //assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Equal("The Nome field is required.", elemento.Text);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            //email
            var inputEmail = driver.FindElement(By.Id("Email"));
            inputEmail.SendKeys("daniel");

            //Botão de Registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            botaoRegistro.Click();

            //assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email]"));
            Assert.Equal("Please enter a valid email address.", elemento.Text);
        }
    }
}
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;
        private RegistroPageObject registroPO;

        public AoEfetuarRegistro(TestFixture testFixture)
        {
            this.driver = testFixture.Driver;
            registroPO = new RegistroPageObject(driver);
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange
            //dado chrome aberto, página inicial do sist. de leilões, dados de registro válidos informados
            registroPO.Visitar();
            registroPO.PreencheFormulario("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "123");

            //act
            //efetuo o registro
            registroPO.SubmeteFormulario();

            //assert
            //devo ser direcionado para uma página de agradecimento
            Assert.Contains("Obrigado", registroPO.PageSource());
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
            registroPO.Visitar();
            registroPO.PreencheFormulario(nome, email, senha, confirmSenha);

            //act
            //efetuamos o registro
            registroPO.SubmeteFormulario();

            //assert
            //devemos nos direcionar para uma página de agradecimento
            Assert.Contains("section-registro", registroPO.PageSource());
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            registroPO.Visitar();
            registroPO.PreencheFormulario(nome: "", email: "daniel.portugal@caelum.com.br", senha: "123", confirmSenha: "123");

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            registroPO.Visitar();

            //email
            registroPO.PreencheFormulario(nome: "", email: "daniel", senha: "", confirmSenha: "");

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }
    }
}
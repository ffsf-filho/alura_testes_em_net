using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //arrange

            //act
            new LoginPO(driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                .EfetuarLogin();

            //assert
            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void DadoCrendenciasInvalidasDeveContinuarLogin()
        {
            //arrange

            //act
            new LoginPO(driver).EfetuarLoginComCredenciais("fulano@example.org", "1232");

            //assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}

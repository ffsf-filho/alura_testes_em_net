using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;

        //Setup
        public AoNavegarParaHome(TestFixture testFixture)
        {
            driver = testFixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDevemosMostarLeiloesNoTitulo()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //Assert
            Assert.Contains("Leil�es", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //Assert
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);
        }
    }
}

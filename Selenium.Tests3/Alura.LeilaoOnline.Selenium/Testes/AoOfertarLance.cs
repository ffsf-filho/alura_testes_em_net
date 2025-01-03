using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //arrange
            new LoginPO(driver).EfetuarLoginComCredenciais("fulano@example.org", "123");

            var detalhePO = new DetalheLeilaoPO(driver);
            detalhePO.Visitar(1);//enandamento

            //act
            detalhePO.OfertarLance(300);

            //assert
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            bool iguais = wait.Until(drv => detalhePO.LanceAtual == 300);
            Assert.True(iguais);
        }
    }
}
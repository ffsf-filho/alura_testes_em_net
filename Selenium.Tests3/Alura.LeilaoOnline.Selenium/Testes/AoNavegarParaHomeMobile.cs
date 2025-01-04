using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver driver;

        public AoNavegarParaHomeMobile()
        {
        }

        [Fact]
        public void DadaLargura992DeveMostrarMenuMobile()
        {
            //arrange
            ConfiguraLarguraDaTelaMobile(992);
            var homePO = new HomeNaoLogadaPO(driver);

            //act
            homePO.Visitar();

            //asert
            Assert.True(homePO.Menu.MenuMobileVisivel);
        }

        [Fact]
        public void DadaLargura993NaoDeveMostrarMenuMobile()
        {
            //arrange
            ConfiguraLarguraDaTelaMobile(993);
            var homePO = new HomeNaoLogadaPO(driver);

            //act
            homePO.Visitar();

            //asert
            Assert.False(homePO.Menu.MenuMobileVisivel);
        }

        private void ConfiguraLarguraDaTelaMobile(long larguraDaTela)
        {
            var deviceSettings = new ChromiumMobileEmulationDeviceSettings();
            deviceSettings.Width = larguraDaTela;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";

            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);
            this.driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}

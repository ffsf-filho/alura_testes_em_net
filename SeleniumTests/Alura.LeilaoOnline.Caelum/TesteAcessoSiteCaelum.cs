using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.LeilaoOnline.Caelum
{
    public class TesteAcessoSiteCaelum:IDisposable
    {
        IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        [Fact]
        public void TestandoAcessoAoSiteDaCaelum()
        {
            //arrange - dado que o navegador está aberto

            //act - quando navegamos para a URL https://www.caelum.com.br
            driver.Navigate().GoToUrl("https://www.caelum.com.br");

            //assert
            Assert.Contains("Caelum", driver.Title);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}

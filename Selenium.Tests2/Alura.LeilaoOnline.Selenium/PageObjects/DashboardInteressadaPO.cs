using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            this.byLogoutLink = By.Id("logout");
            this.byMeuPerfilLink = By.Id("meu-perfil");
            this.bySelectCategorias = By.ClassName("select-wrapper");
            this.byInputTermo = By.Id("termo");
            this.byInputAndamento = By.ClassName("switch");
            this.byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(List<string> categorias, string termo, bool emAndamento)
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);
            select.DeselectAll();

            categorias.ForEach(categ => 
            {
                select.SelectByText(categ);
            });

            driver.FindElement(byInputTermo).SendKeys(termo);

            if (emAndamento)
            {
                driver.FindElement(byInputAndamento).Click();
            }
            driver.FindElement(byBotaoPesquisar).Click();
        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLogoutLink);

            IAction acaoLogout = new Actions(this.driver)
                //Mover para o elemento meu-perfil
                .MoveToElement(linkMeuPerfil)
                //mover para o link de logout
                .MoveToElement(linkLogout)
                //clicar no link de logout
                .Click()
                .Build();
            acaoLogout.Perform();
        }
    }
}

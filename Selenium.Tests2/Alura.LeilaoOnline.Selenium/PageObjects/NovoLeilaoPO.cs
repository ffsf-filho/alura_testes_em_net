using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver driver;
        private By byInputTitulo;
        private By byInputDescricao;
        private By byInputCategoria;
        private By byInputValorInicial;
        private By byInputImagem;
        private By byInputInicioPregao;
        private By byInputTerminoPregao;
        private By byBotaoSalvar;

        public IEnumerable<string> Categorias {
            get
            {
                //var elementoCategoria = driver.FindElement(byInputCategoria);
                //elementoCategoria.FindElements(By.TagName("option"));
                var elementoCategoria = new SelectElement(driver.FindElement(byInputCategoria));
                return elementoCategoria.Options
                    .Where(o => o.Enabled)
                    .Select(o => o.Text);
            } 
        }

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            this.byInputTitulo = By.Id("Titulo");
            this.byInputDescricao = By.Id("Descricao");
            this.byInputCategoria = By.Id("Categoria");
            this.byInputValorInicial = By.Id("ValorInicial");
            this.byInputImagem = By.Id("ArquivoImagem");
            this.byInputInicioPregao = By.Id("InicioPregao");
            this.byInputTerminoPregao = By.Id("TerminoPregao");
            this.byBotaoSalvar = By.CssSelector("button[type=submit]");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormulario(string titulo, string descricao, string categoria, double valor, string imagem, DateTime inicio, DateTime termino)
        {
            driver.FindElement(byInputTitulo).SendKeys(titulo);
            driver.FindElement(byInputDescricao).SendKeys(descricao);
            var SelectCategoria = new SelectElement(driver.FindElement(byInputCategoria));
            SelectCategoria.SelectByText(categoria);
            //driver.FindElement(byInputCategoria).SendKeys(categoria);
            driver.FindElement(byInputValorInicial).SendKeys(valor.ToString());
            driver.FindElement(byInputImagem).SendKeys(imagem);
            driver.FindElement(byInputInicioPregao).SendKeys(inicio.ToString("dd/MM/yyyy"));
            driver.FindElement(byInputTerminoPregao).SendKeys(termino.ToString("dd/MM/yyyy"));
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoSalvar).Click();
        }
    }
}

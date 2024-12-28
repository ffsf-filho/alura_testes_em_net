using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPageObject
    {
        private IWebDriver driver;
        private By byFormRegistro;
        private By byInputNome;
        private By byInputEmail;
        private By byInputSenha;
        private By byInputConfirmSenha;
        private By byBotaoRegistro;
        private By bySpanErroNome;
        private By bySpanErroEmail;

        public string NomeMensagemErro => driver.FindElement(bySpanErroNome).Text;
        public string EmailMensagemErro => driver.FindElement(bySpanErroEmail).Text;

        public RegistroPageObject(IWebDriver driver)
        {
            this.driver = driver;
            this.byFormRegistro = By.TagName("form");
            this.byInputNome = By.Id("Nome");
            this.byInputEmail = By.Id("Email");
            this.byInputSenha = By.Id("Password");
            this.byInputConfirmSenha = By.Id("ConfirmPassword");
            this.byBotaoRegistro = By.Id("btnRegistro");
            this.bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
            this.bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/");
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoRegistro).Click();
        }

        public void PreencheFormulario(string nome, string email, string senha, string confirmSenha)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputSenha).SendKeys(senha);
            driver.FindElement(byInputConfirmSenha).SendKeys(confirmSenha);
        }

        public string PageSource()
        {
            return driver.PageSource;
        }
    }
}

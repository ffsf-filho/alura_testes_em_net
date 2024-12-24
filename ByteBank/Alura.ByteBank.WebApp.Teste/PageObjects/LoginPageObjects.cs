using OpenQA.Selenium;

namespace Alura.ByteBank.WebApp.Teste.PageObjects
{
    public class LoginPageObjects
    {
        private IWebDriver driver;
        private By campoEmail;
        private By campoSenha;
        private By btnLogar;

        public LoginPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            this.campoEmail = By.Id("Email");
            this.campoSenha = By.Id("Senha");
            this.btnLogar = By.Id("btn-logar");
        }

        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void PreencherCampos(string email, string senha)
        {
            driver.FindElement(campoSenha).SendKeys(senha);
            driver.FindElement(campoEmail).SendKeys(email);
        }

        public void BtnClick()
        {
            driver.FindElement(btnLogar).Click();
        }
    }
}

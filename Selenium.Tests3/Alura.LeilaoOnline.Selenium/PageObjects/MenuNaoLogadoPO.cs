using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuNaoLogadoPO
    {
        private IWebDriver driver;
        private By byMenuMobile;

        public bool MenuMobileVisivel
        {
            get
            {
                var elemento = driver.FindElement(byMenuMobile);
                return elemento.Displayed;
            }
        }

        public MenuNaoLogadoPO(IWebDriver driver)
        {
            this.driver = driver;
            this.byMenuMobile = By.ClassName("sidenav-trigger");
            //this.byMenuMobile = By.CssSelector(".sidenav-trigger");
        }
    }
}
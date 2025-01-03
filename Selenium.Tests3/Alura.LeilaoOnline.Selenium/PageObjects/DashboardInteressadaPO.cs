using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;

        public FiltroLeiloesPO Filtro { get;}
        public MenuLogadoPO Menu { get;}

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            this.Filtro = new FiltroLeiloesPO(driver);
            this.Menu = new MenuLogadoPO(driver);
        }
    }
}

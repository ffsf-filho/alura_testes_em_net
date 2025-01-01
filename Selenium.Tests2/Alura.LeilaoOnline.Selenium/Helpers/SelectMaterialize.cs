using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver driver;
        private IWebElement selectWrapper;
        private IEnumerable<IWebElement> opcoes;

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            this.driver = driver;
            this.selectWrapper = driver.FindElement(locatorSelectWrapper);
            opcoes = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        public IEnumerable<IWebElement> Options => opcoes;

        private void OpenWrapper()
        {
            selectWrapper.Click();
        }

        private void LoseFocus()
        {
            selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);
        }

        public void DeselectAll()
        {
            OpenWrapper();

            opcoes.ToList().ForEach(o =>
            {
                o.Click();
            });

            LoseFocus();
        }

        public void SelectByText(string option)
        {
            OpenWrapper();

            opcoes
                .Where(o => o.Text.Contains(option))
                .ToList()
                .ForEach(o =>
                {
                    o.Click();
                });

            LoseFocus();
        }
    }
}

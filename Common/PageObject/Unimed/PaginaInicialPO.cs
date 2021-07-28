using Common.PageObject.Unimed;
using OpenQA.Selenium;

namespace Common.PageObject
{
    public class PaginaInicialPO : Dicionario
    {
        Utilitarios util;

        public PaginaInicialPO(IWebDriver driver)
        {
            util = new Utilitarios(driver);
        }

        public void VisitarSiteUnimed()
        {
            util.NavigateTo(URL_BASE);
        }

        public void AcessarGuiaMedico()
        {
            util.OnClick(PaginaIncial.XP_LINK_GUIA_MEDICO);
        }
    }
}

using OpenQA.Selenium;

namespace Common.PageObject.Unimed
{
    public class Dicionario
    {
        public const string URL_BASE = "https://www.unimed.coop.br/site/";

        public class PaginaIncial
        {
            public static readonly By XP_LINK_GUIA_MEDICO = By.XPath("//a[contains(text(),'Consulte')]");
        }

        public class PaginaGuiaMedico
        {
            public static readonly By XP_LI_BUSCA_DETALHADA = By.XPath("//li[contains(text(),'Busca detalhada')]");
            public static readonly By XP_SELECT_ESPECIALIDADE = SelecionarFiltro("Especialidade");
            public static readonly By XP_SELECT_ESTADO = SelecionarFiltro("Estado");
            public static readonly By XP_SELECT_CIDADE = SelecionarFiltro("Cidade");
            public static readonly By XP_SELECT_TIPO_ESTABELECIMENTO = SelecionarFiltro("Tipo de estabelecimento");
            public static readonly By XP_BUTTON_PESQUISAR = By.XPath("//button[contains(text(),'Pesquisar')]");
            
            public static By SelecionarFiltro(string campoDesejado)
            {
                return By.XPath($"//div[contains(text(),'{campoDesejado}')]/..//input");
            }
        }

        public class PaginaResultadoPesquisa
        {
            public static readonly By BUTTON_VER_MAIS_RESULTADOS = By.CssSelector("button.LoadMoreResultsButton");

            public static string XpEncontrarEspecialidade(string especialidade)
            {
                return $"(//span[contains(@class,'ProviderSpecialties--item') and contains(.,'{especialidade}')])";
            }

            public static string XpEncontrarCidade(string cidade)
            {
                return $"(//a[contains(.,'{cidade}')])";
            }

        }
    }
}

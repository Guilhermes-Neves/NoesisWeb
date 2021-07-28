using Common.PageObject.Unimed;
using OpenQA.Selenium;


namespace Common.PageObject
{
    public class ResultadoPesquisaPO : Dicionario
    {
        Utilitarios util;

        public ResultadoPesquisaPO(IWebDriver driver)
        {
            util = new Utilitarios(driver);
        }

        public void AcessarMaisResultados(int qtdPaginasDesejadas)
        {
            for (int i = 1; i <= qtdPaginasDesejadas; i++)
            {
                util.OnClick(PaginaResultadoPesquisa.BUTTON_VER_MAIS_RESULTADOS);
            }
        }

        public bool EsperarResuladoCarregar(string especialidade)
        {
            if (util.IsElementDisplayed(By.XPath($"{PaginaResultadoPesquisa.XpEncontrarEspecialidade(especialidade)}")))
            {
                return true;
            }

            return false;
        }

        public bool ValidarEspecilidadeRetornada(string especialidade)
        {
            int qtdElementos = util.GetElementCount(By.XPath($"{PaginaResultadoPesquisa.XpEncontrarEspecialidade(especialidade)}"));

            for (int i = 1; i <= qtdElementos; i++)
            {
                string elemento = PaginaResultadoPesquisa.XpEncontrarEspecialidade(especialidade);
                string textoElementoEncontrado = util.GetText(By.XPath($"{elemento}[{i}]"));

                if (!(textoElementoEncontrado.Contains(especialidade)))
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValidarCidadeRetornada(string cidade, bool cidadePesquisada)
        {
            int qtdElementos = util.GetElementCount(By.XPath($"{PaginaResultadoPesquisa.XpEncontrarCidade(cidade)}"));

            if (qtdElementos != 0)
            {
                for (int i = 1; i <= qtdElementos; i++)
                {
                    string elemento = PaginaResultadoPesquisa.XpEncontrarCidade(cidade);
                    string textoElementoEncontrado = util.GetText(By.XPath($"{elemento}[{i}]"));

                    if (!(textoElementoEncontrado.Contains(cidade)))
                    {
                        return false;
                    }
                }

                return true;
            }

            if (!cidadePesquisada)
            {
                return true;
            }

            return false;
        }

       
    }
}

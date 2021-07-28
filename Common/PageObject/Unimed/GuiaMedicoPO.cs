using Common.PageObject.Unimed;
using OpenQA.Selenium;

namespace Common.PageObject
{
    public class GuiaMedicoPO : Dicionario
    {

        Utilitarios util;

        public GuiaMedicoPO(IWebDriver driver)
        {
            util = new Utilitarios(driver);
        }

        public void AcessarBuscaDetalhada()
        {
            util.OnClick(PaginaGuiaMedico.XP_LI_BUSCA_DETALHADA);
        }

        public void SelecionarEspecialidade(string especialidade)
        {
            util.WaitUntilElementAppear(PaginaGuiaMedico.XP_SELECT_ESPECIALIDADE);
            util.SendKey(PaginaGuiaMedico.XP_SELECT_ESPECIALIDADE, especialidade, true);
        }

        public void SelecionarEstado(string estado)
        {
            util.WaitUntilElementAppear(PaginaGuiaMedico.XP_SELECT_ESTADO);
            util.SendKey(PaginaGuiaMedico.XP_SELECT_ESTADO, estado, true);
        }

        public void SelecionarCidade(string cidade)
        {
            util.WaitUntilElementAppear(PaginaGuiaMedico.XP_SELECT_CIDADE);
            util.SendKey(PaginaGuiaMedico.XP_SELECT_CIDADE, cidade, true);

        }

        public void SelecionarTipoEstabelecimento(string tipoEstabelecimento)
        {
            util.WaitUntilElementAppear(PaginaGuiaMedico.XP_SELECT_TIPO_ESTABELECIMENTO);
            util.SendKey(PaginaGuiaMedico.XP_SELECT_TIPO_ESTABELECIMENTO, tipoEstabelecimento, true);
        }

        public void AcionarBotaoPesquisar()
        {
            util.OnClick(PaginaGuiaMedico.XP_BUTTON_PESQUISAR);
        }
    }
}

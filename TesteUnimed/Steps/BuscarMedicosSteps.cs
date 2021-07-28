using Common.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;


namespace Escritorio.Steps
{
    [Binding]
    public class BuscarMedicosSteps :IDisposable
    {
        IWebDriver driver;
        GuiaMedicoPO guiaMedico;
        PaginaInicialPO paginaInicial;
        ResultadoPesquisaPO resultadoPesquisa;

        public BuscarMedicosSteps()
        {
            driver = new ChromeDriver();
            paginaInicial = new PaginaInicialPO(driver);
            guiaMedico = new GuiaMedicoPO(driver);
            resultadoPesquisa = new ResultadoPesquisaPO(driver);
        }

        [Given(@"que visito a página do Guia médico")]
        public void DadoQueVisitoAPaginaDoGuiaMedico()
        {
            paginaInicial.VisitarSiteUnimed();
            paginaInicial.AcessarGuiaMedico();
        }

        [When(@"efetuo a busca com os dados ""(.*)"" ""(.*)"" ""(.*)""  ""(.*)""")]
        public void QuandoEfetuoABuscaComOsDados(string especialidade, string estado, string cidade, string tipoEstabelecimento)
        {
            guiaMedico.AcessarBuscaDetalhada();
            guiaMedico.SelecionarEspecialidade(especialidade);
            guiaMedico.SelecionarEstado(estado);
            guiaMedico.SelecionarCidade(cidade);
            guiaMedico.SelecionarTipoEstabelecimento(tipoEstabelecimento);
            guiaMedico.AcionarBotaoPesquisar();
        }

        [Then(@"eu so vejo médicos da ""(.*)"" e ""(.*)""")]
        public void EntaoEuSoVejoMedicosDaE(string especialidade, string abreviacao)
        {
            Assert.True(resultadoPesquisa.EsperarResuladoCarregar(especialidade));
            Assert.True(resultadoPesquisa.ValidarEspecilidadeRetornada(especialidade));
            Assert.True(resultadoPesquisa.ValidarCidadeRetornada(abreviacao, true));
        }

        [Then(@"eu não vejo a cidade de ""(.*)"" presente")]
        public void EntaoEuNaoVejoACidadeDePresente(string cidade)
        {
            resultadoPesquisa.AcessarMaisResultados(3);
            Assert.True(resultadoPesquisa.ValidarCidadeRetornada(cidade, false));
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}

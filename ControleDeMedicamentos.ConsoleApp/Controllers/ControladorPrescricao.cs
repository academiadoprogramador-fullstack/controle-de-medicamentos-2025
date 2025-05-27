using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Model;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("prescricoes-medicas")]
public class ControladorPrescricao : Controller
{
    private ContextoDados contexto;
    private IRepositorioPrescricao repositorioPrescricao;

    public ControladorPrescricao()
    {
        contexto = new ContextoDados(true);
        repositorioPrescricao = new RepositorioPrescricaoEmArquivo(contexto);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var registros = repositorioPrescricao.SelecionarRegistros();

        var visualizarVM = new VisualizarPrescricoesViewModel(registros);

        return View(visualizarVM);
    }
}

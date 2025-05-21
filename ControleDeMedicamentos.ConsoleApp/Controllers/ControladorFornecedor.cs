using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Model;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("/fornecedores")]
public class ControladorFornecedor : Controller
{
    private readonly ContextoDados contextoDados;
    private readonly IRepositorioFornecedor repositorioFornecedor;

    public ControladorFornecedor()
    {
        contextoDados = new ContextoDados(true);
        repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarFornecedorViewModel();
        return View("Cadastrar", cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarFornecedorViewModel cadastrarVM)
    {
        var novoFornecedor = cadastrarVM.ParaEntidade();

        repositorioFornecedor.CadastrarRegistro(novoFornecedor);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Fornecedor Cadastrado!",
            $"O registro \"{novoFornecedor.Nome}\" foi cadastrado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id)
    {
        var registroSelecionado = repositorioFornecedor.SelecionarRegistroPorId(id);

        var editarVM = new EditarFornecedorViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Telefone,
            registroSelecionado.CNPJ
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id, EditarFornecedorViewModel editarVM)
    {
        var registroEditado = editarVM.ParaEntidade();

        repositorioFornecedor.EditarRegistro(id, registroEditado);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Fornecedor Editado!",
            $"O registro \"{registroEditado.Nome}\" foi editado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult Excluir([FromRoute] int id)
    {
        var registroSelecionado = repositorioFornecedor.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirFornecedorViewModel(
            registroSelecionado.Id,
            registroSelecionado.Nome
        );

        return View("Excluir", excluirVM);
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirConfirmado([FromRoute] int id)
    {
        repositorioFornecedor.ExcluirRegistro(id);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Fornecedor Excluído!",
            "O registro foi excluído com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var registros = repositorioFornecedor.SelecionarRegistros();

        var visualizarVM = new VisualizarFornecedoresViewModel(registros);

        return View(visualizarVM);
    }
}

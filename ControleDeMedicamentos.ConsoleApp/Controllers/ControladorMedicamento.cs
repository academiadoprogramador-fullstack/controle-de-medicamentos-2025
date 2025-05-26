using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Model;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("medicamentos")]
public class ControladorMedicamento : Controller
{
    private readonly ContextoDados contextoDados;
    private readonly IRepositorioMedicamento repositorioMedicamento;
    private readonly IRepositorioFornecedor repositorioFornecedor;

    public ControladorMedicamento()
    {
        contextoDados = new ContextoDados(true);
        repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);
        repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var fornecedores = repositorioFornecedor.SelecionarRegistros();

        var cadastrarVM = new CadastrarMedicamentoViewModel(fornecedores);

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarMedicamentoViewModel cadastrarVM)
    {
        var fornecedores = repositorioFornecedor.SelecionarRegistros();

        var registro = cadastrarVM.ParaEntidade(fornecedores);

        repositorioMedicamento.CadastrarRegistro(registro);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Medicamento Cadastrado!",
            $"O registro \"{registro.Nome}\" foi cadastrado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:guid}")]
    public IActionResult Editar([FromRoute] Guid id)
    {
        var registroSelecionado = repositorioMedicamento.SelecionarRegistroPorId(id);

        var fornecedores = repositorioFornecedor.SelecionarRegistros();

        var editarVM = new EditarMedicamentoViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Descricao,
            registroSelecionado.Fornecedor.Id,
            fornecedores
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    public IActionResult Editar([FromRoute] Guid id, EditarMedicamentoViewModel editarVM)
    {
        var fornecedores = repositorioFornecedor.SelecionarRegistros();

        var registroEditado = editarVM.ParaEntidade(fornecedores);

        repositorioMedicamento.EditarRegistro(id, registroEditado);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Medicamento Editado!",
            $"O registro \"{registroEditado.Nome}\" foi editado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir([FromRoute] Guid id)
    {
        var registroSelecionado = repositorioMedicamento.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirMedicamentoViewModel(
            registroSelecionado.Id,
            registroSelecionado.Nome
        );

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    public IActionResult ExcluirConfirmado([FromRoute] Guid id)
    {
        repositorioMedicamento.ExcluirRegistro(id);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Medicamento Excluído!",
            "O registro foi excluído com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var registros = repositorioMedicamento.SelecionarRegistros();

        var visualizarVM = new VisualizarMedicamentosViewModel(registros);

        return View(visualizarVM);
    }
}

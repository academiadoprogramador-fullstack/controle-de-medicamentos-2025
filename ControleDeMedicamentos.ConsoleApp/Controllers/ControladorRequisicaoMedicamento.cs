﻿using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.Model;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("requisicoes-medicamentos")]
public class ControladorRequisicaoMedicamento : Controller
{
    private ContextoDados contextoDados;
    private IRepositorioRequisicaoMedicamento repositorioRequisicaoMedicamento;
    private IRepositorioFuncionario repositorioFuncionario;
    private IRepositorioMedicamento repositorioMedicamento;
    private IRepositorioPaciente repositorioPaciente;

    public ControladorRequisicaoMedicamento()
    {
        contextoDados = new ContextoDados(true);
        repositorioRequisicaoMedicamento = new RepositorioRequisicaoMedicamentoEmArquivo(contextoDados);
        repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);
        repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);
        repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);
    }

    [HttpGet("entrada/{medicamentoId:int}")]
    public IActionResult CadastrarEntrada(int medicamentoId)
    {
        var funcionarios = repositorioFuncionario.SelecionarRegistros();

        var medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(medicamentoId);

        var cadastrarVM = new CadastrarRequisicaoEntradaViewModel(medicamentoId, funcionarios);

        ViewBag.NomeMedicamento = medicamentoSelecionado.Nome;

        return View("CadastrarEntrada", cadastrarVM);
    }

    [HttpPost("entrada/{medicamentoId:int}")]
    public IActionResult CadastrarEntrada(int medicamentoId, CadastrarRequisicaoEntradaViewModel cadastrarVM)
    {
        var funcionarios = repositorioFuncionario.SelecionarRegistros();
        var medicamentos = repositorioMedicamento.SelecionarRegistros();

        var registro = cadastrarVM.ParaEntidade(funcionarios, medicamentos);

        var medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(medicamentoId);

        medicamentoSelecionado.AdicionarAoEstoque(registro);

        repositorioRequisicaoMedicamento.CadastrarRequisicaoEntrada(registro);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Requisição de Entrada Cadastrada!",
            $"O estoque do medicamento foi atualizado!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("saida/{medicamentoId:int}")]
    public IActionResult CadastrarSaida(int medicamentoId)
    {
        var pacientes = repositorioPaciente.SelecionarRegistros();
        var medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(medicamentoId);

        var cadastrarVM = new CadastrarRequisicaoSaidaViewModel(medicamentoId, pacientes);

        ViewBag.NomeMedicamento = medicamentoSelecionado.Nome;

        return View(cadastrarVM);
    }

    [HttpPost("saida/{medicamentoId:int}")]
    public IActionResult CadastrarSaida(int medicamentoId, CadastrarRequisicaoSaidaViewModel cadastrarVM)
    {
        var pacientes = repositorioPaciente.SelecionarRegistros();
        var medicamentos = repositorioMedicamento.SelecionarRegistros();

        var registro = cadastrarVM.ParaEntidade(pacientes, medicamentos);

        var medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(medicamentoId);

        medicamentoSelecionado.RemoverDoEstoque(registro);

        repositorioRequisicaoMedicamento.CadastrarRequisicaoSaida(registro);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Requisição de Saída Cadastrada!",
            $"O estoque do medicamento foi atualizado!"
        );

        return View("Notificacao", notificacaoVM);
    }
}

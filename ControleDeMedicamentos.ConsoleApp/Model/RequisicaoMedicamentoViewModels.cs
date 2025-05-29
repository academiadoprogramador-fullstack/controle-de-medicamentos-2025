using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Model;

public class CadastrarRequisicaoEntradaViewModel
{
    public Guid MedicamentoId { get; set; }
    public Guid FuncionarioId { get; set; }
    public int QuantidadeRequisitada { get; set; }
    public List<SelecionarFuncionarioViewModel> FuncionariosDisponiveis { get; set; }

    public CadastrarRequisicaoEntradaViewModel() { }

    public CadastrarRequisicaoEntradaViewModel(Guid medicamentoId, List<Funcionario> funcionarios)
    {
        MedicamentoId = medicamentoId;
        FuncionariosDisponiveis = new List<SelecionarFuncionarioViewModel>();

        foreach (var f in funcionarios)
        {
            var selecionarVM = new SelecionarFuncionarioViewModel(f.Id, f.Nome);

            FuncionariosDisponiveis.Add(selecionarVM);
        }
    }
}

public class CadastrarRequisicaoSaidaViewModel
{
    public Guid FuncionarioId { get; set; }
    public Guid PacienteId { get; set; }
    public List<SelecionarFuncionarioViewModel> FuncionariosDisponiveis { get; set; }
    public List<SelecionarPacienteViewModel> PacientesDisponiveis { get; set; }

    public CadastrarRequisicaoSaidaViewModel() { }

    public CadastrarRequisicaoSaidaViewModel(List<Funcionario> funcionarios, List<Paciente> pacientes)
    {
        FuncionariosDisponiveis = new List<SelecionarFuncionarioViewModel>();

        foreach (var p in funcionarios)
        {
            var selecionarVM = new SelecionarFuncionarioViewModel(p.Id, p.Nome);

            FuncionariosDisponiveis.Add(selecionarVM);
        }

        PacientesDisponiveis = new List<SelecionarPacienteViewModel>();

        foreach (var p in pacientes)
        {
            var selecionarVM = new SelecionarPacienteViewModel(p.Id, p.Nome);

            PacientesDisponiveis.Add(selecionarVM);
        }
    }
}

public class CadastrarRequisicaoSaidaCompletaViewModel
{
    public Guid FuncionarioId { get; set; }
    public string NomeFuncionario { get; set; }
    public Guid PacienteId { get; set; }
    public string NomePaciente { get; set; }

    public Guid PrescricaoId { get; set; }
    public List<SelecionarPrescricaoViewModel> PrescricoesDisponiveis { get; set; }

    public CadastrarRequisicaoSaidaCompletaViewModel() { }

    public CadastrarRequisicaoSaidaCompletaViewModel(
        Funcionario funcionario,
        Paciente paciente,
        List<Prescricao> prescicoes
    ) : this()
    {
        FuncionarioId = funcionario.Id;
        NomeFuncionario = funcionario.Nome;

        PacienteId = paciente.Id;
        NomePaciente = paciente.Nome;

        PrescricoesDisponiveis = new List<SelecionarPrescricaoViewModel>();

        foreach (var p in prescicoes)
        {
            var selecionarVM = new SelecionarPrescricaoViewModel(
                p.Id,
                p.Paciente.Nome,
                p.DataEmissao,
                p.MedicamentoPrescritos
            );

            PrescricoesDisponiveis.Add(selecionarVM);
        }
    }
}

public class VisualizarRequisicoesSaidaViewModel
{
    public List<DetalhesRequisicaoSaidaViewModel> Registros { get; }

    public VisualizarRequisicoesSaidaViewModel(List<RequisicaoSaida> requisicoes)
    {
        Registros = [];

        foreach (var r in requisicoes)
        {
            var detalhesVM = r.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesRequisicaoSaidaViewModel
{
    public Guid Id { get; set; }
    public string FuncionarioRequisitante { get; set; }
    public string Paciente { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public List<string> MedicamentoPrescritos { get; set; }

    public DetalhesRequisicaoSaidaViewModel(
        Guid id,
        string funcionarioRequisitante,
        string paciente,
        DateTime dataOcorrencia,
        List<MedicamentoPrescrito> medicamentosPrescritos
    )
    {
        Id = id;
        FuncionarioRequisitante = funcionarioRequisitante;
        Paciente = paciente;
        DataOcorrencia = dataOcorrencia;

        MedicamentoPrescritos = new List<string>();

        foreach (var m in medicamentosPrescritos)
        {
            MedicamentoPrescritos.Add(m.Medicamento.Nome);
        }
    }
}

public class SelecionarFuncionarioViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public SelecionarFuncionarioViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class SelecionarPacienteViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public SelecionarPacienteViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class SelecionarPrescricaoViewModel
{
    public Guid Id { get; set; }
    public string NomePaciente { get; set; }
    public DateTime DataEmissao { get; set; }
    public List<SelecionarMedicamentoPrescritoViewModel> MedicamentoPrescritos { get; set; }

    public SelecionarPrescricaoViewModel() { }

    public SelecionarPrescricaoViewModel(
        Guid id,
        string nomePaciente,
        DateTime dataEmissao,
        List<MedicamentoPrescrito> medicamentoPrescritos
    ) : this()
    {
        Id = id;
        NomePaciente = nomePaciente;
        DataEmissao = dataEmissao;

        MedicamentoPrescritos = new List<SelecionarMedicamentoPrescritoViewModel>();

        foreach (var m in medicamentoPrescritos)
        {
            var selecionarVM = new SelecionarMedicamentoPrescritoViewModel(m.Medicamento.Nome);

            MedicamentoPrescritos.Add(selecionarVM);
        }
    }

    public override string ToString()
    {
        var nomesMedicamentos = string.Join(", ", MedicamentoPrescritos);

        return string.Join(" - ", $"Emissão: {DataEmissao.ToShortDateString()}", $"[{nomesMedicamentos}]");
    }
}

public class SelecionarMedicamentoPrescritoViewModel
{
    public string Nome { get; set; }

    public SelecionarMedicamentoPrescritoViewModel(string nome)
    {
        Nome = nome;
    }

    public override string ToString()
    {
        return Nome;
    }
}
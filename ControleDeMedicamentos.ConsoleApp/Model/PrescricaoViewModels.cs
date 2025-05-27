using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;

namespace ControleDeMedicamentos.ConsoleApp.Model;

public class CadastrarPrescricaoViewModel
{
    public Guid PacienteId { get; set; }
    public List<SelecionarPacienteViewModel> PacientesDisponiveis { get; set; }

    public string CrmMedico { get; set; }

    public List<SelecionarMedicamentoViewModel> MedicamentosDisponiveis { get; set; }
    public List<DetalhesMedicamentoPrescritoViewModel> MedicamentoPrescritos { get; set; }

    public Guid MedicamentoId { get; set; }
    public string DosagemMedicamento { get; set; }
    public string PeriodoMedicamento { get; set; }

    public CadastrarPrescricaoViewModel()
    {
        PacientesDisponiveis = new List<SelecionarPacienteViewModel>();
        MedicamentosDisponiveis = new List<SelecionarMedicamentoViewModel>();
        MedicamentoPrescritos = new List<DetalhesMedicamentoPrescritoViewModel>();
    }

    public CadastrarPrescricaoViewModel(List<Paciente> pacientes, List<Medicamento> medicamentos) : this()
    {
        AdicionarPacientes(pacientes);
        AdicionarMedicamentos(medicamentos);
    }

    public void AdicionarPacientes(List<Paciente> pacientes)
    {
        foreach (var p in pacientes)
        {
            var selecionarPacienteVM = new SelecionarPacienteViewModel(p.Id, p.Nome);

            PacientesDisponiveis.Add(selecionarPacienteVM);
        }
    }

    public void AdicionarMedicamentos(List<Medicamento> medicamentos)
    {
        foreach (var m in medicamentos)
        {
            var selecionarMedicamentoVM = new SelecionarMedicamentoViewModel(m.Id, m.Nome);

            MedicamentosDisponiveis.Add(selecionarMedicamentoVM);
        }
    }
}

public class DetalhesMedicamentoPrescritoViewModel
{
    public Guid MedicamentoId { get; set; }
    public string Medicamento { get; set; }
    public string Dosagem { get; set; }
    public string Periodo { get; set; }

    public DetalhesMedicamentoPrescritoViewModel() { }

    public DetalhesMedicamentoPrescritoViewModel(
        Guid medicamentoId,
        string nomeMedicamento,
        string dosagem,
        string periodo
    ) : this()
    {
        MedicamentoId = medicamentoId;
        Medicamento = nomeMedicamento;
        Dosagem = dosagem;
        Periodo = periodo;
    }
}

public class SelecionarMedicamentoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public SelecionarMedicamentoViewModel() {}

    public SelecionarMedicamentoViewModel(Guid id, string nome) : this()
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarPrescricoesViewModel
{
    public List<DetalhesPrescricaoViewModel> Registros { get; }

    public VisualizarPrescricoesViewModel(List<Prescricao> prescricoes)
    {
        Registros = [];

        foreach (var p in prescricoes)
        {
            var detalhesVM = p.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesPrescricaoViewModel
{
    public Guid Id { get; set; }
    public string CrmMedico { get; set; }
    public string Paciente { get; set; }
    public DateTime DataEmissao { get; set; }

    public DetalhesPrescricaoViewModel(Guid id, string crmMedico, string paciente, DateTime dataEmissao)
    {
        Id = id;
        CrmMedico = crmMedico;
        Paciente = paciente;
        DataEmissao = dataEmissao;
    }
}

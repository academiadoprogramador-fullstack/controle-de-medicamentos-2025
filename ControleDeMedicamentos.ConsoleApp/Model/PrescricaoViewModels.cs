using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;

namespace ControleDeMedicamentos.ConsoleApp.Model;

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
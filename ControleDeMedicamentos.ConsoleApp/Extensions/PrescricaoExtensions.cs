using ControleDeMedicamentos.ConsoleApp.Model;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class PrescricaoExtensions
{
    public static DetalhesPrescricaoViewModel ParaDetalhesVM(this Prescricao prescricao)
    {
        return new DetalhesPrescricaoViewModel(
            prescricao.Id,
            prescricao.CrmMedico,
            prescricao.Paciente.Nome,
            prescricao.DataEmissao
        );
    }
}

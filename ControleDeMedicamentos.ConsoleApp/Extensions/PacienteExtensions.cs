using ControleDeMedicamentos.ConsoleApp.Model;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class PacienteExtensions
{
    public static Paciente ParaEntidade(this FormularioPacienteViewModel formularioVM)
    {
        return new Paciente(formularioVM.Nome, formularioVM.Telefone, formularioVM.CartaoSus);
    }

    public static DetalhesPacienteViewModel ParaDetalhesVM(this Paciente paciente)
    {
        return new DetalhesPacienteViewModel(
            paciente.Id,
            paciente.Nome,
            paciente.Telefone,
            paciente.CartaoSus
        );
    }
}
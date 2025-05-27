using ControleDeMedicamentos.ConsoleApp.Model;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class RequisicaoSaidaExtensions
{
    public static RequisicaoSaida ParaEntidade(
        this CadastrarRequisicaoSaidaViewModel formularioVM,
        List<Paciente> pacientes,
        List<Medicamento> medicamentos
    )
    {
        Paciente pacienteSelecionado = null;

        foreach (var f in pacientes)
        {
            if (f.Id == formularioVM.PacienteId)
                pacienteSelecionado = f;
        }

        Medicamento medicamentoSelecionado = null;

        foreach (var m in medicamentos)
        {
            if (m.Id == formularioVM.MedicamentoId)
                medicamentoSelecionado = m;
        }

        return new RequisicaoSaida(pacienteSelecionado, medicamentoSelecionado, formularioVM.QuantidadeRequisitada);
    }
}

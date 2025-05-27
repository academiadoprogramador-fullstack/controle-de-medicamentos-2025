using ControleDeMedicamentos.ConsoleApp.Model;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class RequisicaoSaidaExtensions
{
    public static RequisicaoSaida ParaEntidade(
        this CadastrarRequisicaoSaidaViewModel formularioVM,
        List<Funcionario> funcionarios,
        List<Medicamento> medicamentos,
        List<Prescricao> prescricoes
    )
    {
        Funcionario funcionarioSelecionado = null;

        foreach (var f in funcionarios)
        {
            if (f.Id == formularioVM.FuncionarioId)
                funcionarioSelecionado = f;
        }

        Medicamento medicamentoSelecionado = null;

        foreach (var m in medicamentos)
        {
            if (m.Id == formularioVM.MedicamentoId)
                medicamentoSelecionado = m;
        }

        Prescricao prescricaoSelecionada = null;

        foreach (var p in prescricoes)
        {
            if (p.Id == formularioVM.PrescricaoId)
                prescricaoSelecionada = p;
        }

        return new RequisicaoSaida(funcionarioSelecionado, medicamentoSelecionado);
    }
}

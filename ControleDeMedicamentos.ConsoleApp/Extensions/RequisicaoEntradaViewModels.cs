using ControleDeMedicamentos.ConsoleApp.Model;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class RequisicaoEntradaExtensions
{
    public static RequisicaoEntrada ParaEntidade(
        this CadastrarRequisicaoEntradaViewModel formularioVM, 
        List<Funcionario> funcionarios,
        List<Medicamento> medicamentos
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

        return new RequisicaoEntrada(funcionarioSelecionado, medicamentoSelecionado, formularioVM.QuantidadeRequisitada);
    }

    //public static DetalhesPacienteViewModel ParaDetalhesVM(this Paciente paciente)
    //{
    //    return new DetalhesPacienteViewModel(
    //        paciente.Id,
    //        paciente.Nome,
    //        paciente.Telefone,
    //        paciente.CartaoSus
    //    );
    //}
}

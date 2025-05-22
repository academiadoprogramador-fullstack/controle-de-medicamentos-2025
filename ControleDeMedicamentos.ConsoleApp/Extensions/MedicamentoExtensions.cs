using ControleDeMedicamentos.ConsoleApp.Model;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Extensions;

public static class MedicamentoExtensions
{
    public static Medicamento ParaEntidade(
        this FormularioMedicamentoViewModel formularioVM,
        List<Fornecedor> fornecedores
    )
    {
        Fornecedor fornecedorSelecionado = null;

        foreach (var f in fornecedores)
        {
            if (f.Id == formularioVM.FornecedorId)
                fornecedorSelecionado = f;
        }

        return new Medicamento(
            formularioVM.Nome,
            formularioVM.Descricao,
            fornecedorSelecionado
        );
    }

    public static DetalhesMedicamentoViewModel ParaDetalhesVM(this Medicamento medicamento)
    {
        return new DetalhesMedicamentoViewModel(
            medicamento.Id,
            medicamento.Nome,
            medicamento.Descricao,
            medicamento.Fornecedor.Nome,
            medicamento.QuantidadeEmEstoque,
            medicamento.EmFalta
        );
    }
}
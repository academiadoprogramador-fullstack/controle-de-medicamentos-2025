using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoMedicamento;

public class RequisicaoSaida
{
    public Guid Id { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public Funcionario Funcionario { get; set; }
    public Prescricao Prescricao { get; set; }

    [ExcludeFromCodeCoverage]
    public RequisicaoSaida() { }

    public RequisicaoSaida(
        Funcionario funcionario,
        Medicamento medicamento,
        Prescricao prescricao
    )
    {
        Id = Guid.NewGuid();
        DataOcorrencia = DateTime.Now;
        Funcionario = funcionario;
        Prescricao = prescricao;
    }

    public string Validar()
    {
        string erros = string.Empty;

        if (Funcionario == null)
            erros += "O campo \"Funcionário\" é obrigatório.";

        else if (Prescricao.MedicamentoPrescritos.Count < 1)
            erros += "O campo \"Quantidade Requisitada de Medicamentos\" necessita conter um valor positivo.";

        foreach (var medicamentoPrescrito in Prescricao.MedicamentoPrescritos)
        {
            var quantidadeEmEstoque = medicamentoPrescrito.Medicamento.QuantidadeEmEstoque;

            if (QuantidadeRequisitada > quantidadeEmEstoque)
                    erros += "O campo \"Quantidade Requisitada\" ultrapassa a quantidade em estoque do medicamento.";

        }

        return erros;
    }
}

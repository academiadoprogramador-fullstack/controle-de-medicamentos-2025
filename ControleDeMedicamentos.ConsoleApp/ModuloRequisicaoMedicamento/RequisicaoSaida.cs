using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoMedicamento;

public class RequisicaoSaida
{
    public Guid Id { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public Paciente Paciente { get; set; }
    public Medicamento Medicamento { get; set; }
    public int QuantidadeRequisitada { get; set; }

    [ExcludeFromCodeCoverage]
    public RequisicaoSaida() { }

    public RequisicaoSaida(
        Paciente paciente,
        Medicamento medicamento,
        int quantidadeRequisitada
    )
    {
        Id = Guid.NewGuid();
        DataOcorrencia = DateTime.Now;
        Paciente = paciente;
        Medicamento = medicamento;
        QuantidadeRequisitada = quantidadeRequisitada;
    }

    public string Validar()
    {
        string erros = string.Empty;

        if (Paciente == null)
            erros += "O campo \"Paciente\" é obrigatório.";

        if (Medicamento == null)
            erros += "O campo \"Medicamento\" é obrigatório.";

        else if (QuantidadeRequisitada < 1)
            erros += "O campo \"Quantidade Requisitada\" necessita conter um valor positivo.";

        else if (QuantidadeRequisitada > Medicamento.QuantidadeEmEstoque)
            erros += "O campo \"Quantidade Requisitada\" ultrapassa a quantidade em estoque do medicamento.";

        return erros;
    }
}

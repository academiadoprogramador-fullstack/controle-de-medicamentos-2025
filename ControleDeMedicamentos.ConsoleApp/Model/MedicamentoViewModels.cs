using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Model;

public abstract class FormularioMedicamentoViewModel
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int FornecedorId { get; set; }
    public List<SelecionarFornecedorViewModel> FornecedoresDisponiveis { get; set; }

    protected FormularioMedicamentoViewModel()
    {
        FornecedoresDisponiveis = new List<SelecionarFornecedorViewModel>();
    }
}

public class SelecionarFornecedorViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SelecionarFornecedorViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class CadastrarMedicamentoViewModel : FormularioMedicamentoViewModel
{
    public CadastrarMedicamentoViewModel() { }

    public CadastrarMedicamentoViewModel(List<Fornecedor> fornecedores)
    {
        foreach (var f in fornecedores)
        {
            var selecionarVM = new SelecionarFornecedorViewModel(f.Id, f.Nome);

            FornecedoresDisponiveis.Add(selecionarVM);
        }
    }
}

public class EditarMedicamentoViewModel : FormularioMedicamentoViewModel
{
    public int Id { get; set; }

    public EditarMedicamentoViewModel() { }

    public EditarMedicamentoViewModel(
        int id,
        string nome,
        string descricao,
        int fornecedorId,
        List<Fornecedor> fornecedores
    )
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        FornecedorId = fornecedorId;

        foreach (var f in fornecedores)
        {
            var selecionarVM = new SelecionarFornecedorViewModel(f.Id, f.Nome);

            FornecedoresDisponiveis.Add(selecionarVM);
        }
    }
}

public class ExcluirMedicamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirMedicamentoViewModel() { }

    public ExcluirMedicamentoViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarMedicamentosViewModel
{
    public List<DetalhesMedicamentoViewModel> Registros { get; }

    public VisualizarMedicamentosViewModel(List<Medicamento> medicamentos)
    {
        Registros = new List<DetalhesMedicamentoViewModel>();

        foreach (var m in medicamentos)
        {
            var detalhesVM = m.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesMedicamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string NomeFornecedor { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public bool EmFalta { get; set; }

    public DetalhesMedicamentoViewModel(int id, string nome, string descricao, string nomeFornecedor, int quantidade, bool emFalta)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        NomeFornecedor = nomeFornecedor;
        QuantidadeEmEstoque = quantidade;
        EmFalta = emFalta;
    }
}

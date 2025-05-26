using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System;

namespace ControleDeMedicamentos.ConsoleApp.Model;

public abstract class FormularioFornecedorViewModel
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CNPJ { get; set; }
}

public class CadastrarFornecedorViewModel : FormularioFornecedorViewModel
{
    public CadastrarFornecedorViewModel() { }

    public CadastrarFornecedorViewModel(string nome, string telefone, string cnpj) : this()
    {
        Nome = nome;
        Telefone = telefone;
        CNPJ = cnpj;
    }
}

public class EditarFornecedorViewModel : FormularioFornecedorViewModel
{
    public Guid Id { get; set; }

    public EditarFornecedorViewModel() { }

    public EditarFornecedorViewModel(Guid id, string nome, string telefone, string cnpj) : this()
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CNPJ = cnpj;
    }
}

public class ExcluirFornecedorViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public ExcluirFornecedorViewModel() { }

    public ExcluirFornecedorViewModel(Guid id, string nome) : this()
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarFornecedoresViewModel
{
    public List<DetalhesFornecedorViewModel> Registros { get; }

    public VisualizarFornecedoresViewModel(List<Fornecedor> fornecedores)
    {
        Registros = [];

        foreach (var f in fornecedores)
        {
            var detalhesVM = f.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesFornecedorViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CNPJ { get; set; }

    public DetalhesFornecedorViewModel(Guid id, string nome, string telefone, string cnpj)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CNPJ = cnpj;
    }
}

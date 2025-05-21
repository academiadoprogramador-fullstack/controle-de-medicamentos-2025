using ControleDeMedicamentos.ConsoleApp.Extensions;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleDeMedicamentos.ConsoleApp.Model;

public abstract class FormularioFuncionarioViewModel
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
}

public class CadastrarFuncionarioViewModel : FormularioFuncionarioViewModel
{
    public CadastrarFuncionarioViewModel() { }

    public CadastrarFuncionarioViewModel(string nome, string telefone, string cpf) : this()
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }
}

public class EditarFuncionarioViewModel : FormularioFuncionarioViewModel
{
    public int Id { get; set; }

    public EditarFuncionarioViewModel() { }

    public EditarFuncionarioViewModel(int id, string nome, string telefone, string cpf) : this()
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }
}

public class ExcluirFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirFuncionarioViewModel() { }

    public ExcluirFuncionarioViewModel(int id, string nome) : this()
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarFuncionariosViewModel
{
    public List<DetalhesFuncionarioViewModel> Registros { get; }

    public VisualizarFuncionariosViewModel(List<Funcionario> funcionarios)
    {
        Registros = [];

        foreach (var f in funcionarios)
        {
            var detalhesVM = f.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }

    public DetalhesFuncionarioViewModel(int id, string nome, string telefone, string cpf)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }
}
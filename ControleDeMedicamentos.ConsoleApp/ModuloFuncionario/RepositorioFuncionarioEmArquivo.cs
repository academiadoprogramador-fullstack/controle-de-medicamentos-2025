using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

public class RepositorioFuncionarioEmArquivo : RepositorioBaseEmArquivo<Funcionario>
{
    public RepositorioFuncionarioEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Funcionario> ObterRegistros()
    {
        return contexto.Funcionarios;
    }
}

using ControleDeMedicamentos.Dominio.ModuloFuncionario;
using ControleDeMedicamentos.Infraestrutura.Arquivos.Compartilhado;

namespace ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloFuncionario;

public class RepositorioFuncionarioEmArquivo : RepositorioBaseEmArquivo<Funcionario>, IRepositorioFuncionario
{
    public RepositorioFuncionarioEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Funcionario> ObterRegistros()
    {
        return contexto.Funcionarios;
    }
}

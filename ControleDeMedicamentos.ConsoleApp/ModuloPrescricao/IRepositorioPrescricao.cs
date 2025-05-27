using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;

public interface IRepositorioPrescricao
{
    public void CadastrarRegistro(Prescricao novoRegistro);
    public List<Prescricao> SelecionarRegistros();
}

public class RepositorioPrescricaoEmArquivo : IRepositorioPrescricao
{
    private ContextoDados contexto;
    private List<Prescricao> registros = new List<Prescricao>();

    public RepositorioPrescricaoEmArquivo(ContextoDados contexto)
    {
        this.contexto = contexto;
        registros = contexto.Prescricoes;
    }

    public void CadastrarRegistro(Prescricao novoRegistro)
    {
        registros.Add(novoRegistro);

        contexto.Salvar();
    }

    public List<Prescricao> SelecionarRegistros()
    {
        return registros;
    }
}

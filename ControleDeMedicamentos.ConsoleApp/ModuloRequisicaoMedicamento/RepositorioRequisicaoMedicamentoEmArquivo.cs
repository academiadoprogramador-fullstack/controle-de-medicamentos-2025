using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

public class RepositorioRequisicaoMedicamentoEmArquivo : IRepositorioRequisicaoMedicamento
{
    private ContextoDados contexto;
    private List<RequisicaoEntrada> requisicoesEntrada;
    private List<RequisicaoSaida> requisicoesSaida;

    public RepositorioRequisicaoMedicamentoEmArquivo(ContextoDados contexto)
    {
        this.contexto = contexto;

        requisicoesEntrada = contexto.RequisicoesEntrada;
        requisicoesSaida = contexto.RequisicoesSaida;
    }

    public void CadastrarRequisicaoEntrada(RequisicaoEntrada requisicao)
    {
        requisicoesEntrada.Add(requisicao);

        contexto.Salvar();
    }

    public void CadastrarRequisicaoSaida(RequisicaoSaida requisicao)
    {
        requisicoesSaida.Add(requisicao);

        contexto.Salvar();
    }

    public List<RequisicaoSaida> SelecionarRequisicoesSaida()
    {
        return requisicoesSaida;
    }
}
namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

public interface IRepositorioRequisicaoMedicamento
{
    public void CadastrarRequisicaoEntrada(RequisicaoEntrada requisicao);
    public void CadastrarRequisicaoSaida(RequisicaoSaida requisicao);
}
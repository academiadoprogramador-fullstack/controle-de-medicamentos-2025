namespace ControleDeMedicamentos.Dominio.ModuloRequisicaoMedicamentos;

public interface IRepositorioRequisicaoMedicamento
{
    public void CadastrarRequisicaoEntrada(RequisicaoEntrada requisicao);
    public void CadastrarRequisicaoSaida(RequisicaoSaida requisicao);
    public List<RequisicaoSaida> SelecionarRequisicoesSaida();
}
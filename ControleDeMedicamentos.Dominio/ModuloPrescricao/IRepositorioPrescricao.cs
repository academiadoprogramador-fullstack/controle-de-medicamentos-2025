namespace ControleDeMedicamentos.Dominio.ModuloPrescricao;

public interface IRepositorioPrescricao
{
    public void CadastrarRegistro(Prescricao novoRegistro);
    public List<Prescricao> SelecionarRegistros();
}

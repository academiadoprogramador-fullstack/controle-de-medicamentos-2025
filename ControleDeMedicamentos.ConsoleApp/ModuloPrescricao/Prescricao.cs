using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;

public class Prescricao : EntidadeBase<Prescricao>
{
    public string CrmMedico { get; set; }
    public DateTime DataEmissao { get; set; }
    public Paciente Paciente { get; set; }
    public List<MedicamentoPrescrito> MedicamentoPrescritos { get; set; }

    public Prescricao() { }

    public Prescricao(string crmMedico, Paciente paciente, List<MedicamentoPrescrito> medicamentoPrescritos)
    {
        Id = Guid.NewGuid();
        DataEmissao = DateTime.Now;
        CrmMedico = crmMedico;

        Paciente = paciente;
        MedicamentoPrescritos = medicamentoPrescritos;
    }

    public override void AtualizarRegistro(Prescricao registroEditado)
    {
        throw new NotImplementedException();
    }

    public override string Validar()
    {
        throw new NotImplementedException();
    }
}

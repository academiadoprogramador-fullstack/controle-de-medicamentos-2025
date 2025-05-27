using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricao;

public class MedicamentoPrescrito
{
    public Guid Id { get; set; }
    public Medicamento Medicamento { get; set; }
    public string Dosagem { get; set; }
    public string Periodo { get; set; }

    public MedicamentoPrescrito() { }

    public MedicamentoPrescrito(Medicamento medicamento, string dosagem, string periodo)
    {
        Id = Guid.NewGuid();
        Medicamento = medicamento;
        Dosagem = dosagem;
        Periodo = periodo;
    }
}

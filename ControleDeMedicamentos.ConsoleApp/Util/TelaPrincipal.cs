using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.Util;

public class TelaPrincipal
{
    private char opcaoPrincipal;

    private ContextoDados contexto;
    private TelaPaciente telaPaciente;

    public TelaPrincipal()
    {
        contexto = new ContextoDados(true);

        IRepositorioPaciente repositorioPaciente = new RepositorioPacienteEmArquivo(contexto);

        telaPaciente = new TelaPaciente(repositorioPaciente);
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("|        Controle de Medicamentos        |");
        Console.WriteLine("------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Pacientes");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        opcaoPrincipal = Console.ReadLine()[0];
    }

    public ITelaCrud ObterTela()
    {
        if (opcaoPrincipal == '1')
            return telaPaciente;

        return null;
    }
}
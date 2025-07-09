using ControleDeMedicamentos.ConsoleApp.DepedencyInjection;
using ControleDeMedicamentos.Dominio.ModuloFornecedor;
using ControleDeMedicamentos.Dominio.ModuloFuncionario;
using ControleDeMedicamentos.Dominio.ModuloMedicamento;
using ControleDeMedicamentos.Dominio.ModuloPaciente;
using ControleDeMedicamentos.Dominio.ModuloPrescricao;
using ControleDeMedicamentos.Dominio.ModuloRequisicaoMedicamentos;
using ControleDeMedicamentos.Infraestrutura.Arquivos.Compartilhado;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloFornecedor;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloFuncionario;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloMedicamento;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloPaciente;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloPrescricao;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloRequisicaoMedicamento;

namespace ControleDeMedicamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped((_) => new ContextoDados(true));
        builder.Services.AddScoped<IRepositorioFornecedor, RepositorioFornecedorEmArquivo>();
        builder.Services.AddScoped<IRepositorioFuncionario, RepositorioFuncionarioEmArquivo>();
        builder.Services.AddScoped<IRepositorioPaciente, RepositorioPacienteEmArquivo>();
        builder.Services.AddScoped<IRepositorioMedicamento, RepositorioMedicamentoEmArquivo>();
        builder.Services.AddScoped<IRepositorioPrescricao, RepositorioPrescricaoEmArquivo>();
        builder.Services.AddScoped<IRepositorioRequisicaoMedicamento, RepositorioRequisicaoMedicamentoEmArquivo>();

        builder.Services.AddSerilogConfig(builder.Logging);

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        app.MapDefaultControllerRoute();

        app.Run();
    }
}

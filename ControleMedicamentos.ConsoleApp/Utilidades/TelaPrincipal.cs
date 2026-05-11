using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleMedicamentos.ConsoleApp.Utilidades;

public class TelaPrincipal
{
    private readonly IRepositorio<Fornecedor> repositorioFornecedor;
    private readonly IRepositorio<Paciente> repositorioPaciente;
    private readonly IRepositorio<Medicamentos> repositorioMedicamento;
    private readonly IRepositorio<Funcionario> repositorioFuncionario;
    

    public TelaPrincipal(
        IRepositorio<Fornecedor> repositorioFornecedor,
        IRepositorio<Paciente> repositorioPaciente,
        IRepositorio<Medicamentos> repositorioMedicamento,
        IRepositorio<Funcionario> repositorioFuncionario
    )
    {
        this.repositorioFornecedor = repositorioFornecedor;
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFuncionario = repositorioFuncionario;
    }

    public ITelaOpcoes? ApresentarMenuOpcoesPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Controle de Medicamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gestão de Fornecedores");
        Console.WriteLine("2 - Gestão de Pacientes");
        Console.WriteLine("3 - Gestão de Medicamentos");
        Console.WriteLine("4 - Gestão de Funcionários");
        Console.WriteLine("5 - Gestão de Estoque");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaFornecedor(repositorioFornecedor);

        if (opcaoMenuPrincipal == "2")
            return new TelaPaciente(repositorioPaciente);

        if (opcaoMenuPrincipal == "3")
            return new TelaMedicamentos(repositorioMedicamento);

        if (opcaoMenuPrincipal == "4")
            return new TelaFuncionario(repositorioFuncionario);

        return null;
    }
}

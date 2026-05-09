using System;
using System.Reflection;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPacientes;

public class TelaPaciente : TelaBase<Paciente>, ITelaCrud, ITelaOpcoes
{
    public TelaPaciente(IRepositorio<Paciente> repositorio) : base("Paciente", repositorio)
    {

    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualizando Pacientes");

        List<Paciente> pacientes = repositorio.SelecionarRegistros();


        Console.WriteLine(
            "{0, -5} | {1, -30} | {2, -15} | {3, -15} | {4, -15}",
            "Id", "Nome", "Telefone", "CPF", "Cartão SUS"
        );

        foreach (Paciente p in pacientes)
        {
            Console.WriteLine(
                "{0, -5} | {1, -30} | {2, -15} | {3, -15} | {4, -15}",
                p.Id, p.Nome, p.Telefone, p.CPF, p.CartaoSus);
        }
    }

    protected override Paciente ObterDadosCadastrais()
    {
        Paciente paciente = new Paciente();

        Console.Write("Digite o nome: ");
        paciente.Nome = Console.ReadLine()!;

        Console.Write("Digite o Telefone (ex: (49) 99999-9999): ");
        paciente.Telefone = Console.ReadLine()!;


        RepositorioPacienteEmArquivo repoPaciente = (RepositorioPacienteEmArquivo)repositorio;

        while (true)
        {
            Console.Write("Digite o CPF (11 dígitos): ");
            string cpfDigitado = Console.ReadLine()!;

            if (repoPaciente.CPFJaExiste(cpfDigitado))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Já existe um paciente com este CPF.");
                Console.ResetColor();
                continue;
            }

            paciente.CPF = cpfDigitado;
            break;
        }

        Console.Write("Digite o Cartão SUS (15 dígitos): ");
        paciente.CartaoSus = Console.ReadLine()!;

        return paciente;

    }
}
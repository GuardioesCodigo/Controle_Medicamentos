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

        List<Paciente> pacientes = repositorio.SelecionarTodos();


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

        Console.ReadLine();
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

            paciente.CPF = cpfDigitado;

            List<string> erros = paciente.Validar();
            bool formatoInvalido = erros.Any(e => e.Contains("CPF"));

            bool duplicado = repoPaciente.CPFJaExiste(paciente.CPF);

            if (formatoInvalido)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Formatando errado! Digite exatamente 11 números.");
                Console.ResetColor();
            }
            else if (duplicado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Este CPF já pertence a outro paciente.");
                Console.ResetColor();
            }
            else
            {
                break;
            }

        }

        while (true)
        {
            Console.Write("Digite o Cartão SUS (15 dígitos): ");
            paciente.CartaoSus = Console.ReadLine()!;

            List<string> erros = paciente.Validar();
            bool formatoInvalido = erros.Any(e => e.Contains("SUS"));
            bool duplicado = repoPaciente.CartaoSusJaExiste(paciente.CartaoSus);

            if (formatoInvalido)
            {
                Console.WriteLine("Formato do Cartão SUS inválido! (Devem ser 15 dígitos)");
            }
            else if (duplicado)
            {
                Console.WriteLine("Erro: Este Cartão SUS já pertence a outro paciente.");
            }
            else
            {
                break; // Sai do loop se estiver tudo OK
            }
        }
        return paciente;
    }
}
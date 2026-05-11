using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Utilidades;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionarios;

public class TelaFuncionario : TelaBase<Funcionario>, ITelaOpcoes, ITelaCrud
{
    public TelaFuncionario(IRepositorio<Funcionario> repositorio) 
    : base("Funcionario", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        ExibirCabecalho("Vizualização de Funcionarios");
   
        List<Funcionario> funcionarios = new List<Funcionario>();

        if (funcionarios.Count == 0)
            Notificador.ExibirMensagem("Nenhum registro de Funcionário encontrado");

        foreach (Funcionario f in funcionarios)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -20}",
                f.Id, f.Nome, f.Telefone, f.Cpf
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Funcionario ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do Funcionário: ");
        string nomeFuncionario = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do Funcionário: ");
        string telefoneFuncionario = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o CPF do Funcionário: ");
        string cpfFuncionario = Console.ReadLine() ?? string.Empty;

        return new Funcionario(nomeFuncionario, telefoneFuncionario, cpfFuncionario);
    }

    protected override List<string> ValidarRegistroDuplicado(Funcionario novaEntidade, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        List<Funcionario> funcionarios = new List<Funcionario>();

        foreach (Funcionario f in funcionarios)
        {
            if (f.Id != idIgnorado && f.Cpf == novaEntidade.Cpf)
            {
                erros.Add($"Já existe um Funcionario com o CPF \"{novaEntidade.Cpf}\"");
            }
        }

        return erros;
    }

}

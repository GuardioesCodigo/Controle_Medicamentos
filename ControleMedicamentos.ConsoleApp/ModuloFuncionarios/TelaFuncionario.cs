using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionarios;

public class TelaFuncionario : TelaBase<Funcionario>, ITelaOpcoes, ITelaCrud
{
    public TelaFuncionario(IRepositorio<Funcionario> repositorio) 
    : base("Funcionario", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        throw new NotImplementedException();
    }

    protected override Funcionario ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do Funcionário: ");
        string nomeFuncionario = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do Funcionário: ");
        string telefoneFuncionario = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o cpf do Funcionário: ");
        string cpfFuncionario = Console.ReadLine() ?? string.Empty;

        return new Funcionario(nomeFuncionario, telefoneFuncionario, cpfFuncionario);
    }

    protected override List<string> ValidarRegistroDuplicado(Funcionario novaEntidade, string? idIgnorado = null)
    {
        return base.ValidarRegistroDuplicado(novaEntidade, idIgnorado);
    }

}

using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Utilidades;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedores;

public class TelaFornecedor : TelaBase<Fornecedor>, ITelaOpcoes, ITelaCrud
{
    public TelaFornecedor(
        IRepositorio<Fornecedor> repositorio
        )  : base("Fornecedor", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {

    }

    protected override Fornecedor ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do fornecedor: ");
        string nomeFornecedor = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o Telefone do fornecedor: ");
        string telefoneFornecedor = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o CNPJ do fornecedor: ");
        string cnpjFornecedor = Console.ReadLine() ?? string.Empty;

        return new Fornecedor(nomeFornecedor, telefoneFornecedor, cnpjFornecedor);
    }
}

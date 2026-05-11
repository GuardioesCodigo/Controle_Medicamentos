using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Utilidades;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedores;

public class TelaFornecedor : TelaBase<Fornecedor>, ITelaOpcoes, ITelaCrud
{
    public TelaFornecedor(IRepositorio<Fornecedor> repositorio) 
    : base("Fornecedor", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Fornecedores");

        List<Fornecedor> fornecedores = repositorio.SelecionarTodos();

        if (fornecedores.Count == 0)
        {
            Notificador.ExibirMensagem("Nenhum fornecedor registrado");
        }

        foreach (Fornecedor f in fornecedores)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -20}",
                f.Id, f.Nome, f.Telefone, f.Cnpj
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
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

    protected override List<string> ValidarRegistroDuplicado(Fornecedor novaEntidade, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        List<Fornecedor> fornecedores = repositorio.SelecionarTodos();

        foreach (Fornecedor f in fornecedores)
        {
            if (f.Id != idIgnorado && f.Cnpj == novaEntidade.Cnpj)
            {
                erros.Add($"Já existe um Fornecedor com o CNPJ \"{novaEntidade.Cnpj}\"");
            }
        }

        return erros;
    }
}
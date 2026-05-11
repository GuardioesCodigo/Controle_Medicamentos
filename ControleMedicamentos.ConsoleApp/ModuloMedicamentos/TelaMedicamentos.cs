using System;
using System.Security.Cryptography.X509Certificates;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

public class TelaMedicamentos : TelaBase<Medicamentos>, ITelaCrud, ITelaOpcoes
{

    public TelaMedicamentos(IRepositorio<Medicamentos> repositorio) : base("Medicamentos", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualizando Medicamentos");

        List<Medicamentos> medicamentos = repositorio.SelecionarRegistros();

        if (medicamentos.Count == 0)
        {
            Console.WriteLine("Nenhum medicamento cadastrado.");
            return;
        }

        Console.WriteLine(
        "{0, -5} | {1, -20} | {2, -20} | {3, -10} | {4, -15}",
        "Id", "Nome", "Fornecedor", "Qtd", "Status"
    );

        foreach (Medicamentos medicamento in medicamentos)
        {
            string status = "OK";
            if (medicamento.EstaEmFalta)
            {
                Console.ForegroundColor = ConsoleColor.Yellow; ;
                status = "EM FALTA";
            }

            Console.WriteLine(
            "{0, -5} | {1, -20} | {2, -20} | {3, -10} | {4, -15}",
            medicamento.Id, medicamento.Nome, medicamento.Fornecedor, medicamento.Quantidade, status
        );

            Console.ResetColor();
        }
    }

    protected override Medicamentos ObterDadosCadastrais()
    {
        Medicamentos medicamento = new Medicamentos();

        Console.Write("Digite o nome: ");
        medicamento.Nome = Console.ReadLine()!;

        Console.Write("Digite a descrição: ");
        medicamento.Descricao = Console.ReadLine()!;

        Console.Write("Digite o fornecedor: ");
        medicamento.Fornecedor = Console.ReadLine()!;

        while (true)
        {
            Console.WriteLine("Digite a quantidade em estoque: ");
            if (int.TryParse(Console.ReadLine(), out int qtdDigitada) && qtdDigitada >= 0)
            {
                medicamento.Quantidade = qtdDigitada;
                break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro: Digite um número inteiro maior ou igual a zero.");
            Console.ResetColor();
        }
        return medicamento;
    }

    public override void Cadastrar()
    {

        RepositorioMedicamentosEmArquivo repo = (RepositorioMedicamentosEmArquivo)repositorio;

        ExibirCabecalho("Cadastrando Medicamento");

        Medicamentos novoMedicamento = ObterDadosCadastrais();

        List<string> erros = novoMedicamento.Validar();

        if (erros.Count > 0)
        {
            ExibirErros(erros);
            return;
        }

        if (repo.MedicamentoJaExiste(novoMedicamento.Nome))
        {
            Medicamentos medicamentoExistente = repo.SelecionarPorNome(novoMedicamento.Nome);
            medicamentoExistente.Quantidade += novoMedicamento.Quantidade;

            repo.GravaMudancas();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nO medicamento '{novoMedicamento.Nome}' já consta no sistema.");
            Console.WriteLine($"Foram adicionadas {novoMedicamento.Quantidade} unidades ao estoque atual.");
            Console.ResetColor();
        }

        else
        {
            repositorio.Cadastrar(novoMedicamento);
            Console.WriteLine("\nMedicamento cadastrado com sucesso!");
        }

        Console.ReadLine();
    }
}

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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhum medicamento cadastrado.");
            Console.ResetColor();


            if (deveExibirCabecalho)
            {
                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
            return;
        }

        Console.WriteLine(
            "{0, -5} | {1, -20} | {2, -20} | {3, -10} | {4, -15}",
            "Id", "Nome", "Fornecedor", "Qtd", "Status"
        );
        Console.WriteLine("---------------------------------------------------------------------------");


        foreach (Medicamentos m in medicamentos)
        {
            if (m.EstaEmFalta)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (m.Quantidade < 20)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(
                "{0, -5} | {1, -20} | {2, -20} | {3, -10} | {4, -15}",
                m.Id, m.Nome, m.Fornecedor, m.Quantidade, m.Status
            );

            Console.ResetColor();
        }


        if (deveExibirCabecalho)
        {
            Console.WriteLine("\nDigite [S] para voltar ao menu inicial:");

            while (Console.ReadLine()?.ToLower() != "s")
            {
                Console.WriteLine("Opção inválida. Digite [s] para sair:");
            }
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
        ExibirCabecalho("Cadastrando Medicamento");

        Medicamentos novoMedicamento;
        List<string> erros;

        // Loop interno para garantir que o medicamento seja válido antes de prosseguir
        while (true)
        {
            novoMedicamento = (Medicamentos)ObterDadosCadastrais(); // Cast para o seu tipo
            erros = novoMedicamento.Validar();

            if (erros.Count == 0)
                break;

            ExibirErros(erros);
            Console.WriteLine("\nPressione Enter para tentar novamente...");
            Console.ReadLine();
            ExibirCabecalho("Cadastrando Medicamento");
        }

        // Agora sim, a lógica de reposição que fizemos
        RepositorioMedicamentosEmArquivo repo = (RepositorioMedicamentosEmArquivo)repositorio;

        if (repo.MedicamentoJaExiste(novoMedicamento.Nome))
        {
            Medicamentos medicamentoExistente = repo.SelecionarPorNome(novoMedicamento.Nome);
            medicamentoExistente.Quantidade += novoMedicamento.Quantidade;
            repo.GravaMudancas();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nEstoque atualizado! {novoMedicamento.Nome} agora tem {medicamentoExistente.Quantidade} unidades.");
            Console.ResetColor();
        }
        else
        {
            repo.Cadastrar(novoMedicamento);
            Console.WriteLine("\nMedicamento cadastrado com sucesso!");
        }

        Console.ReadLine(); // Pausa para o usuário ler a confirmação
    }
}

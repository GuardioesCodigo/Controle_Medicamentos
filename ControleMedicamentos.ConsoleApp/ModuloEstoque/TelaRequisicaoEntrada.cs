using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloEstoque;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public class TelaRequisicaoEntrada : TelaBase<RequisicaoEntrada>, ITelaCrud
{
    private RepositorioMedicamentosEmArquivo repoMedicamento;
    private RepositorioFuncionariosEmArquivo repoFuncionario;
    private TelaMedicamentos telaMedicamento;
    private TelaFuncionario telaFuncionario;


    public TelaRequisicaoEntrada(
        IRepositorio<RequisicaoEntrada> repoRequisicao,
        IRepositorio<Medicamentos> repoMedicamento,
        IRepositorio<Funcionario> repoFuncionario,
        TelaMedicamentos telaMedicamento,
        TelaFuncionario telaFuncionario) : base("Cadastro de Requisição de Entrada", (IRepositorio<RequisicaoEntrada>)repoRequisicao)
    {
        this.repoMedicamento = (RepositorioMedicamentosEmArquivo)repoMedicamento;
        this.repoFuncionario = (RepositorioFuncionariosEmArquivo)repoFuncionario;
        this.telaMedicamento = telaMedicamento;
        this.telaFuncionario = telaFuncionario;
    }

    protected override RequisicaoEntrada ObterDadosCadastrais()
    {
        return ObterRegistro();
    }

    protected RequisicaoEntrada ObterRegistro()
    {

        telaMedicamento.VisualizarTodos(false);
        Console.Write("\nDigite o ID do Medicamento: ");
        string idMed = Console.ReadLine() ?? "";
        Medicamentos med = repoMedicamento.SelecionarPorId(idMed)!;


        telaFuncionario.VisualizarTodos(false);
        Console.Write("\nDigite o ID do Funcionário: ");
        string idFunc = Console.ReadLine() ?? "";
        Funcionario func = repoFuncionario.SelecionarPorId(idFunc)!;

        Console.Write("Digite a quantidade: ");
        int qtd = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Digite a data (ex: 11/05/2026): ");
        DateTime data;
        if (!DateTime.TryParse(Console.ReadLine(), out data))
        {
            data = DateTime.Now;
        }

        return new RequisicaoEntrada(med, func, qtd, data);
    }

    public override string ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Estoque - Entradas");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Registrar Entrada");
        Console.WriteLine("2 - Editar Registro de Entrada"); // Se você permitir editar
        Console.WriteLine("3 - Excluir Registro de Entrada");
        Console.WriteLine("4 - Visualizar Entradas Realizadas");
        Console.WriteLine("S - Voltar ao Menu Principal");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        return Console.ReadLine()?.ToUpper() ?? "";
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.Clear();
            Console.WriteLine("--- Visualizando Requisições de Entrada ---");
        }

        List<RequisicaoEntrada> registros = repositorio.SelecionarTodos();

        if (registros.Count == 0)
        {
            Console.WriteLine("Nenhum registro cadastrado.");
            return;
        }

        foreach (RequisicaoEntrada r in registros)
        {
            string nomeMed = r.Medicamento?.Nome ?? "Não encontrado";
            string nomeFunc = r.Funcionario?.Nome ?? "Não encontrado";

            // CORRIGIDO: Era r.id, agora é r.Id (com I maiúsculo)
            Console.WriteLine($"ID: {r.Id} | Medicamento: {nomeMed} | Qtd: {r.Quantidade} | Funcionário: {nomeFunc}");
        }

        if (deveExibirCabecalho)
            Console.ReadLine();
    }
}
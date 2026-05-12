using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPacientes;
using ControleMedicamentos.ConsoleApp.Utilidades;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public class TelaRequisicaoSaida : TelaBase<RequisicaoDeSaida>, ITelaOpcoes, ITelaCrud
{
    private readonly IRepositorio<Paciente> repositorioPaciente;
    private readonly IRepositorio<Medicamentos> repositorioMedicamento;
    private TelaPaciente telaPaciente;
    private TelaMedicamentos telaMedicamentos;
    public TelaRequisicaoSaida(
        IRepositorio<RequisicaoDeSaida> repositorio,
        IRepositorio<Paciente> repositorioPaciente,
        IRepositorio<Medicamentos> repositorioMedicamento,
        TelaPaciente telaPaciente,
        TelaMedicamentos telaMedicamentos)
        : base("RequisicaoDeSaida", repositorio)
    {
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioPaciente = repositorioPaciente;
        this.telaMedicamentos = telaMedicamentos;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Vizualização de Requisições de saída");

        List<RequisicaoDeSaida> requisicaoDeSaidas = repositorio.SelecionarTodos();

        if (requisicaoDeSaidas.Count == 0)
        {
            Notificador.ExibirMensagem("Nenhuma requisição de saída registrada!");
        }

        foreach (RequisicaoDeSaida Rs in requisicaoDeSaidas)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -20}",
                Rs.Id, Rs.Paciente.Nome, Rs.MedicamentoRequisitado.Nome, Rs.Data
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override RequisicaoDeSaida ObterDadosCadastrais()
    {

        // telaPaciente.VisualizarTodos(false);
        Console.Write("Digite o nome do Paciente: ");
        string nomePaciente = Console.ReadLine() ?? string.Empty;

        telaMedicamentos.VisualizarTodos(false);
        Console.Write("Digite o nome do medicamento: ");
        string nomeMedicamento = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite a data da requisição de saída: ");
        string textoData = Console.ReadLine() ?? string.Empty;

        DateTime dataRequisicaoSaida;

        while (!DateTime.TryParse(textoData, out dataRequisicaoSaida))
        {
            Console.Write("Data inválida. Digite novamente: ");
            textoData = Console.ReadLine() ?? string.Empty;
        }

        Paciente? pacienteSelecionado = repositorioPaciente.SelecionarTodos().FirstOrDefault(p => p.Nome == nomePaciente);

        if (pacienteSelecionado == null)
        {
            Console.WriteLine("Paciente não encontrado.");
            return null;
        }

        Medicamentos? medicamentoSelecionado = repositorioMedicamento.SelecionarTodos().FirstOrDefault(m => m.Nome == nomeMedicamento);

        if (medicamentoSelecionado == null)
        {
            Console.WriteLine("Medicamento não encontrado.");
            return null;
        }

        return new RequisicaoDeSaida(
            pacienteSelecionado,
            medicamentoSelecionado,
            dataRequisicaoSaida
        );
    }
}
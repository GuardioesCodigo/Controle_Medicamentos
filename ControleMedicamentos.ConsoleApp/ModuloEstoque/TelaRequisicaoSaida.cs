using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Utilidades;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public class TelaRequisicaoSaida : TelaBase<RequisicaoDeSaida>, ITelaOpcoes, ITelaCrud
{
    public TelaRequisicaoSaida(IRepositorio<RequisicaoDeSaida> repositorio) 
    : base("RequisicaoDeSaida", repositorio)
    {
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
                Rs.Id, Rs.Paciente, Rs.MedicamentoRequisitado, Rs.Data
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
        throw new NotImplementedException();
    }
}

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
        throw new NotImplementedException();
    }
}

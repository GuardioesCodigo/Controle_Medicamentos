using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public class RepositorioRequisicaoSaidaEmArquivo : RepositorioBaseEmArquivo<RequisicaoDeSaida>, IRepositorio<RequisicaoDeSaida>
{
    public RepositorioRequisicaoSaidaEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<RequisicaoDeSaida> CarregarRegistros()
    {
        return contexto.requisicoesSaida;
    }
}

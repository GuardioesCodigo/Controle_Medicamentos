
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;


public class RepositorioRequisicaoEntrada : RepositorioBaseEmArquivo<RequisicaoEntrada>, IRepositorio<RequisicaoEntrada>
{
    public RepositorioRequisicaoEntrada(ContextoJson contexto) : base(contexto) { }

    public override void Cadastrar(RequisicaoEntrada novaEntidade)
    {
        novaEntidade.Medicamento.Quantidade += novaEntidade.Quantidade;

        base.Cadastrar(novaEntidade);
    }

    protected override List<RequisicaoEntrada> CarregarRegistros()
    {
        return contexto.RequisicoesEntrada;
    }
}
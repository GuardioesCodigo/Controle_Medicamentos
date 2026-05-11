using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionarios;

public class RepositorioFuncionariosEmArquivo : RepositorioBaseEmArquivo<Funcionario>, IRepositorio<Funcionario>
{
    public RepositorioFuncionariosEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Funcionario> CarregarRegistros()
    {
        return contexto.funcionarios;
    }
}

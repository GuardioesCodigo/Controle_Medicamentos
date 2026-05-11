using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionarios;

public class RepositorioFuncionariosEmArquivo : RepositorioBaseEmArquivo<Funcionarios>, IRepositorio<Funcionarios>
{
    public RepositorioFuncionariosEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Funcionarios> CarregarRegistros()
    {
        return contexto.funcionarios;
    }
}

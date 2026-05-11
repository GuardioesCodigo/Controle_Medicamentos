using System;
using System.Collections.Generic;
using System.Linq;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleMedicamentos.ConsoleApp.ModuloPacientes;

public class RepositorioPacienteEmArquivo : RepositorioBaseEmArquivo<Paciente>, IRepositorio<Paciente>
{
    public RepositorioPacienteEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Paciente> CarregarRegistros()
    {
        return contexto.Pacientes;
    }

    public bool CPFJaExiste(string cpf)
    {
        return registros.Any(x => x.CPF == cpf);
    }

    public bool CartaoSusJaExiste(string cartaoSus)
    {
        return registros.Any(x => x.CartaoSus == cartaoSus);
    }

}
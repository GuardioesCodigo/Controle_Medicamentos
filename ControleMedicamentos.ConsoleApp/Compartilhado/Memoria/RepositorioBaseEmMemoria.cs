using System;
using System.Collections.Generic;
using System.Linq;

using ControleMedicamentos.ConsoleApp.Compartilhado;
namespace ControleMedicamentos.ConsoleApp.Compartilhado.Memoria;


public abstract class RepositorioBaseEmMemoria<T> where T : EntidadeBase
{
    protected List<T> registros = new List<T>();

    public virtual void Cadastrar(T entidade)
    {
        registros.Add(entidade);
    }

    public bool Excluir(T registro)
    {
        return registros.Remove(registro);
    }

    public List<T> SelecionarRegistros()
    {
        return registros;
    }

    public virtual bool Editar(string idSelecionado, T entidadeAtualizada)
    {
        T? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        registroSelecionado.AtualizarDados(entidadeAtualizada);

        return true;
    }

    public virtual bool Excluir(string idSelecionado)
    {
        T? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        registros.Remove(registroSelecionado);

        return true;
    }

    public virtual T? SelecionarPorId(string idSelecionado)
    {
        return registros.FirstOrDefault(x => x.Id == idSelecionado);
    }

    public virtual List<T> SelecionarTodos()
    {
        return registros;
    }
}

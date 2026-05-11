using ControleMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleMedicamentos.ConsoleApp.Compartilhado;

public interface IRepositorio<T> where T : EntidadeBase
{
    void Cadastrar(T entidade);
    bool Editar(string idSelecionado, T entidadeAtualizada);
    bool Excluir(T registro);
    bool Excluir(string idSelecionado);
    T? SelecionarPorId(string idSelecionado);
    List<T> SelecionarRegistros();
    List<T> SelecionarTodos();
}

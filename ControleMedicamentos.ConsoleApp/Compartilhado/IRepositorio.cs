using ControleMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleMedicamentos.ConsoleApp.Compartilhado;

public interface IRepositorio<T>
{
    void Cadastrar(T entidade);
    bool Editar(string idSelecionado, T entidadeAtualizada);
    bool Excluir(T registro);
    T? SelecionarPorId(string idSelecionado);
    List<Paciente> SelecionarRegistros();
    List<T> SelecionarTodos();
}

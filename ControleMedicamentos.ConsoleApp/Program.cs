using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleMedicamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {

        ContextoJson contexto = new ContextoJson();



        contexto.Carregar();


        RepositorioMedicamentosEmArquivo repoPaciente = new RepositorioPacienteEmArquivo(contexto);
        TelaPaciente telaPaciente = new TelaPaciente(repoPaciente);



        while (true)
        {
            // O nome correto na sua TelaBase é ObterOpcaoMenu
            string? opcao = telaPaciente.ObterOpcaoMenu();

            if (opcao == "S")
                break;

            if (opcao == "1")
            {
                telaPaciente.Cadastrar(); // Na TelaBase é Cadastrar e não Inserir
                contexto.Salvar();
            }

            else if (opcao == "2")
            {
                telaPaciente.Editar();
                contexto.Salvar();
            }

            else if (opcao == "3")
            {
                telaPaciente.Excluir();
                contexto.Salvar();
            }

            else if (opcao == "4")
                telaPaciente.VisualizarTodos(true);
            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();

        }
    }
}

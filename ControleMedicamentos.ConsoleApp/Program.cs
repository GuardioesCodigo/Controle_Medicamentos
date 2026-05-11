using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleMedicamentos.ConsoleApp.ModuloPacientes;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos; // Adicione este using

namespace ControleMedicamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        ContextoJson contexto = new ContextoJson();
        contexto.Carregar();

        // Inicializando os Repositórios
        RepositorioPacienteEmArquivo repoPaciente = new RepositorioPacienteEmArquivo(contexto);

        // Inicializando as Telas
        RepositorioMedicamentosEmArquivo repoMedicamento = new RepositorioMedicamentosEmArquivo(contexto);
        TelaMedicamentos telaMedicamento = new TelaMedicamentos(repoMedicamento);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Controle de Medicamentos ---");
            Console.WriteLine("1 - Gerenciar Pacientes");
            Console.WriteLine("2 - Gerenciar Medicamentos");
            Console.WriteLine("S - Sair");
            Console.Write("\nEscolha uma opção: ");

            string? opcaoPrincipal = Console.ReadLine()?.ToUpper();

            if (opcaoPrincipal == "S")
                break;

            if (opcaoPrincipal == "1")
                ExecutarMenu(telaMedicamento);

            else if (opcaoPrincipal == "2")
                ExecutarMenu(telaMedicamento);
        }

        static void ExecutarMenu(dynamic tela)
        {
            while (true)
            {
                string? opcao = tela.ObterOpcaoMenu();

                if (opcao == "S")
                    break;

                if (opcao == "1")
                    tela.Cadastrar();

                else if (opcao == "2")
                    tela.Editar();

                else if (opcao == "3")
                    tela.Excluir();

                else if (opcao == "4")
                    tela.VisualizarTodos(true);
            }
        }
    }
}
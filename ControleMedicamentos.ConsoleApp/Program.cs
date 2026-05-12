using System;
using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleMedicamentos.ConsoleApp.ModuloPacientes;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Utilidades;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using System.Text.Json;
using ControleMedicamentos.ConsoleApp.ModuloEstoque;


ContextoJson contexto = new ContextoJson();

try
{
    contexto.Carregar();
}

catch (JsonException)
{
    Notificador.ExibirMensagem("O arquivo de armazenamento está corrompido! Contate o suporte.");
    return;
}

IRepositorio<Fornecedor> repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
IRepositorio<Paciente> repositorioPaciente = new RepositorioPacienteEmArquivo(contexto);
IRepositorio<Medicamentos> repositorioMedicamento = new RepositorioMedicamentosEmArquivo(contexto);
IRepositorio<Funcionario> repositorioFuncionario = new RepositorioFuncionariosEmArquivo(contexto);
IRepositorio<RequisicaoEntrada> repositorioRequisicaoEntrada = new RepositorioRequisicaoEntrada(contexto);
IRepositorio<RequisicaoDeSaida> repositorioRequisicaoSaida = new RepositorioRequisicaoSaidaEmArquivo(contexto);

TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor);
TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);
TelaMedicamentos telaMedicamento = new TelaMedicamentos(repositorioMedicamento);
TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
TelaRequisicaoSaida telaRequisicaoSaida = new TelaRequisicaoSaida(repositorioRequisicaoSaida, repositorioPaciente, repositorioMedicamento, telaPaciente, telaMedicamento);

TelaPrincipal telaPrincipal = new TelaPrincipal(
    repositorioFornecedor,
    repositorioPaciente,
    repositorioMedicamento,
    repositorioFuncionario,
    repositorioRequisicaoEntrada,
    repositorioRequisicaoSaida
);



while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

        if (opcaoSubMenu == "S")
        {
            Console.Clear();
            break;
        }

        if (telaSelecionada is ITelaCrud telaCrud)
        {
            if (opcaoSubMenu == "1")
                telaCrud.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaCrud.Editar();

            else if (opcaoSubMenu == "3")
                telaCrud.Excluir();

            else if (opcaoSubMenu == "4")
                telaCrud.VisualizarTodos(deveExibirCabecalho: true);
        }
    }
}
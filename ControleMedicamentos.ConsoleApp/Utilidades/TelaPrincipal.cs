using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.Utilidades;

public class TelaPrincipal
{
    public ITelaOpcoes? ApresentarMenuOpcoesPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar Fornecedores");
        Console.WriteLine("2 - Gerenciar Pacientes");
        Console.WriteLine("3 - Gerenciar Medicamentos");
        Console.WriteLine("4 - Gerenciar Funcionários");
        Console.WriteLine("5 - Gerenciar Estoque");
        Console.WriteLine("6 - Gerenciar Requisições de Saída");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        return null;
    }
}

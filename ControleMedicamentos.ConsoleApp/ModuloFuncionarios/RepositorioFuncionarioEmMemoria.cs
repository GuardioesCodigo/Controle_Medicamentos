using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Memoria;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionarios;

public class RepositorioFuncionarioEmMemoria : RepositorioBaseEmMemoria<Funcionario>, IRepositorio<Funcionario>;

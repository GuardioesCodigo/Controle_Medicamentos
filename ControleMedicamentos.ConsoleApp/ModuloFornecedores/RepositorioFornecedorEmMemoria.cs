using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Compartilhado.Memoria;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedores;

public class RepositorioFornecedorEmMemoria : RepositorioBaseEmMemoria<Fornecedor>, IRepositorio<Fornecedor>;

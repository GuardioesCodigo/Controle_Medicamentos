using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedores;

public class Fornecedor : EntidadeBase
{

    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cnpj { get; set; }

    public Fornecedor(string nome, string telefone, string cnpj)
    {
        Nome = nome;
        Telefone = telefone; 
        Cnpj = cnpj;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if(string.IsNullOrWhiteSpace(Nome))
            erros.Add ("O campo \"Nome\" deve ser preenchido");

        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres.");

        int contadorDigitos = 0;
        bool contemLetraOuSimbolo = false;

        for (int i = 0; i < Telefone.Length; i++)
        {
            char caractereAtual = Telefone[i];

            if (char.IsDigit(caractereAtual))
                contadorDigitos++;

            else
            {
                contemLetraOuSimbolo = true;
                break;
            }
        }

        if (contadorDigitos < 10 || contadorDigitos > 11)
            erros.Add("O campo \"Telefone\" deve conter entre 10 e 11 caracteres");

        if (contemLetraOuSimbolo)
            erros.Add("O campo \"Telefone\" deve conter entre 10 e 11 caracteres");

        if (Cnpj.Length < 13 || Cnpj.Length > 15)
            erros.Add("O campo \"Cnpj\" deve conter 14 caracteres");

            return erros;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Fornecedor fornecedorAtualizado = (Fornecedor)entidadeAtualizada;

        Nome = fornecedorAtualizado.Nome;
        Telefone = fornecedorAtualizado.Telefone;
        Cnpj = fornecedorAtualizado.Cnpj;
    }
} 

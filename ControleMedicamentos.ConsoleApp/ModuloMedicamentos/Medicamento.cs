using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;


namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

public class Medicamentos : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public int Quantidade { get; set; }

    public string Fornecedor { get; set; } = string.Empty;

    public bool EstaEmFalta => Quantidade < 20;


    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O nome é obrigatório.");

        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O nome deve ter entre 3 e 100 caracteres.");

        else if (Descricao.Length < 5 || Descricao.Length > 255)
            erros.Add("A descrição deve ter entre 5 e 255 caracteres.");

        else if (Quantidade < 0)
            erros.Add("A quantidade em estoque não pode ser negativa.");

        else if (string.IsNullOrWhiteSpace(Fornecedor))
            erros.Add("O fornecedor é obrigatório.");

        return erros;
    }
    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Medicamentos medicamentosAtualizado = (Medicamentos)entidadeAtualizada; //Cast

        this.Nome = medicamentosAtualizado.Nome;
        this.Descricao = medicamentosAtualizado.Descricao;
        this.Quantidade = medicamentosAtualizado.Quantidade;
        this.Fornecedor = medicamentosAtualizado.Fornecedor;
    }
}
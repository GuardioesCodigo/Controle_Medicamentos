using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public class RequisicaoEntrada : EntidadeBase
{
    public Medicamentos Medicamento { get; set; }
    public Funcionario Funcionario { get; set; }
    public int Quantidade { get; set; }
    public DateTime Data { get; set; }

    public RequisicaoEntrada()
    {
    }


    public RequisicaoEntrada(Medicamentos medicamento, Funcionario funcionario, int quantidade, DateTime data)
    {
        this.Medicamento = medicamento;
        this.Funcionario = funcionario;
        this.Quantidade = quantidade;
        this.Data = data;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        RequisicaoEntrada atualizada = (RequisicaoEntrada)entidadeAtualizada;
        this.Medicamento = atualizada.Medicamento;
        this.Funcionario = atualizada.Funcionario;
        this.Quantidade = atualizada.Quantidade;
        this.Data = atualizada.Data;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Medicamento == null)
            erros.Add("O medicamento é obrigatório");

        if (Quantidade <= 0)
            erros.Add("A quantidade deve ser maior que zero");

        return erros;
    }
}
using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleMedicamentos.ConsoleApp.ModuloEstoque;

public class RequisicaoDeSaida : EntidadeBase
{
    public Paciente Paciente {get; set;}
    public Medicamentos MedicamentoRequisitado {get; set;}
    public DateTime Data {get; set;}

    public RequisicaoDeSaida()
    {  
    }

    public RequisicaoDeSaida(Paciente paciente, Medicamentos medicamentoRequisitado, DateTime data)
    {
        Paciente = paciente;
        MedicamentoRequisitado = medicamentoRequisitado;
        Data = data;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Paciente == null)
            erros.Add("O campo \"Paciente\" deve ser preenchido");

        if (MedicamentoRequisitado == null)
            erros.Add("O campo \"Medicamento Requisitado\" deve ser preenchido");

        if (Data.Date > DateTime.Today)
            erros.Add("O campo \"Data\" não pode ser futura");

        return erros;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        RequisicaoDeSaida requisicaoSaidaAtualizada = (RequisicaoDeSaida)entidadeAtualizada;

        this.Paciente = requisicaoSaidaAtualizada.Paciente;
        this.MedicamentoRequisitado = requisicaoSaidaAtualizada.MedicamentoRequisitado;
        this.Data = requisicaoSaidaAtualizada.Data;
    }
}

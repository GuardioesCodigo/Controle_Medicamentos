





using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

using ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos;


public class RepositorioMedicamentosEmArquivo : RepositorioBaseEmArquivo<Medicamentos>, IRepositorio<Medicamentos>
{

    public List<Medicamentos> Medicamentos { get; set; } = new List<Medicamentos>();
    public RepositorioMedicamentosEmArquivo(ContextoJson contexto) : base(contexto)
    {

    }
    public List<Medicamentos> SelecionarRegistros()
    {
        return registros;
    }


    public void GravaMudancas()
    {
        contexto.Salvar();
    }

    protected override List<Medicamentos> CarregarRegistros()
    {
        return contexto.Medicamentos;
    }

    public bool MedicamentoJaExiste(string Medicamento)
    {
        return registros.Any(x => x.Nome.ToUpper() == Medicamento.ToUpper());
    }

    public Medicamentos SelecionarPorNome(string nome)
    {
        return registros.Find(x => x.Nome.ToUpper() == nome.ToUpper())!;
    }


}



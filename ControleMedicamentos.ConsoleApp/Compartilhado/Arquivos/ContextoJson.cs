using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ControleMedicamentos.ConsoleApp.ModuloPacientes;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;


namespace ControleMedicamentos.ConsoleApp.Compartilhado.Arquivos;

public class ContextoJson
{
    private readonly string caminhoArquivo;

    public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
    public List<Fornecedor> Fornecedores { get; set; } = new List<Fornecedor>();
    public List<Funcionario> funcionarios {get; set;} = new List<Funcionario>();

    public List<Medicamentos> Medicamentos { get; set; } = new();


    public ContextoJson()
    {
        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string caminhoDiretorio = Path.Combine(caminhoAppData, "ControleDeMedicamentos");

        Directory.CreateDirectory(caminhoDiretorio);

        caminhoArquivo = Path.Combine(caminhoDiretorio, "dados.json");
    }

    public void Salvar()
    {
        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.WriteIndented = true;
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        string jsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        if (!File.Exists(caminhoArquivo))
            return;

        string jsonString = File.ReadAllText(caminhoArquivo);

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoJson? contextoSalvo = JsonSerializer.Deserialize<ContextoJson>(jsonString, opcoesJson);

        if (contextoSalvo == null)
            return;

        this.Fornecedores = contextoSalvo.Fornecedores;

        this.Pacientes = contextoSalvo.Pacientes;

        this.Medicamentos = contextoSalvo.Medicamentos;

        this.funcionarios = contextoSalvo.funcionarios;

    }
}

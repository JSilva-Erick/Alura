using System.Text.Json;

namespace Exercício.Modelo;

internal class ListaPessoas
{
    public string Nome { get; set; }
    public List<Pessoa>? ListaDePessoas { get; }
    
    public ListaPessoas(string nome)
    {
        Nome = nome;
        ListaDePessoas = new();
    }

    public void AdicionarPessoa(Pessoa pessoa)
    {
        ListaDePessoas.Add(pessoa);
    }

    public void GerarArquivoJson()
    {
        string nome = $"Lista de pessoas limpas no {Nome}";
        string json = JsonSerializer.Serialize(new 
        { 
            dados = nome,
            pessoas = ListaDePessoas
        });


        string nomeDoArquivo = $"dados-pessoas.json";

        File.WriteAllText(nomeDoArquivo, json);
        Console.WriteLine($"Arquivo {nomeDoArquivo} gerado no diretório: {Path.GetFullPath(nomeDoArquivo)}");
    }
}

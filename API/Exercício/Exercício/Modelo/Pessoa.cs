using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exercício.Modelo;

internal class Pessoa
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public int? Idade { get; set; }

    public void ExibirDadosPessoa()
    {
        Console.WriteLine();
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Idade: {Idade}");
        Console.WriteLine($"Email: {Email}");
    }
}

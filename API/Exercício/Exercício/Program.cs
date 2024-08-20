using Exercício.Modelo;
using System.Text.Json;

//var pessoa1 = new Pessoa();

//Console.WriteLine("Digite o nome: ");
//pessoa1.Nome = Console.ReadLine();
//Console.WriteLine("Digite a Idade: ");
//pessoa1.Idade = Int32.Parse(Console.ReadLine());
//Console.WriteLine("Digite o email: ");
//pessoa1.Email = Console.ReadLine();
//Console.WriteLine();

//pessoa1.ExibirDadosPessoa();
//pessoa1.GerarArquivoJson();
//try
//{
//    string arquivo = File.ReadAllText("dados-Erick.json");
//    Pessoa pessoa = JsonSerializer.Deserialize<Pessoa>(arquivo)!;
//    pessoa.ExibirDadosPessoa();
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Tivemos um problema{ex.Message}");
//}

var ListaPessoas = new ListaPessoas("serasa");

while (true)
{
    Pessoa pessoa = new();
    Console.WriteLine("Digite o nome ou 'sair' para finalizar:");
    string nome = Console.ReadLine()!;

    if (nome.ToLower().Equals("sair"))
        break;

    pessoa.Nome = nome;
    Console.WriteLine("Digite a idade:");
    pessoa.Idade = Int32.Parse(Console.ReadLine()!);
    Console.WriteLine("Digite o email:");
    pessoa.Email = Console.ReadLine();
    ListaPessoas.AdicionarPessoa(pessoa);
    Console.WriteLine();
}

ListaPessoas.GerarArquivoJson();
using PokeGoshi.Model;
using RestSharp;
using System.Text.Json;


namespace PokeGoshi.Service
{
    internal class Conexao
    {
        public static PokemonDetalhe ObterDetalhes(PokemonResult especie)
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
            RestRequest request = new RestRequest(especie.Nome.ToLower(), Method.Get);


            var response = client.Execute(request);
            return JsonSerializer.Deserialize<PokemonDetalhe>(response.Content);
        }
        public static List<PokemonResult> GetEspeciesDisponiveis()
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
            RestRequest request = new RestRequest("", Method.Get);

            var response = client.Execute(request);

            var Pokemons = JsonSerializer.Deserialize<TodosPokemons>(response.Content);
            return Pokemons.Results;
        }
    }
}

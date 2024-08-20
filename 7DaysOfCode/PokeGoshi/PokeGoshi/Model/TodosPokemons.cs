using System.Text.Json.Serialization;

namespace PokeGoshi.Model
{
    internal class TodosPokemons
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        [JsonPropertyName("results")]
        public List<PokemonResult> Results { get; set; }

    }
}

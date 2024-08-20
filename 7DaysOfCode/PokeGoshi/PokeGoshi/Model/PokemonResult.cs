using System.Text.Json.Serialization;

namespace PokeGoshi.Model
{
    internal class PokemonResult
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}

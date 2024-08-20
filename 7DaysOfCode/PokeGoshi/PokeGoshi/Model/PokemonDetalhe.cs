using System.Text.Json.Serialization;

namespace PokeGoshi.Model
{
    internal class PokemonDetalhe()
    {
        [JsonPropertyName("weight")]
        public double Peso {  get; set; }
        [JsonPropertyName("height")]
        public double Altura { get; set; }
        [JsonPropertyName("name")]
        public string Nome { get; set; }
        [JsonPropertyName("abilities")]
        public List<GetHabilidades> Habilidades { get; set; }

    }

    public class GetHabilidades
    {
        [JsonPropertyName("ability")]
        public GetHabilidade Habilidade { get; set; }
    }
    public class GetHabilidade
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; }
    }
}

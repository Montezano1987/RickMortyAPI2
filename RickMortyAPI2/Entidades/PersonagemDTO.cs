using System.Text.Json.Serialization;

namespace RickMortyAPI2.Entidades
{
    public class PersonagemDTO
    {
        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("results")]
        public List<Personagem> Personagens { get; set; }
    }
}

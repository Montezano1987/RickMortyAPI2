using System.Text.Json.Serialization;

namespace RickMortyAPI2.Entidades
{
    public class Episodio
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("air_date")]
        public string AirDate { get; set; }
    }
}

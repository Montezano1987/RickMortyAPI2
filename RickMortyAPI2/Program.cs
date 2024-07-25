using RickMortyAPI2.Entidades;
using System.Text.Json;

public class Program
{
    public static readonly HttpClient _httpClient = new HttpClient();

    public static async Task Main(string[] args)
    {
        var personagens = await BuscarTodosPersonagens();
        var personagemJerrySmith = personagens.FirstOrDefault(p => p.Name == "Summer Smith");
        int quantidadeJerryEpisodios = personagemJerrySmith?.Episode.Count ?? 0;
        Console.WriteLine($"Summer Smith participou de {quantidadeJerryEpisodios} episódios.");

        foreach (var urlEpisodio in personagemJerrySmith.Episode)
        {
            var episodio = await BuscarEpisodioPorUrl(urlEpisodio);
            Console.WriteLine($"Episódio: {episodio.Name}, Data de exibição: {episodio.AirDate}");
        }

    }

    public static async Task<List<Personagem>> BuscarTodosPersonagens()
    {
        string url = "https://rickandmortyapi.com/api/character";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        var results = JsonSerializer.Deserialize<PersonagemDTO>(responseBody);

        return results.Personagens;
    }

    public static async Task<Episodio> BuscarEpisodioPorUrl(string urlEpisodio)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(urlEpisodio);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        var episodio = JsonSerializer.Deserialize<Episodio>(responseBody);

        return episodio;
    }
}
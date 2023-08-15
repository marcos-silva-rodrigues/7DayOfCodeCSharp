// See https://aka.ms/new-console-template for more information


using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class Program
{
    static string BASE_URL = "https://pokeapi.co/api/v2/pokemon/";
    public static void Main(string[] args)
    {
        Task<ResponseSchema<Pokemon>?> task = GetPokemon();
        task.Wait();

        if (task.Result != null)
        {
            var data = task.Result;
            Console.WriteLine("# Lista de Pokemons #");
            Console.WriteLine("# Quantidade Atual: " + data.Count + " #\n");
            Console.WriteLine("# Proxima Página: " + data.Next + " #\n");
            Console.WriteLine("# Página Anteiror: " + data.Previous + " #\n");
            if (data.Results != null) ShowPokemons(data.Results);
        }

 
        }

    async static Task<ResponseSchema<Pokemon>?> GetPokemon()
    {
        using HttpClient client = new();
        var responseStream = await client.GetStreamAsync(BASE_URL);
        var json = await JsonSerializer.DeserializeAsync<ResponseSchema<Pokemon>>(responseStream);
        return json;
    }

    static void ShowPokemons(List<Pokemon> pokemons)
    {
        pokemons.ForEach(poke =>
        {
            Console.WriteLine("#################################\n");
            Console.WriteLine("Nome: " + poke.Name + "\n");
            Console.WriteLine("Mais Detalhes: " + poke.Url + "\n");
            Console.WriteLine("#################################\n");
        });
    }
}

class Pokemon
{
    [property: JsonPropertyName("name")]
    public string? Name { get; set; }

    [property: JsonPropertyName("url")]
    public string? Url { get; set; }
}

class ResponseSchema<T>
{
    [property: JsonPropertyName("count")]
    public int? Count { get; set; }

    [property: JsonPropertyName("next")]
    public string? Next { get; set; }

    [property: JsonPropertyName("previous")]
    public string? Previous { get; set; }

    [property: JsonPropertyName("results")]
    public List<T>? Results { get; set; }
}

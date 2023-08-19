using Day1.Model;
using Day4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Day1.Repository
{
    public class PokemonRepo
    {

        async public Task< ResponseSchema<PokemonDto> ?>GetAll ()
        {
            using (HttpClient client = new())
            {
                var _uri = new Uri("https://pokeapi.co/api/v2/pokemon/");
                var responseStream = await client.GetStreamAsync(_uri);
                var json = await JsonSerializer.DeserializeAsync<ResponseSchema<PokemonDto>>(responseStream);
                return json;
            }
        }

        async public Task<Pokemon?> GetDetails(PokemonDto dto)
        {
            using (HttpClient client = new())
            {
                var _uri = new Uri(dto.Url);
                var responseStream = await client.GetStreamAsync(_uri);
                var json = await JsonSerializer.DeserializeAsync<Pokemon>(responseStream);
                return json;
            }
        }
    }
}

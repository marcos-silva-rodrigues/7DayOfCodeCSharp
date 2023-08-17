using Day1.Model;
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

        private Uri _uri;

        public PokemonRepo()
        {
            _uri = new Uri("https://pokeapi.co/api/v2/pokemon/");
        }

        async public Task< ResponseSchema<Pokemon> ?>GetAll ()
        {
            using (HttpClient client = new())
            {
                var responseStream = await client.GetStreamAsync(_uri);
                var json = await JsonSerializer.DeserializeAsync<ResponseSchema<Pokemon>>(responseStream);
                return json;
            }
        }
    }
}

using Day1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Model
{
    public class User
    {
        public string Name { get; }
        public List<Pokemon> Pokemons { get; }

        public User(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }
    }
}

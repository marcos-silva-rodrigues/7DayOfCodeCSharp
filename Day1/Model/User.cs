using Day1.Model;
using Day4.Model;
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
        public List<Pet> Pets { get; }

        public User(string name)
        {
            Name = name;
            Pets = new List<Pet>();
        }

        public void AddPokemon(Pet pokemon)
        {
            Pets.Add(pokemon);
        }
    }
}

using Day1.Model;
using Day1.Repository;
using Day2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.View
{
    public class PokemonView
    {
        public string OpenMenu(string name)
        {
            Console.WriteLine("# Menu");
            Console.WriteLine($"# {name} Você deseja:");
            Console.WriteLine("# 1 - Adotar um mascote virtual");
            Console.WriteLine("# 2 - Ver seus mascotes");
            Console.WriteLine("# 3 - Sair");
            Console.WriteLine("\n");

            var option = Console.ReadLine();
            return option;
        }

        public string GetUsername()
        {
            Console.WriteLine("Qual é seu nome?");
            var name = Console.ReadLine();
            return name.ToUpper();
        }

        public string SelectPokemon(string name, List<Pokemon>pokemons)
        {
  
            Console.WriteLine($"# {name} Escolha uma espécie:");
            for (int i = 0; i < pokemons.Count; i++)
            {
                Console.WriteLine($"# {i + 1} - {pokemons[i].Name}");
            }

            
            Console.WriteLine("\n");
            string option = Console.ReadLine();
            return option;
        }

        public void AdoptedPokemon(string name, Pokemon pokemon)
        {
            Console.WriteLine($"# {name} Adotou {pokemon.Name}");
            Console.WriteLine("\n");
        }

        public void ShowAdoptedPokemon(string name, List<Pokemon> pokemons)
        {
            Console.WriteLine($"{name} já adotou {pokemons.Count} pokemons:");
            pokemons.ForEach(poke =>
            {
                Console.WriteLine($"# {poke.Name}");
            });
            Console.WriteLine("\n");
        }

        public void ErrorMessage()
        {
            Console.WriteLine("Houve um erro, Tente novamente mais tarde!");
            Console.WriteLine("\n");
        }
    }
}

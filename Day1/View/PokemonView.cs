using Day1.Model;
using Day1.Repository;
using Day2.Model;
using Day4.Model;
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

        public string SelectPokemon(string name, List<PokemonDto>pokemons)
        {
  
            Console.WriteLine($"# {name} Escolha uma espécie:");
            for (int i = 0; i < pokemons.Count; i++)
            {
                Console.WriteLine($"# {i + 1} - {pokemons[i].Name}");
            }

            
            Console.WriteLine("");
            string option = Console.ReadLine();
            return option;
        }

        public void AdoptedPokemon(string name, PokemonDto pokemon)
        {
            Console.WriteLine($"# {name} Adotou {pokemon.Name}");
            Console.WriteLine("");
        }

        public string ShowPets(string name, List<Pet> pets)
        {
            Console.WriteLine($"{name} já adotou {pets.Count} pokemons:");
            Console.WriteLine($"Selecione o número do pokemon para ver seu detalhe");
            var index = 0;
            pets.ForEach(pet =>
            {
                Console.WriteLine($"#{index + 1} {pet.Name}");
                index++;
            });
            Console.WriteLine("#0 - Voltar ");
            string option = Console.ReadLine();
            return option;
        }

        public void ErrorMessage()
        {
            Console.WriteLine("Houve um erro, Tente novamente mais tarde!");
            Console.WriteLine("\n");
        }

        public string ShowPetDetails(string name, Pet pet)
        {
            Console.WriteLine($"#Nome: {pet.Name}");
            Console.WriteLine($"#Altura: {pet.Height}");
            Console.WriteLine($"#Peso: {pet.Weight}");
            Console.WriteLine(pet.Sad ? "Está triste" : "Esta feliz");
            Console.WriteLine(pet.Hunger ? "Está com fome" : "Esta sem fome");
            Console.WriteLine($"#{name} você deseja:");

            Console.WriteLine($"# 1 - Alimentar o {pet.Name}");
            Console.WriteLine($"# 2 - Brincar com {pet.Name}");
            Console.WriteLine($"# 3 - Sair ");
            string option = Console.ReadLine();
            return option;
        }
    }
}

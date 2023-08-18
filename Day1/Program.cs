// See https://aka.ms/new-console-template for more information


using Day1.Repository;
using Day1.Model;
using Day2.Model;
using System.Xml.Linq;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Qual é seu nome?");
        var name = Console.ReadLine();
        if (name == null) return;
        User user = new User(name);
        bool close = true;
       
        do
        {
            string option = ShowMenu(user);
            var pokeRepo = new PokemonRepo();

            switch (Convert.ToChar(option))
            {
                case '1':
                    SelectPokemons(user, pokeRepo);
                    break;
                case '2':
                    user.Pokemons.ForEach(poke =>
                    {
                        Console.WriteLine($"# {poke.Name}");
                    });
               
                    break;
                case '3':
                    close = false;
                    break;
                default:
                    Console.WriteLine("Opção invalida");
                    break;
            }

        } while (close);

        

        //var pokeRepo = new PokemonRepo();
        //var task = pokeRepo.GetAll();
        //task.Wait();
        //if (task.Result == null)
        //{
        //    Console.WriteLine("# Erro ao buscar pokemons #");
        //    return;
        //}
        //var data = task.Result;
        //Console.WriteLine("# Lista de Pokemons #");
        //Console.WriteLine("# Quantidade Atual: " + data.Count + " #\n");
        //Console.WriteLine("# Proxima Página: " + data.Next + " #\n");
        //Console.WriteLine("# Página Anteiror: " + data.Previous + " #\n");
        //ShowPokemons(data.Results);
    }

    static string ShowMenu(User user)
    {
        Console.WriteLine("# Menu");
        Console.WriteLine($"# {user.Name} Você deseja:");
        Console.WriteLine("# 1 - Adotar um mascote virtual");
        Console.WriteLine("# 2 - Ver seus mascotes");
        Console.WriteLine("# 3 - Sair");

        string option = Console.ReadLine();
        return option;
    }

    static void SelectPokemons(User user, PokemonRepo repo)
    {
        var pokemons = repo.GetAll();
        pokemons.Wait();
        if (pokemons.Result == null)
        {
            Console.WriteLine("# Erro ao buscar pokemons ");
            return;
        }
        Console.WriteLine($"# {user.Name} Escolha uma espécie:");
        var data = pokemons.Result.Results;
        for (int i = 0; i < data.Count; i++)
        {
            Console.WriteLine($"# {i + 1} - {data[i].Name}");
        }
        string option = Console.ReadLine();
        Pokemon pokemon = data[Int32.Parse(option)];
        user.AddPokemon(pokemon);
        Console.WriteLine($"# {user.Name} Adotou {pokemon.Name}");
    }
}

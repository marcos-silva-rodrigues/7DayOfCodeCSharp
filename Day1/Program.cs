// See https://aka.ms/new-console-template for more information


using Day1.Repository;
using Day1.Model;

class Program
{
    public static void Main(string[] args)
    {

        var pokeRepo = new PokemonRepo();
        var task = pokeRepo.GetAll();
        task.Wait();
        if (task.Result == null)
        {
            Console.WriteLine("# Erro ao buscar pokemons #");
            return;
        }
        var data = task.Result;
        Console.WriteLine("# Lista de Pokemons #");
        Console.WriteLine("# Quantidade Atual: " + data.Count + " #\n");
        Console.WriteLine("# Proxima Página: " + data.Next + " #\n");
        Console.WriteLine("# Página Anteiror: " + data.Previous + " #\n");
        ShowPokemons(data.Results);
    }

    static void ShowPokemons(List<Pokemon> pokemons)
    {
        pokemons.ForEach(poke =>
        {
            Console.WriteLine("#################################\n");
            Console.WriteLine("Nome: " + poke.Name + "\n");
            Console.WriteLine("Mais Detalhes: " + poke.Url + "\n");
        });
    }
}

// See https://aka.ms/new-console-template for more information


using Day1.Repository;
using Day1.Model;
using Day2.Model;
using System.Xml.Linq;
using Day2.View;
using Day2.Controller;

class Program
{
    public static void Main(string[] args)
    {
        var controller = new PokemonController(new PokemonView(), new PokemonRepo());
        controller.Start();
    }


}

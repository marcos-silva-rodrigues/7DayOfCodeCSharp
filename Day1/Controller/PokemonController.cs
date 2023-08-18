using Day1.Model;
using Day1.Repository;
using Day2.Model;
using Day2.View;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Controller
{
    public class PokemonController
    {
        private PokemonView _view;
        private PokemonRepo _repo;

        private bool _stop = true;
        
        private User user;

        public PokemonController(PokemonView view, PokemonRepo repo)
        {
            _view = view;
            _repo = repo;
        }

        public void Start()
        {
            var name = _view.GetUsername();
            user = new User(name);
            do
            {

                Console.WriteLine("\n");
                string option = _view.OpenMenu(user.Name);
                
                try
                {
                    switch (Convert.ToChar(option))
                    {
                        case '1':
                            AdoptPokemon();
                            break;
                        case '2':
                            _view.ShowAdoptedPokemon(user.Name, user.Pokemons);
                            break;
                        case '3':
                            StopGame();
                            break;
                        default:
                            Console.WriteLine("Opção invalida");
                            break;
                    }
                } catch
                {
                    Console.WriteLine("Opção invalida");
                }
   

            } while (_stop);

        }

        private void StopGame()
        {
            _stop = false;
        }

        private void AdoptPokemon()
        {
            var task = _repo.GetAll();
            task.Wait();
            if (task.Result == null)
            {
                _view.ErrorMessage();
                StopGame();
            };
            var pokemons = task.Result.Results;
            string pokemonIndex = _view.SelectPokemon(user.Name, pokemons);
            Pokemon pokemon = pokemons[Int32.Parse(pokemonIndex)-1];
            user.AddPokemon(pokemon);
            _view.AdoptedPokemon(user.Name, pokemon);
        }


    }
}

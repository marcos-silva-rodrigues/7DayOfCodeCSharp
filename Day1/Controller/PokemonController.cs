using AutoMapper;
using Day1.Model;
using Day1.Repository;
using Day2.Model;
using Day2.View;
using Day4.Model;

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
                            ShowPetOptions();
                            
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
            PokemonDto pokemon = pokemons[Int32.Parse(pokemonIndex)-1];
            var task2 = _repo.GetDetails(pokemon);
            task2.Wait();

            if (task2.Result == null)
            {
                _view.ErrorMessage();
                StopGame();
            };

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Pokemon, Pet>());
            var mapper = new Mapper(config);

            var pet = mapper.Map<Pet>(task2.Result);
            user.AddPokemon(pet);
            _view.AdoptedPokemon(user.Name, pokemon);
        }
        private void ShowPetOptions()
        {
            var control = true;
            do
            {
                try
                {
                    string option  = _view.ShowPets(user.Name, user.Pets);
                    int pokemonAdoptIndex = Int32.Parse(option);
                    if (pokemonAdoptIndex == 0)
                    {
                        control = false;
                    } else
                    {
                        Pet pet = user.Pets[pokemonAdoptIndex - 1];
                        PetInterative(pet);
                    }
                }
                catch
                {
                    Console.WriteLine("Opção invalida");
                }

            } while (control);

        }

        private void PetInterative(Pet pet)
        {
            var control = true;
            do
            {
                try
                {
                    string option = _view.ShowPetDetails(user.Name, pet);
                    int choose = Int32.Parse(option);
                    switch(choose)
                    {
                        case 1:
                            pet.Food();
                            break;
                        case 2:
                            pet.Play();
                            break;
                        case 3:
                            control = false;
                            break;
                        default:
                            Console.WriteLine("Opção invalida");
                            break;
                    }

                }
                catch
                {
                    Console.WriteLine("Opção invalida");
                }

            } while (control);

        }
    }
}

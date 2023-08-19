using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Day4.Model
{
    public class Pet
    {
        private Pokemon _pokemon;

        public string Name { get { return _pokemon.Name; } }
        public int Weight { get { return _pokemon.Weight; } }
        public int Height { get { return _pokemon.Height; } }

        private int _hunger = 5;
        private int _sad = 5;

        public bool Sad
        {
            get { return _sad > 4; }
        }

        public bool Hunger
        {
            get { return _hunger > 4; }
        }

        public Pet(Pokemon pokemon)
        {
            _pokemon = pokemon;
        }



        public void Food()
        {
           _hunger--;
           _sad++;
        }


        public void Play()
        {
            _sad--;
            _hunger++;
        }
    }
}

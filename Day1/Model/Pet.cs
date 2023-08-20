namespace Day4.Model
{
    public class Pet
    {

        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        public Pet(int weight, string name, int height)
        {
            Weight = weight;
            Name = name;
            Height = height;
        }

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

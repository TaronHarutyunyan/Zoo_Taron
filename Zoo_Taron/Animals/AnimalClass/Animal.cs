using System;
using System.Timers;

namespace Zoo_Taron
{
    
    abstract class Animal
    {
        private readonly Timer _timer;
        private string _name;
        public event Action MakingSound;
        public AnimalTypes TypeOfThis { get; private set; }
        public ALiveOrDeadStatus AliveOrDead { get; private set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null) _name = value;
                else throw new Exception();
            }
        }
        public Gender Gender { get; private set; }
        public FoodType FoodType { get; set; }
        public Cage Cage { get; set; }
        
        public readonly int StomachSize = 10000;
        public int HungerLevel { get; private set; }
        public Animal(string name,Gender gender,FoodType ftype)
        {
            Name = name;
            Gender = gender;
            FoodType = ftype;
            HungerLevel = 2000;
            AliveOrDead = ALiveOrDeadStatus.ALive;
            GettingHungry();
            SetAnimalType();
        }

        public void SetInCage(Cage c)
        {
            if (TypeOfThis == c.AnimalType) Cage = c;
            Cage.FoodAddedInPlate += Eat;
        }
        private void GettingHungry()
        {
            _timer.Interval = 60000;
            _timer.Elapsed += GetHungry;
        }

        private void GetHungry(object sender, ElapsedEventArgs e)
        {
            if (HungerLevel <= 0) AliveOrDead = ALiveOrDeadStatus.Dead;
            else if (IsHungry()) MakingSound?.Invoke();
            else HungerLevel--;
        }       

        public bool IsHungry()
        {
            return (HungerLevel < 5000);
        }
        private void SetAnimalType()
        {
            switch (this)
            {
                case AmphibianAnimal:
                    TypeOfThis = AnimalTypes.Amphibian;
                    break;
                case AquaticAnimal:
                    TypeOfThis = AnimalTypes.Aquatic;
                    break;
                case TerrestrialAnimal:
                    TypeOfThis = AnimalTypes.Terrestrial;
                    break;
                case FlyingAnimal:
                    TypeOfThis = AnimalTypes.Flying;
                    break;
                default:
                    //Log
                    break;
            }
        }

        public void Eat()
        {
            Food lfood = Cage.FoodPlate.Foods[Cage.FoodPlate.Foods.Count - 1];
            Cage.FoodPlate.Foods.Remove(lfood);
            HungerLevel += lfood.Calories;
            
        }
    }
}

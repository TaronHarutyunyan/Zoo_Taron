using System;
using System.Collections.Generic;

namespace Zoo_Taron
{
    class Cage
    {
        public Plate FoodPlate;
        public event Action FoodAddedInPlate;
        public event Action AnimalAddedinCage;
        public List<Animal> AnimalsInCage { get;private set; }
        public AnimalTypes AnimalType { get; set; }
        public bool HasWorker { get; set; }
        public Cage(AnimalTypes type)
        {
            AnimalsInCage = new();
            AnimalType = type;
            FoodPlate = new Plate();
            HasWorker = false;
        }
        public override string ToString()
        {
            return $"Cage For {AnimalType}";
        }
        public void PutAnimalInCage(Animal a)
        {
            if (a.TypeOfThis == AnimalType) AnimalsInCage.Add(a);
            AnimalAddedinCage?.Invoke();
        }
        public void AddFood(Food f)
        {
            FoodPlate.Foods.Add(f);
            FoodAddedInPlate?.Invoke();
        }

    }
}

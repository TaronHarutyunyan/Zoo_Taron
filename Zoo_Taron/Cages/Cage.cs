using System;
using System.Collections.Generic;

namespace Zoo_Taron
{
    class Cage
    {
        public Plate FoodPlate;
        public event Action FoodAddedInPlate;
        public List<Animal> AnimalsInCage { get; set; }
        public AnimalTypes AnimalType { get; set; }
        public Cage(AnimalTypes type)
        {
            AnimalType = type;
        }

        public void AddFood(Food f)
        {
            FoodPlate.Foods.Add(f);
            FoodAddedInPlate?.Invoke();
        }

    }
}

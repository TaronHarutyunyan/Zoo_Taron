using System;

namespace Zoo_Taron
{
    class Worker
    {
        public Cage WorkCage { get; set; }
        public Worker(Cage c)
        {
            WorkCage = c;            
            SubscribeToAnimalsInCage();
        }

        private void SubscribeToAnimalsInCage()
        {
            foreach (var animal in WorkCage.AnimalsInCage)
            {
                animal.MakingSound += Work;
            }
        }

        private void Work()
        {
            WorkCage.AddFood(new Food(WorkCage.AnimalsInCage[0].FoodType));
        }
    }
}

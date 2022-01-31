using System;

namespace Zoo_Taron
{
    class Worker
    {
        public Cage WorkCage { get; set; }
        public Worker(Cage c)
        {
            WorkCage = c;
            WorkCage.HasWorker = true;
            WorkCage.AnimalAddedinCage+=SubscribeToAnimalsInCage;
        }

        private void SubscribeToAnimalsInCage()
        {
            WorkCage.AnimalsInCage[^1].MakingSound += Work;
        }

        private void Work()
        {
            WorkCage.AddFood(new Food(WorkCage.AnimalsInCage[0].FoodType));            
        }
    }
}

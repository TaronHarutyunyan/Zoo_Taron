using System;
using System.Collections.Generic;

namespace Zoo_Taron
{
    class Program
    {
        public static List<Cage> Cages = new();
        public static List<Animal> Animals = new();
        public static List<Worker> Workers = new();
        static void Main()
        {
            while (true)
            {
                try
                {
                    Start();
                }
                catch (Exception e)
                {
                    Log log = Log.GetInstance();
                    log.Write(e.Message + "/" + e.StackTrace);
                }

            }
        }
        static void Start()
        {
            Console.Clear();
            Console.WriteLine("__________MAIN MENU__________");
            Console.WriteLine("1) Create Cage");
            Console.WriteLine("2) Create Animal");
            Console.WriteLine("3) Create Worker");
            Console.WriteLine("4) Place Animal In Cage");
            Console.WriteLine("5) Show Zoo Info");
            Console.WriteLine("6) Exit");            
            switch (NumberInput(1,6))
            {
                case 1:
                    CreateCage();
                    break;
                case 2:
                    CreateAnimal();
                    break;
                case 3:
                    CreateWorker();
                    break;
                case 4:
                    PlaceAnimalInCage();
                    break;
                case 5:
                    ShowZooInfo();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void ShowZooInfo()
        {
            Console.Clear();
            Console.WriteLine("_____________ZOO___________");
            for (int i = 0; i < Cages.Count; i++)
            {
                Console.WriteLine(Cages[i] + " Has Worker - " + Cages[i].HasWorker);                
                for (int j = 0; j < Cages[i].AnimalsInCage.Count; j++)
                {
                    Console.WriteLine(Cages[i].AnimalsInCage[j]);
                }
            }
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadLine();
            Log.GetInstance().Write("Info Was Shown In Console");
        }

        private static void PlaceAnimalInCage()
        {
            Console.Clear();
            Console.WriteLine("SELECT ANIMAL");
            int l = 1;
            foreach (var item in Animals)
            {
                Console.WriteLine(l + " " +item);
                l++;
            }
            Animal lAnimal = Animals[NumberInput(l, Animals.Count)-1];
            l = 1;
            Console.WriteLine("SELECT CAGE");
            foreach (var item in Cages)
            {
                Console.WriteLine(l + " " + item);
                l++;
            }
            Cage lCage = Cages[NumberInput(l, Cages.Count) - 1];
            lAnimal.SetInCage(lCage);
            Log log  = Log.GetInstance();
            log.Write("Animal Set In Cage");
        }

        private static void CreateWorker()
        {
            Console.Clear();
            Console.WriteLine("__________CREATE WORKER_________");
            Workers.Add(new Worker(SelectCageWithNoWorker()));
            Log.GetInstance().Write("Worker Created");
        }

        private static void CreateAnimal()
        {
            Console.Clear();
            Console.WriteLine("__________CREATE ANIMAL__________");
            Console.WriteLine("Enter Type");
            Console.WriteLine("1) Amphibian");
            Console.WriteLine("2) Aquatic");
            Console.WriteLine("3) Flying");
            Console.WriteLine("4) Terrestrial");
            int lTypeNumber = NumberInput(1,4);
            Console.WriteLine("Enter Name (Example - Dog)");
            string lName = Console.ReadLine();
            Console.WriteLine("Select Gender");
            Console.WriteLine("1) Male");
            Console.WriteLine("2) Female");
            Gender lGender = (Gender)NumberInput(1, 2);
            Console.WriteLine("Select Food Type");
            Console.WriteLine("1) Meat");
            Console.WriteLine("2) Grass");
            FoodType lFoodType = (FoodType)NumberInput(1, 2);
            switch (lTypeNumber)
            {
                case 1:
                    Animals.Add(new AmphibianAnimal(lName, lGender, lFoodType));
                    break;
                case 2:
                    Animals.Add(new AquaticAnimal(lName, lGender, lFoodType));
                    break;
                case 3:
                    Animals.Add(new FlyingAnimal(lName, lGender, lFoodType));
                    break;
                case 4:
                    Animals.Add(new TerrestrialAnimal(lName, lGender, lFoodType));
                    break;
            }
            Log.GetInstance().Write("Animal Created And Added To List");
        }
        

        private static int NumberInput(int minNumber, int maxNumber)
        {
            if (!int.TryParse(Console.ReadLine(), out int lInput)) throw new Exception("Input Cant Convert To Int");
            if(lInput < minNumber || lInput > maxNumber) throw new Exception("Invalid Input Number");
            return lInput;
        }
        private static void CreateCage()
        {
            Console.Clear();
            Console.WriteLine("__________CREATE CAGE_________");
            Console.WriteLine("Select Cage Type");
            Console.WriteLine("Cage For 1) Amphibian");
            Console.WriteLine("         2) Aquatic");
            Console.WriteLine("         3) Flying");
            Console.WriteLine("         4) Terrestrial   Animal");
            Cages.Add(new Cage((AnimalTypes)NumberInput(1, 4)));
            Log log = Log.GetInstance();
            log.Write($"Cage Created");
        }

        private static Cage SelectCageWithNoWorker()
        {
            Console.WriteLine("SELECT CAGE NUMBER");
            int l = 1;
            int[] larr = new int[Cages.Count+1];
            for (int i = 0; i < Cages.Count; i++)
            {
                if (!Cages[i].HasWorker)
                {
                    Console.WriteLine($"{l} {Cages[i]}");
                    larr[l] = i;
                    l++;
                }
            }
            return Cages[larr[NumberInput(1, l)]];
        }
    }
}

using System;
using System.Collections.Generic;

namespace Zoo_Taron
{
    class Program
    {
        public static List<Cage> Cages = new();
        public static List<Animal> Animals = new();
        static void Main()
        {
            while (true)
            {
                try
                {
                    Start();
                }
                catch (Exception)
                {
                    //
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
            switch (NumberInput(1,3))
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
            //
            
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
        }

        private static void CreateWorker()
        {
            Console.Clear();
            Console.WriteLine("__________CREATE WORKER_________");
            //????Uxxaki Petqa Vor meji metodnery ashxaten
            //mejy metodner kan grancac urish eventin
            //cragrum vochmi tex es workerin es chem dimelu inqy uxxaki stexcvela u ashxatuma;            
            //GC-n jnjelua te che u ete jnjelua miangamic kjnji te inchvor jamanak heto?
            new Worker(SelectCageWithNoWorker());
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
        }
        

        private static int NumberInput(int minNumber, int maxNumber)
        {
            if ((!int.TryParse(Console.ReadLine(), out int lInput)) && (lInput < minNumber && lInput > maxNumber)) throw new Exception();
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
                    //Console.WriteLine($"Animals Count - {Cages[i].AnimalsInCage.Count}");
                    larr[l] = i;
                    l++;
                }
            }
            return Cages[larr[NumberInput(1, l)]];
        }
    }
}

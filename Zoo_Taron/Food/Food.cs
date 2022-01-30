
namespace Zoo_Taron
{
    class Food
    {
        public FoodType Foodtype { get; set; }
        public int Calories { get; private set; }
        public Food(FoodType f)
        {
            if (f == FoodType.Meat) Calories = 2000;
            else if(f==FoodType.Grass) Calories = 1000;
        }
        
    }
}

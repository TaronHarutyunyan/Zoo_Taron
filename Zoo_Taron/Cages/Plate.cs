using System.Collections.Generic;

namespace Zoo_Taron
{
    class Plate
    {
        public List<Food> Foods { get; set; }
        public bool IsEmpty()
        {
            return (Foods.Count > 0);
        }
        public bool IsFull()
        {
            return (Foods.Count == 5);
        }
    }
}

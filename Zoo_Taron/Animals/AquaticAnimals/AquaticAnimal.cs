using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Taron
{
    class AquaticAnimal : Animal, ISwimable
    {
        public AquaticAnimal(string name,Gender gender,FoodType ftype) : base(name, gender, ftype)
        {
            
        }
        public void Swim()
        {
            throw new NotImplementedException();
        }
    }
}

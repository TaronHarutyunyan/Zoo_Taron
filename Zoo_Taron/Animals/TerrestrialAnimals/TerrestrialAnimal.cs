using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Taron
{
    class TerrestrialAnimal : Animal,IWalkable
    {
        public TerrestrialAnimal(string name, Gender gender, FoodType ftype) : base(name, gender, ftype)
        {

        }

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
}

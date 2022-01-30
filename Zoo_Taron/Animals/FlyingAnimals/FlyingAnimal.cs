using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Taron
{
    class FlyingAnimal:Animal,IFlyable
    {
        public FlyingAnimal(string name, Gender gender, FoodType ftype) : base(name, gender, ftype)
        {

        }

        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
}

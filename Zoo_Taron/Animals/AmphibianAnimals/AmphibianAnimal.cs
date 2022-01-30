namespace Zoo_Taron
{
    class AmphibianAnimal : Animal, IWalkable, ISwimable
    {
        public AmphibianAnimal(string name,Gender gender,FoodType ftype) : base(name, gender, ftype)
        {

        }
        public void Swim()
        {
            throw new System.NotImplementedException();
        }

        public void Walk()
        {
            throw new System.NotImplementedException();
        }
    }
}

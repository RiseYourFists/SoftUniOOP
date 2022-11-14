namespace Animals
{
    using System;

    public class Animal
    {
        public string Name { get; set; }

        public string FavoriteFood { get; set; }

        public Animal(string name, string favoriteFood)
        {
            Name = name;
            FavoriteFood= favoriteFood;
        }

        public virtual string ExplainSelf()
            => $"I am {Name} and my fovourite food is {FavoriteFood}";
        
    }
}
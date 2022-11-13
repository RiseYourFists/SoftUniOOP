using BorderControl.Contracts;
using System;

namespace BorderControl
{
    public class Citizen : IIdentifiable, IBirthable, IBuyable
    {
        public Citizen(string name, string age, string id, DateTime birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Id { get; set; }

        public DateTime BirthDate { get; set; }

        public int FoodSupply { get; set; }

        public void BuyFood()
        {
            FoodSupply += 10;
        }

        public string GetYear()
            => $"{BirthDate.Day:d2}/{BirthDate.Month:d2}/{BirthDate.Year}";
    }
}

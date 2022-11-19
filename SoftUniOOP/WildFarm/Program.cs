using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            var farmList = new List<Animal>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var animalInfo = input.Split();
                var type = animalInfo[0];
                var name = animalInfo[1];
                var weight = double.Parse(animalInfo[2]);

                Animal animal = GetAnimalType(animalInfo, type, name, weight);
                farmList.Add(animal);

                var foodAtributes = Console.ReadLine().Split();
                var foodName = foodAtributes[0];
                var amount = int.Parse(foodAtributes[1]);

                Food food = GetFoodType(foodName, amount);
                Console.WriteLine(animal.MakeSound());
                FeedAnimal(food, animal);
            }

            farmList.ForEach(x => Console.WriteLine(x));
        }

        public static Food GetFoodType(string foodName, int amount)
        {
            Food food;
            switch (foodName)
            {
                case "Vegetable":
                    food = new Vegetable(amount);
                    break;
                case "Fruit":
                    food = new Fruit(amount);
                    break;
                case "Meat":
                    food = new Meat(amount);
                    break;
                default:
                    food = new Seeds(amount);
                    break;
            }

            return food;
        }

        public static Animal GetAnimalType(string[] animalInfo, string type, string name, double weight)
        {
            Animal animal;
            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, weight, animalInfo[3], animalInfo[4]);
                    break;
                case "Tiger":
                    animal = new Tiger(name, weight, animalInfo[3], animalInfo[4]);
                    break;
                case "Dog":
                    animal = new Dog(name, weight, animalInfo[3]);
                    break;
                case "Mouse":
                    animal = new Mouse(name, weight, animalInfo[3]);
                    break;
                case "Owl":
                    animal = new Owl(name, weight, double.Parse(animalInfo[3]));
                    break;
                default:
                    animal = new Hen(name, weight, double.Parse(animalInfo[3]));
                    break;

            }

            return animal;
        }

        public static void FeedAnimal(Food food, Animal animal)
        {
            void DoesNotLike() => Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
            var foodType = food.GetType().Name;
            
            switch (animal.GetType().Name)
            {
                case "Cat":
                    // veggies & meat
                    if (foodType != "Vegetable" && foodType != "Meat")
                    {
                        DoesNotLike();
                        return;
                    }
                    break;

                case "Dog":
                case "Tiger":
                case "Owl":
                    //meat
                    if (foodType != "Meat")
                    {
                        DoesNotLike();
                        return;
                    }
                    break;
                case "Mouse":
                    //veggies & fruits
                    if (foodType != "Vegetable" && foodType != "Fruit")
                    {
                        DoesNotLike();
                        return;
                    }
                    break;
                case "Hen":
                    //everything
                    break;
            }

            animal.Feed(food);
        }
    }
}

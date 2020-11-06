using System;
using System.Collections.Generic;
using WildFarm.Models;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalInfo = string.Empty;
            int index = 0;

            while ((animalInfo = Console.ReadLine()) != "End")
            {   
                string[] info = animalInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
  
                    Animal animal = null;
                    //Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";
                    //Birds - "{Type} {Name} {Weight} {WingSize}";
                    //Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}";

                    string animalType = info[0];
                    string animalName = info[1];
                    double weight = double.Parse(info[2]);  

                    if (animalType == "Cat" || animalType == "Tiger")
                    {
                        string livingRegion = info[3];
                        string breed = info[4];

                        if (animalType == "Cat")
                        {
                            animal = new Cat(animalName, weight, livingRegion, breed);
                        }

                        else
                        {
                            animal = new Tiger(animalName, weight, livingRegion, breed);
                        }
                    }

                    else if (animalType == "Owl" || animalType == "Hen")
                    {
                        double wingSize = double.Parse(info[3]);

                        if (animalType == "Owl")
                        {
                            animal = new Owl(animalName, weight, wingSize);
                        }

                        else
                        {
                            animal = new Hen(animalName, weight, wingSize);
                        }
                    }

                    else if (animalType == "Mouse" || animalType == "Dog")
                    {
                        string livingRegion = info[3];

                        if (animalType == "Mouse")
                        {
                            animal = new Mouse(animalName, weight, livingRegion);
                        }
                        else
                        {
                            animal = new Dog(animalName, weight, livingRegion);
                        }
                    }

                    animals.Add(animal);

                Console.WriteLine(animal.ProduceSound());

                string[] foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                Food food = null;

                if (foodType == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }

                else if (foodType == "Fruit")
                {
                    food = new Fruit(quantity);
                }

                else if (foodType == "Meat")
                {
                    food = new Meat(quantity);
                }

                else if (foodType == "Seeds")
                {
                    food = new Seeds(quantity);
                }

                Type animalT = animal.GetType();

                if (animalT.Name == "Hen")
                {
                    animal.Weight += 0.35 * quantity;
                    animal.FoodEaten += quantity;
                }

                else if (animalT.Name == "Mouse")
                {
                    if (foodType == "Fruit" || foodType == "Vegetable")
                    {
                        animal.Weight += 0.10 * quantity;
                        animal.FoodEaten += quantity;
                    }

                    else
                    {
                        Console.WriteLine($"{animalT.Name} does not eat {foodType}!");
                    }
                }

                else if (animalT.Name == "Cat")
                {
                    if (foodType == "Meat" || foodType == "Vegetable")
                    {
                        animal.Weight += 0.30 * quantity;
                        animal.FoodEaten += quantity;
                    }

                    else
                    {
                        Console.WriteLine($"{animalT.Name} does not eat {foodType}!");
                    }
                }

                else if (animalT.Name == "Tiger" || animalT.Name == "Dog" || animalT.Name == "Owl")
                {
                    if (foodType == "Meat")
                    {
                        if (animalT.Name == "Tiger")
                        {
                            animal.Weight += 1.00 * quantity;
                        }

                        else if (animalT.Name == "Dog")
                        {
                            animal.Weight += 0.40 * quantity;
                        }

                        else if (animalT.Name == "Owl")
                        {
                            animal.Weight += 0.25 * quantity;
                        }

                        animal.FoodEaten += quantity;
                    }

                    else
                    {
                        Console.WriteLine($"{animalT.Name} does not eat {foodType}!");
                    }
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}

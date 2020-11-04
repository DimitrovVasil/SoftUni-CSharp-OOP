using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (animalType != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split();
                //Tom 12 Male

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                try
                {
                    Animal animal = new Animal(name, age, gender);

                    if (animalType == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }

                    else if (animalType == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }

                    else if (animalType == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }

                    else if (animalType == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }

                    else if (animalType == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }

                    animals.Add(animal);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                animalType = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal.ToString());
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}

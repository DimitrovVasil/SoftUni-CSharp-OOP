
using FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<IBuyer> creatures = new HashSet<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string inputCreature = Console.ReadLine();
                string[] creatureInfo = inputCreature.Split();

                string name = creatureInfo[0];
                int age = int.Parse(creatureInfo[1]);

                if (creatureInfo.Length == 4)
                {              
                    string id = creatureInfo[2];
                    string birthdate = creatureInfo[3];

                    IBuyer creature = new Citizen(name, age, id, birthdate);
                    creatures.Add(creature);
                }

                else if (creatureInfo.Length == 3)
                {
                    string group = creatureInfo[2];
                    IBuyer creature = new Rebel(name, age, group);
                    creatures.Add(creature);
                }
            }

            string input = Console.ReadLine();

            int foodSum = 0;

            while (input != "End")
            {
                IBuyer targetCitizen = creatures.FirstOrDefault(c => c.Name == input);

                if (targetCitizen != null)
                {
                    foodSum += targetCitizen.BuyFood();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(foodSum);

        }
    }
}

using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<ICreature> creatures = new List<ICreature>();

            string input = Console.ReadLine();

            while (input != "End")
            {    
                string[] creatureInfo = input.Split();

                string name = creatureInfo[0];

                if (creatureInfo.Length == 3)
                {
                    int age = int.Parse(creatureInfo[1]);
                    string id = (creatureInfo[2]);

                    ICreature creature = new Citizen(name, age, id);
                    creatures.Add(creature);
                }

                else if (creatureInfo.Length == 2)
                {
                    string id = (creatureInfo[1]);

                    ICreature creature = new Robot(name, id);
                    creatures.Add(creature);
                }

                input = Console.ReadLine();
            }

            string numToCheck = Console.ReadLine();

            var detained = new List<ICreature>();

            detained = creatures.Where(c => c.Id.EndsWith(numToCheck)).ToList();

            foreach (var creature in detained)
            {
                Console.WriteLine(creature.Id);
            }


        }
    }
}

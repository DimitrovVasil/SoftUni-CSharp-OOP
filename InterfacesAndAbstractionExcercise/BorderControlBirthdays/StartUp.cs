
using BorderControlBirthdays.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControlBirthdays
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBirthdayable> creatures = new List<IBirthdayable>();

            string input = Console.ReadLine();

            while (input != "End")
            {    
                string[] creatureInfo = input.Split();

                string name = creatureInfo[1];
                
                if (creatureInfo[0] == "Citizen")
                {
                    int age = int.Parse(creatureInfo[2]);
                    string id = creatureInfo[3];
                    string birthdate = creatureInfo[4];

                    IBirthdayable creature = new Citizen(name, age, id, birthdate);
                    creatures.Add(creature);
                }

                else if (creatureInfo[0] == "Pet")
                {
                    string birthdate = creatureInfo[2];
                    IBirthdayable creature = new Pet(name, birthdate);
                    creatures.Add(creature);
                }

                input = Console.ReadLine();
            }

            string yearToCheck = Console.ReadLine();

            var birthdays = new List<IBirthdayable>();

            birthdays = creatures.Where(c => c.Birthday.EndsWith(yearToCheck)).ToList();

            foreach (var creature in birthdays)
            {
                Console.WriteLine(creature.Birthday);
            }
        }
    }
}

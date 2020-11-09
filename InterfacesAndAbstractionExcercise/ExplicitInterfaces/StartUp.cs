using ExplicitInterfaces.Interfaces;
using ExplicitInterfaces.Models;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] personInfo = input.Split();

                string name = personInfo[0];
                string country = personInfo[1];
                int age = int.Parse(personInfo[2]);

                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}

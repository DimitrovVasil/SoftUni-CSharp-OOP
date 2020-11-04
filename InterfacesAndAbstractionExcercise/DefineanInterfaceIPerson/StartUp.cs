using PersonInfo;
using System;

namespace PersonInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();

            Citizen citizen = new Citizen(name, age, id, birthdate);

            Console.WriteLine(citizen.Id);
            Console.WriteLine(citizen.Birthdate);
        }
    }
}

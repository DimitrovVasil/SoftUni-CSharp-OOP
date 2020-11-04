using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int horsePower = int.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());

            Motorcycle motorcycle = new Motorcycle(horsePower, fuel);

            Console.WriteLine(motorcycle.Fuel);
            Console.WriteLine(motorcycle.HorsePower);
        }
    } 
}

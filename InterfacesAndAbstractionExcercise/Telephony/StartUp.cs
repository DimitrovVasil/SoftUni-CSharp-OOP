using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(numbers[i]));
                }

                else if (numbers[i].Length == 10)
                {
                    Console.WriteLine(smartphone.Call(numbers[i]));
                }  
            }

            for (int i = 0; i < urls.Length; i++)
            {
                Console.WriteLine(smartphone.Browse(urls[i]));
            }
        }
    }
}

using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();

            double fuelQuantity = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);

            Car car = new Car(fuelQuantity, fuelConsumption);

            string[] truckInfo = Console.ReadLine().Split();

            double fuelQuantityTruck = double.Parse(truckInfo[1]);
            double fuelConsumptionTruck = double.Parse(truckInfo[2]);

            Truck truck = new Truck(fuelQuantityTruck, fuelConsumptionTruck);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string cmd = input[0];
                string vehicle = input[1];

                if (cmd == "Drive")
                {
                    double distance = double.Parse(input[2]);

                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }

                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }

                else if (cmd == "Refuel")
                {
                    double liters = double.Parse(input[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(liters);
                    }

                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}

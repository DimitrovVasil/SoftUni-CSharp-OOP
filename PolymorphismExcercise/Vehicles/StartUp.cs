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
            double tankCapacityCar = double.Parse(carInfo[3]);

            Car car = new Car(fuelQuantity, fuelConsumption, tankCapacityCar);

            string[] truckInfo = Console.ReadLine().Split();

            double fuelQuantityTruck = double.Parse(truckInfo[1]);
            double fuelConsumptionTruck = double.Parse(truckInfo[2]);
            double tankCapacityTruck = double.Parse(truckInfo[3]);

            Truck truck = new Truck(fuelQuantityTruck, fuelConsumptionTruck, tankCapacityTruck);

            string[] busInfo = Console.ReadLine().Split();

            double fuelQuantityBus = double.Parse(busInfo[1]);
            double fuelConsumptionBus = double.Parse(busInfo[2]);
            double tankCapacityBus = double.Parse(busInfo[3]);

            Bus bus = new Bus(fuelQuantityBus, fuelConsumptionBus, tankCapacityBus);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string cmd = input[0];
                string vehicle = input[1];

                try
                {
                    if (cmd == "Drive" || cmd == "DriveEmpty")
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

                        else if (vehicle == "Bus")
                        {
                            if (cmd == "DriveEmpty")
                            {
                                bus.IsConditionerOn = false;
                            }

                            else 
                            {
                                bus.IsConditionerOn = true;
                            }

                            Console.WriteLine(bus.Drive(distance));
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

                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(liters);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

               
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}

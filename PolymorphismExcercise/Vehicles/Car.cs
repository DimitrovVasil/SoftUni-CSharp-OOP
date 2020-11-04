using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Car : Vehicle
    {
        public Car(decimal fuelQuantity, decimal fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += FuelConsumption * 0.9m;
        }

        
    }
}

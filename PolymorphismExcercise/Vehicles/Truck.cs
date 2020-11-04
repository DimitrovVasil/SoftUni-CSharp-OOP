using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {

        public Truck(decimal fuelQuantity, decimal fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += FuelConsumption * 1.6m;
        }

        public override void Refuel(decimal amount)
        {
            amount = 0.95m * amount;
            FuelQuantity += amount;
        }
    }
}

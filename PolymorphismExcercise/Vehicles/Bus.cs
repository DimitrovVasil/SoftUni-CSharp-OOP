using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public bool IsConditionerOn { get; set; }

        public override string Drive(double distance)
        {
            if (IsConditionerOn)
            {
                FuelConsumption += 1.4;
            }

            return base.Drive(distance);
        }

    }
}

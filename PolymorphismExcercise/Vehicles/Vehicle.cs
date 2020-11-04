using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle
    {
        private decimal fuelQuantity;
        private decimal fuelConsumption;
        

        protected Vehicle(decimal fuelQuantity, decimal fuelConsumption)
        {
           FuelQuantity = fuelQuantity;
           FuelConsumption = fuelConsumption;
        }

        public decimal FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public decimal FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public string Drive(decimal distance)
        {
            if (FuelConsumption * distance <= FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption * distance);
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(decimal amount)
        {
            FuelQuantity += amount;
        }
    }
}

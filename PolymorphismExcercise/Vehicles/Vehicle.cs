using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
           FuelQuantity = fuelQuantity;
           FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public string Drive(double distance)
        {
            if (FuelConsumption * distance <= FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption * distance);
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double amount)
        {
            FuelQuantity += amount;
        }
    }
}

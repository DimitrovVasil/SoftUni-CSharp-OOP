using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Vehicles
{
    public class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
           
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }

                else
                {
                    fuelQuantity = value;
                }
                
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double TankCapacity { get;  }

        public virtual string Drive(double distance)
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
            if (TankCapacity - FuelQuantity < amount)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this is Truck)
            {
                amount = amount * 0.95;
            }

            FuelQuantity += amount;
        }
    }
}

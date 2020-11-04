using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            FuelConsumption = DefaultFuelConsumption;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption { get; set; }
        public virtual double DefaultFuelConsumption
        {
            get 
            { 
                return 1.25; 
            } 
            set
            {
                DefaultFuelConsumption = 1.25; 
            } 
        }

        public virtual void Drive(double kilometers)
        {
            double fuelLeft = Fuel - (kilometers * FuelConsumption);

            if (fuelLeft >= 0)
            {
                Fuel -= (kilometers * FuelConsumption);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using EasterRaces.Models.Cars.Contracts;


namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            MinHorsePower = minHorsePower;
            MaxHorsePower = maxHorsePower;
        }

        public int MinHorsePower { get; set; }
        public int MaxHorsePower { get; set; }
        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                if (value == null || value == "" || value == " " || value == "  " || value == "   "|| value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                model = value;
            }
        }

        public virtual int HorsePower { get; set; }

        public double CubicCentimeters { get; set; }

        public double CalculateRacePoints(int laps)
        {
            double result = CubicCentimeters / HorsePower * laps;
            return result;
        }
    }

}
